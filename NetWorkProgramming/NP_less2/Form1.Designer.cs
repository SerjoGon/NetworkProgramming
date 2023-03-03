namespace NP_less2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_connection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.btn_sendmsg = new System.Windows.Forms.Button();
            this.btn_closeconnection = new System.Windows.Forms.Button();
            this.btn_choos = new System.Windows.Forms.Button();
            this.rtb_chat = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connection
            // 
            this.btn_connection.Location = new System.Drawing.Point(3, 4);
            this.btn_connection.Name = "btn_connection";
            this.btn_connection.Size = new System.Drawing.Size(170, 31);
            this.btn_connection.TabIndex = 0;
            this.btn_connection.Text = "connection";
            this.btn_connection.UseVisualStyleBackColor = true;
            this.btn_connection.Click += new System.EventHandler(this.btn_connection_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_message);
            this.panel1.Controls.Add(this.btn_sendmsg);
            this.panel1.Controls.Add(this.btn_closeconnection);
            this.panel1.Controls.Add(this.btn_choos);
            this.panel1.Controls.Add(this.btn_connection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // tb_message
            // 
            this.tb_message.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_message.Location = new System.Drawing.Point(0, 77);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(800, 23);
            this.tb_message.TabIndex = 4;
            // 
            // btn_sendmsg
            // 
            this.btn_sendmsg.Location = new System.Drawing.Point(179, 4);
            this.btn_sendmsg.Name = "btn_sendmsg";
            this.btn_sendmsg.Size = new System.Drawing.Size(158, 31);
            this.btn_sendmsg.TabIndex = 3;
            this.btn_sendmsg.Text = "Отправить сообщение";
            this.btn_sendmsg.UseVisualStyleBackColor = true;
            this.btn_sendmsg.Click += new System.EventHandler(this.btn_sendmsg_Click);
            // 
            // btn_closeconnection
            // 
            this.btn_closeconnection.Location = new System.Drawing.Point(549, 3);
            this.btn_closeconnection.Name = "btn_closeconnection";
            this.btn_closeconnection.Size = new System.Drawing.Size(248, 31);
            this.btn_closeconnection.TabIndex = 2;
            this.btn_closeconnection.Text = "Close connection";
            this.btn_closeconnection.UseVisualStyleBackColor = true;
            this.btn_closeconnection.Click += new System.EventHandler(this.btn_closeconnection_Click);
            // 
            // btn_choos
            // 
            this.btn_choos.Location = new System.Drawing.Point(343, 3);
            this.btn_choos.Name = "btn_choos";
            this.btn_choos.Size = new System.Drawing.Size(191, 31);
            this.btn_choos.TabIndex = 1;
            this.btn_choos.Text = "Выбор собеседника";
            this.btn_choos.UseVisualStyleBackColor = true;
            this.btn_choos.Click += new System.EventHandler(this.btn_choos_Click);
            // 
            // rtb_chat
            // 
            this.rtb_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_chat.Location = new System.Drawing.Point(0, 100);
            this.rtb_chat.Name = "rtb_chat";
            this.rtb_chat.Size = new System.Drawing.Size(800, 350);
            this.rtb_chat.TabIndex = 2;
            this.rtb_chat.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_chat);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_connection;
        private Panel panel1;
        private TextBox tb_message;
        private Button btn_sendmsg;
        private Button btn_closeconnection;
        private Button btn_choos;
        private RichTextBox rtb_chat;
    }
}