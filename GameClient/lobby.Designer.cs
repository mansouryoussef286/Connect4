namespace Client
{
    partial class lobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lobby));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.joinBtn = new System.Windows.Forms.Button();
            this.createRoomBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(79, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connect 4 ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(575, 65);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 466);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(269, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 64);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(92, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(397, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Players";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(269, 65);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(304, 466);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // joinBtn
            // 
            this.joinBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(178)))), ((int)(((byte)(73)))));
            this.joinBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinBtn.ForeColor = System.Drawing.Color.White;
            this.joinBtn.Location = new System.Drawing.Point(57, 125);
            this.joinBtn.Margin = new System.Windows.Forms.Padding(2);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(145, 57);
            this.joinBtn.TabIndex = 4;
            this.joinBtn.Text = "Join";
            this.joinBtn.UseVisualStyleBackColor = false;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            this.joinBtn.MouseEnter += new System.EventHandler(this.joinBtn_MouseEnter);
            this.joinBtn.MouseLeave += new System.EventHandler(this.joinBtn_MouseLeave);
            // 
            // createRoomBtn
            // 
            this.createRoomBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(131)))), ((int)(((byte)(219)))));
            this.createRoomBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoomBtn.ForeColor = System.Drawing.Color.White;
            this.createRoomBtn.Location = new System.Drawing.Point(57, 236);
            this.createRoomBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createRoomBtn.Name = "createRoomBtn";
            this.createRoomBtn.Size = new System.Drawing.Size(145, 58);
            this.createRoomBtn.TabIndex = 5;
            this.createRoomBtn.Text = "Create Room";
            this.createRoomBtn.UseVisualStyleBackColor = false;
            this.createRoomBtn.Click += new System.EventHandler(this.createRoomBtn_Click);
            this.createRoomBtn.MouseEnter += new System.EventHandler(this.createRoomBtn_MouseEnter);
            this.createRoomBtn.MouseLeave += new System.EventHandler(this.createRoomBtn_MouseLeave);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.disconnectBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectBtn.ForeColor = System.Drawing.Color.White;
            this.disconnectBtn.Location = new System.Drawing.Point(57, 367);
            this.disconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(145, 53);
            this.disconnectBtn.TabIndex = 6;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = false;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            this.disconnectBtn.MouseEnter += new System.EventHandler(this.disconnectBtn_MouseEnter);
            this.disconnectBtn.MouseLeave += new System.EventHandler(this.disconnectBtn_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 531);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.createRoomBtn);
            this.Controls.Add(this.joinBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "lobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Lobby ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lobby_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lobby_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.Button createRoomBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}