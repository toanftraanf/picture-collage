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
            if (string.IsNullOrEmpty(imgPathBefore) || string.IsNullOrEmpty(imgPathAfter))
            {
                MessageBox.Show("Please select two images first.");
                return;
            }

            Image imageBefore = Image.FromFile(imgPathBefore);
            Image imageAfter = Image.FromFile(imgPathAfter);

            int maxWidth = Math.Max(imageBefore.Width, imageAfter.Width);
            int totalHeight = Math.Max(imageBefore.Height, imageAfter.Height);

            Bitmap collage = new Bitmap(maxWidth * 2, totalHeight);

            using (Graphics g = Graphics.FromImage(collage))
            {
                // Draw 'Before' image on the left
                g.DrawImage(imageBefore, new Rectangle(0, 0, imageBefore.Width, imageBefore.Height));

                // Draw 'After' image on the right
                g.DrawImage(imageAfter, new Rectangle(imageBefore.Width, 0, imageAfter.Width, imageAfter.Height));
            }

            // Allow user to choose where to save the collage
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                collage.Save(saveFileDialog.FileName);
                MessageBox.Show("Collage saved successfully!");
            }
        }
    }
}