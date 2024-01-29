using System;
using System.Windows.Forms;
namespace Editor
{
    partial class Dialog
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dstBox = new System.Windows.Forms.GroupBox();
            this.dstWorld = new System.Windows.Forms.ComboBox();
            this.dstPlayer = new System.Windows.Forms.ComboBox();
            this.dstPlayerLabel = new System.Windows.Forms.Label();
            this.dstWorldLabel = new System.Windows.Forms.Label();
            this.transferButton = new System.Windows.Forms.Button();
            this.srcBox = new System.Windows.Forms.GroupBox();
            this.srcPlayer = new System.Windows.Forms.ComboBox();
            this.srcPlayerLabel = new System.Windows.Forms.Label();
            this.srcWorld = new System.Windows.Forms.ComboBox();
            this.srcWorldLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.openSavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.dstManualBox = new System.Windows.Forms.GroupBox();
            this.dstOpen = new System.Windows.Forms.Button();
            this.dstInput = new System.Windows.Forms.TextBox();
            this.dstManualLabel = new System.Windows.Forms.Label();
            this.srcManualBox = new System.Windows.Forms.GroupBox();
            this.srcOpen = new System.Windows.Forms.Button();
            this.srcManualLabel = new System.Windows.Forms.Label();
            this.srcInput = new System.Windows.Forms.TextBox();
            this.modeBox = new System.Windows.Forms.GroupBox();
            this.nameMode = new System.Windows.Forms.RadioButton();
            this.manualMode = new System.Windows.Forms.RadioButton();
            this.defaultMode = new System.Windows.Forms.RadioButton();
            this.srcNameBox = new System.Windows.Forms.GroupBox();
            this.srcNamePlayer = new System.Windows.Forms.ComboBox();
            this.nameNewLabel = new System.Windows.Forms.Label();
            this.srcNameInput = new System.Windows.Forms.TextBox();
            this.nameOldLabel = new System.Windows.Forms.Label();
            this.dstNameBox = new System.Windows.Forms.GroupBox();
            this.dstNameWorld = new System.Windows.Forms.ComboBox();
            this.dstNameLabel = new System.Windows.Forms.Label();
            this.dstBox.SuspendLayout();
            this.srcBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.actionBox.SuspendLayout();
            this.dstManualBox.SuspendLayout();
            this.srcManualBox.SuspendLayout();
            this.modeBox.SuspendLayout();
            this.srcNameBox.SuspendLayout();
            this.dstNameBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dstBox
            // 
            this.dstBox.Controls.Add(this.dstWorld);
            this.dstBox.Controls.Add(this.dstPlayer);
            this.dstBox.Controls.Add(this.dstPlayerLabel);
            this.dstBox.Controls.Add(this.dstWorldLabel);
            this.dstBox.Location = new System.Drawing.Point(12, 12);
            this.dstBox.Name = "dstBox";
            this.dstBox.Size = new System.Drawing.Size(477, 55);
            this.dstBox.TabIndex = 0;
            this.dstBox.TabStop = false;
            this.dstBox.Text = "Destination";
            // 
            // dstWorld
            // 
            this.dstWorld.DisplayMember = "None";
            this.dstWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dstWorld.FormattingEnabled = true;
            this.dstWorld.Location = new System.Drawing.Point(49, 20);
            this.dstWorld.Name = "dstWorld";
            this.dstWorld.Size = new System.Drawing.Size(184, 21);
            this.dstWorld.TabIndex = 4;
            this.dstWorld.SelectedIndexChanged += new System.EventHandler(this.dstWorld_SelectedIndexChanged);
            // 
            // dstPlayer
            // 
            this.dstPlayer.DisplayMember = "None";
            this.dstPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dstPlayer.FormattingEnabled = true;
            this.dstPlayer.Location = new System.Drawing.Point(281, 20);
            this.dstPlayer.Name = "dstPlayer";
            this.dstPlayer.Size = new System.Drawing.Size(184, 21);
            this.dstPlayer.TabIndex = 3;
            this.dstPlayer.SelectedIndexChanged += new System.EventHandler(this.dstPlayer_SelectedIndexChanged);
            // 
            // dstPlayerLabel
            // 
            this.dstPlayerLabel.AutoSize = true;
            this.dstPlayerLabel.Location = new System.Drawing.Point(239, 23);
            this.dstPlayerLabel.Name = "dstPlayerLabel";
            this.dstPlayerLabel.Size = new System.Drawing.Size(36, 13);
            this.dstPlayerLabel.TabIndex = 2;
            this.dstPlayerLabel.Text = "Player";
            // 
            // dstWorldLabel
            // 
            this.dstWorldLabel.AutoSize = true;
            this.dstWorldLabel.Location = new System.Drawing.Point(8, 24);
            this.dstWorldLabel.Name = "dstWorldLabel";
            this.dstWorldLabel.Size = new System.Drawing.Size(35, 13);
            this.dstWorldLabel.TabIndex = 0;
            this.dstWorldLabel.Text = "World";
            // 
            // transferButton
            // 
            this.transferButton.Enabled = false;
            this.transferButton.Location = new System.Drawing.Point(11, 19);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(174, 23);
            this.transferButton.TabIndex = 4;
            this.transferButton.Text = "Transfer";
            this.transferButton.UseVisualStyleBackColor = true;
            this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
            // 
            // srcBox
            // 
            this.srcBox.Controls.Add(this.srcPlayer);
            this.srcBox.Controls.Add(this.srcPlayerLabel);
            this.srcBox.Controls.Add(this.srcWorld);
            this.srcBox.Controls.Add(this.srcWorldLabel);
            this.srcBox.Location = new System.Drawing.Point(12, 73);
            this.srcBox.Name = "srcBox";
            this.srcBox.Size = new System.Drawing.Size(477, 55);
            this.srcBox.TabIndex = 5;
            this.srcBox.TabStop = false;
            this.srcBox.Text = "Source";
            // 
            // srcPlayer
            // 
            this.srcPlayer.DisplayMember = "None";
            this.srcPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.srcPlayer.FormattingEnabled = true;
            this.srcPlayer.Location = new System.Drawing.Point(281, 20);
            this.srcPlayer.Name = "srcPlayer";
            this.srcPlayer.Size = new System.Drawing.Size(184, 21);
            this.srcPlayer.TabIndex = 3;
            this.srcPlayer.SelectedIndexChanged += new System.EventHandler(this.srcPlayer_SelectedIndexChanged);
            // 
            // srcPlayerLabel
            // 
            this.srcPlayerLabel.AutoSize = true;
            this.srcPlayerLabel.Location = new System.Drawing.Point(239, 23);
            this.srcPlayerLabel.Name = "srcPlayerLabel";
            this.srcPlayerLabel.Size = new System.Drawing.Size(36, 13);
            this.srcPlayerLabel.TabIndex = 2;
            this.srcPlayerLabel.Text = "Player";
            // 
            // srcWorld
            // 
            this.srcWorld.DisplayMember = "None";
            this.srcWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.srcWorld.FormattingEnabled = true;
            this.srcWorld.Location = new System.Drawing.Point(49, 20);
            this.srcWorld.Name = "srcWorld";
            this.srcWorld.Size = new System.Drawing.Size(184, 21);
            this.srcWorld.TabIndex = 1;
            this.srcWorld.SelectedIndexChanged += new System.EventHandler(this.srcWorld_SelectedIndexChanged);
            // 
            // srcWorldLabel
            // 
            this.srcWorldLabel.AutoSize = true;
            this.srcWorldLabel.Location = new System.Drawing.Point(8, 24);
            this.srcWorldLabel.Name = "srcWorldLabel";
            this.srcWorldLabel.Size = new System.Drawing.Size(35, 13);
            this.srcWorldLabel.TabIndex = 0;
            this.srcWorldLabel.Text = "World";
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Location = new System.Drawing.Point(191, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(78, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.stripMenuButton});
            this.statusBar.Location = new System.Drawing.Point(0, 196);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1519, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(483, 22);
            this.statusLabel.Text = "Idle";
            // 
            // stripMenuButton
            // 
            this.stripMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSavesToolStripMenuItem,
            this.openBackupsToolStripMenuItem});
            this.stripMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripMenuButton.Name = "stripMenuButton";
            this.stripMenuButton.Size = new System.Drawing.Size(13, 20);
            this.stripMenuButton.Text = "toolStripSplitButton1";
            // 
            // openSavesToolStripMenuItem
            // 
            this.openSavesToolStripMenuItem.Name = "openSavesToolStripMenuItem";
            this.openSavesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openSavesToolStripMenuItem.Text = "Open Saves";
            this.openSavesToolStripMenuItem.Click += new System.EventHandler(this.openSavesToolStripMenuItem_Click);
            // 
            // openBackupsToolStripMenuItem
            // 
            this.openBackupsToolStripMenuItem.Name = "openBackupsToolStripMenuItem";
            this.openBackupsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openBackupsToolStripMenuItem.Text = "Open Backups";
            this.openBackupsToolStripMenuItem.Click += new System.EventHandler(this.openBackupsToolStripMenuItem_Click);
            // 
            // actionBox
            // 
            this.actionBox.Controls.Add(this.transferButton);
            this.actionBox.Controls.Add(this.refreshButton);
            this.actionBox.Location = new System.Drawing.Point(207, 134);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(282, 53);
            this.actionBox.TabIndex = 4;
            this.actionBox.TabStop = false;
            this.actionBox.Text = "Actions";
            // 
            // dstManualBox
            // 
            this.dstManualBox.Controls.Add(this.dstOpen);
            this.dstManualBox.Controls.Add(this.dstInput);
            this.dstManualBox.Controls.Add(this.dstManualLabel);
            this.dstManualBox.Location = new System.Drawing.Point(495, 12);
            this.dstManualBox.Name = "dstManualBox";
            this.dstManualBox.Size = new System.Drawing.Size(477, 55);
            this.dstManualBox.TabIndex = 5;
            this.dstManualBox.TabStop = false;
            this.dstManualBox.Text = "Destination";
            this.dstManualBox.Visible = false;
            // 
            // dstOpen
            // 
            this.dstOpen.Location = new System.Drawing.Point(387, 19);
            this.dstOpen.Name = "dstOpen";
            this.dstOpen.Size = new System.Drawing.Size(79, 22);
            this.dstOpen.TabIndex = 4;
            this.dstOpen.Text = "Open";
            this.dstOpen.UseVisualStyleBackColor = true;
            this.dstOpen.Click += new System.EventHandler(this.dstOpen_Click);
            // 
            // dstInput
            // 
            this.dstInput.Location = new System.Drawing.Point(49, 20);
            this.dstInput.Name = "dstInput";
            this.dstInput.Size = new System.Drawing.Size(328, 20);
            this.dstInput.TabIndex = 3;
            this.dstInput.TextChanged += new System.EventHandler(this.dstInput_TextChanged);
            // 
            // dstManualLabel
            // 
            this.dstManualLabel.AutoSize = true;
            this.dstManualLabel.Location = new System.Drawing.Point(9, 24);
            this.dstManualLabel.Name = "dstManualLabel";
            this.dstManualLabel.Size = new System.Drawing.Size(36, 13);
            this.dstManualLabel.TabIndex = 2;
            this.dstManualLabel.Text = "Player";
            // 
            // srcManualBox
            // 
            this.srcManualBox.Controls.Add(this.srcOpen);
            this.srcManualBox.Controls.Add(this.srcManualLabel);
            this.srcManualBox.Controls.Add(this.srcInput);
            this.srcManualBox.Location = new System.Drawing.Point(495, 73);
            this.srcManualBox.Name = "srcManualBox";
            this.srcManualBox.Size = new System.Drawing.Size(477, 55);
            this.srcManualBox.TabIndex = 6;
            this.srcManualBox.TabStop = false;
            this.srcManualBox.Text = "Source";
            this.srcManualBox.Visible = false;
            // 
            // srcOpen
            // 
            this.srcOpen.Location = new System.Drawing.Point(387, 19);
            this.srcOpen.Name = "srcOpen";
            this.srcOpen.Size = new System.Drawing.Size(79, 22);
            this.srcOpen.TabIndex = 7;
            this.srcOpen.Text = "Open";
            this.srcOpen.UseVisualStyleBackColor = true;
            this.srcOpen.Click += new System.EventHandler(this.srcOpen_Click);
            // 
            // srcManualLabel
            // 
            this.srcManualLabel.AutoSize = true;
            this.srcManualLabel.Location = new System.Drawing.Point(9, 24);
            this.srcManualLabel.Name = "srcManualLabel";
            this.srcManualLabel.Size = new System.Drawing.Size(36, 13);
            this.srcManualLabel.TabIndex = 5;
            this.srcManualLabel.Text = "Player";
            // 
            // srcInput
            // 
            this.srcInput.Location = new System.Drawing.Point(49, 20);
            this.srcInput.Name = "srcInput";
            this.srcInput.Size = new System.Drawing.Size(328, 20);
            this.srcInput.TabIndex = 6;
            this.srcInput.TextChanged += new System.EventHandler(this.srcInput_TextChanged);
            // 
            // modeBox
            // 
            this.modeBox.Controls.Add(this.nameMode);
            this.modeBox.Controls.Add(this.manualMode);
            this.modeBox.Controls.Add(this.defaultMode);
            this.modeBox.Location = new System.Drawing.Point(11, 134);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(192, 53);
            this.modeBox.TabIndex = 7;
            this.modeBox.TabStop = false;
            this.modeBox.Text = "Mode";
            // 
            // nameMode
            // 
            this.nameMode.AutoSize = true;
            this.nameMode.Location = new System.Drawing.Point(137, 23);
            this.nameMode.Name = "nameMode";
            this.nameMode.Size = new System.Drawing.Size(53, 17);
            this.nameMode.TabIndex = 2;
            this.nameMode.Text = "Name";
            this.nameMode.UseVisualStyleBackColor = true;
            this.nameMode.CheckedChanged += new System.EventHandler(this.nameMode_CheckedChanged);
            // 
            // manualMode
            // 
            this.manualMode.AutoSize = true;
            this.manualMode.Location = new System.Drawing.Point(71, 23);
            this.manualMode.Name = "manualMode";
            this.manualMode.Size = new System.Drawing.Size(60, 17);
            this.manualMode.TabIndex = 1;
            this.manualMode.Text = "Manual";
            this.manualMode.UseVisualStyleBackColor = true;
            this.manualMode.CheckedChanged += new System.EventHandler(this.manualMode_CheckedChanged);
            // 
            // defaultMode
            // 
            this.defaultMode.AutoSize = true;
            this.defaultMode.Checked = true;
            this.defaultMode.Location = new System.Drawing.Point(6, 23);
            this.defaultMode.Name = "defaultMode";
            this.defaultMode.Size = new System.Drawing.Size(59, 17);
            this.defaultMode.TabIndex = 0;
            this.defaultMode.TabStop = true;
            this.defaultMode.Text = "Default";
            this.defaultMode.UseVisualStyleBackColor = true;
            this.defaultMode.CheckedChanged += new System.EventHandler(this.defaultMode_CheckedChanged);
            // 
            // srcNameBox
            // 
            this.srcNameBox.Controls.Add(this.srcNamePlayer);
            this.srcNameBox.Controls.Add(this.nameNewLabel);
            this.srcNameBox.Controls.Add(this.srcNameInput);
            this.srcNameBox.Controls.Add(this.nameOldLabel);
            this.srcNameBox.Location = new System.Drawing.Point(978, 73);
            this.srcNameBox.Name = "srcNameBox";
            this.srcNameBox.Size = new System.Drawing.Size(477, 55);
            this.srcNameBox.TabIndex = 9;
            this.srcNameBox.TabStop = false;
            this.srcNameBox.Text = "Name";
            this.srcNameBox.Visible = false;
            // 
            // srcNamePlayer
            // 
            this.srcNamePlayer.DisplayMember = "None";
            this.srcNamePlayer.FormattingEnabled = true;
            this.srcNamePlayer.Location = new System.Drawing.Point(37, 20);
            this.srcNamePlayer.Name = "srcNamePlayer";
            this.srcNamePlayer.Size = new System.Drawing.Size(196, 21);
            this.srcNamePlayer.TabIndex = 10;
            // 
            // nameNewLabel
            // 
            this.nameNewLabel.AutoSize = true;
            this.nameNewLabel.Location = new System.Drawing.Point(239, 23);
            this.nameNewLabel.Name = "nameNewLabel";
            this.nameNewLabel.Size = new System.Drawing.Size(29, 13);
            this.nameNewLabel.TabIndex = 8;
            this.nameNewLabel.Text = "New";
            // 
            // srcNameInput
            // 
            this.srcNameInput.Location = new System.Drawing.Point(274, 20);
            this.srcNameInput.Name = "srcNameInput";
            this.srcNameInput.Size = new System.Drawing.Size(191, 20);
            this.srcNameInput.TabIndex = 9;
            this.srcNameInput.TextChanged += new System.EventHandler(this.srcNameInput_TextChanged);
            // 
            // nameOldLabel
            // 
            this.nameOldLabel.AutoSize = true;
            this.nameOldLabel.Location = new System.Drawing.Point(8, 24);
            this.nameOldLabel.Name = "nameOldLabel";
            this.nameOldLabel.Size = new System.Drawing.Size(23, 13);
            this.nameOldLabel.TabIndex = 5;
            this.nameOldLabel.Text = "Old";
            // 
            // dstNameBox
            // 
            this.dstNameBox.Controls.Add(this.dstNameWorld);
            this.dstNameBox.Controls.Add(this.dstNameLabel);
            this.dstNameBox.Location = new System.Drawing.Point(978, 12);
            this.dstNameBox.Name = "dstNameBox";
            this.dstNameBox.Size = new System.Drawing.Size(477, 55);
            this.dstNameBox.TabIndex = 8;
            this.dstNameBox.TabStop = false;
            this.dstNameBox.Text = "Target";
            this.dstNameBox.Visible = false;
            // 
            // dstNameWorld
            // 
            this.dstNameWorld.DisplayMember = "None";
            this.dstNameWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dstNameWorld.FormattingEnabled = true;
            this.dstNameWorld.Location = new System.Drawing.Point(49, 20);
            this.dstNameWorld.Name = "dstNameWorld";
            this.dstNameWorld.Size = new System.Drawing.Size(416, 21);
            this.dstNameWorld.TabIndex = 6;
            this.dstNameWorld.SelectedIndexChanged += new System.EventHandler(this.dstNameWorld_SelectedIndexChanged);
            // 
            // dstNameLabel
            // 
            this.dstNameLabel.AutoSize = true;
            this.dstNameLabel.Location = new System.Drawing.Point(8, 24);
            this.dstNameLabel.Name = "dstNameLabel";
            this.dstNameLabel.Size = new System.Drawing.Size(35, 13);
            this.dstNameLabel.TabIndex = 5;
            this.dstNameLabel.Text = "World";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 218);
            this.Controls.Add(this.srcNameBox);
            this.Controls.Add(this.modeBox);
            this.Controls.Add(this.dstNameBox);
            this.Controls.Add(this.srcManualBox);
            this.Controls.Add(this.dstManualBox);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.srcBox);
            this.Controls.Add(this.dstBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palworld Appearance Transfer";
            this.dstBox.ResumeLayout(false);
            this.dstBox.PerformLayout();
            this.srcBox.ResumeLayout(false);
            this.srcBox.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.actionBox.ResumeLayout(false);
            this.dstManualBox.ResumeLayout(false);
            this.dstManualBox.PerformLayout();
            this.srcManualBox.ResumeLayout(false);
            this.srcManualBox.PerformLayout();
            this.modeBox.ResumeLayout(false);
            this.modeBox.PerformLayout();
            this.srcNameBox.ResumeLayout(false);
            this.srcNameBox.PerformLayout();
            this.dstNameBox.ResumeLayout(false);
            this.dstNameBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox dstBox;
        private Label dstPlayerLabel;
        private Label dstWorldLabel;
        private Button transferButton;
        private ComboBox dstPlayer;
        private GroupBox srcBox;
        private ComboBox srcPlayer;
        private Label srcPlayerLabel;
        private ComboBox srcWorld;
        private Label srcWorldLabel;
        private Button refreshButton;
        private StatusStrip statusBar;
        private GroupBox actionBox;
        private ToolStripStatusLabel statusLabel;
        private ComboBox dstWorld;
        private GroupBox dstManualBox;
        private Button dstOpen;
        private TextBox dstInput;
        private Label dstManualLabel;
        private GroupBox srcManualBox;
        private Button srcOpen;
        private Label srcManualLabel;
        private TextBox srcInput;
        private GroupBox modeBox;
        private RadioButton manualMode;
        private RadioButton defaultMode;
        private RadioButton nameMode;
        private GroupBox srcNameBox;
        private Label nameOldLabel;
        private GroupBox dstNameBox;
        private ComboBox dstNameWorld;
        private Label dstNameLabel;
        private ComboBox srcNamePlayer;
        private Label nameNewLabel;
        private TextBox srcNameInput;
        private ToolStripDropDownButton stripMenuButton;
        private ToolStripMenuItem openBackupsToolStripMenuItem;
        private ToolStripMenuItem openSavesToolStripMenuItem;
    }
}

