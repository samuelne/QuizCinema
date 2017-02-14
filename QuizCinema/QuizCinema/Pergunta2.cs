using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCinema
{
    public partial class Pergunta2 : Form
    {
        public Pergunta2()
        {
            InitializeComponent();
        }

        private void btnPerg2_Click(object sender, EventArgs e)
        {
            Pergunta3 perg3 = new Pergunta3();
            perg3.Show();
            this.Close();
        }
    }
}
