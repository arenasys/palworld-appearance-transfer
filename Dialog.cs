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
            DoTransfer();
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
    }
}
