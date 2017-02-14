using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuizCinema
{
    public partial class Pergunta1 : Form
    {
        public Pergunta1()
        {
            InitializeComponent();
        }

        private void btnPerg1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection("Server = AME0556341W10-1\\SQLEXPRESS;Database=db_QuizCinema;Trusted_Connection=Yes"))
            {
                using (SqlCommand cmd = new SqlCommand("insert into tb_pergunta(id_jogador) OUTPUT INSERTED.ID values(@ID_JOGADOR)", conexao))
                {
                    

                }

            }
                        
            Pergunta2 perg2 = new Pergunta2();
            perg2.Show();
            this.Close();
        }
    }
}
