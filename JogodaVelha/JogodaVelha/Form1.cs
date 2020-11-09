using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogodaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatepontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];



        public Form1()
        {
            InitializeComponent();
        }



        private void clickdebotao(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final==false)
            {

                if (turno == true)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                    lbrod.Text = Convert.ToString(rodadas);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    lbrod.Text = Convert.ToString(rodadas);
                    turno = !turno;
                    Checagem(2);

                } // final da estrutura
            }
        } // final metodo botao

        void Vencedor(int PlayerVencedor)
        {
            jogo_final = true;

            if(PlayerVencedor == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou!!");
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou!!");
                turno = false;
            }
        }

        void Checagem(int checagemPlayer)
        {
            string suporte;

            if (checagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            } // final suporte

            for (int horizontal = 0; horizontal < 8; horizontal++)
            {

                if (suporte == texto[horizontal])
                {

                    if (horizontal != 7) { 

                        if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2] )
                        {
                            Vencedor(checagemPlayer);
                            return;
                        }
                    } else
                    {
                        if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 1])
                        {
                            Vencedor(checagemPlayer);
                            return;
                        }
                    }
                }

            }// final do looping horizontal

            for (int vertical = 0; vertical < 3; vertical++)
            {

                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(checagemPlayer);
                        return;
                    }
                }

            }// final do looping vertical

            if (texto[0] == suporte)
            {


                if (texto[0] == texto[4] && texto[0] == texto[8] && texto[4] == texto[8])
                {
                    Vencedor(checagemPlayer);
                    return;
                }
            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6] && texto[4] == texto[6])
                {
                    Vencedor(checagemPlayer);
                    return;
                }
            }

            if( rodadas == 9 && jogo_final == false)
            {
                empatepontos++;
                empate.Text = Convert.ToString(empatepontos);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }


        }
        private void btnlimpar_Click(object sender, EventArgs e)
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
            rodadas = 0;
            lbrod.Text = Convert.ToString(rodadas);
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void btnreseta_Click(object sender, EventArgs e)
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            Xpontos.Text = "0";
            Opontos.Text = "0";
            empate.Text = "0";
            rodadas = 0;
            lbrod.Text = Convert.ToString(rodadas);
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }
    }   
}

