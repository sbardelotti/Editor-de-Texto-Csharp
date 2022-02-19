using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_Texto
{
    public partial class F_Principal : Form
    {
        StringReader leitura = null;    //Usado na impressão
        
        public F_Principal()
        {
            InitializeComponent();
        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);     //Criando o arquivo e definindo(nome, tipo, método de acesso)
                    StreamWriter elementoEscritor = new StreamWriter(arquivo);      //Buffer para escrever
                    elementoEscritor.Flush();                                       //Preparando o Buffer
                    elementoEscritor.BaseStream.Seek(0, SeekOrigin.Begin);          //Definindo a posição inical do Buffer
                    elementoEscritor.Write(this.richTextBox1.Text);                 //O que será escrito
                    elementoEscritor.Flush();                                       //Atualizando o Buffer
                    elementoEscritor.Close();                                       //Encerrando o processo
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Multiselect = false; //Apenas um arquivo pode ser aberto por vez
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"Bibliotecas\Documentos\";
            openFileDialog1.Filter = "(*.MIMI)|*.MIMI"; 
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader elementoLeitor = new StreamReader(arquivo);
                    elementoLeitor.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = elementoLeitor.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = elementoLeitor.ReadLine();
                    }
                    elementoLeitor.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro na leitura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }

        }

        private void Colar()
        {
            richTextBox1.Paste();
        }
        
        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            string nomeFonte = null;
            float tamanhoFonte = 0f;
            bool n,i,s = false;

            nomeFonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);


            if (n == false)
            {
                if(i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if(i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);

                }
                else if (i == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);

                }     
            }
            else
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline);

                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);

                }
            }
            
        }

        private void Italico()
        {
            string nomeFonte = null;
            float tamanhoFonte = 0f;
            bool n, i, s = false;

            nomeFonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);


            if (i == false)
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);

                }
                else if (n == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);

                }
            }
            else
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);

                }
            }
        }

        private void Sublinhado()
        {
            string nomeFonte = null;
            float tamanhoFonte = 0f;
            bool n, i, s = false;

            nomeFonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Regular);


            if (s == false)
            {
                if (i == true & n == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (i == false & n == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (i == true & n == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline | FontStyle.Italic);

                }
                else if (i == false & n == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Underline);

                }
            }
            else
            {
                if (i == true & n == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);

                }
                else if (i == false & n == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Bold);

                }
                else if (i == true & n == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, FontStyle.Italic);

                }
            }
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void Imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0f;
            float posY = 0f;
            int cont = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if(margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }
            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics); //Calculando o número de linhas por páginas com base na medida das margens
            linha = leitura.ReadLine();
            while(cont < linhasPagina)
            {
                posY = (margemSuperior + (cont + fonte.GetHeight(e.Graphics)));     //define a posição vertical de cada linha
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, posY, new StringFormat());
                cont++;
                linha = leitura.ReadLine();
            }
            if(linha != null)
            {
                e.HasMorePages = true;  //Se ainda tiver linha para imprimir cria uma nova página para impressão
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();   //Remove Pincel
        }
    }
}
