using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RDPStateSaver
{
    [Serializable]
    public enum SaveSystemEvent
    {
        RemoteDisconnect,
        SessionLock
    }

    public partial class RDPStateSaver : Form
    {
        private WindowWorker worker;
        private WindowSavedState disconnectState;
        private WindowSavedState manualSavedState;

        public RDPStateSaver()
        {
            InitializeComponent();

            sysTrayIcon.Text = Application.ProductName;
            sysTrayIcon.Icon = Properties.Resources.Icon;

            sysTrayMenu_AutoManageState.Checked = Properties.Settings.Default.AutoManageState;
            sysTrayMenu_AutoSaveInterval.Enabled = Properties.Settings.Default.AutoManageState;
            sysTrayMenu_AutoSaveInterval.Text = Properties.Settings.Default.AutoSaveInterval.ToString();

            sysTrayMenu_SystemEventRemote.Checked = Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.RemoteDisconnect;
            sysTrayMenu_SystemEventSession.Checked = Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.SessionLock;
            
            worker = new WindowWorker();
            disconnectState = new WindowSavedState();
            manualSavedState = new WindowSavedState();

            Log.Clear();
        }

        private void RDPStateSaver_Load(object sender, EventArgs e)
        {
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            if (Properties.Settings.Default.AutoManageState)
            {
                //It's not ideal running this constantly but I can't find any event that occurs on RDP 
                //disconnect that doesn't fire until after the number of monitors has changed (and thereby 
                //stores incorrect positions). I went through every event covered by SystemEvents but they 
                //are all too late (even DisplaySettingsChanging). So until I have time to look for a 
                //better solution, just store off the positions periodically.
                worker.Start();
            }
        }

        private void RDPStateSaver_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HandleDisconnect()
        {
            if (Properties.Settings.Default.AutoManageState)
            {
                worker.Pause();

                disconnectState.Set(worker.SavedState);
                LogState("State on disconnect", disconnectState);

                sysTrayMenu_RestoreDisconnectState.Enabled = disconnectState.HasState;
            }
        }

        private void HandleConnect()
        {
            if (Properties.Settings.Default.AutoManageState)
            {
                Task.Run(async delegate
                {
                    await Task.Delay(500);
                    disconnectState.Restore();
                    LogState("State after (re)connect restore:");

                    worker.Unpause();
                });
            }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            Log.Add("Session Switch Event: " + e.Reason.ToString());

            if ((e.Reason == SessionSwitchReason.RemoteDisconnect && Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.RemoteDisconnect) ||
                (e.Reason == SessionSwitchReason.SessionLock && Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.SessionLock))
            {
                HandleDisconnect();
            }
            else if ((e.Reason == SessionSwitchReason.RemoteConnect && Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.RemoteDisconnect) ||
                (e.Reason == SessionSwitchReason.SessionUnlock && Properties.Settings.Default.SaveSystemEvent == SaveSystemEvent.SessionLock))
            {
                HandleConnect();
            }
        }

        private void sysTrayMenu_AutoManageState_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoManageState = !Properties.Settings.Default.AutoManageState;
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.AutoManageState)
            {
                sysTrayMenu_AutoManageState.Checked = true;
                worker.Start();
            }
            else
            {
                sysTrayMenu_AutoManageState.Checked = false;
                worker.Stop();
            }
        }

        private void sysTrayMenu_ManualSaveState_Click(object sender, EventArgs e)
        {
            worker.SaveWindowsState(manualSavedState);
            sysTrayMenu_ManualRestoreState.Enabled = manualSavedState.HasState;
            LogState("State on manual save:", manualSavedState);
        }

        private void sysTrayMenu_ManualRestoreState_Click(object sender, EventArgs e)
        {
            manualSavedState.Restore();
            LogState("State after manual restore:");
        }

        private void sysTrayMenu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sysTrayMenu_SystemEventRemote_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveSystemEvent = SaveSystemEvent.RemoteDisconnect;
            Properties.Settings.Default.Save();

            sysTrayMenu_SystemEventRemote.Checked = true;
            sysTrayMenu_SystemEventSession.Checked = false;
        }

        private void sysTrayMenu_SystemEventSession_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveSystemEvent = SaveSystemEvent.SessionLock;
            Properties.Settings.Default.Save();

            sysTrayMenu_SystemEventRemote.Checked = false;
            sysTrayMenu_SystemEventSession.Checked = true;
        }

        private void sysTrayMenu_RestoreDisconnectState_Click(object sender, EventArgs e)
        {
            if (disconnectState.HasState)
            {
                disconnectState.Restore();
                LogState("State after restore state on disconnect:");
            }
        }

        private void LogState(string text, WindowSavedState state = null)
        {
            //If we have a specific state in mind then log that.
            //Otherwise grab the current state and log it.
            if (state == null)
            {
                state = new WindowSavedState();
                worker.SaveWindowsState(state);
            }
            
            state.LogState(text);
        }

        private void sysTrayMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (Int32.TryParse(sysTrayMenu_AutoSaveInterval.Text, out int newValue))
            {
                Properties.Settings.Default.AutoSaveInterval = Math.Max(1000, newValue);
                Properties.Settings.Default.Save();
            }
            else
            {
                sysTrayMenu_AutoSaveInterval.Text = Properties.Settings.Default.AutoSaveInterval.ToString();
            }
        }
    }
}
