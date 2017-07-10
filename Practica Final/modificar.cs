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
    public partial class modificar : Form1
    {
        conexion objetoMiClase = new conexion();
        public modificar()
        {
            InitializeComponent();
        }

        private void modificar_Load(object sender, EventArgs e)
        {
            try
            {
                lbtitulo.Text = "MODIFICAR DE BBDD";
                string dato1;
                int ides;
                string dato2;
                SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "");
                while (midatareader.Read())
                {
                    ides = midatareader.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader.GetString(6);
                    lvrecetas.Items.Add(dato1 + "." + dato2);
                }
                midatareader.Close();

                SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "ingredientes", "");
                while (midatareader2.Read())
                {
                    ides = midatareader2.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader2.GetString(1);
                    lvingredientes.Items.Add(dato1 + "." + dato2);
                }
                midatareader2.Close();
                SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "vinos", "");
                while (midatareader3.Read())
                {
                    ides = midatareader3.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader3.GetString(1);
                    lvmodificavino.Items.Add(dato1 + "." + dato2);
                }
                midatareader3.Close();
                SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "utensilios", "");
                while (midatareader4.Read())
                {
                    ides = midatareader4.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader4.GetString(1);
                    lvmodificarutensilios.Items.Add(dato1 + "." + dato2);
                }
                midatareader4.Close();
                SqlDataReader midatareader5 = objetoMiClase.leerbasedatos("*", "alergenos", "");
                while (midatareader5.Read())
                {
                    ides = midatareader5.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader5.GetString(1);
                    lvmodicalergeno.Items.Add(dato1 + "." + dato2);
                }
                midatareader5.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al funcion modificar apartados " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificareceta_Click(object sender, EventArgs e)
        {
            try
            {
                var x = lvrecetas.SelectedItems[0].Text.Split('.');
                int identificador = Convert.ToInt32(x[0]);
                modicaregistro modifi = new modicaregistro(0, identificador);
                modifi.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar registro " + ex.Message + ex.StackTrace);
            }

        }

        private void btnmodificaringrediente_Click(object sender, EventArgs e)
        {
            try
            {
                var x = lvingredientes.SelectedItems[0].Text.Split('.');
                int identificador = Convert.ToInt32(x[0]);
                modicaregistro modifi = new modicaregistro(1, identificador);
                modifi.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar ingredientes " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificavino_Click(object sender, EventArgs e)
        {
            try
            {
                var x = lvmodificavino.SelectedItems[0].Text.Split('.');
                int identificador = Convert.ToInt32(x[0]);
                modicaregistro modifi = new modicaregistro(2, identificador);
                modifi.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar vino " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificarutensilios_Click(object sender, EventArgs e)
        {
            try
            {
                var x = lvmodificarutensilios.SelectedItems[0].Text.Split('.');
                int identificador = Convert.ToInt32(x[0]);
                modicaregistro modifi = new modicaregistro(3, identificador);
                modifi.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar utensilios " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodicaralergeno_Click(object sender, EventArgs e)
        {
            try
            {
                var x = lvmodicalergeno.SelectedItems[0].Text.Split('.');
                int identificador = Convert.ToInt32(x[0]);
                modicaregistro modifi = new modicaregistro(4, identificador);
                modifi.ShowDialog();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show("Error al llamar a la funcion modificar alergeno " + ex.Message + ex.StackTrace);
            }
        }
    }
}
