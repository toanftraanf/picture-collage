namespace CollageApp
{
    partial class frmMain
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
            pbBefore = new PictureBox();
            btnBefore = new Button();
            btnAfter = new Button();
            pbAfter = new PictureBox();
            btnCollage = new Button();
            btnAlbum = new Button();
            ((System.ComponentModel.ISupportInitialize)pbBefore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAfter).BeginInit();
            SuspendLayout();
            // 
            // pbBefore
            // 
            pbBefore.Location = new Point(130, 48);
            pbBefore.Margin = new Padding(0);
            pbBefore.Name = "pbBefore";
            pbBefore.Size = new Size(411, 392);
            pbBefore.TabIndex = 0;
            pbBefore.TabStop = false;
            // 
            // btnBefore
            // 
            btnBefore.Location = new Point(289, 486);
            btnBefore.Name = "btnBefore";
            btnBefore.Size = new Size(94, 29);
            btnBefore.TabIndex = 2;
            btnBefore.Text = "Trước";
            btnBefore.UseVisualStyleBackColor = true;
            btnBefore.Click += btnBefore_Click;
            // 
            // btnAfter
            // 
            btnAfter.Location = new Point(768, 486);
            btnAfter.Name = "btnAfter";
            btnAfter.Size = new Size(94, 29);
            btnAfter.TabIndex = 3;
            btnAfter.Text = "Sau";
            btnAfter.UseVisualStyleBackColor = true;
            btnAfter.Click += btnAfter_Click;
            // 
            // pbAfter
            // 
            pbAfter.Location = new Point(541, 48);
            pbAfter.Margin = new Padding(0);
            pbAfter.Name = "pbAfter";
            pbAfter.Size = new Size(411, 392);
            pbAfter.TabIndex = 4;
            pbAfter.TabStop = false;
            // 
            // btnCollage
            // 
            btnCollage.Location = new Point(507, 577);
            btnCollage.Name = "btnCollage";
            btnCollage.Size = new Size(94, 29);
            btnCollage.TabIndex = 5;
            btnCollage.Text = "GHÉP";
            btnCollage.UseVisualStyleBackColor = true;
            btnCollage.Click += btnCollage_Click;
            // 
            // btnAlbum
            // 
            btnAlbum.Location = new Point(12, 616);
            btnAlbum.Name = "btnAlbum";
            btnAlbum.Size = new Size(124, 40);
            btnAlbum.TabIndex = 6;
            btnAlbum.Text = "Album ảnh";
            btnAlbum.UseVisualStyleBackColor = true;
            btnAlbum.Click += btnAlbum_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 668);
            Controls.Add(btnAlbum);
            Controls.Add(btnCollage);
            Controls.Add(pbAfter);
            Controls.Add(btnAfter);
            Controls.Add(btnBefore);
            Controls.Add(pbBefore);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GHÉP ẢNH";
            ((System.ComponentModel.ISupportInitialize)pbBefore).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAfter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbBefore;
        private Button btnBefore;
        private Button btnAfter;
        private PictureBox pbAfter;
        private Button btnCollage;
        private Button btnAlbum;
    }
}