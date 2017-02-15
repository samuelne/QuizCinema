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
    public partial class TelaBoasVindas : Form
    {
        public TelaBoasVindas()
        {
            InitializeComponent();

        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            Pergunta1 perg1 = new Pergunta1();
            perg1.Show();
            this.Close();
        }
    }
}
