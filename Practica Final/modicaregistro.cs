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
    public partial class modicaregistro : Form1
    {
        conexion objetoMiClase = new conexion();
        int pestana, identificador, idimagenasociada;
        public modicaregistro(int tab, int ids)
        {
            pestana = tab;
            identificador = ids;
            InitializeComponent();
        }
        int ides, id2, int1; string dato1, dato2, dato3, dato4, dato5, dato6, dato7, imagenreceta;
        private void modicaregistro_Load(object sender, EventArgs e)
        {
            try
            {

                lbtitulo.Text = "MODIFICAR REGISTROS";
                tabControl2.SelectedIndex = pestana;

                switch (pestana)
                {
                    case 0:

                        tabPage8.Enabled = false;
                        tabPage7.Enabled = false;
                        tabPage9.Enabled = false;
                        tabPage10.Enabled = false;

                        SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where id=" + identificador);
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
                            txttituloreceta.Text = dato7;
                            txtdescripcionreceta.Text = dato5;
                            txtdificultad.Text = dato2;
                            txtobservacion.Text = dato6;
                            txttiempo.Text = dato3;
                            txttipoplato.Text = dato4;
                        }
                        midatareader.Close();
                        string aux1, aux2;
                        SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "esdereceta", " where id_receta =" + dato1);
                        while (midatareader3.Read())
                        {
                            id2 = midatareader3.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                            while (midatareader4.Read())
                            {
                                dato2 = midatareader4.GetString(2);
                                imagenreceta = dato2;
                                pbimagenreceta.ImageLocation = dato2;
                                ofdabreimagen.FileName = dato2;
                            }
                            midatareader4.Close();
                        }
                        midatareader3.Close();

                        SqlDataReader midatareader5 = objetoMiClase.leerbasedatos("*", "tiene", " where Id_receta =" + ides);
                        while (midatareader5.Read())
                        {
                            id2 = midatareader5.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader6 = objetoMiClase.leerbasedatos("*", "ingredientes", " where ingrediente_Id=" + id2);
                            while (midatareader6.Read())
                            {
                                id2 = midatareader6.GetInt32(0);
                                aux1 = Convert.ToString(id2);
                                aux2 = midatareader6.GetString(1);
                                lvingredientesreceta.Items.Add(aux1 + "." + aux2);
                            }
                            midatareader6.Close();
                        }
                        midatareader5.Close();

                        SqlDataReader midatareader7 = objetoMiClase.leerbasedatos("*", "usa", " where Id_receta =" + ides);
                        while (midatareader7.Read())
                        {
                            id2 = midatareader7.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader8 = objetoMiClase.leerbasedatos("*", "utensilios", " where utensilios_Id=" + id2);
                            while (midatareader8.Read())
                            {
                                id2 = midatareader8.GetInt32(0);
                                aux1 = Convert.ToString(id2);
                                aux2 = midatareader8.GetString(1);
                                clbutensiliosreceta.SetItemChecked(clbutensiliosreceta.Items.Add(aux1 + "." + aux2), true);

                            }
                            midatareader8.Close();
                        }
                        midatareader7.Close();

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
                                clbreecetasasociadas.SetItemChecked(clbreecetasasociadas.Items.Add(aux1 + "." + aux2), true);
                            }
                            midatareader10.Close();
                        }
                        midatareader9.Close();

                        SqlDataReader midatareader11 = objetoMiClase.leerbasedatos("*", "recomienda", " where id_receta =" + ides);
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
                                clvinosrecomendados.SetItemChecked(clvinosrecomendados.Items.Add(aux1 + "." + aux2), true);
                            }
                            midatareader10.Close();
                        }
                        midatareader11.Close();

                        SqlDataReader midatareader13 = objetoMiClase.leerbasedatos("*", "utensilios", "");
                        while (midatareader13.Read())
                        {
                            ides = midatareader13.GetInt32(0);
                            dato2 = midatareader13.GetString(1);
                            dato1 = Convert.ToString(ides);
                            clbutensiliosreceta.Items.Add(dato1 + "." + dato2);
                        }
                        midatareader13.Close();



                        //MessageBox.Show(pbimagenreceta.ImageLocation);




                        SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "receta", "");
                        while (midatareader2.Read())
                        {
                            ides = midatareader2.GetInt32(0);
                            dato1 = Convert.ToString(ides);
                            dato2 = midatareader2.GetString(6);
                            clbreecetasasociadas.Items.Add(dato1 + "." + dato2);
                        }
                        midatareader2.Close();

                        SqlDataReader midatareader14 = objetoMiClase.leerbasedatos("*", "vinos", "");
                        while (midatareader14.Read())
                        {
                            ides = midatareader14.GetInt32(0);
                            dato1 = Convert.ToString(ides);
                            dato2 = midatareader14.GetString(1);
                            dato3 = midatareader14.GetString(2);
                            clvinosrecomendados.Items.Add(dato1 + "." + dato2 + "." + dato3);
                        }
                        midatareader14.Close();

                        break;
                    case 1:
                        tabPage6.Enabled = false;
                        tabPage8.Enabled = false;
                        tabPage9.Enabled = false;
                        tabPage10.Enabled = false;
                        SqlDataReader midatareader30 = objetoMiClase.leerbasedatos("*", "ingredientes", "where ingrediente_Id=" + identificador);
                        while (midatareader30.Read())
                        {
                            ides = midatareader30.GetInt32(0);
                            double doble1;
                            dato2 = midatareader30.GetString(1);
                            int1 = midatareader30.GetInt32(2);
                            doble1 = midatareader30.GetDouble(3);
                            txtnombreingrediente.Text = dato2;

                            dato1 = int1.ToString();
                            txtcantidad.Text = dato1;

                            dato3 = doble1.ToString();
                            txtcostes.Text = dato3;
                        }
                        midatareader30.Close();

                        SqlDataReader midatareader31 = objetoMiClase.leerbasedatos("*", "contiene", " where Id_ingrediente =" + ides);
                        while (midatareader31.Read())
                        {
                            id2 = midatareader31.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader32 = objetoMiClase.leerbasedatos("*", "alergenos", " where alergeno_Id=" + id2);
                            while (midatareader32.Read())
                            {
                                id2 = midatareader32.GetInt32(0);
                                aux1 = Convert.ToString(id2);
                                aux2 = midatareader32.GetString(1);
                                clbalergenoingrediente.SetItemChecked(clbalergenoingrediente.Items.Add(aux1 + "." + aux2), true);
                            }
                            midatareader32.Close();
                        }
                        midatareader31.Close();

                        SqlDataReader midatareader33 = objetoMiClase.leerbasedatos("*", "esdeingrediente", " where Id_ingrediente =" + ides);
                        while (midatareader33.Read())
                        {
                            id2 = midatareader33.GetInt32(1);
                            aux1 = Convert.ToString(id2);
                            SqlDataReader midatareader34 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                            while (midatareader34.Read())
                            {
                                dato2 = midatareader34.GetString(2);
                                pbingrediente.ImageLocation = dato2;
                                ofdabreimagen.FileName = dato2;
                            }
                            midatareader34.Close();
                        }
                        midatareader33.Close();

                        SqlDataReader midatareader35 = objetoMiClase.leerbasedatos("*", "alergenos", "");
                        while (midatareader35.Read())
                        {
                            ides = midatareader35.GetInt32(0);
                            dato1 = Convert.ToString(ides);
                            dato2 = midatareader35.GetString(1);

                            clbalergenoingrediente.Items.Add(dato1 + "." + dato2);
                        }
                        midatareader35.Close();

                        break;
                    case 2:


                        tabPage6.Enabled = false;
                        tabPage7.Enabled = false;
                        tabPage9.Enabled = false;
                        tabPage10.Enabled = false;



                        SqlDataReader midatareader40 = objetoMiClase.leerbasedatos("*", "vinos", "where vinos_Id=" + identificador);
                        while (midatareader40.Read())
                        {
                            ides = midatareader40.GetInt32(0);
                            dato2 = midatareader40.GetString(1);
                            dato3 = midatareader40.GetString(2);
                            txtdenominacionvino.Text = dato3;
                            txtnombrevino.Text = dato2;
                        }
                        midatareader40.Close();
                        break;
                    case 3:
                        tabPage6.Enabled = false;
                        tabPage7.Enabled = false;
                        tabPage8.Enabled = false;
                        tabPage10.Enabled = false;

                        SqlDataReader midatareader50 = objetoMiClase.leerbasedatos("*", "utensilios", "where utensilios_Id=" + identificador);
                        while (midatareader50.Read())
                        {
                            ides = midatareader50.GetInt32(0);
                            dato2 = midatareader50.GetString(1);
                            txtnombrutensilio.Text = dato2;

                        }
                        midatareader50.Close();

                        break;
                    case 4:

                        tabPage6.Enabled = false;
                        tabPage8.Enabled = false;
                        tabPage9.Enabled = false;
                        tabPage7.Enabled = false;
                        SqlDataReader midatareader60 = objetoMiClase.leerbasedatos("*", "alergenos", "where alergeno_id=" + identificador);
                        while (midatareader60.Read())
                        {
                            ides = midatareader60.GetInt32(0);
                            dato2 = midatareader60.GetString(1);
                            dato3 = midatareader60.GetString(2);
                            txtnombrealergeno.Text = dato2;
                            txttipoalergeno.Text = dato3;

                        }
                        midatareader60.Close();

                        SqlDataReader midatareader61 = objetoMiClase.leerbasedatos("*", "esdealergenos", " where id_alergeno =" + identificador);
                        while (midatareader61.Read())
                        {
                            id2 = midatareader61.GetInt32(0);
                            aux1 = Convert.ToString(id2);

                            SqlDataReader midatareader62 = objetoMiClase.leerbasedatos("*", "imagenes", " where imagen_Id=" + id2);
                            while (midatareader62.Read())
                            {
                                dato2 = midatareader62.GetString(2);
                                pbimagenalergeno.ImageLocation = dato2;
                                ofdabreimagen.FileName = dato2;
                            }
                            midatareader62.Close();
                        }
                        midatareader61.Close();
                        break;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar al modificar " + ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                insertaingrediente insertaing = new insertaingrediente("hola");
                insertaing.ShowDialog();
                lvingredientesreceta.Items.Add(insertaing.ing.ToString());
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al  insertar ingrediente" + ex.Message + ex.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    pbimagenreceta.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al cambiar la imagen " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificarreceta_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                if (objetoMiClase.modificarbasedatos("titulo='" + txttituloreceta.Text + "', dificultad='" + txtdificultad.Text + "', tiempo='" + txttiempo.Text + "', tipo_plato='" + txttipoplato.Text + "', descripcion='" + txtdescripcionreceta.Text + "', observacion='" + txtobservacion.Text + "'", "receta", "where id=" + identificador))
                {
                    MessageBox.Show("RECETA MODIFICADA CORRECTAMENTE");
                }
                int i = 0;
                while (i < lvingredientesreceta.Items.Count)
                {
                    var x = lvingredientesreceta.Items[i].Text.Split('.');
                    try
                    {
                        if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", identificador + "," + x[0] + "," + x[2])) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }
                    i++;
                }
                i = 0;
                while (i < clbutensiliosreceta.CheckedItems.Count)
                {
                    var x = clbutensiliosreceta.CheckedItems[i].ToString().Split('.');
                    try
                    {
                        if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", identificador + "," + x[0])) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }
                    i++;
                }
                i = 0;
                while (i < clvinosrecomendados.CheckedItems.Count)
                {
                    var x = clvinosrecomendados.CheckedItems[i].ToString().Split('.');
                    try
                    {
                        if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)", x[0] + "," + identificador)) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }
                    i++;
                }
                i = 0;
                while (i < clbreecetasasociadas.CheckedItems.Count)
                {
                    var x = clbreecetasasociadas.CheckedItems[i].ToString().Split('.');
                    try
                    {
                        if (objetoMiClase.insertarbasedatos("asocia (id_recetaasociada,id_receta)", x[0] + "," + identificador)) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }
                    i++;
                }
                //metemos imagen
                if (objetoMiClase.eliminarbasedatos("esdereceta", "where id_receta =" + ides)) { /*ok*/ }

                if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }
                SqlDataReader midatareader22 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");

                while (midatareader22.Read())
                {
                    idimagenasociada = midatareader22.GetInt32(0);
                }
                midatareader22.Close();
                //relacionamos imagen
                try
                {
                    if (objetoMiClase.insertarbasedatos("esdereceta (id_imagen,id_receta)", idimagenasociada + "," + identificador)) { /*OK*/}
                }
                catch
                {
                    /*OK*/
                }
                Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al modificar " + ex.Message + ex.StackTrace);
            }

        }

        private void btnimageningrediente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    pbingrediente.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al cambiar la imagen " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificaingrediente_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                objetoMiClase.conectar();
                if (objetoMiClase.modificarbasedatos("nombre='" + txtnombreingrediente.Text + "', cantidad='" + txtcantidad.Text + "', costes='" + txtcostes.Text + "'", "ingredientes", "where ingrediente_Id=" + identificador))
                {
                    MessageBox.Show("INGREDIENTE MODIFICADO CORRECTAMENTE");

                    //metemos imagen
                    try
                    {

                        if (objetoMiClase.eliminarbasedatos("esdeingrediente", "where id_ingrediente =" + identificador)) { /*ok*/ }

                        if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }
                        SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");
                        while (midatareader2.Read())
                        {
                            idimagenasociada = midatareader2.GetInt32(0);
                        }
                        midatareader2.Close();

                        //relacionamos imagen


                        if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,id_ingrediente)", idimagenasociada + "," + identificador)) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }
                    i = 0;
                    while (i < clbalergenoingrediente.CheckedItems.Count)
                    {
                        var x = clbalergenoingrediente.CheckedItems[i].ToString().Split('.');
                        try
                        {
                            if (objetoMiClase.insertarbasedatos("contiene (id_ingrediente,id_alergeno)", identificador + "," + x[0])) { /*OK*/ }
                        }
                        catch
                        {
                            /*OK*/
                        }
                        i++;
                    }


                    Close();


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al modificar ingrediente " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificavino_Click(object sender, EventArgs e)
        {
            try
            {

                objetoMiClase.conectar();
                if (objetoMiClase.modificarbasedatos("nombre='" + txtnombrevino.Text + "', denominacion='" + txtdenominacionvino.Text + "'", "vinos", "where vinos_Id=" + identificador))
                {
                    MessageBox.Show("VINO MODIFICADO CORRECTAMENTE");
                    Close();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al modificar vino " + ex.Message + ex.StackTrace);
            }

        }

        private void btnmodificarutensilio_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                if (objetoMiClase.modificarbasedatos("nombre='" + txtnombrutensilio.Text + "'", "utensilios", "where utensilios_Id=" + identificador))
                {
                    MessageBox.Show("UTENSILIO MODIFICADO CORRECTAMENTE");
                    Close();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar utensilio " + ex.Message + ex.StackTrace);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdabreimagen.ShowDialog() == DialogResult.OK)
                {
                    pbimagenalergeno.Image = Image.FromFile(ofdabreimagen.FileName);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar imagen de alergeno " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificaralergeno_Click(object sender, EventArgs e)
        {
            try
            {

                objetoMiClase.conectar();
                if (objetoMiClase.modificarbasedatos("nombre='" + txtnombrealergeno.Text + "', tipo='" + txttipoalergeno.Text + "'", "alergenos", "where alergeno_Id=" + identificador))
                {
                    MessageBox.Show("ALERGENO MODIFICADO CORRECTAMENTE");

                    //metemos imagen
                    try
                    {
                        if (objetoMiClase.eliminarbasedatos("esdealergenos", "where id_alergeno =" + identificador)) { /*ok*/ }

                        if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + ofdabreimagen.FileName + "','" + ofdabreimagen.FileName + "'")) { /*OK*/ }
                        SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + ofdabreimagen.FileName + "'");
                        while (midatareader2.Read())
                        {
                            idimagenasociada = midatareader2.GetInt32(0);
                        }
                        midatareader2.Close();

                        //relacionamos imagen
                        if (objetoMiClase.insertarbasedatos("esdealergenos (id_imagen,id_alergeno)", idimagenasociada + "," + identificador)) { /*OK*/ }
                    }
                    catch
                    {
                        /*OK*/
                    }



                    Close();


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion modificar alergeno " + ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvingredientesreceta.Clear();
        }
    }
}

