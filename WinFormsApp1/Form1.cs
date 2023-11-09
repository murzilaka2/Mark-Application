using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Image loadedImage;
        private string captionText = "Your text";
        private Font captionFont = new Font("Arial", 18);
        private Color captionColor = Color.Red;
        private Point captionLocation = new Point(10, 10);
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();

            Button editButton = new Button();
            editButton.Text = "Edit Signature";
            editButton.Dock = DockStyle.Bottom;
            editButton.Location = new Point(10,50);
            editButton.Click += EditButton_Click;
            this.Controls.Add(editButton);

            Button loadButton = new Button();
            loadButton.Text = "Load Image";
            loadButton.Dock = DockStyle.Bottom;
            loadButton.Location = new Point(10, 10);
            loadButton.Click += LoadButton_Click;
            this.Controls.Add(loadButton);

            pictureBox = new PictureBox();
            pictureBox.BackColor = Color.AliceBlue;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Paint += PictureBox_Paint;
            this.Controls.Add(pictureBox);
        }

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (loadedImage != null)
            {
                e.Graphics.DrawImage(loadedImage, 5, 5);
                e.Graphics.DrawString(captionText, captionFont, new SolidBrush(captionColor), captionLocation);
            }
        }

        private void LoadButton_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openfl = new OpenFileDialog();
            openfl.Filter = "Images (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (openfl.ShowDialog() == DialogResult.OK)
            {
                loadedImage = Image.FromFile(openfl.FileName);
                this.ClientSize = new Size(loadedImage.Width + 50, loadedImage.Height + 50);
                this.Refresh();
            }
        }

        private void EditButton_Click(object? sender, EventArgs e)
        {
            using (EditCaptureForm form = new EditCaptureForm(captionText, captionFont, captionColor, captionLocation))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    captionText = form.CaptionText;
                    captionFont = form.CaptionFont; 
                    captionColor = form.CaptionColor;
                    captionLocation = form.CaptionLocation;
                    this.Refresh();
                }
            }
        }
    }
}