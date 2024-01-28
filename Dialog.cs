using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
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
