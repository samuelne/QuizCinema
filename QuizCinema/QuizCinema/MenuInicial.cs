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

                               

                string pathServer = "Server = DESKTOP-V7V5L0R\\SQLEXPRESS;";
                    pathServer +=   "Database=db_QuizCinema;";
                    pathServer +=   "Trusted_Connection=Yes;";

                string pathInsert = "insert into tb_jogador(nome, sobrenome, email) OUTPUT INSERTED.ID_JOGADOR values(@NOME, @SOBRENOME, @EMAIL)";

                using (SqlConnection conexao = new SqlConnection(pathServer))
                {
                     SqlCommand cmd = new SqlCommand(pathInsert, conexao);
                    

                        cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                        cmd.Parameters.AddWithValue("SOBRENOME", txtSobrenome.Text);
                        cmd.Parameters.AddWithValue("EMAIL", txtEmail.Text);



                        //ABRE A CONEXAO
                        conexao.Open();

                        int id_jogador;
                        id_jogador = (int)cmd.ExecuteScalar();


                    //Mensagem Salvo no banco
                    //MessageBox.Show("Salvo no banco");



                    if (id_jogador > 0)
                        {

                        TelaBoasVindas boasVindas = new TelaBoasVindas();
                        boasVindas.lblBemVindo.Text = boasVindas.lblBemVindo.Text + " " + txtNome.Text + " " + txtSobrenome.Text;

                        Pergunta1 p1 = new Pergunta1(id_jogador);
                        p1.lblNome.Text = txtNome.Text + " " + txtSobrenome.Text;

                        Pergunta2 p2 = new Pergunta2(id_jogador);
                        p2.lblNome.Text = txtNome.Text + " " + txtSobrenome.Text;

                        Pergunta3 p3 = new Pergunta3(id_jogador);
                        p3.lblNome.Text = txtNome.Text + " " + txtSobrenome.Text;

                        Pergunta4 p4 = new Pergunta4(id_jogador);
                        p4.lblNome.Text = txtNome.Text + " " + txtSobrenome.Text;


                        string select = "SELECT SUM (pontos) FROM tb_perguntas WHERE id_jogador = 37";


                        SqlCommand ler = new SqlCommand(select, conexao);
                        

                        int pontos;

                        pontos = (int)ler.ExecuteScalar();

                        MenuFinal final = new MenuFinal(id_jogador, pontos);                             


                        final.lblPontos.Text = txtNome.Text + " " + txtSobrenome.Text + " " + final.lblPontos.Text + ": " + pontos;

                        if (pontos == 0)
                        {
                            final.lblSaudar.Text = "Precisa Estudar";
                        }

                        if (pontos == 10)
                        {
                            final.lblSaudar.Text = "Precisa Estudar";
                        }

                        if (pontos == 20)
                        {
                            final.lblSaudar.Text = "Foi Bem";
                        }

                        if (pontos == 30)
                        {
                            final.lblSaudar.Text = "Foi Bem";
                        }

                        if (pontos == 40)
                        {
                            final.lblSaudar.Text = "Parabéns";

                        }


                        this.Hide();

                        boasVindas.ShowDialog();               

                        //Pergunta1 p1 = new Pergunta1(id_jogador);
                        p1.ShowDialog();
                        
                        //Pergunta2 p2 = new Pergunta2(id_jogador);
                        p2.ShowDialog();

                        //Pergunta3 p3 = new Pergunta3(id_jogador);
                        p3.ShowDialog();

                        //Pergunta4 p4 = new Pergunta4(id_jogador);
                        p4.ShowDialog();
                        
                        //MenuFinal final= new MenuFinal(id_jogador, pontos);
                        final.ShowDialog();                                                              
                        }

                        else
                        {
                            MessageBox.Show("DEU RUIMMMM!!!! Algo aconteceu durante o insert");
                        }


                    

                }

            }
                        

        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.Text = "";
        }


        private void txtSobrenome_Enter(object sender, EventArgs e)
        {
            txtSobrenome.Text = "";
        }


        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

    }
}
