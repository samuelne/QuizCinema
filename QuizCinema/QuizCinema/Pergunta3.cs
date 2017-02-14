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
    public partial class Pergunta3 : Form
    {
        public Pergunta3()
        {
            InitializeComponent();
        }

        private void btnPerg3_Click(object sender, EventArgs e)
        {
            Pergunta4 perg4 = new Pergunta4();
            perg4.Show();
        }
    }
}
