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
    public partial class Pergunta4 : Form
    {
        public Pergunta4()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            
            MenuFinal final = new MenuFinal();

            string pathServer = "Server = AME0556341W10-1\\SQLEXPRESS;";
            pathServer += "Database=db_QuizCinema;";
            pathServer += "Trusted_Connection=Yes;";

            using (SqlConnection conexao = new SqlConnection(pathServer))
            {

                string sSQL = @"SELECT @@IDENTITY tb_jogador";

                SqlCommand cmd = new SqlCommand(sSQL, conexao);

                //cmd.Connection = conexao;

                //ABRE A CONEXAO
                conexao.Open();

                string nome;

                cmd.ExecuteReader();

                

                //SqlDataReader reader = cmd.ExecuteReader();

                //reader.Read();

                //final.lblPontos.Text = reader.GetValue(0) + " " + final.lblPontos.Text;
                
               
                


                //FECHA A CONEXAO
                conexao.Close();




            }

            final.lblPontos.Text = " " + final.lblPontos.Text;
            
            final.Show();
            this.Close();
        }
    }
}
