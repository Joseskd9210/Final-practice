using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Final
{
    
    public partial class Form1 : Form
    {
        conexion objetoMiClase = new conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                menu mimenu = new menu();
                mimenu.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al abrir el panel" + ex.Message + ex.StackTrace);
            }
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {

            try
            {
                busca busquedas = new busca(txtbuscador.Text);
                busquedas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Al buscar"+ex.Message + ex.StackTrace);
            }
        }
    }
}
