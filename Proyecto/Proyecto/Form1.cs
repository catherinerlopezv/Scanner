using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            if(buscar.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = buscar.FileName;
            }
        }

        private void Leer_Click(object sender, EventArgs e)
        {
       
            String Leer = File.ReadAllText(textBox1.Text);
            TxtAr.Text = Leer;

            Parser parser = new Parser();
            try
            {
                textBox2.Text += parser.Parse(Leer).AST.ToString();
            }
            catch (ParseException)
            {
                textBox2.Text = textBox2.Text + "Parsing failed, best effort parser error:";
                textBox2.Text =  textBox2.Text + parser.BestErrorToString();
            }
        }
    }
}
