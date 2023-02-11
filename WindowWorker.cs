using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RDPStateSaver
{
    class WindowWorker
    {
        enum State
        {
            STOPPED,
            RUNNING,
            PAUSED,
            STOPPING
        }

        public delegate void AutoStateSavedCallback();

        private State state;

        public WindowSavedState SavedState { get; private set; }

        public WindowWorker()
        {
            state = State.STOPPED;
            SavedState = new WindowSavedState();
        }

        public void Start()
        {
            bool DoStart = state == State.STOPPED;
            
            if (state == State.STOPPED || state == State.STOPPING)
            {
                state = State.RUNNING;
            }

            if (DoStart)
            {
                RunWorker();
            }
        }

        private void RunWorker()
        {
            Task.Run(async delegate
            {
                await Task.Delay(500); //Slight delay before starting.

                while (true)
                {
                    if (state == State.STOPPING)   //Have we stopped the worker?
                        break;

                    if (state == State.RUNNING)
                    {
                        SaveWindowsState(SavedState);
                    }

                    await Task.Delay(Properties.Settings.Default.AutoSaveInterval);
                }

                state = State.STOPPED;
            });
        }

        private string GetWindowTitle(IntPtr hWnd)
        {
            string windowTitle = string.Empty;

            int windowTextLength = Native.GetWindowTextLength(hWnd);
            if (windowTextLength > 0)
            {
                StringBuilder stringBuilder = new StringBuilder(windowTextLength);
                if (Native.GetWindowText(hWnd, stringBuilder, windowTextLength + 1) != 0)
                {
                    windowTitle = stringBuilder.ToString();
                }
            }

            return windowTitle;
        }

        public void SaveWindowsState(WindowSavedState windowState)
        {
            Dictionary<IntPtr, Native.WINDOWPLACEMENT> windows = new Dictionary<IntPtr, Native.WINDOWPLACEMENT>();

            Native.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (hWnd == Native.GetShellWindow())
                    return true;

                if (!Native.IsWindowVisible(hWnd))
                    return true;

                //This part obtained from https://devblogs.microsoft.com/oldnewthing/20071008-00/?p=24863
                IntPtr hWndWalk = Native.GetAncestor(hWnd, Native.GetAncestorFlags.GetRootOwner);
                IntPtr hWndTry = IntPtr.Zero;
                while ((hWndTry = Native.GetLastActivePopup(hWndWalk)) != hWndTry)
                {
                    if (Native.IsWindowVisible(hWndTry))
                        break;

                    hWndWalk = hWndTry;
                }

                if (hWndWalk != hWnd)
                    return true;

                uint flags = Native.GetWindowLong(hWnd, (int)Native.WindowLongFlags.GWL_EXSTYLE);
                if ((flags & (uint)Native.WindowStyles.WS_EX_TOOLWINDOW) != 0)
                    return true;

                Native.DwmGetWindowAttribute(hWnd, Native.DWMWINDOWATTRIBUTE.Cloaked, out bool isCloaked, Marshal.SizeOf(typeof(bool)));

                if (isCloaked)
                    return true;

                Native.WINDOWPLACEMENT placement = default(Native.WINDOWPLACEMENT);
                placement.Length = Marshal.SizeOf(placement);
                Native.GetWindowPlacement(hWnd, ref placement);

                windows[hWnd] = placement;

                return true;

            }, IntPtr.Zero);

            windowState.Set(windows);
        }

        public void Pause()
        {
            if (state == State.RUNNING)
            {
                state = State.PAUSED;
            }
        }

        public void Unpause()
        {
            if (state == State.PAUSED)
            {
                state = State.RUNNING;
            }
        }

        public void Stop()
        {
            if (state != State.STOPPED)
            {
                state = State.STOPPING;
            }
        }
    }
}
