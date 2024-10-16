using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private Image originalImage; // Переменная для хранения оригинального изображения
        private float zoomFactor = 1.0f; // Коэффициент масштабирования

        public Form1()
        {
            InitializeComponent();
        }
        private void chooseImageButton_Click(object sender, EventArgs e)// Метод для выбора изображения
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем изображение
                    originalImage = Image.FromFile(openFileDialog.FileName);
                    pictureBox.Image = originalImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Устанавливаем режим отображения изображения
                    zoomFactor = 1.0f; // Сбрасываем коэффициент масштабирования
                    pictureBox.Refresh();
                }
            }
        }
        private void zoomTrackBar_Scroll(object sender, EventArgs e) // Метод для масштабирования изображения
        {
            if (originalImage != null)
            {
                zoomFactor = zoomTrackBar.Value / 10.0f;// Получаем значение масштаба с ползунка TrackBar (значение от 1 до 200%)

                pictureBox.Width = (int)(originalImage.Width * zoomFactor); // Обновляем размеры PictureBox относительно коэффициента масштабирования
                pictureBox.Height = (int)(originalImage.Height * zoomFactor);

                pictureBox.Left = (this.ClientSize.Width - pictureBox.Width) / 2;// Центрируем PictureBox
                pictureBox.Top = (this.ClientSize.Height - pictureBox.Height - 60) / 2; // -60 для учета кнопок
            }
        }
    }
}
