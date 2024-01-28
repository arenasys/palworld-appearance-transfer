using System;
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
        }

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
            if (manualCheck.Enabled)
            {
                transferButton.Enabled = srcInput.Text.Length != 0 && dstInput.Text.Length != 0;
            }
            else
            {
                transferButton.Enabled = ((srcWorld.SelectedIndex != dstWorld.SelectedIndex) || (srcPlayer.SelectedIndex != dstPlayer.SelectedIndex));
            }
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

        private void dstWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePlayers(dstPlayer, dstWorld.SelectedIndex);
        }

        private void srcWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePlayers(srcPlayer, srcWorld.SelectedIndex);
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            if (manualCheck.Checked)
            {
                DoManualTransfer();
            }
            else
            {
                DoTransfer();
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

        private void manualCheck_CheckedChanged(object sender, EventArgs e)
        {
            dstBox.Visible = !manualCheck.Checked;
            srcBox.Visible = !manualCheck.Checked;
            dstManualBox.Visible = manualCheck.Checked;
            srcManualBox.Visible = manualCheck.Checked;
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
    }
}
