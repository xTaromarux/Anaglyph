using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Anaglyph.UserControls
{
    public partial class UC_Result : UserControl
    {
        public UC_Result()
        {
            InitializeComponent();
            LoadImageIfExist();
        }

        private void LoadImageIfExist()
        {
            string imagePath = @"C:\Users\igor\source\repos\Anaglyph\Anaglyph\Resources\ResultImage.jpg"; 

            if (File.Exists(imagePath))
            {
                try
                {
                    Image image = Image.FromFile(imagePath);
                    pictureBox.Image = image;
                    pictureBox.BorderStyle = BorderStyle.None;   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas wczytywania obrazu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Plik obrazu nie istnieje w podanej ścieżce.");
            }
        }
    }
}
