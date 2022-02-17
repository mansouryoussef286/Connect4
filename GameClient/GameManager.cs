using Client.Popups;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    ///  Responsible for all Connect4 Game client logic 
    /// </summary>

    public class GameManager
    {
        #region server fields
        //server variables
        static TcpClient server;
        static string ip;
        static int port;
        static IPAddress ServerIP;
        
        public static bool connStatus;

        //user's info
        static NetworkStream ConnectionStream;
        static BinaryReader br;
        static BinaryWriter bw;

        public static List<clientPlayer> playerslist;
        public static List<clientRoom> Roomslist;

        //client thread
        public static Task recieveThread;

        //current client player and room
        public static clientPlayer CurrentPlayer = new clientPlayer("noName", false);
        public static clientRoom CurrentRoom;

        public enum Flag
        {
            sendLoginInfo = 100,
            getPlayers = 210,
            getRooms = 220,
            createRoom = 310,
            joinRoom = 320,
            asktoplay = 400,
            waittopaly = 405,
            SendMove = 410,
            updateBoard = 420,
            gameResult = 500,
            playAgain = 600,
            leaveRoom = 650,
            disconnect = 700
        }

        #endregion

        GameManager()
        {
            ip = "127.0.0.1";
            port = 2222;
            connStatus = false;
            ServerIP = IPAddress.Parse(ip);

            playerslist = new List<clientPlayer>();
            Roomslist = new List<clientRoom>();
        }


        //Connect the user to the server and return The result of the attempt 
        public static void Login(string userName)
        {
            try
            {
                //connect with the server
                server = new TcpClient();
                server.Connect(ServerIP, port);
                ConnectionStream = server.GetStream();
                br = new BinaryReader(ConnectionStream);
                bw = new BinaryWriter(ConnectionStream);

                SendServerRequest(Flag.sendLoginInfo, userName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //check if the login name is valid from the server
        public static bool isloginSuc(string userName)
        {
            var msg = br.ReadString();
            var msgArray = msg.Split(',');
            var data = msgArray.ToList();
            //MessageBox.Show(data.ElementAt(0) + "," + data.ElementAt(1));
            if (data.ElementAt(1) == "1")
            {
                CurrentPlayer.Name = userName;
                connStatus = true;
                return true;
            }
            else
            {
                MessageBox.Show("userName is already taken!");
                return false;
            }
        }

        
        //sending requests to the game server
        public static void SendServerRequest(Flag flag,params string[] data)
        {
            var f = (int)flag;
            string msg = f.ToString();
           
            if (data.Length >0)
            {
                foreach (var item in data)
                {
                    msg += "," + item;
                }
            }
            bw.Write(msg);
        }

        //receiving the server requests
        public static void ReceiveServerResponse()
        {
            //read the response
            var msg = br.ReadString();
            //MessageBox.Show(msg);
            //split on the response and get the sent data
            var msgArray = msg.Split(',');
            Flag flag = (Flag)int.Parse(msgArray[0]);
            var data = msgArray.ToList();
            data.RemoveAt(0);
            //switch on the flag 
            switch (flag)
            {
                #region accepting players and rooms list response
                case Flag.getPlayers:
                     playerslist = Getplayers(data);
                    lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                    {
                        lobby.mainlobby.showplayers();
                    }));
                    break;

                case Flag.getRooms:
                    Roomslist = GetRooms(data);
                    lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                    {
                        lobby.mainlobby.showrooms();
                    }));
                    break;
                #endregion
                #region joining a room and ask to play
                case Flag.joinRoom:
                    joinRoom(data);
                    break;
                case Flag.asktoplay:
                    //"400, askingPlayer.Name + askingPlayer.Color"
                    acceptTheChallenger(data[0]);
                    break;
                case Flag.waittopaly:
                    //care if the owner refused he return 405,0 so it throws exception 
                    playgame(data.ElementAt(0), data.ElementAt(1), data.ElementAt(2)); // if 405,1: hide or open gamebaord     else 405,0:close choose color host didnt accpet
                    break;
                #endregion
                #region handling game moves and result
                case Flag.SendMove:
                    GameBoard.turn = int.Parse(data.ElementAt(0));
                    data.RemoveAt(0);
                    updateBoard(data);
                    break;
                case Flag.updateBoard:
                    break;
                case Flag.gameResult:
                    showWinningMesg(data);
                        break;
                #endregion
            }
            //MessageBox.Show(msg);
            ReceiveServerResponse();
        }



        #region  lobby client handling functions
        //after the response of joining a room is recieved
        private static void joinRoom(List<string> data)
        {
            //check on the incoming flag
            if (data.ElementAt(0) == "1")
            {
                //join as a challenger 
                lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                {
                    string hostColor = data.ElementAt(1);
                    choosecolor chooseColorForm = new choosecolor();
                    chooseColorForm.OpponentColor = Color.FromArgb(int.Parse(hostColor));
                    var dg = chooseColorForm.ShowDialog();
                    if (dg == DialogResult.OK)
                    {
                        GameManager.SendServerRequest(Flag.asktoplay, GameManager.CurrentPlayer.Name, GameManager.CurrentPlayer.Color.ToArgb().ToString());
                        waiting wait = new waiting();
                        wait.Show();
                    }
                }));
            }
            else if (data.ElementAt(0) == "2")
            {
                //join as a spectator 
                string hostColor = data.ElementAt(1);
                string ChallngerColor = data.ElementAt(2);
                string size = data.ElementAt(3);

                string[] sizear = size.Split('+');
                lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                {
                    //lobby.mainlobby.join_spectate.Close();

                    message ms = new message();
                    ms.msg = "YOU ARE NOW SPECTATING \n THE GAME";
                    DialogResult res = ms.ShowDialog();

                    //GameBoard.columns = int.Parse(sizear[1]);
                    //GameBoard.rows = int.Parse(sizear[0]);
                    //GameBoard.HostColor = Color.FromArgb(Int32.Parse(hostColor));
                    //GameBoard.ChallangerColor = Color.FromArgb(Int32.Parse(ChallngerColor));
                    //GameBoard.turn = 0;
                    //GameBoard.playerTurn = 3;

                    //lobby.seegamebaord = new GameBoard();
                    //lobby.seegamebaord.Show();
                }));
            }
            else
            {
                //room not found
                MessageBox.Show("this room isnot found it may be deleted by its owner");
            }
        }
        
        //lesssa
        private static void showWinningMesg(List<string> data)
        {

            switch (data[0])
            {
                case "0":
                    GameBoard.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        winORlose.result = 0;
                        GameBoard.winandlose = new winORlose();
                        GameBoard.winandlose.ShowDialog();


                    }));
                    break;
                case "1":
                    GameBoard.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        winORlose.result = 1;
                        GameBoard.winandlose = new winORlose();
                        GameBoard.winandlose.ShowDialog();

                    }));
                    break;
                case "-1":
                    GameBoard.currntGameboard.Invoke(new MethodInvoker(delegate ()
                    {
                        winORlose.result = -1;
                        winORlose.winner = data[1];
                        GameBoard.winandlose = new winORlose();
                        GameBoard.winandlose.ShowDialog();
                    }));
                    break;
                default:
                    break;
            }
        }

        //accept the challenger in the host lobby
        private static void acceptTheChallenger(string data)
        {
            //pop up a menu asking the room owner if he wants the challenger to play or not
            acceptTheChallenger dlg = new acceptTheChallenger();
            string[] arr = data.Split('+');
            dlg.challengerLabel = $"{arr[0]} wants to challange you ";
            DialogResult ownerResponse = dlg.ShowDialog();
            //if the owner accepts
            if (ownerResponse == DialogResult.OK)
            {
                SendServerRequest(Flag.waittopaly, "1");
                lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                {
                    message ms = new message();
                    ms.msg = $"  You are currently playing against: {arr[0]}";
                    lobby.wait.Close();
                    lobby.mainlobby.board.Show();

                }));
            }
            else
            {
                SendServerRequest(Flag.waittopaly, "0");
            }
            GameBoard.ChallangerColor = Color.FromArgb(int.Parse(arr[1]));
            GameBoard.ChallangerBrush = new SolidBrush(GameBoard.ChallangerColor);
        }
        //start the game in challenger lobby
        private static void playgame(string response, string size, string hostcolor)
        {
            //if the host accepted me
            if (int.Parse(response) == 1)
            {
                var sizear = size.Split('+');
                lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                {
                    lobby.wait.Close();
                    //lobby.mainlobby.Hide();
                    //display acceptance message
                    message ms = new message();
                    ms.msg = "the owner has accepted you!";
                    DialogResult res = ms.ShowDialog();

                    //open the board
                    //GameBoard.columns = int.Parse(sizear[1]);
                    //GameBoard.rows = int.Parse(sizear[0]);
                    //GameBoard.HostColor = Color.FromArgb(Int32.Parse(hostcolor));
                    //GameBoard.ChallangerColor = CurrentPlayer.PlayerColor;
                    //GameBoard.turn = 1;
                    //GameBoard.playerTurn = 2;

                    lobby.seegamebaord = new GameBoard();
                    lobby.seegamebaord.Show();
                }));
            }
            else
            {
                lobby.mainlobby.Invoke(new MethodInvoker(delegate ()
                {
                    //display rejection message
                    message ms = new message();
                    ms.msg = "the owner has rejected you!";
                    DialogResult res = ms.ShowDialog();
                    //de-assign the room to me 
                    CurrentRoom = null;

                    //lobby.seegamebaord.Close();
                }));

            }
        }

        //lesssa
        private static void updateBoard(List<string> data)
        {
            //int[,] tempbaord = new int[GameBoard.rows, GameBoard.columns];

            for (int i = 0; i < data.Count; i++)
            {
                var rowstring = data.ElementAt(i);
                var row = rowstring.Split('+');
                for (int j = 0; j < row.Length; j++)
                {

                    GameBoard.currntGameboard.board[i, j] = int.Parse(row[j]);
                    //GameBoard.currntGameboard.board[i, j] = int.Parse(row[j]);

                }

            }
            //check if the game board is shown so it is updated,
            //as when a player send that he doesnot want to play again
            //and the game board panel is closed it doesnot throw an exception
            if (GameBoard.currntGameboard.Visible)
            {
                GameBoard.currntGameboard.BeginInvoke(new MethodInvoker(delegate () {

                    GameBoard.currntGameboard.repaintBord();
                }));

            }

            //string updateStr = "";
            //for (int row = 0; row < rows; row++)
            //{
            //    updateStr += "[";
            //    for (int col = 0; col <columns; col++)
            //    {
            //        if (col < columns - 1)
            //            updateStr += board[row, col] + ",";
            //        else
            //            updateStr += board[row, col];
            //    }
            //    if (row < rows - 1)
            //        updateStr += "],";
            //    else
            //        updateStr += "]";
            //}

        }

        #endregion


        #region update the room and players list
        //Get all the players on the server and return them as a List of Players
        public static List<clientPlayer> Getplayers(List<string> data)
        {
            var players = new List<clientPlayer>();

            foreach (var item in data)
            {
                var name = item.Split('+')[0];
                bool isplaying =bool.Parse( item.Split('+')[1]);
                players.Add(new clientPlayer(name, isplaying));
            }
            return players;
        }

        //Get all the players on the server and return them as an List of Players
        public static List<clientRoom> GetRooms(List<string> data)
        {   
            var rooms = new List<clientRoom>();
            foreach (var item in data)
            {
                //roomname + pname-isplaying-pcol + pname-isplaying-pcol
                string[] room = item.Split('+');
                string roomName = room[0];
                string hostName = room[1].Split('-')[0];

                clientRoom addedRoom = new clientRoom(hostName, roomName);
                if (room.Length >2)
                {
                    for(var i = 2; i < room.Length; i++)
                    {
                        bool isplaying = true;
                        if (i > 3)
                        {
                            isplaying = false;
                        }
                        addedRoom.RoomPlayers.Add(new clientPlayer(room[i].Split('-')[0], isplaying));
                    }
                }
                rooms.Add(addedRoom);
            }
            return rooms;
        }
        #endregion
    }
}
