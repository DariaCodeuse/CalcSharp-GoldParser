using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)        // Boton de igual para obtener el resultado
        {
            try
            {
                // Obtener la expresión matemática desde muestraSentencia
                string expression = muestraSentencia.Text;

                // Ejecutar el parser para evaluar la expresión
                parser.Parse(expression);

                // Obtener el resultado del parser
                double result = Convert.ToDouble(parser.resultado);

                // Mostrar el resultado en digitosIndividuales
                digitosIndividuales.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el resultado: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, ".");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, "^");
        }   

        private void button20_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, "(");
        }

        private void btnPClose_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, ")");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void btnResults_Click(object sender, EventArgs e)
        {

        }

        private void btnClearEverything_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.ClearEverything(muestraSentencia, digitosIndividuales);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            // Número 0
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "0");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            // Número 1
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "1");
        }
        private void btnNum2_Click(object sender, EventArgs e)
        {
            // Numero 2
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            // Numero 3
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            // Numero 4
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            // Numero 5
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "9");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, " / ");
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, " * ");
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, " - ");
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, " + ");
        }

        private void textBoxSentence_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearADigit_Click(object sender, EventArgs e)
        {
            string s = digitosIndividuales.Text; ;
            digitosIndividuales.Text = s.Remove(s.Length - 1);
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.teclasNumericas(muestraSentencia, digitosIndividuales, "3.14159");
        }

        private void btnPotenciaTen_Click(object sender, EventArgs e)
        {
            CalculadoraHelper.InsertarSimbolo(muestraSentencia, "10^");
        }
    }
}
