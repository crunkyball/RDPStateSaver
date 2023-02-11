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
            this.sysTrayMenu_RestoreStateOnDisconnect = new System.Windows.Forms.ToolStripMenuItem();
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
            this.sysTrayMenu_RestoreStateOnDisconnect,
            this.sysTrayMenu_ManualSaveState,
            this.sysTrayMenu_ManualRestoreState,
            this.sysTrayMenu_Exit});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(224, 136);
            this.sysTrayMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.sysTrayMenu_Closed);
            // 
            // sysTrayMenu_AutoManageState
            // 
            this.sysTrayMenu_AutoManageState.Checked = true;
            this.sysTrayMenu_AutoManageState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sysTrayMenu_AutoManageState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayMenu_AutoSaveInterval});
            this.sysTrayMenu_AutoManageState.Name = "sysTrayMenu_AutoManageState";
            this.sysTrayMenu_AutoManageState.Size = new System.Drawing.Size(223, 22);
            this.sysTrayMenu_AutoManageState.Text = "Auto Manage State";
            this.sysTrayMenu_AutoManageState.Click += new System.EventHandler(this.sysTrayMenu_AutoManageState_Click);
            // 
            // sysTrayMenu_AutoSaveInterval
            // 
            this.sysTrayMenu_AutoSaveInterval.Name = "sysTrayMenu_AutoSaveInterval";
            this.sysTrayMenu_AutoSaveInterval.Size = new System.Drawing.Size(100, 23);
            this.sysTrayMenu_AutoSaveInterval.ToolTipText = "Auto Save Interval";
            // 
            // sysTrayMenu_RestoreStateOnDisconnect
            // 
            this.sysTrayMenu_RestoreStateOnDisconnect.Enabled = false;
            this.sysTrayMenu_RestoreStateOnDisconnect.Name = "sysTrayMenu_RestoreStateOnDisconnect";
            this.sysTrayMenu_RestoreStateOnDisconnect.Size = new System.Drawing.Size(223, 22);
            this.sysTrayMenu_RestoreStateOnDisconnect.Text = "Restore State On Disconnect";
            this.sysTrayMenu_RestoreStateOnDisconnect.Click += new System.EventHandler(this.sysTrayMenu_RestoreStateOnDisconnect_Click);
            // 
            // sysTrayMenu_ManualSaveState
            // 
            this.sysTrayMenu_ManualSaveState.Name = "sysTrayMenu_ManualSaveState";
            this.sysTrayMenu_ManualSaveState.Size = new System.Drawing.Size(223, 22);
            this.sysTrayMenu_ManualSaveState.Text = "Manual Save State";
            this.sysTrayMenu_ManualSaveState.Click += new System.EventHandler(this.sysTrayMenu_ManualSaveState_Click);
            // 
            // sysTrayMenu_ManualRestoreState
            // 
            this.sysTrayMenu_ManualRestoreState.Enabled = false;
            this.sysTrayMenu_ManualRestoreState.Name = "sysTrayMenu_ManualRestoreState";
            this.sysTrayMenu_ManualRestoreState.Size = new System.Drawing.Size(223, 22);
            this.sysTrayMenu_ManualRestoreState.Text = "Manual Restore State";
            this.sysTrayMenu_ManualRestoreState.Click += new System.EventHandler(this.sysTrayMenu_ManualRestoreState_Click);
            // 
            // sysTrayMenu_Exit
            // 
            this.sysTrayMenu_Exit.Name = "sysTrayMenu_Exit";
            this.sysTrayMenu_Exit.Size = new System.Drawing.Size(223, 22);
            this.sysTrayMenu_Exit.Text = "Exit";
            this.sysTrayMenu_Exit.Click += new System.EventHandler(this.sysTrayMenu_Exit_Click);
            // 
            // RDPStateSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 181);
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
        private System.Windows.Forms.ToolStripMenuItem sysTrayMenu_RestoreStateOnDisconnect;
        private System.Windows.Forms.ToolStripTextBox sysTrayMenu_AutoSaveInterval;
    }
}

