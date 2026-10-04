using System.Drawing;

namespace Primo_Progetto26_27
{
    public partial class Form1 : Form
    {
        char[,] griglia;

        public Form1()
        {
            InitializeComponent();

            // Collego i 36 pulsanti al metodo BottoneCliccato.
            // Il for prende button1, button2, ... button36 e a ognuno dice:
            // "quando ti premono, esegui BottoneCliccato".
            for (int n = 1; n <= 36; n++)
            {
                Button b = (Button)Controls.Find("button" + n, true)[0];   // cerco il pulsante per nome
                b.Click += BottoneCliccato;                                // collego il click
            }
        }

        static char[,] RiempiCaselle()
        {
            char[,] m = new char[6, 6];
            Random rnd = new Random();

            int[] Lnavi = { 3, 3, 2, 2, 1 };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    m[i, j] = '~';
                }
            }

            for (int k = 0; k < Lnavi.Length; k++)
            {
                int lunghezza = Lnavi[k];

                bool occupata = false;
                while (occupata == false)
                {
                    int riga = rnd.Next(6);
                    int col = rnd.Next(6 - lunghezza + 1);

                    bool libero = true;
                    for (int i = 0; i < lunghezza; i++)
                    {
                        if (m[riga, col + i] != '~')
                        {
                            libero = false;
                        }
                    }

                    if (libero)
                    {
                        for (int i = 0; i < lunghezza; i++)
                        {
                            m[riga, col + i] = Convert.ToChar(lunghezza + '0');
                        }
                        occupata = true;
                    }
                }
            }
            return m;
        }        
        private void BottoneCliccato(object sender, EventArgs e)
        {
            // Se non hai ancora premuto AVVIA la matrice non esiste: non faccio niente
            if (griglia == null)
            {
                MessageBox.Show("non hai premuto avvia");
                return;
            }

            // sender è il pulsante che hai premuto;
            Button premuto = (Button)sender;

            
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
                {
                    int numero = r * 6 + c + 1;   

                    
                    if (premuto.Name == "button" + numero)
                    {
                        if (griglia[r, c] == 'X' || griglia[r, c] == 'O')
                        {
                            return;//non faccio niente
                        }

                        if (char.IsDigit(griglia[r, c]))
                        {
                            griglia[r, c] = 'X';
                            premuto.Text = "X";   // il ~ del pulsante diventa X
                            MessageBox.Show("Colpito!");

                            int rimaste = 0;
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 6; j++)
                                {
                                    if (char.IsDigit(griglia[i, j]))
                                    {
                                        rimaste++;
                                    }
                                }
                            }

                            if (rimaste == 0)
                            {
                                MessageBox.Show("Complimenti hai vinto!");
                                griglia = null;
                                return;
                            }
                        }
                        else
                        {
                            griglia[r, c] = 'O';
                            premuto.Text = "O";
                            MessageBox.Show("Acqua!");
                        }
                    }
                }
            }
        }

        private void BtnAVVIO_Click(object sender, EventArgs e)
        {
            griglia = RiempiCaselle();  
                      
        }

        private void StampaProva(char[,] m)
        {
            string s = "";
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
                    s += m[r, c] + " ";
                s += "\n";
            }
            MessageBox.Show(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}