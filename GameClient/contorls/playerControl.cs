using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class playerControl : UserControl
    {
        public playerControl()
        {
            InitializeComponent();
        }


        private string _playername;

        public string playerControlname
        {
            get { return _playername; }
            set { _playername = value; label1.Text = value; }
        }
        public bool PlayerControlIsplaying
        {
            set {
                label2.Visible = value;
                label3.Visible = !value;
            }
        }
    }
}
