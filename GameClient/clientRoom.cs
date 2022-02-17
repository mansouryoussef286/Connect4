using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class clientRoom
    {
        int roomID;
        string roomName;
        static int counter = 0; //to specify room ID
        //room specifications
        int rows;
        int cols;
        int[,] board;
        int playerTurn = 1;
        int gameEnded = 0;
        //room players list
        List<clientPlayer> roomPlayers = new List<clientPlayer>();

        //class getters and setters
        public int RoomID { get { return roomID; } set { roomID = value; } }
        public string RoomName { get { return roomName; } set { roomName = value; } }
        public int Rows { get { return rows; } set { rows = value; } }
        public int Cols { get { return cols; } set { cols = value; } }
        public int[,] Board { get { return board; } set { board = value; } }
        public int PlayerTurn { get { return playerTurn; } set { playerTurn = value; } }
        public int GameEnded { get { return gameEnded; } set { gameEnded = value; } }
        public List<clientPlayer> RoomPlayers { get { return roomPlayers; } }

        public clientRoom(string roomOwner, string name)
        {
            counter++;
            roomID = counter;
            roomName = name;
            clientPlayer host = new clientPlayer(name, true);
            roomPlayers.Add(host);
        }
    }
}
