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
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection("Server = AME0556341W10-1\\SQLEXPRESS;Database=db_QuizCinema;Trusted_Connection=Yes"))
            {
                using (SqlCommand cmd = new SqlCommand("insert into tb_pergunta(id_jogador) OUTPUT INSERTED.ID values(@ID_JOGADOR)", conexao))
                {


                }

            }

            TelaBoasVindas boasVindas = new TelaBoasVindas();
            boasVindas.Show();
            this.Hide();
        }
    }
}
