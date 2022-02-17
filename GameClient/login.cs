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
    public partial class login : Form
    {
        lobby start_lobby;
        public string playerName;
        private bool firstlogin = true;

        public login()
        {
            InitializeComponent();
        }

        //handle the login button
        private void loginBtn_click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                MessageBox.Show("you need to Enter a user Name to login");
            }
            else
            {
                //the client entered a username
                playerName = userNameTextBox.Text;
                if (firstlogin)
                {
                    try
                    {
                        GameManager.Login(playerName);
                        firstlogin = false;
                        //start_lobby = new lobby();
                        //start_lobby.Show();
                        //this.Hide();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The Server is Offline please try again later");
                    }
                    if (GameManager.isloginSuc(playerName))
                    {
                        start_lobby = new lobby();
                        start_lobby.Text += "- " + playerName;
                        GameManager.recieveThread = new Task(GameManager.ReceiveServerResponse);
                        GameManager.recieveThread.Start();
                        GameManager.SendServerRequest(GameManager.Flag.getPlayers);
                        GameManager.SendServerRequest(GameManager.Flag.getRooms);

                        start_lobby.Show();
                        this.Hide();
                    }
                }
                else
                {
                    GameManager.SendServerRequest(GameManager.Flag.sendLoginInfo, playerName);
                    if (GameManager.isloginSuc(playerName))
                    {
                        start_lobby = new lobby();
                        start_lobby.Text += "- " + playerName;
                        GameManager.recieveThread = new Task(GameManager.ReceiveServerResponse);
                        GameManager.recieveThread.Start();
                        GameManager.SendServerRequest(GameManager.Flag.getPlayers);
                        GameManager.SendServerRequest(GameManager.Flag.getRooms);

                        start_lobby.Show();
                        this.Hide();
                    }
                }
            }
        }

        //handle enter key press on the text box
        private void userNameTextBox_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_click(new object(), EventArgs.Empty);
            }
        }

        #region   drag the borderless form 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Login_MouseDown(object sender, MouseEventArgs e)
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {


            try
            {
                if (GameManager.connStatus)
                {
                    GameManager.SendServerRequest(GameManager.Flag.disconnect, "");
                }
            }
            catch (Exception)
            {


            }
        }
        #endregion
    }
}


