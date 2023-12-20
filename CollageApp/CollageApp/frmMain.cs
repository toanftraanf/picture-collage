using System.Windows.Forms;

namespace CollageApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string imgPathBefore;
        private string imgPathAfter;
        private Point? beforeImageLocation = null;
        private Point? afterImageLocation = null;

        private void btnBefore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPathBefore = ofd.FileName;
                Image imgBefore = Image.FromFile(ofd.FileName);
                UpdatePictureBoxSize(pbBefore, imgBefore);
            }
        }

        // Update the PictureBox size according to the loaded image
        private void UpdatePictureBoxSize(PictureBox pictureBox, Image image)
        {
            if (image.Width > pictureBox.Width || image.Height > pictureBox.Height)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
            pictureBox.Image = image;
        }

        private void btnAfter_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPathAfter = ofd.FileName;
                Image imgAfter = Image.FromFile(ofd.FileName);
                UpdatePictureBoxSize(pbAfter, imgAfter);
            }
        }

        private void btnCollage_Click(object sender, EventArgs e)

        {
            // Set the default directory for saving images
            string defaultSaveDirectory = @"D:/AnhSoSanh";

            // Checking if the default directory exists, if not, create it
            if (!Directory.Exists(defaultSaveDirectory))
            {
                Directory.CreateDirectory(defaultSaveDirectory);
            }

            if (string.IsNullOrEmpty(imgPathBefore) || string.IsNullOrEmpty(imgPathAfter))
            {
                MessageBox.Show("Vui lòng chọn ảnh.");
                return;
            }

            Image imageBefore = Image.FromFile(imgPathBefore);
            Image imageAfter = Image.FromFile(imgPathAfter);

            int maxWidth = imageBefore.Width + imageAfter.Width;
            int totalHeight = Math.Max(imageBefore.Height, imageAfter.Height);

            Bitmap collage = new Bitmap(maxWidth, totalHeight);

            using (Graphics g = Graphics.FromImage(collage))
            {
                // Fill with white background
                g.FillRectangle(Brushes.White, 0, 0, collage.Width, collage.Height);

                // Draw 'Before' image
                g.DrawImage(imageBefore, new Rectangle(0, 0, imageBefore.Width, imageBefore.Height));

                // Draw 'After' image
                g.DrawImage(imageAfter, new Rectangle(imageBefore.Width, 0, imageAfter.Width, imageAfter.Height));

                // Add 'Before' and 'After' text to the images
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                {

                    // 'Before' text on imageBefore
                    Rectangle rectBefore = new Rectangle(0, imageBefore.Height - 40, imageBefore.Width, 40);
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(brush, rectBefore);
                    }
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        g.DrawString("TRƯỚC", font, brush, rectBefore, sf);
                    }

                    // 'After' text on imageAfter
                    Rectangle rectAfter = new Rectangle(imageBefore.Width, imageAfter.Height - 40, imageAfter.Width, 40);
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(brush, rectAfter);
                    }
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        g.DrawString("SAU", font, brush, rectAfter, sf);
                    }
                }
            }

            // Get the current date and time to use as part of the file name
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            // Define the default file path and name
            string defaultFilePath = Path.Combine(defaultSaveDirectory, $"Collage_{currentDateTime}.jpg");
            // Saving the collage directly to the default file path
            collage.Save(defaultFilePath);
            MessageBox.Show("Collage saved successfully!");
            // Open the saved image using the default image viewer
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(defaultFilePath) { UseShellExecute = true });
        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
            // Set the default directory for saving images
            string defaultSaveDirectory = @"D:/AnhSoSanh";

            // Open the default picture folder using the default image viewer
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(defaultSaveDirectory) { UseShellExecute = true });
        }
    }
}