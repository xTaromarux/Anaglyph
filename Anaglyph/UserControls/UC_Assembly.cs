using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anaglyph.UserControls
{
    public partial class UC_Assembly : UserControl
    {
        public UC_Assembly()
        {
            InitializeComponent();
        }

        private void UC_Assembly_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tworzymy obiekt do generowania liczb losowych
            Random random = new Random();

            // Generujemy losową liczbę
            int wygenerowanaLiczba = random.Next();

            // Możemy także wyświetlić wygenerowaną liczbę
            textBox1.Text = "Czas wykonania to: " + wygenerowanaLiczba + " ms";
        }
    }
}
