using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPStateSaver
{
    class WindowSavedState
    {
        private Dictionary<IntPtr, Native.WINDOWPLACEMENT> windows;

        public bool HasState { get { return windows.Count > 0; } }

        public WindowSavedState()
        {
            windows = new Dictionary<IntPtr, Native.WINDOWPLACEMENT>();
        }

        public void Set(WindowSavedState otherState)
        {
            Set(otherState.windows);
        }

        public void Set(Dictionary<IntPtr, Native.WINDOWPLACEMENT> newState)
        {
            lock (windows)
            {
                windows.Clear();

                foreach (KeyValuePair<IntPtr, Native.WINDOWPLACEMENT> window in newState)
                {
                    windows[window.Key] = window.Value;
                }
            }
        }

        public void MinimizeAll()
        {
            lock (windows)
            {
                foreach (KeyValuePair<IntPtr, Native.WINDOWPLACEMENT> window in windows)
                {
                    Native.WINDOWPLACEMENT placement = window.Value;
                    placement.ShowCmd = Native.ShowWindowCommands.Minimize;
                    Native.SetWindowPlacement(window.Key, ref placement);
                }
            }
        }

        public void Restore()
        {
            lock (windows)
            {
                foreach (KeyValuePair<IntPtr, Native.WINDOWPLACEMENT> window in windows)
                {
                    Native.WINDOWPLACEMENT placement = window.Value;
                    Native.ShowWindowCommands windowCmd = placement.ShowCmd;

                    //This is pretty crap but I haven't found a way around it yet. Basically, if
                    //a window is maximised then it ignores the placement, so minimise it first.
                    if (windowCmd == Native.ShowWindowCommands.Maximize)
                    {
                        placement.ShowCmd = Native.ShowWindowCommands.Minimize;
                        Native.SetWindowPlacement(window.Key, ref placement);
                        placement.ShowCmd = windowCmd;
                    }

                    Native.SetWindowPlacement(window.Key, ref placement);
                }
            }
        }

        public void LogState(string text)
        {
            if (text.Length > 0)
            {
                Log.Add(text);
            }

            lock (windows)
            {
                foreach (KeyValuePair<IntPtr, Native.WINDOWPLACEMENT> window in windows)
                {
                    IntPtr hWnd = window.Key;
                    Native.WINDOWPLACEMENT placement = window.Value;

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

                    string posString = string.Format(" ({0},{1},{2},{3})", placement.NormalPosition.Top, placement.NormalPosition.Left, placement.NormalPosition.Bottom, placement.NormalPosition.Right);
                    Log.Add("\t" + windowTitle + posString);
                }
            }
        }
    }
}
