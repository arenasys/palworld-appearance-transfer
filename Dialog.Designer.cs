﻿using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
namespace Editor
{
    partial class Dialog
    {
        private OrderedDictionary saves;
        private OrderedDictionary names;

        public delegate void TransferCallback(string srcSave, string dstSave);
        public TransferCallback transferCallback;

        public delegate void RefreshCallback();
        public RefreshCallback refreshCallback;

        delegate void SetLabelCallback(string value);
        public void SetLabel(string value)
        {
            if (this.dstWorldLabel.InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(SetLabel);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.statusLabel.Text = value;
            }
        }

        delegate void SetSavesCallback(OrderedDictionary saves, OrderedDictionary names);
        public void SetSaves(OrderedDictionary saves, OrderedDictionary names)
        {
            if (this.dstWorldLabel.InvokeRequired)
            {
                SetSavesCallback d = new SetSavesCallback(SetSaves);
                this.Invoke(d, new object[] { saves, names });
            }
            else
            {
                this.saves = saves;
                this.names = names;

                PopulateWorlds(dstWorld);
                PopulateWorlds(srcWorld);
                DoLock();
            }
        }

        public void PopulateWorlds(ComboBox worlds)
        {
            worlds.Items.Clear();
            foreach (DictionaryEntry world in this.saves)
            {
                worlds.Items.Add(names[world.Key]);
            }
            worlds.SelectedIndex = 0;
        }

        public void PopulatePlayers(ComboBox players, int world)
        {
            players.Items.Clear();
            if (world >= 0)
            {
                foreach (var player in (string[])this.saves[world])
                {
                    players.Items.Add(names[player]);
                }
            }
            players.SelectedIndex = 0;
        }

        public void DoLock()
        {
            transferButton.Enabled = ((srcWorld.SelectedIndex != dstWorld.SelectedIndex) || (srcPlayer.SelectedIndex != dstPlayer.SelectedIndex));
        }

        public void DoTransfer()
        {
            string srcSave = ((string[])this.saves[srcWorld.SelectedIndex])[this.srcPlayer.SelectedIndex];
            string dstSave = ((string[])this.saves[dstWorld.SelectedIndex])[this.dstPlayer.SelectedIndex];

            this.transferCallback.Invoke(srcSave, dstSave);
        }

        public void DoRefresh()
        {
            this.refreshCallback.Invoke();
        }

        delegate void DoCloseCallback();
        public void DoClose()
        {
            if (this.dstWorldLabel.InvokeRequired)
            {
                DoCloseCallback d = new DoCloseCallback(DoClose);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.Close();
            }
        }

        private System.ComponentModel.IContainer components = null;

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
            this.dstBox = new System.Windows.Forms.GroupBox();
            this.dstWorld = new System.Windows.Forms.ComboBox();
            this.dstPlayer = new System.Windows.Forms.ComboBox();
            this.dstPlayerLabel = new System.Windows.Forms.Label();
            this.dstWorldLabel = new System.Windows.Forms.Label();
            this.transferButton = new System.Windows.Forms.Button();
            this.sourceBox = new System.Windows.Forms.GroupBox();
            this.srcPlayer = new System.Windows.Forms.ComboBox();
            this.srcPlayerLabel = new System.Windows.Forms.Label();
            this.srcWorld = new System.Windows.Forms.ComboBox();
            this.srcWorldLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.dstBox.SuspendLayout();
            this.sourceBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.actionBox.SuspendLayout();
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
            this.transferButton.Size = new System.Drawing.Size(333, 23);
            this.transferButton.TabIndex = 4;
            this.transferButton.Text = "Transfer";
            this.transferButton.UseVisualStyleBackColor = true;
            this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
            // 
            // sourceBox
            // 
            this.sourceBox.Controls.Add(this.srcPlayer);
            this.sourceBox.Controls.Add(this.srcPlayerLabel);
            this.sourceBox.Controls.Add(this.srcWorld);
            this.sourceBox.Controls.Add(this.srcWorldLabel);
            this.sourceBox.Location = new System.Drawing.Point(12, 73);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(477, 55);
            this.sourceBox.TabIndex = 5;
            this.sourceBox.TabStop = false;
            this.sourceBox.Text = "Source";
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
            this.refreshButton.Location = new System.Drawing.Point(350, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(115, 23);
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
            this.statusBar.Size = new System.Drawing.Size(498, 22);
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
            this.actionBox.Controls.Add(this.transferButton);
            this.actionBox.Controls.Add(this.refreshButton);
            this.actionBox.Location = new System.Drawing.Point(12, 134);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(477, 53);
            this.actionBox.TabIndex = 4;
            this.actionBox.TabStop = false;
            this.actionBox.Text = "Actions";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 224);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.sourceBox);
            this.Controls.Add(this.dstBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palworld Appearance Transfer";
            this.dstBox.ResumeLayout(false);
            this.dstBox.PerformLayout();
            this.sourceBox.ResumeLayout(false);
            this.sourceBox.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.actionBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox dstBox;
        private Label dstPlayerLabel;
        private Label dstWorldLabel;
        private Button transferButton;
        private ComboBox dstPlayer;
        private GroupBox sourceBox;
        private ComboBox srcPlayer;
        private Label srcPlayerLabel;
        private ComboBox srcWorld;
        private Label srcWorldLabel;
        private Button refreshButton;
        private StatusStrip statusBar;
        private GroupBox actionBox;
        private ToolStripStatusLabel statusLabel;
        private ComboBox dstWorld;
    }
}
