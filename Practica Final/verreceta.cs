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
    public partial class verreceta : Form1
    {
        conexion objetoMiClase = new conexion();
        int idreceta;
        int ides, id2, id3, int1; 
        string dato1, dato2, dato3, dato4, dato5, dato6, dato7,aux1, aux2,aux3; 
        double suma=0,auxsuma, auxsuma2;
        public verreceta(int id)
        {
            idreceta = id;
            InitializeComponent();
        }

        private void verreceta_Load(object sender, EventArgs e)
        {
            try
            {
                lbtitulo.Text = "DETALLES DE UNA RECETA";
                SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where id=" + idreceta);
                while (midatareader.Read())
                {
                    ides = midatareader.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader.GetString(1);
                    dato3 = midatareader.GetString(2);
                    dato4 = midatareader.GetString(3);
                    dato5 = midatareader.GetString(4);
                    dato6 = midatareader.GetString(5);
                    dato7 = midatareader.GetString(6);
                    lbtituloreceta.Text = dato7;
                    txtdescripcion.Text = dato5;
                    lbdificultad.Text = dato2;
                    txtobservaciones.Text = dato6;
                    lbtiempo.Text = dato3;
                    lbtipoplato.Text = dato4;
                }
                midatareader.Close();

                SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "esdereceta", " where id_receta =" + dato1);
                while (midatareader3.Read())
                {
                    id2 = midatareader3.GetInt32(1);
                    aux1 = Convert.ToString(id2);
                    SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                    while (midatareader4.Read())
                    {
                        dato2 = midatareader4.GetString(2);
                        pbreceta.ImageLocation = dato2;
                    }
                    midatareader4.Close();
                }
                midatareader3.Close();

                SqlDataReader midatareader5 = objetoMiClase.leerbasedatos("*", "tiene", " where Id_receta =" + idreceta);
                while (midatareader5.Read())
                {

                    id2 = midatareader5.GetInt32(1);
                    aux1 = Convert.ToString(id2);
                    int1 = midatareader5.GetInt32(2);
                    aux3 = Convert.ToString(int1);


                    SqlDataReader midatareader99 = objetoMiClase.leerbasedatos("*", "contiene", " where Id_ingrediente =" + id2);
                    while (midatareader99.Read())
                    {
                        id3 = midatareader99.GetInt32(1);
                        aux1 = Convert.ToString(id2);
                        SqlDataReader midatareader10 = objetoMiClase.leerbasedatos("*", "alergenos", " where alergeno_Id=" + id3);
                        while (midatareader10.Read())
                        {

                            aux2 = midatareader10.GetString(1);
                            lvalergenos.Items.Add(aux2);
                        }
                        midatareader10.Close();
                    }
                    midatareader99.Close();



                    SqlDataReader midatareader6 = objetoMiClase.leerbasedatos("*", "ingredientes", " where ingrediente_Id=" + id2);
                    while (midatareader6.Read())
                    {
                        id2 = midatareader6.GetInt32(0);
                        aux1 = Convert.ToString(id2);
                        aux2 = midatareader6.GetString(1);

                        auxsuma2 = midatareader6.GetDouble(3);
                        auxsuma = auxsuma2 * int1;
                        suma = suma + auxsuma;

                        SqlDataReader midatareader66 = objetoMiClase.leerbasedatos("*", "esdeingrediente", " where Id_ingrediente =" + aux1);
                        while (midatareader66.Read())
                        {
                            id2 = midatareader66.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                            midatareader4.Read();

                            dato2 = midatareader4.GetString(2);

                            //  ilingredientes.Images.Add(Image.FromFile(dato2));
                            //aqui el codigo que pone la imagen en el listview
                        }
                        midatareader66.Close();
                        lvingredientes.Items.Add(int1.ToString() + " de " + aux2);

                        lbprecio.Text = suma.ToString() + " €";

                    }
                    midatareader6.Close();
                }
                midatareader5.Close();


                SqlDataReader midatareader9 = objetoMiClase.leerbasedatos("*", "asocia", " where id_receta =" + ides);
                while (midatareader9.Read())
                {
                    id2 = midatareader9.GetInt32(1);
                    aux1 = Convert.ToString(id2);
                    SqlDataReader midatareader10 = objetoMiClase.leerbasedatos("*", "receta", " where id=" + id2);
                    while (midatareader10.Read())
                    {
                        id2 = midatareader10.GetInt32(0);
                        aux1 = Convert.ToString(id2);
                        aux2 = midatareader10.GetString(6);
                        lvrecetas.Items.Add(aux1 + "." + aux2);
                    }
                    midatareader10.Close();
                }
                midatareader9.Close();



                SqlDataReader midatareader11 = objetoMiClase.leerbasedatos("*", "recomienda", " where id_receta =" + idreceta);
                while (midatareader11.Read())
                {
                    id2 = midatareader11.GetInt32(0);
                    aux1 = Convert.ToString(id2);
                    SqlDataReader midatareader10 = objetoMiClase.leerbasedatos("*", "vinos", " where vinos_Id=" + id2);
                    while (midatareader10.Read())
                    {
                        id2 = midatareader10.GetInt32(0);
                        aux1 = Convert.ToString(id2);
                        aux2 = midatareader10.GetString(1);
                        aux3 = midatareader10.GetString(2);
                        lvinosrecomendados.Items.Add(aux2 + " " + aux3);
                    }
                    midatareader10.Close();
                }
                midatareader11.Close();




                SqlDataReader midatareader22 = objetoMiClase.leerbasedatos("*", "usa", " where Id_receta =" + idreceta);
                while (midatareader22.Read())
                {
                    id2 = midatareader22.GetInt32(1);
                    aux1 = Convert.ToString(id2);
                    SqlDataReader midatareader10 = objetoMiClase.leerbasedatos("*", "utensilios", " where utensilios_Id=" + id2);
                    while (midatareader10.Read())
                    {
                        id2 = midatareader10.GetInt32(0);
                        aux1 = Convert.ToString(id2);
                        aux2 = midatareader10.GetString(1);
                        lvutensilios.Items.Add(aux2);
                    }
                    midatareader10.Close();
                }
                midatareader22.Close();

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al mostrar " + ex.Message + ex.StackTrace);
            }







        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                INFORMES infor = new INFORMES();
                infor.Show();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show("Error al llamar al informe " + ex.Message + ex.StackTrace);
            }
        }
    }
}
