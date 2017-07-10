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
    public partial class busca : Form1
    {
        conexion objetoMiClase = new conexion();
        string buscar;
        public busca( string cadena)
        {
            InitializeComponent();
            buscar = cadena;
        }
        string dato1, dato2, aux1, aux2;

        public int idreceta, contador = 0, registrofinal, cuenta, registro = 0, id2, identificador1 = 0, identificador2 = 0, identificador3 = 0, identificador4 = 0;
        SqlDataReader midatareader=null;
        private void busca_Load(object sender, EventArgs e)
        {
            lbtitulo.Text="Busquedas de " +buscar+ ".";
            objetoMiClase.conectar();


                    pan1.Visible = false; pan2.Visible = false;
                    pan3.Visible = false; pan4.Visible = false;
            
            if (registro != 1) {
                midatareader = objetoMiClase.leerbasedatos("*", "receta", " WHERE titulo LIKE '%"+ buscar +"%'");
                registro = 1;
                }

                while (midatareader.Read() && contador<4)
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


                }
                //midatareader.Close();
         




        }

        private void btnsiguienete_Click(object sender, EventArgs e)
        {
            contador = 0;
            this.busca_Load(null,null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //midatareader.Close();
            //SqlDataReader midatareader = null;
           // registro = 0;
            //this.busca_Load(null, null);
           // this.Show();
            Form2 otra = new Form2();
            otra.ShowDialog();
            Close();


        }

        private void btnverreceta1_Click(object sender, EventArgs e)
        {
            if (identificador1 != 0)
            {
            verreceta mostrar = new verreceta(identificador1);
            mostrar.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (identificador2!= 0)
            {
                verreceta mostrar = new verreceta(identificador2);
                mostrar.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (identificador3 != 0)
            {
                verreceta mostrar = new verreceta(identificador3);
                mostrar.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (identificador4 != 0)
            {
                verreceta mostrar = new verreceta(identificador4);
                mostrar.ShowDialog();
            }
        }
    }
}
