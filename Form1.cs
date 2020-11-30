using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void validarTexto(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void validarNumero(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }


            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTexto(sender, e);
        }

        private void txtSalarioxHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumero(sender, e);
        }

        private void txtHorasTrabajadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumero(sender, e);
        }

        private void txtHorasExtras_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumero(sender, e);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double salxh, ht, he, sb, imp, sn;
            try
            {
                salxh = Convert.ToDouble(txtSalarioxHora.Text);
                ht = Convert.ToDouble(txtHorasTrabajadas.Text);
                he = Convert.ToDouble(txtHorasExtras.Text);

                sb = (salxh * ht) + (2 * (salxh * he));
                imp = sb * 0.15;
                sn = sb - imp;

                txtSalarioBase.Text = sb.ToString();
                txtImpuesto.Text = imp.ToString();
                txtSalarioNeto.Text = sn.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error denotado por:\n" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control datos in this.groupBox1.Controls)
            {
                if (datos is TextBox)
                    datos.Text = string.Empty;
            }

            foreach (Control res in this.groupBox2.Controls)
            {
                if (res is TextBox)
                {
                    res.Text = string.Empty;
                }
            }
            txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "CONFIRMAR SALIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
