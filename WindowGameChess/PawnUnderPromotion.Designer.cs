namespace WindowGameChess
{
    partial class PawnUnderPromotion
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
            this.BoxType = new System.Windows.Forms.ComboBox();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoxType
            // 
            this.BoxType.FormattingEnabled = true;
            this.BoxType.Items.AddRange(new object[] {
            "Rook",
            "Knight",
            "Bishop",
            "Queen"});
            this.BoxType.Location = new System.Drawing.Point(73, 12);
            this.BoxType.Name = "BoxType";
            this.BoxType.Size = new System.Drawing.Size(121, 21);
            this.BoxType.TabIndex = 0;
            this.BoxType.Text = "Choose One Type";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(94, 48);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 1;
            this.button.Text = "OK";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // PawnUnderPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 94);
            this.Controls.Add(this.button);
            this.Controls.Add(this.BoxType);
            this.Name = "PawnUnderPromotion";
            this.Text = "PawnUnderPromotion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox BoxType;
        private System.Windows.Forms.Button button;
    }
}