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
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.manualCheck = new System.Windows.Forms.CheckBox();
            this.dstManualBox = new System.Windows.Forms.GroupBox();
            this.dstOpen = new System.Windows.Forms.Button();
            this.dstInput = new System.Windows.Forms.TextBox();
            this.dstManualLabel = new System.Windows.Forms.Label();
            this.srcManualBox = new System.Windows.Forms.GroupBox();
            this.srcOpen = new System.Windows.Forms.Button();
            this.srcManualLabel = new System.Windows.Forms.Label();
            this.srcInput = new System.Windows.Forms.TextBox();
            this.dstBox.SuspendLayout();
            this.srcBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.actionBox.SuspendLayout();
            this.dstManualBox.SuspendLayout();
            this.srcManualBox.SuspendLayout();
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
            this.transferButton.Size = new System.Drawing.Size(264, 23);
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
            this.refreshButton.Location = new System.Drawing.Point(281, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(117, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 202);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(503, 22);
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
            this.statusLabel.Size = new System.Drawing.Size(496, 22);
            this.statusLabel.Text = "Idle";
            // 
            // actionBox
            // 
            this.actionBox.Controls.Add(this.manualCheck);
            this.actionBox.Controls.Add(this.transferButton);
            this.actionBox.Controls.Add(this.refreshButton);
            this.actionBox.Location = new System.Drawing.Point(12, 134);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(477, 53);
            this.actionBox.TabIndex = 4;
            this.actionBox.TabStop = false;
            this.actionBox.Text = "Actions";
            // 
            // manualCheck
            // 
            this.manualCheck.AutoSize = true;
            this.manualCheck.Location = new System.Drawing.Point(404, 23);
            this.manualCheck.Name = "manualCheck";
            this.manualCheck.Size = new System.Drawing.Size(61, 17);
            this.manualCheck.TabIndex = 5;
            this.manualCheck.Text = "Manual";
            this.manualCheck.UseVisualStyleBackColor = true;
            this.manualCheck.CheckedChanged += new System.EventHandler(this.manualCheck_CheckedChanged);
            // 
            // dstManualBox
            // 
            this.dstManualBox.Controls.Add(this.dstOpen);
            this.dstManualBox.Controls.Add(this.dstInput);
            this.dstManualBox.Controls.Add(this.dstManualLabel);
            this.dstManualBox.Location = new System.Drawing.Point(12, 12);
            this.dstManualBox.Name = "dstManualBox";
            this.dstManualBox.Size = new System.Drawing.Size(477, 55);
            this.dstManualBox.TabIndex = 5;
            this.dstManualBox.TabStop = false;
            this.dstManualBox.Text = "Destination";
            this.dstManualBox.Visible = false;
            // 
            // dstOpen
            // 
            this.dstOpen.Location = new System.Drawing.Point(387, 22);
            this.dstOpen.Name = "dstOpen";
            this.dstOpen.Size = new System.Drawing.Size(78, 22);
            this.dstOpen.TabIndex = 4;
            this.dstOpen.Text = "Open";
            this.dstOpen.UseVisualStyleBackColor = true;
            this.dstOpen.Click += new System.EventHandler(this.dstOpen_Click);
            // 
            // dstInput
            // 
            this.dstInput.Location = new System.Drawing.Point(53, 23);
            this.dstInput.Name = "dstInput";
            this.dstInput.Size = new System.Drawing.Size(328, 20);
            this.dstInput.TabIndex = 3;
            this.dstInput.TextChanged += new System.EventHandler(this.dstInput_TextChanged);
            // 
            // dstManualLabel
            // 
            this.dstManualLabel.AutoSize = true;
            this.dstManualLabel.Location = new System.Drawing.Point(11, 26);
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
            this.srcManualBox.Location = new System.Drawing.Point(12, 73);
            this.srcManualBox.Name = "srcManualBox";
            this.srcManualBox.Size = new System.Drawing.Size(477, 55);
            this.srcManualBox.TabIndex = 6;
            this.srcManualBox.TabStop = false;
            this.srcManualBox.Text = "Source";
            this.srcManualBox.Visible = false;
            // 
            // srcOpen
            // 
            this.srcOpen.Location = new System.Drawing.Point(387, 20);
            this.srcOpen.Name = "srcOpen";
            this.srcOpen.Size = new System.Drawing.Size(78, 22);
            this.srcOpen.TabIndex = 7;
            this.srcOpen.Text = "Open";
            this.srcOpen.UseVisualStyleBackColor = true;
            this.srcOpen.Click += new System.EventHandler(this.srcOpen_Click);
            // 
            // srcManualLabel
            // 
            this.srcManualLabel.AutoSize = true;
            this.srcManualLabel.Location = new System.Drawing.Point(11, 24);
            this.srcManualLabel.Name = "srcManualLabel";
            this.srcManualLabel.Size = new System.Drawing.Size(36, 13);
            this.srcManualLabel.TabIndex = 5;
            this.srcManualLabel.Text = "Player";
            // 
            // srcInput
            // 
            this.srcInput.Location = new System.Drawing.Point(53, 21);
            this.srcInput.Name = "srcInput";
            this.srcInput.Size = new System.Drawing.Size(328, 20);
            this.srcInput.TabIndex = 6;
            this.srcInput.TextChanged += new System.EventHandler(this.srcInput_TextChanged);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 224);
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
            this.actionBox.PerformLayout();
            this.dstManualBox.ResumeLayout(false);
            this.dstManualBox.PerformLayout();
            this.srcManualBox.ResumeLayout(false);
            this.srcManualBox.PerformLayout();
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
        private CheckBox manualCheck;
        private GroupBox dstManualBox;
        private Button dstOpen;
        private TextBox dstInput;
        private Label dstManualLabel;
        private GroupBox srcManualBox;
        private Button srcOpen;
        private Label srcManualLabel;
        private TextBox srcInput;
    }
}

