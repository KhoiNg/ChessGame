namespace WindowGameChess
{
    partial class FormChess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
            this.panelOther = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarDown2 = new System.Windows.Forms.ProgressBar();
            this.progressBarDown1 = new System.Windows.Forms.ProgressBar();
            this.textBoxTurn = new System.Windows.Forms.TextBox();
            this.panelPosition = new System.Windows.Forms.Panel();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.pictureTheme = new System.Windows.Forms.PictureBox();
            this.PictureChess = new System.Windows.Forms.PictureBox();
            this.panelOther.SuspendLayout();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureChess)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.label3);
            this.panelOther.Controls.Add(this.label2);
            this.panelOther.Controls.Add(this.label1);
            this.panelOther.Controls.Add(this.progressBarDown2);
            this.panelOther.Controls.Add(this.progressBarDown1);
            this.panelOther.Controls.Add(this.textBoxTurn);
            this.panelOther.Location = new System.Drawing.Point(510, 31);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(237, 160);
            this.panelOther.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Turn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player 2 Time Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player 1 Time Left";
            // 
            // progressBarDown2
            // 
            this.progressBarDown2.Location = new System.Drawing.Point(17, 124);
            this.progressBarDown2.Name = "progressBarDown2";
            this.progressBarDown2.Size = new System.Drawing.Size(115, 23);
            this.progressBarDown2.TabIndex = 2;
            // 
            // progressBarDown1
            // 
            this.progressBarDown1.Location = new System.Drawing.Point(17, 73);
            this.progressBarDown1.Name = "progressBarDown1";
            this.progressBarDown1.Size = new System.Drawing.Size(115, 20);
            this.progressBarDown1.TabIndex = 1;
            // 
            // textBoxTurn
            // 
            this.textBoxTurn.Location = new System.Drawing.Point(16, 28);
            this.textBoxTurn.Name = "textBoxTurn";
            this.textBoxTurn.ReadOnly = true;
            this.textBoxTurn.Size = new System.Drawing.Size(116, 20);
            this.textBoxTurn.TabIndex = 0;
            // 
            // panelPosition
            // 
            this.panelPosition.Location = new System.Drawing.Point(510, 197);
            this.panelPosition.Name = "panelPosition";
            this.panelPosition.Size = new System.Drawing.Size(237, 170);
            this.panelPosition.TabIndex = 2;
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureTheme);
            this.panelPicture.Location = new System.Drawing.Point(510, 373);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(236, 117);
            this.panelPicture.TabIndex = 3;
            // 
            // pictureTheme
            // 
            this.pictureTheme.BackgroundImage = global::WindowGameChess.Properties.Resources.Chess_Theme;
            this.pictureTheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureTheme.Location = new System.Drawing.Point(4, 3);
            this.pictureTheme.Name = "pictureTheme";
            this.pictureTheme.Size = new System.Drawing.Size(229, 111);
            this.pictureTheme.TabIndex = 0;
            this.pictureTheme.TabStop = false;
            // 
            // PictureChess
            // 
            this.PictureChess.Location = new System.Drawing.Point(12, 31);
            this.PictureChess.Name = "PictureChess";
            this.PictureChess.Size = new System.Drawing.Size(492, 456);
            this.PictureChess.TabIndex = 4;
            this.PictureChess.TabStop = false;
            // 
            // FormChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.PictureChess);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panelPosition);
            this.Controls.Add(this.panelOther);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChess";
            this.Text = "Chess Game";
            this.panelOther.ResumeLayout(false);
            this.panelOther.PerformLayout();
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureChess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelOther;
        private System.Windows.Forms.Panel panelPosition;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.ProgressBar progressBarDown2;
        private System.Windows.Forms.ProgressBar progressBarDown1;
        private System.Windows.Forms.TextBox textBoxTurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureTheme;
        private System.Windows.Forms.PictureBox PictureChess;
    }
}

