using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace Editor
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();

            this.Width = 516;

            dstManualBox.Top = dstBox.Top;
            dstManualBox.Left = dstBox.Left;
            srcManualBox.Top = srcBox.Top;
            srcManualBox.Left = srcBox.Left;

            dstNameBox.Top = dstBox.Top;
            dstNameBox.Left = dstBox.Left;
            srcNameBox.Top = srcBox.Top;
            srcNameBox.Left = srcBox.Left;
        }

        private OrderedDictionary saves;
        private OrderedDictionary names;
        private bool working = false;

        public delegate void TransferCallback(string srcSave, string dstSave);
        public TransferCallback transferCallback;

        public delegate void RefreshCallback();
        public RefreshCallback refreshCallback;

        public delegate void RenameCallback(string worldFolder, string oldName, string newName);
        public RenameCallback renameCallback;

        public delegate void OpenCallback(string type);
        public OpenCallback openCallback;

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
                SetWorking(value.EndsWith("..."));
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

                PopulateWorlds(dstWorld, includeBackup: false);
                PopulateWorlds(srcWorld);
                PopulateWorlds(dstNameWorld, includeBackup: false);
                DoLock();
            }
        }
        public void PopulateWorlds(ComboBox worlds, bool includeBackup = true)
        {
            worlds.Items.Clear();
            foreach (DictionaryEntry world in this.saves)
            {
                if((string)world.Key == "backup" && !includeBackup)
                {
                    continue;
                }
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

        public void SetWorking(bool working)
        {
            this.working = working;
            DoLock();
        }
        public void DoLock()
        {
            if(working)
            {
                transferButton.Enabled = false;
                refreshButton.Enabled = false;
                return;
            }

            refreshButton.Enabled = true;

            if (manualMode.Checked)
            {
                transferButton.Enabled = srcInput.Text.Length != 0 && dstInput.Text.Length != 0;
            }
            else if(nameMode.Checked)
            {
                transferButton.Enabled = srcNameInput.Text.Length != 0;
            }
            else
            {
                transferButton.Enabled = ((srcWorld.SelectedIndex != dstWorld.SelectedIndex) || (srcPlayer.SelectedIndex != dstPlayer.SelectedIndex));
            }
        }

        public void DoVisible()
        {
            dstBox.Visible = defaultMode.Checked;
            srcBox.Visible = defaultMode.Checked;
            dstManualBox.Visible = manualMode.Checked;
            srcManualBox.Visible = manualMode.Checked;
            dstNameBox.Visible = nameMode.Checked;
            srcNameBox.Visible = nameMode.Checked;

            transferButton.Text = nameMode.Checked ? "Rename" : "Transfer";
            DoLock();
        }

        public void DoTransfer()
        {
            string srcSave = ((string[])this.saves[srcWorld.SelectedIndex])[this.srcPlayer.SelectedIndex];
            string dstSave = ((string[])this.saves[dstWorld.SelectedIndex])[this.dstPlayer.SelectedIndex];

            this.transferCallback.Invoke(srcSave, dstSave);
        }

        public void DoManualTransfer()
        {
            string srcSave = this.srcInput.Text;
            string dstSave = this.dstInput.Text;

            this.transferCallback.Invoke(srcSave, dstSave);
        }
        public void DoRename()
        {
            try
            {
                string dstSave = ((string[])this.saves[dstNameWorld.SelectedIndex])[0];
                string worldFolder = Path.GetDirectoryName(Path.GetDirectoryName(dstSave));

                string oldName = this.srcNamePlayer.Text;
                string newName = this.srcNameInput.Text;

                this.renameCallback.Invoke(worldFolder, oldName, newName);
            }
            catch { }

        }

        public void DoRefresh()
        {
            this.refreshCallback.Invoke();
        }

        public void DoOpen(string type)
        {
            this.openCallback.Invoke(type);
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

        private void dstWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePlayers(dstPlayer, dstWorld.SelectedIndex);
        }

        private void srcWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePlayers(srcPlayer, srcWorld.SelectedIndex);
        }

        private void dstNameWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePlayers(srcNamePlayer, dstNameWorld.SelectedIndex);
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            if (manualMode.Checked)
            {
                var result = MessageBox.Show("Transferring will modify the player save file. A backup will be created.\nContinue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DoManualTransfer();
                }
                
            }
            else if(nameMode.Checked)
            {
                var result = MessageBox.Show("Renaming will modify the world save file. A world backup will be created.\nContinue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DoRename();
                }
            }
            else
            {
                var result = MessageBox.Show("Transferring will modify the player save file. A backup will be created.\nContinue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DoTransfer();
                }
            }
        }
        
        private void refreshButton_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void srcPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoLock();
        }

        private void dstPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoLock();
        }

        private void dstOpen_Click(object sender, EventArgs e)
        {
            var picker = new OpenFileDialog()
            {
                FileName = "",
                Filter = "Save files (*.sav)|*.sav",
                Title = "Open destination save file"
            };
            if(picker.ShowDialog() == DialogResult.OK)
            {
                dstInput.Text = picker.FileName;
            }
        }

        private void srcOpen_Click(object sender, EventArgs e)
        {
            var picker = new OpenFileDialog()
            {
                FileName = "",
                Filter = "Save files (*.sav)|*.sav",
                Title = "Open source save file"
            };
            if (picker.ShowDialog() == DialogResult.OK)
            {
                srcInput.Text = picker.FileName;
            }
        }

        private void dstInput_TextChanged(object sender, EventArgs e)
        {
            DoLock();
        }

        private void srcInput_TextChanged(object sender, EventArgs e)
        {
            DoLock();
        }

        private void defaultMode_CheckedChanged(object sender, EventArgs e)
        {
            DoVisible();
        }

        private void manualMode_CheckedChanged(object sender, EventArgs e)
        {
            DoVisible();
        }

        private void nameMode_CheckedChanged(object sender, EventArgs e)
        {
            DoVisible();
        }

        private void srcNameInput_TextChanged(object sender, EventArgs e)
        {
            DoLock();
        }

        private void openSavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpen("saves");
        }

        private void openBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpen("backups");
        }
    }
}
