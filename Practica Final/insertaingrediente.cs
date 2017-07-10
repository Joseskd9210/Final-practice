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

namespace Practica_Final
{
     public partial class insertaingrediente : Form1
    {
        public string ing="0";
        conexion objetoMiClase = new conexion();
        public insertaingrediente(string arumento)
        {
            InitializeComponent();
            //MessageBox.Show(arumento);
        }

        private void insertaingrediente_Load(object sender, EventArgs e)
        {
            try
            {
                lbtitulo.Text = "INSERTAR INGREDIENTE";
                objetoMiClase.conectar();
                SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "ingredientes", "");
                string dato1;
                int ides;
                string dato2;
                while (midatareader.Read())
                {

                    ides = midatareader.GetInt32(0);
                    dato2 = midatareader.GetString(1);
                    dato1 = Convert.ToString(ides);

                    lvingrediente.Items.Add(dato1 + "." + dato2);

                }
                midatareader.Close();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al Cargar ingrediente" + ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  lvingredienteselec.Items.Add(lvingrediente.SelectedItems[0].Text + "." + tbcantingrediente.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                ing = lvingrediente.SelectedItems[0].Text.TrimEnd() + "." + tbcantingrediente.Text;
                Close();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al boton ingrediente" + ex.Message + ex.StackTrace);
            }

        }
    }
}
