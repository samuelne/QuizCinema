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

            if (txtNome.Text == "Digite seu nome")
            {

                MessageBox.Show("Você deve informar seu nome", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtNome.Focus();
            }

            if (txtSobrenome.Text == "Digite seu sobrenome")
            {
                MessageBox.Show("Você deve informar seu sobrenome", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtSobrenome.Focus();
            }

            if (txtEmail.Text == "Digite seu email")
            {
                MessageBox.Show("Você deve informar seu email", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtEmail.Focus();
            }
            else
            {

                TelaBoasVindas boasVindas = new TelaBoasVindas();
                boasVindas.lblBemVindo.Text = boasVindas.lblBemVindo.Text + " " + txtNome.Text;


                string pathServer = "Server = AME0556341W10-1\\SQLEXPRESS;";
                    pathServer +=   "Database=db_QuizCinema;";
                    pathServer +=   "Trusted_Connection=Yes;";

                using (SqlConnection conexao = new SqlConnection(pathServer))
                {
                     SqlCommand cmd = new SqlCommand();
                    

                        cmd.Connection = conexao;



                        //CRIA A VARIAVEL DE INSERCAO
                        string insert = "INSERT INTO tb_jogador";
                        insert += "(nome, sobrenome, email)";
                        insert += " VALUES ";
                        insert += " ( ";

                        insert += " '" + txtNome.Text + "' ,";
                        insert += " '" + txtSobrenome.Text + "' ,";
                        insert += " '" + txtEmail.Text + "' ";  

                        insert += " ) ";

                        //ABRE A CONEXAO
                        conexao.Open();

                        //PASSA O COMANDO INSERT COMPLETO
                        cmd.CommandText = insert;

                        //EXECUTA O INSERT
                        cmd.ExecuteNonQuery();

                        //EXECUTA O INSERT
                        int id_jogador = 1;
                        //id_jogador = (int) cmd.ExecuteScalar();

                        //Mensagem Salvo no banco
                        MessageBox.Show("Salvo no banco");
                                           
                        //FECHA A CONEXAO
                        //conexao.Close();

                        //id_jogador = (int) cmd.ExecuteScalar();

                    if (id_jogador > 0)
                        {
                            boasVindas.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("DEU RUIMMMM!!!! Algo aconteceu durante o insert");
                        }


                    

                }

            }
                        

        }
    }
}
