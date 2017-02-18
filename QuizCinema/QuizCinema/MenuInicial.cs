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

            //VERIFICA SE O CAMPO FOI ADD NOME SENÃO EMITE ALERTA
            if (txtNome.Text == "Digite seu nome")
            {

                MessageBox.Show("Você deve informar seu nome", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtNome.Focus();
            }


            //VERIFICA SE O CAMPO FOI ADD SOBRENOME SENÃO EMITE ALERTA
            if (txtSobrenome.Text == "Digite seu sobrenome")
            {
                MessageBox.Show("Você deve informar seu sobrenome", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtSobrenome.Focus();
            }

            //VERIFICA SE O CAMPO FOI ADD EMAIL SENÃO EMITE ALERTA
            if (txtEmail.Text == "Digite seu email")
            {
                MessageBox.Show("Você deve informar seu email", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtEmail.Focus();
            }


            else
            {
                //PASSAGEM DE CAMINHO PARA CONEXAO COM O SERVIDOR
                string pathServer = "Server = DESKTOP-V7V5L0R\\SQLEXPRESS;";
                pathServer += "Database=db_QuizCinema;";
                pathServer += "Trusted_Connection=Yes;";

                //PASSAGEM DE CAMINHO PARA DAR COMANDO NO BANCO
                string pathInsert = "insert into tb_jogador(nome, sobrenome, email) OUTPUT INSERTED.ID_JOGADOR values(@NOME, @SOBRENOME, @EMAIL)";


                //CRIANDO A INSTANCIA DA CONEXAO COM O BANCO
                using (SqlConnection conexao = new SqlConnection(pathServer))
                {
                    //CRIANDO A INSTANCIA DE COMANDO COM O BANCO
                    SqlCommand cmd = new SqlCommand(pathInsert, conexao);

                    //PEGANDO OS VALORES DAS TXTBOX E GUARDANDO NO BANCO
                    cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                    cmd.Parameters.AddWithValue("SOBRENOME", txtSobrenome.Text);
                    cmd.Parameters.AddWithValue("EMAIL", txtEmail.Text);



                    //ABRE A CONEXAO
                    conexao.Open();

                    //PEGA A PRIMEIRA COLUNA DO BANCO E PASSA O VALOR PARA VARIAVEL ID_JOGADOR
                    int id_jogador;
                    id_jogador = (int)cmd.ExecuteScalar();


                    if (id_jogador > 0)
                    {

                        //INSTANCIA 
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

                        MenuFinal final = new MenuFinal(id_jogador);


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

                        int pontos = 0;
                        string select = "SELECT SUM (pontos) FROM tb_perguntas WHERE id_jogador = ";
                        select += id_jogador;

                        //CRIANDO A INSTANCIA DE COMANDO COM O BANCO
                        using (SqlCommand ler = new SqlCommand(select, conexao))
                            {                            
                            
                            
                                object result = ler.ExecuteScalar();

                            if(result.GetType() != typeof(DBNull))
                            {
                                pontos = (int) result;
                                final.lblPontos.Text = txtNome.Text + " " + txtSobrenome.Text + " " + final.lblPontos.Text + " " + pontos.ToString ();
                            }

                            if (result.GetType() == typeof(DBNull))
                            {
                                final.lblPontos.Text = txtNome.Text + " " + txtSobrenome.Text + " " + final.lblPontos.Text + " " + pontos.ToString();
                            }

                        }


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


        private void txtNome_Leave(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                txtNome.Text = "Digite seu nome";
            }
            

        }


        private void txtSobrenome_Enter(object sender, EventArgs e)
        {
            txtSobrenome.Text = "";
        }


        private void txtSobrenome_Leave(object sender, EventArgs e)
        {
            if (txtSobrenome.Text == "")
            {
                txtSobrenome.Text = "Digite seu sobrenome";
            }
        }


        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Digite seu email";
            }
        }
    }
}
