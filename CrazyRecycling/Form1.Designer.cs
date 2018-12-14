using System.Windows.Forms;

namespace CrazyRecycling
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.YourMessageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChatRoomLabel = new System.Windows.Forms.Label();
            this.PlayerMessageLabel = new System.Windows.Forms.Label();
            this.JoinChatButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AchievmentsLabel = new System.Windows.Forms.Label();
            this.NotificationsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CrazyRecycling.Properties.Resources.Player;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // YourMessageTextBox
            // 
            this.YourMessageTextBox.Enabled = false;
            this.YourMessageTextBox.Location = new System.Drawing.Point(967, 321);
            this.YourMessageTextBox.Name = "YourMessageTextBox";
            this.YourMessageTextBox.Size = new System.Drawing.Size(120, 20);
            this.YourMessageTextBox.TabIndex = 2;
            this.YourMessageTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(967, 347);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(119, 23);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 9;
            // 
            // ChatRoomLabel
            // 
            this.ChatRoomLabel.AutoSize = true;
            this.ChatRoomLabel.Location = new System.Drawing.Point(901, 96);
            this.ChatRoomLabel.Name = "ChatRoomLabel";
            this.ChatRoomLabel.Size = new System.Drawing.Size(60, 13);
            this.ChatRoomLabel.TabIndex = 5;
            this.ChatRoomLabel.Text = "ChatRoom:";
            this.ChatRoomLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // PlayerMessageLabel
            // 
            this.PlayerMessageLabel.AutoSize = true;
            this.PlayerMessageLabel.Location = new System.Drawing.Point(883, 324);
            this.PlayerMessageLabel.Name = "PlayerMessageLabel";
            this.PlayerMessageLabel.Size = new System.Drawing.Size(78, 13);
            this.PlayerMessageLabel.TabIndex = 7;
            this.PlayerMessageLabel.Text = "Your Message:";
            // 
            // JoinChatButton
            // 
            this.JoinChatButton.Enabled = false;
            this.JoinChatButton.Location = new System.Drawing.Point(967, 376);
            this.JoinChatButton.Name = "JoinChatButton";
            this.JoinChatButton.Size = new System.Drawing.Size(183, 54);
            this.JoinChatButton.TabIndex = 8;
            this.JoinChatButton.Text = "Join chat!";
            this.JoinChatButton.UseVisualStyleBackColor = true;
            this.JoinChatButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.AcceptsReturn = true;
            this.ChatTextBox.Enabled = false;
            this.ChatTextBox.Location = new System.Drawing.Point(967, 96);
            this.ChatTextBox.Multiline = true;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.ReadOnly = true;
            this.ChatTextBox.Size = new System.Drawing.Size(250, 219);
            this.ChatTextBox.TabIndex = 4;
            this.ChatTextBox.Text = "zigmas: sveiki \r\namibijus: labas\r\n";
            this.ChatTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 578);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Player info";
            // 
            // AchievmentsLabel
            // 
            this.AchievmentsLabel.AutoSize = true;
            this.AchievmentsLabel.Location = new System.Drawing.Point(964, 462);
            this.AchievmentsLabel.Name = "AchievmentsLabel";
            this.AchievmentsLabel.Size = new System.Drawing.Size(104, 13);
            this.AchievmentsLabel.TabIndex = 11;
            this.AchievmentsLabel.Text = "default Achievement";
            this.AchievmentsLabel.Click += new System.EventHandler(this.AchievmentsLabel_Click);
            // 
            // NotificationsLabel
            // 
            this.NotificationsLabel.AutoSize = true;
            this.NotificationsLabel.Location = new System.Drawing.Point(964, 497);
            this.NotificationsLabel.Name = "NotificationsLabel";
            this.NotificationsLabel.Size = new System.Drawing.Size(95, 13);
            this.NotificationsLabel.TabIndex = 12;
            this.NotificationsLabel.Text = "default Notification";
            this.NotificationsLabel.Click += new System.EventHandler(this.NotificationsLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 600);
            this.Controls.Add(this.NotificationsLabel);
            this.Controls.Add(this.AchievmentsLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JoinChatButton);
            this.Controls.Add(this.PlayerMessageLabel);
            this.Controls.Add(this.ChatRoomLabel);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.YourMessageTextBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Crazy Recycling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MaskedTextBox YourMessageTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ChatRoomLabel;
        private System.Windows.Forms.Label PlayerMessageLabel;
        private Button JoinChatButton;
        private TextBox ChatTextBox;
        private Label label4;
        private Label AchievmentsLabel;
        private Label NotificationsLabel;
    }
}

