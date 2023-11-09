using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditCaptureForm : Form
    {
        public string CaptionText { get; private set; }
        public Font CaptionFont { get; private set; }
        public Color CaptionColor { get; private set; }
        public Point CaptionLocation { get; private set; }

        private TextBox captionTextBox = new TextBox();
        private Button fontButton = new Button();
        private Button colorButton = new Button();
        private Button okButton = new Button();
        private Button cancelButton = new Button();

        public EditCaptureForm(string text, Font font, Color color, Point location)
        {
            InitializeComponent();
            CaptionText = text;
            CaptionFont = font;
            CaptionColor = color;
            CaptionLocation = location;

            this.Text = "Edit signature";
            this.Size = new Size(350, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            Label textLabel = new Label();
            textLabel.Text = "Text"; ;
            textLabel.Location = new Point(10, 10);
            this.Controls.Add(textLabel);

            captionTextBox.Text = text;
            captionTextBox.Location = new Point(110, 10);
            captionTextBox.Size = new Size(160,20);
            this.Controls.Add(captionTextBox);

            fontButton.Text = "Choose font";
            fontButton.Location = new Point(110, 40);
            fontButton.Click += FontButton_Click;
            this.Controls.Add(fontButton);

            Label colorLabel = new Label();
            colorLabel.Text = "Color";
            colorLabel.Location = new Point(10, 70);
            this.Controls.Add(colorLabel);

            okButton.Text = "Ok";
            okButton.Location = new Point(60, 100);
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(140,100);
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            colorButton.Location = new Point(110,70);
            colorButton.Size = new Size(40,20);
            colorButton.BackColor = color;
            colorButton.Click += ColorButton_Click;
            this.Controls.Add(colorButton);
        }

        private void ColorButton_Click(object? sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = CaptionColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CaptionColor = colorDialog.Color;
                colorButton.BackColor = CaptionColor;
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            CaptionText = captionTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void FontButton_Click(object? sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                CaptionFont = fontDialog.Font;
            }
        }
    }
}
