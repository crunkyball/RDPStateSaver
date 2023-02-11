namespace RDPStateSaver
{
    partial class RDPStateSaver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysTrayMenu_AutoManageState = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_AutoSaveInterval = new System.Windows.Forms.ToolStripTextBox();
            this.sysTrayMenu_SystemEventRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_SystemEventSession = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_RestoreDisconnectState = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_ManualSaveState = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_ManualRestoreState = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysTrayIcon
            // 
            this.sysTrayIcon.ContextMenuStrip = this.sysTrayMenu;
            this.sysTrayIcon.Text = "notifyIcon1";
            this.sysTrayIcon.Visible = true;
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayMenu_AutoManageState,
            this.sysTrayMenu_ManualSaveState,
            this.sysTrayMenu_ManualRestoreState,
            this.sysTrayMenu_Exit});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(186, 114);
            this.sysTrayMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.sysTrayMenu_Closed);
            // 
            // sysTrayMenu_AutoManageState
            // 
            this.sysTrayMenu_AutoManageState.Checked = true;
            this.sysTrayMenu_AutoManageState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sysTrayMenu_AutoManageState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayMenu_AutoSaveInterval,
            this.sysTrayMenu_SystemEventRemote,
            this.sysTrayMenu_SystemEventSession,
            this.sysTrayMenu_RestoreDisconnectState});
            this.sysTrayMenu_AutoManageState.Name = "sysTrayMenu_AutoManageState";
            this.sysTrayMenu_AutoManageState.Size = new System.Drawing.Size(185, 22);
            this.sysTrayMenu_AutoManageState.Text = "Auto Manage State";
            this.sysTrayMenu_AutoManageState.Click += new System.EventHandler(this.sysTrayMenu_AutoManageState_Click);
            // 
            // sysTrayMenu_AutoSaveInterval
            // 
            this.sysTrayMenu_AutoSaveInterval.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sysTrayMenu_AutoSaveInterval.Name = "sysTrayMenu_AutoSaveInterval";
            this.sysTrayMenu_AutoSaveInterval.Size = new System.Drawing.Size(100, 23);
            this.sysTrayMenu_AutoSaveInterval.ToolTipText = "Auto Save Interval";
            // 
            // sysTrayMenu_SystemEventRemote
            // 
            this.sysTrayMenu_SystemEventRemote.Checked = true;
            this.sysTrayMenu_SystemEventRemote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sysTrayMenu_SystemEventRemote.Name = "sysTrayMenu_SystemEventRemote";
            this.sysTrayMenu_SystemEventRemote.Size = new System.Drawing.Size(260, 22);
            this.sysTrayMenu_SystemEventRemote.Text = "On Remote Disconnect/Connect";
            this.sysTrayMenu_SystemEventRemote.Click += new System.EventHandler(this.sysTrayMenu_SystemEventRemote_Click);
            // 
            // sysTrayMenu_SystemEventSession
            // 
            this.sysTrayMenu_SystemEventSession.Name = "sysTrayMenu_SystemEventSession";
            this.sysTrayMenu_SystemEventSession.Size = new System.Drawing.Size(260, 22);
            this.sysTrayMenu_SystemEventSession.Text = "On Session Lock/Unlock";
            this.sysTrayMenu_SystemEventSession.Click += new System.EventHandler(this.sysTrayMenu_SystemEventSession_Click);
            // 
            // sysTrayMenu_RestoreDisconnectState
            // 
            this.sysTrayMenu_RestoreDisconnectState.Enabled = false;
            this.sysTrayMenu_RestoreDisconnectState.Name = "sysTrayMenu_RestoreDisconnectState";
            this.sysTrayMenu_RestoreDisconnectState.Size = new System.Drawing.Size(260, 22);
            this.sysTrayMenu_RestoreDisconnectState.Text = "Force Restore Last Disconnect State";
            this.sysTrayMenu_RestoreDisconnectState.Click += new System.EventHandler(this.sysTrayMenu_RestoreDisconnectState_Click);
            // 
            // sysTrayMenu_ManualSaveState
            // 
            this.sysTrayMenu_ManualSaveState.Name = "sysTrayMenu_ManualSaveState";
            this.sysTrayMenu_ManualSaveState.Size = new System.Drawing.Size(185, 22);
            this.sysTrayMenu_ManualSaveState.Text = "Manual Save State";
            this.sysTrayMenu_ManualSaveState.Click += new System.EventHandler(this.sysTrayMenu_ManualSaveState_Click);
            // 
            // sysTrayMenu_ManualRestoreState
            // 
            this.sysTrayMenu_ManualRestoreState.Enabled = false;
            this.sysTrayMenu_ManualRestoreState.Name = "sysTrayMenu_ManualRestoreState";
            this.sysTrayMenu_ManualRestoreState.Size = new System.Drawing.Size(185, 22);
            this.sysTrayMenu_ManualRestoreState.Text = "Manual Restore State";
            this.sysTrayMenu_ManualRestoreState.Click += new System.EventHandler(this.sysTrayMenu_ManualRestoreState_Click);
            // 
            // sysTrayMenu_Exit
            // 
            this.sysTrayMenu_Exit.Name = "sysTrayMenu_Exit";
            this.sysTrayMenu_Exit.Size = new System.Drawing.Size(185, 22);
            this.sysTrayMenu_Exit.Text = "Exit";
            this.sysTrayMenu_Exit.Click += new System.EventHandler(this.sysTrayMenu_Exit_Click);
            // 
            // RDPStateSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 223);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RDPStateSaver";
            this.Text = "RDP State Saver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RDPStateSaver_FormClosing);
            this.Load += new System.EventHandler(this.RDPStateSaver_Load);
            this.sysTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon sysTrayIcon;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_Exit;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_ManualSaveState;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_ManualRestoreState;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_AutoManageState;
        private System.Windows.Forms.ToolStripTextBox sysTrayMenu_AutoSaveInterval;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_SystemEventRemote;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_SystemEventSession;
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_RestoreDisconnectState;
    }
}

