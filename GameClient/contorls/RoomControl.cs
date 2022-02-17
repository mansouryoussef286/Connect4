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
    public partial class RoomControl : UserControl
    {
        //public string selected_room;
        private int _NumberofPlayers;

        public string roomname
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public int NumberofPlayers
        {
            get { return _NumberofPlayers; }
            set
            {
                _NumberofPlayers = value;
                if (value == 1)
                {
                    label2.Text = _NumberofPlayers.ToString() + " player";
                }
                else
                {
                    label2.Text = _NumberofPlayers.ToString() + " players";
                }
            }
        }

        public RoomControl()
        {
            InitializeComponent();
        }

        private void RoomControl_MouseClick(object sender, MouseEventArgs e)
        {
            lobby parentForm = (this.Parent.Parent as lobby);

            if (e.Button == MouseButtons.Left)
            {
                if (parentForm.prev_select != null)
                {
                    parentForm.prev_select.BackColor = Color.White;
                }
                //selected_room = this.label1.Text;
                this.BackColor = Color.Silver;
                parentForm.prev_select= this;
            }
        }
    }
}
