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
    public partial class Form2 : Form1
    {
        conexion objetoMiClase = new conexion();
        public Form2()
        {
            InitializeComponent();
        }
        string dato1, dato2, aux1, aux2;

        public int idreceta, contador = 0, registrofinal, cuenta, registro = 0, id2, identificador1 = 0, identificador2 = 0, identificador3 = 0, identificador4 = 0;
        SqlDataReader midatareader=null;
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();

                pan1.Visible = false; pan2.Visible = false;
                pan3.Visible = false; pan4.Visible = false;

                if (registro != 1)
                {
                    midatareader = objetoMiClase.leerbasedatos("*", "receta", "");
                    registro = 1;
                }

                while (midatareader.Read())
                {
                    idreceta = midatareader.GetInt32(0);
                    dato1 = midatareader.GetString(6);
                    dato2 = midatareader.GetString(4);
                    SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "esdereceta", " where id_receta =" + idreceta);
                    while (midatareader3.Read())
                    {
                        id2 = midatareader3.GetInt32(1);
                        aux1 = Convert.ToString(id2);
                        SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                        while (midatareader4.Read())
                        {
                            aux2 = midatareader4.GetString(2);
                        }
                        midatareader4.Close();
                    }
                    midatareader3.Close();

                    switch (contador)
                    {
                        case 0:
                            pan1.Visible = true;
                            ltituloreceta1.Text = dato1;
                            txtdescripcion1.Text = dato2;
                            pbreceta1.ImageLocation = aux2;
                            identificador1 = idreceta;

                            break;
                        case 1:
                            pan2.Visible = true;
                            ltituloreceta2.Text = dato1;
                            txtdescripcion2.Text = dato2;
                            pbreceta2.ImageLocation = aux2;
                            identificador2 = idreceta;
                            break;
                        case 2:
                            pan3.Visible = true;
                            ltituloreceta3.Text = dato1;
                            txtdescripcion3.Text = dato2;
                            pbreceta3.ImageLocation = aux2;
                            identificador3 = idreceta;
                            break;
                        case 3:
                            pan4.Visible = true;
                            ltituloreceta4.Text = dato1;
                            txtdescripcion4.Text = dato2;
                            pbreceta4.ImageLocation = aux2;
                            identificador4 = idreceta;
                            break;

                    }
                    contador++;
                    if (contador == 4) { break; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar recetas " + ex.Message + ex.StackTrace);
            }
             
        }

        private void btnsiguienete_Click(object sender, EventArgs e)
        {
            try
            {
                contador = 0;
                this.Form2_Load(null, null);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error boton siguiente " + ex.Message + ex.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //midatareader.Close();
            //SqlDataReader midatareader = null;
           // registro = 0;
            //this.Form2_Load(null, null);
           // this.Show();
            Form2 otra = new Form2();
            otra.ShowDialog();
            Close();


        }

        private void btnverreceta1_Click(object sender, EventArgs e)
        {
            try
            {
                if (identificador1 != 0)
                {
                    verreceta mostrar = new verreceta(identificador1);
                    mostrar.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al boton receta 1 " + ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (identificador2 != 0)
                {
                    verreceta mostrar = new verreceta(identificador2);
                    mostrar.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al boton receta 2 " + ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (identificador3 != 0)
                {
                    verreceta mostrar = new verreceta(identificador3);
                    mostrar.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al boton receta 3 " + ex.Message + ex.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (identificador4 != 0)
                {
                    verreceta mostrar = new verreceta(identificador4);
                    mostrar.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al boton receta 4 " + ex.Message + ex.StackTrace);
            }
        }
    }
}
