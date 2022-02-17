using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Client
{
    public class clientPlayer
    {
        string name;
        Color color;
        bool isPlaying = false;
        bool playAgain = false;
        int score = 0;
        clientRoom myRoom = null;
        //player network and streams
        NetworkStream nstream;
        BinaryReader br;
        BinaryWriter bw;
        //player specific task to handle each player requests
        Task playerThread;

        //assign a cancellation token for the task
        public CancellationTokenSource tokenSource = new CancellationTokenSource();
        public CancellationToken ct; //this.tokenSource.Token;


        #region class getters and setters
        public string Name { get { return name; } set { name = value; } }
        public Color Color { get { return color; } set { color = value; } }
        public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
        public bool PlayAgain { get { return playAgain; } set { playAgain = value; } }
        public int Score { get { return score; } set { score = value; } }
        public clientRoom MyRoom { get { return myRoom; } set { myRoom = value; } }
        public NetworkStream Nstream { get { return nstream; } set { nstream = value; } }
        public BinaryReader Br { get { return br; } set { br = value; } }
        public BinaryWriter Bw { get { return bw; } set { bw = value; } }
        public Task PlayerThread { get { return playerThread; } set { playerThread = value; } }
        #endregion  
        
        public clientPlayer(string name, bool isplaying)
        {
            this.name = name;
            this.isPlaying = isplaying;
        }
    }

}
