using Client.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Client
{
    public partial class lobby : Form
    {
        //pop-up menus and controls
        public choosecolor chooseColorForm;
        public spectate spectateForm;
        public createRoom createRoomForm;
        public RoomControl prev_select;
        public static waiting wait;

        

        //challenger player selected room roomcontrol
        //public static RoomControl currentroom;

        //create room data 
        public string Roomname_new;
        public int board_hight;
        public int board_width;
        public Form board;
        public static lobby mainlobby;
        public static GameBoard seegamebaord;


        public lobby()  
        {
            InitializeComponent();
            mainlobby = this;
        }
       
        #region updating the lobby
        //updating the players in the lobby
        public void showplayers()
        {
            flowLayoutPanel1.Controls.Clear();
            playerControl[] playerlist = new playerControl[GameManager.playerslist.Count];
            for (int i = 0; i < playerlist.Length; i++)
            {
                //add a control for each player in the player list
                playerlist[i] = new playerControl();
                playerlist[i].playerControlname = GameManager.playerslist[i].Name;
                playerlist[i].PlayerControlIsplaying = GameManager.playerslist[i].IsPlaying;
                //add the control to the panel
                flowLayoutPanel1.Controls.Add(playerlist[i]);
            }
        }
        //updating the rooms in the lobby
        public void showrooms()
        {
            flowLayoutPanel2.Controls.Clear();
            RoomControl[] roomlist = new RoomControl[GameManager.Roomslist.Count];
            for (int i = 0; i < roomlist.Length; i++)
            {
                roomlist[i] = new RoomControl();
                roomlist[i].roomname = GameManager.Roomslist[i].RoomName;
                if (GameManager.Roomslist[i].RoomPlayers.Count>1)
                {
                    //add a control for each player in the player list
                    roomlist[i].NumberofPlayers = GameManager.Roomslist[i].RoomPlayers.Count;
                }
                //add the control to the panel
                flowLayoutPanel2.Controls.Add(roomlist[i]);
            }
        }
        #endregion


        #region buttons clicking handling
        //clicking handling
        private void joinBtn_Click(object sender, EventArgs e)
        {
            var cons = flowLayoutPanel2.Controls;
            var selected = from RoomControl con in cons
                           where con.BackColor == Color.Silver
                           select con.TabIndex;
            GameManager.CurrentRoom = GameManager.Roomslist[selected.ElementAt(0)];
            if (selected.Count() == 0) 
            {
                //no room selected
                message ms = new message();
                ms.msg = "please select a room before \n joining";
                DialogResult res = ms.ShowDialog();
            }
            else //a room was selected
            {
                //send the join room server request
                GameManager.SendServerRequest(GameManager.Flag.joinRoom, GameManager.CurrentRoom.RoomName);
                //if (GameManager.Roomslist[selected.ElementAt(0)].challenger == null)//&& !GameManager.Rommslist[selected.ElementAt(0)].occupied  
                //{
                //    GameManager.SendServerRequest(Flag.joinRoom, GameManager.Roomslist[selected.ElementAt(0)].Name);
                //    chooseColorForm = new choosecolor();
                //    var dg = chooseColorForm.ShowDialog();
                //    if (dg == DialogResult.OK)
                //    {
                //        GameManager.SendServerRequest(Flag.asktoplay, GameManager.CurrentPlayer.Name, GameManager.CurrentPlayer.PlayerColor.ToArgb().ToString());
                //        wait = new waiting();
                //        wait.Show();

                //    }
                //    //GameManager.Rommslist[selected.ElementAt(0)].occupied = true;
                //}
                //else
                //{
                //    //GameManager.SendServerRequest(Flag.joinRoom, GameManager.Rommslist[selected.ElementAt(0)].Name);
                //    //MessageBox.Show(selected.ElementAt(0).ToString() + "you are inspectator");
                //    spectateForm = new spectate();
                //    var dg = spectateForm.ShowDialog();

                //    if (dg == DialogResult.OK)
                //    {
                //        GameManager.SendServerRequest(Flag.joinRoom, GameManager.Roomslist[selected.ElementAt(0)].Name);

                //    }
                //}



            }



        }
        private void createRoomBtn_Click(object sender, EventArgs e)
        {
            createRoomForm = new createRoom();
            var dg = createRoomForm.ShowDialog();

            if (dg == DialogResult.OK)
            {
                //create a room  
                GameManager.CurrentRoom = new clientRoom(GameManager.CurrentPlayer.Name, createRoomForm.Roomname_new);
                GameManager.CurrentRoom.Rows = createRoomForm.board_hight;
                GameManager.CurrentRoom.Cols = createRoomForm.board_width;
                GameManager.CurrentPlayer.Color = createRoomForm.Selected_color1;
                //send the create room request
                GameManager.SendServerRequest(GameManager.Flag.createRoom,
                    GameManager.CurrentPlayer.Name + "+" + createRoomForm.Selected_color1.ToArgb().ToString(),
                     Roomname_new, board_hight.ToString() + "+"+board_width.ToString());
                
                //assign the current player stats

                //GameBoard.rows = board_width;
                //GameBoard.columns = board_hight;
                //GameBoard.HostColor = createRoomForm.Selected_color1;
                //GameBoard.ChallangerColor = Color.Purple;
                //GameBoard.turn = 1;
                //GameBoard.playerTurn = 1;
                //board = new GameBoard();

                wait = new waiting();
                wait.msg = "Waiting for somone to join \nso you can Play :)";
                wait.Show();
            }

        }
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region lobby buttons handling rendring effects
        private void disconnectBtn_MouseEnter(object sender, EventArgs e)
        {
            disconnectBtn.BackColor = Color.DarkRed;
        }
        private void disconnectBtn_MouseLeave(object sender, EventArgs e)
        {
            disconnectBtn.BackColor = Color.FromArgb(217, 83, 79);
        }
        private void joinBtn_MouseEnter(object sender, EventArgs e)
        {
            joinBtn.BackColor = Color.Green;
        }
        private void joinBtn_MouseLeave(object sender, EventArgs e)
        {
            joinBtn.BackColor = Color.FromArgb(51, 178, 73);
        }
        private void createRoomBtn_MouseEnter(object sender, EventArgs e)
        {
            createRoomBtn.BackColor = Color.Blue;

        }
        private void createRoomBtn_MouseLeave(object sender, EventArgs e)
        {
            createRoomBtn.BackColor = Color.FromArgb(87, 131, 219);

        }
        #endregion

        //on form closing send the disconnect player flag to the server
        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameManager.SendServerRequest(GameManager.Flag.disconnect, "");
            (this.Parent as login).Close();
            Application.Exit();
        }

        #region drag the borderless form 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Lobby_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}
