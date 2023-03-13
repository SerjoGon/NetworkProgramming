namespace NP_less2_server
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_updateClientsList = new System.Windows.Forms.Button();
            this.tmr_refreshconnection = new System.Windows.Forms.Timer(this.components);
            this.rtb_clients = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(93, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_updateClientsList);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 3;
            // 
            // btn_updateClientsList
            // 
            this.btn_updateClientsList.Location = new System.Drawing.Point(12, 74);
            this.btn_updateClientsList.Name = "btn_updateClientsList";
            this.btn_updateClientsList.Size = new System.Drawing.Size(156, 23);
            this.btn_updateClientsList.TabIndex = 2;
            this.btn_updateClientsList.Text = "update clients";
            this.btn_updateClientsList.UseVisualStyleBackColor = true;
            this.btn_updateClientsList.Click += new System.EventHandler(this.btn_updateClientsList_Click);
            // 
            // tmr_refreshconnection
            // 
            this.tmr_refreshconnection.Interval = 3000;
            this.tmr_refreshconnection.Tick += new System.EventHandler(this.tmr_refreshConnection_Tick);
            // 
            // rtb_clients
            // 
            this.rtb_clients.Location = new System.Drawing.Point(0, 103);
            this.rtb_clients.Name = "rtb_clients";
            this.rtb_clients.Size = new System.Drawing.Size(800, 348);
            this.rtb_clients.TabIndex = 4;
            this.rtb_clients.Text = "";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_clients);
            this.Controls.Add(this.panel1);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_start;
        private Button btn_stop;
        private Panel panel1;
        private System.Windows.Forms.Timer tmr_refreshconnection;
        private Button btn_updateClientsList;
        private RichTextBox rtb_clients;
    }
}