using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using Entity;using BLL;
using System.Windows.Forms;

namespace AyB
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
        void guardar()
        {
            Pedido pedido = new Pedido();
           pedido.tipoPedido = comboBox1.Text;
            pedido.abono = Convert.ToDecimal(txtabono.Text);
            pedido.especificacion = TXTespecificaciones.Text;
            pedido.fecha= Convert.ToDateTime(DateTime.Now);

            //if (rbtEmplazamiento.Checked == true)
            //{
            //    formulario.emplazado = "con emplazamiento";
            //}
            //else
            //{
            //    if (rbtSinEmplamiento.Checked == true)
            //    {
            //        formulario.emplazado = "sin emplazamiento";
            //    }

            //}

            //string mensaje = logica.guardar(formulario);
            //MessageBox.Show(mensaje);
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {

        }
    }
}
