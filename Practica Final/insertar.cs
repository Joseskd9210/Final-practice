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
    public partial class insertar : Form1
    {   int idreceta,idimagenasociada,idingrediente,idalergeno;
        conexion objetoMiClase = new conexion();
        public insertar()
        {
            InitializeComponent();
        }

        private void btninsertarreceta_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                if (objetoMiClase.insertarbasedatos("receta (titulo, dificultad, tiempo, tipo_plato, descripcion, observacion )", "'" + tbtitulo.Text + "','" + tbdificultad.Text + "','" + tbtiempo.Text + "','" + tbtipoplato.Text + "','" + tbdescripcion.Text + "','" + tbobservacion.Text + "'"))
                {
                    MessageBox.Show("RECETA INSERTADA CORRECTAMENTE");

                    SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where titulo='" + tbtitulo.Text + "'");


                    while (midatareader.Read())
                    {
                        idreceta = midatareader.GetInt32(0);
                    }
                    midatareader.Close();

                }
                int i = 0;

                while (i < lvingre.Items.Count)
                {


                    var x = lvingre.Items[i].Text.Split('.');

                    if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", idreceta + "," + x[0] + "," + x[2])) { /*OK*/ }
                    i++;
                }
                i = 0;
                while (i < clbutensilios.CheckedItems.Count)
                {
                    var x = clbutensilios.CheckedItems[i].ToString().Split('.');

                    if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", idreceta + "," + x[0])) { /*OK*/ }
                    i++;
                }
                i = 0;
                while (i < clvvinos.CheckedItems.Count)
                {
                    var x = clvvinos.CheckedItems[i].ToString().Split('.');

                    if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)", x[0] + "," + idreceta)) { /*OK*/ }
                    i++;
                }
                i = 0;
                while (i < clbrecetasasociadas.CheckedItems.Count)
                {
                    var x = clbrecetasasociadas.CheckedItems[i].ToString().Split('.');

                    if (objetoMiClase.insertarbasedatos("asocia (id_recetaasociada,id_receta)", x[0] + "," + idreceta)) { /*OK*/ }
                    i++;
                }
                //metemos imagen

                if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }

                SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");

                while (midatareader2.Read())
                {
                    idimagenasociada = midatareader2.GetInt32(0);
                }
                midatareader2.Close();
                //relacionamos imagen
                if (objetoMiClase.insertarbasedatos("esdereceta (id_imagen,id_receta)", idimagenasociada + "," + idreceta)) { /*OK*/ }

                Close();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al insertar reseta" + ex.Message + ex.StackTrace);
            }
           
        }

        private void insertar_Load(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "utensilios", "");
                string dato1;
                int ides;
                string dato2;
                string dato3;

                while (midatareader.Read())
                {
                    ides = midatareader.GetInt32(0);
                    dato2 = midatareader.GetString(1);
                    dato1 = Convert.ToString(ides);
                    clbutensilios.Items.Add(dato1 + "." + dato2);
                }
                midatareader.Close();


                SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "receta", "");
                while (midatareader2.Read())
                {
                    ides = midatareader2.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader2.GetString(6);
                    clbrecetasasociadas.Items.Add(dato1 + "." + dato2);
                }
                midatareader2.Close();

                SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "vinos", "");
                while (midatareader3.Read())
                {
                    ides = midatareader3.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader3.GetString(1);
                    dato3 = midatareader3.GetString(2);
                    clvvinos.Items.Add(dato1 + "." + dato2 + "." + dato3);
                }
                midatareader3.Close();

                SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "alergenos", "");
                while (midatareader4.Read())
                {
                    ides = midatareader4.GetInt32(0);
                    dato1 = Convert.ToString(ides);
                    dato2 = midatareader4.GetString(1);
                    clbalergenoingrediente.Items.Add(dato1 + "." + dato2);
                }
                midatareader4.Close();

            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al leer de base de datos " + ex.Message + ex.StackTrace);
            }

        }

        private void btnaddimg_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    picimagenreceta.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al elegir imagen " + ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insertaingrediente insertaing = new insertaingrediente("TEST");
                insertaing.ShowDialog();
                lvingre.Items.Add(insertaing.ing.ToString());
                //MessageBox.Show(insertaing.ing.ToString());
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al insertar ingrediente " + ex.Message + ex.StackTrace);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                objetoMiClase.conectar();
                if (objetoMiClase.insertarbasedatos("ingredientes (nombre, cantidad, costes)", "'" + tbingrediente.Text + "','" + tbcantidad.Text + "','" + tbcostes.Text + "'"))
                {
                    MessageBox.Show("INGREDIENTE INSERTADO CORRECTAMENTE");

                    SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + tbingrediente.Text + "'");

                    while (midatareader.Read())
                    {
                        idingrediente = midatareader.GetInt32(0);
                    }
                    midatareader.Close();

                    //metemos imagen
                    if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }

                    SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");

                    while (midatareader2.Read())
                    {
                        idimagenasociada = midatareader2.GetInt32(0);
                    }
                    midatareader2.Close();
                    //relacionamos imagen
                    if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,id_ingrediente)", idimagenasociada + "," + idingrediente)) { /*OK*/ }

                    i = 0;
                    while (i < clbalergenoingrediente.CheckedItems.Count)
                    {
                        var x = clbalergenoingrediente.CheckedItems[i].ToString().Split('.');

                        if (objetoMiClase.insertarbasedatos("contiene (id_ingrediente,id_alergeno)", idingrediente + "," + x[0])) { /*OK*/ }
                        i++;
                    }


                    Close();


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error insertar ingrediente " + ex.Message + ex.StackTrace);
            }
        
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btbuscarimagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    pbingredientes.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error imagen " + ex.Message + ex.StackTrace);
            }
        }

        private void btinsertarvino_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                if (objetoMiClase.insertarbasedatos("vinos (nombre, denominacion)", "'" + tbnombrevino.Text + "','" + tbdenominacion.Text + "'"))
                {
                    MessageBox.Show("VINO INSERTADO CORRECTAMENTE");
                    Close();
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al inserar vino " + ex.Message + ex.StackTrace);
            }
        }

        private void btninsertautensilio_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                if (objetoMiClase.insertarbasedatos("utensilios (nombre)", "'" + tbnombreutensilio.Text + "'"))
                {
                    MessageBox.Show("UTENSILIO INSERTADO CORRETAMENTE");
                    Close();
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al insertar utensilio " + ex.Message + ex.StackTrace);
            }
        }

        private void btninsrtaralergenos_Click(object sender, EventArgs e)
        {
            try
            {

                objetoMiClase.conectar();
                if (objetoMiClase.insertarbasedatos("alergenos (nombre, tipo)", "'" + tbnombrealergeno.Text + "','" + tbtipoalergeno.Text + "'"))
                {
                    MessageBox.Show("ALERGENO INSERTADO CORRECTAMENTE");

                    SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "alergenos", "where nombre='" + tbnombrealergeno.Text + "'");

                    while (midatareader.Read())
                    {
                        idalergeno = midatareader.GetInt32(0);
                    }
                    midatareader.Close();
                    //metemos imagen
                    if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }

                    SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");

                    while (midatareader2.Read())
                    {
                        idimagenasociada = midatareader2.GetInt32(0);
                    }
                    midatareader2.Close();
                    //relacionamos imagen
                    if (objetoMiClase.insertarbasedatos("esdealergenos (id_imagen,id_alergeno)", idimagenasociada + "," + idalergeno)) { /*OK*/ }

                    Close();


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al insertar alergeno " + ex.Message + ex.StackTrace);
            }
        }

        private void btaddimgalergeno_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    pbimagenalrgeno.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error imagen " + ex.Message + ex.StackTrace);
            }
        }

        private void clbutensilios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lvingre.Clear();
        }
    }
}
