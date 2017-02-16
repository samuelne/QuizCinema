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
        public int id_jogador_banco;
        public Pergunta4(int id_jogador)
        {
            InitializeComponent();
            id_jogador_banco = id_jogador;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {


            if (rbnAlternativa3.Checked == true)
            {

                string pathServer = "Server = DESKTOP-V7V5L0R\\SQLEXPRESS;";
                pathServer += "Database=db_QuizCinema;";
                pathServer += "Trusted_Connection=Yes;";

                int pontos = 10;
                string nivel = "Facil";

                string pathInsert = "INSERT INTO tb_perguntas ";
                pathInsert += "(pergunta, resposta_correta, nivel, pontos , id_jogador)";
                pathInsert += " VALUES ";
                pathInsert += " ( ";

                pathInsert += " '" + lblPergunta4.Text + "' ,";
                pathInsert += " '" + rbnAlternativa3.Text + "' ,";
                pathInsert += " '" + nivel + "' ,";
                pathInsert += " '" + pontos + "' ,";
                pathInsert += " '" + id_jogador_banco + "' ";

                pathInsert += " ) ";

                using (SqlConnection conexao = new SqlConnection(pathServer))
                {
                    using (SqlCommand cmd = new SqlCommand(pathInsert, conexao))
                    {
                        //ABRE A CONEXAO
                        conexao.Open();

                        //PASSA O COMANDO INSERT COMPLETO
                        cmd.CommandText = pathInsert;

                        //EXECUTA O INSERT
                        cmd.ExecuteNonQuery();


                        //Mensagem Salvo no banco
                        //MessageBox.Show("Salvo no banco");

                        //FECHA A CONEXAO
                        conexao.Close();



                        string select = "SELECT SUM (pontos) FROM tb_perguntas WHERE id_jogador = ";

                        SqlCommand read = new SqlCommand(select);
                        

                            SqlCommand ler = new SqlCommand(select, conexao);



                            select += id_jogador_banco;

                            MessageBox.Show(select);


                            //pontos = (int)ler.ExecuteScalar();

                            //MenuFinal final = new MenuFinal(id_jogador);

                            ////final.lblPontos.Text = txtNome.Text + " " + txtSobrenome.Text + " " + final.lblPontos.Text + ": " + pontos;

                            //if (pontos == 0)
                            //{
                            //    final.lblSaudar.Text = "Precisa Estudar";
                            //}

                            //if (pontos == 10)
                            //{
                            //    final.lblSaudar.Text = "Precisa Estudar";
                            //}

                            //if (pontos == 20)
                            //{
                            //    final.lblSaudar.Text = "Foi Bem";
                            //}

                            //if (pontos == 30)
                            //{
                            //    final.lblSaudar.Text = "Foi Bem";
                            //}

                            //if (pontos == 40)
                            //{
                            //    final.lblSaudar.Text = "Parabéns";

                            //}

                            

                        }


                    }
                    //MenuFinal final = new MenuFinal();
                    //final.lblPontos.Text = " " + final.lblPontos.Text;

                    //  final.Show();
                    this.Close();
                }

            this.Close();
        }
        }
    }
