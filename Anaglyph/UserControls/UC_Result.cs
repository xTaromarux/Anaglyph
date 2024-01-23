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
using CSharp_Anaglyph;

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
            CSharp_Anaglyph.Alghorytm CSharp_Anaglyph_Dll = new CSharp_Anaglyph.Alghorytm();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string parentDirectory = CSharp_Anaglyph_Dll.GoUpDirectories(currentDirectory, 3);
            string imagePath = parentDirectory + "\\Resources\\Result.jpg"; 

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

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        public void Close()
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
