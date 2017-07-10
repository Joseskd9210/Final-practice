using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Practica_Final
{

    public partial class menu : Form1
    {
        conexion objetoMiClase = new conexion();
        public menu()
        {
            InitializeComponent();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {

                insertar inserta = new insertar();
                inserta.Show();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error en boton insertar " + ex.Message + ex.StackTrace);
            }

        }

        private void menu_Load(object sender, EventArgs e)
        {
            lbtitulo.Text = "MENU RECETARIO";
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminar elimina = new eliminar();
                elimina.Show();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al llamar a la funcion eliminar " + ex.Message + ex.StackTrace);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                modificar modifica = new modificar();
                modifica.Show();
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Error al llamar a la funcion modificar " + ex.Message + ex.StackTrace);
            }
        }
        int idimagenasociada, idreceta, idvinos, idutensilios, idingrediente;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                objetoMiClase.conectar();
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Archivos xml(*.xml)|*.xml";
                open.Title = "XML";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument xDoc = new XmlDocument();

                    //La ruta del documento XML permite rutas relativas
                    //respecto del ejecutable!


                    xDoc.Load(open.FileName);

                    XmlNodeList recetas = xDoc.GetElementsByTagName("recetas");
                    XmlNodeList lista = ((XmlElement)recetas[0]).GetElementsByTagName("receta");

                    foreach (XmlElement nodo in lista)
                    {

                        //Compruebo las recetas
                        XmlNodeList nDificultad = nodo.GetElementsByTagName("dificultad");
                        XmlNodeList nTiempo = nodo.GetElementsByTagName("tiempo");
                        XmlNodeList nTipoPlato = nodo.GetElementsByTagName("tipoplato");
                        XmlNodeList nDescripcion = nodo.GetElementsByTagName("descripcion");
                        XmlNodeList nObservacion = nodo.GetElementsByTagName("observacion");
                        XmlNodeList nTitulo = nodo.GetElementsByTagName("titulo");
                        XmlNodeList nImagen = nodo.GetElementsByTagName("imagen");
                        //Compruebo receta
                        MessageBox.Show("INSERTADO CORRECTAMENTE");

                        SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where titulo='" + nTitulo[0].InnerText + "'");
                        if (!midatareader.HasRows)
                        {
                            if (objetoMiClase.insertarbasedatos("receta (titulo, dificultad, tiempo, tipo_plato, descripcion, observacion )", "'" + nTitulo[0].InnerText + "','" + nDificultad[0].InnerText + "','" + nTiempo[0].InnerText + "','" + nTipoPlato[0].InnerText + "','" + nDescripcion[0].InnerText + "','" + nObservacion[0].InnerText + "'"))
                            {


                                SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "receta", "where titulo='" + nTitulo[0].InnerText + "'");
                                while (midatareader1.Read())
                                {
                                    idreceta = midatareader1.GetInt32(0);
                                }
                                midatareader1.Close();

                                if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagen[0].InnerText + "','" + nImagen[0].InnerText + "'"))
                                {
                                    /*OK*/
                                }

                                SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nImagen[0].InnerText + "'");
                                while (midatareader2.Read())
                                {
                                    idimagenasociada = midatareader2.GetInt32(0);
                                }
                                midatareader2.Close();

                                //relacionamos imagen
                                if (objetoMiClase.insertarbasedatos("esdereceta (id_imagen,id_receta)", idimagenasociada + "," + idreceta))
                                {
                                    /*OK*/
                                }
                            }
                        }
                        midatareader.Close();

                        //Vinos
                        XmlNodeList vinos = xDoc.GetElementsByTagName("vinos");
                        XmlNodeList listaVinos = ((XmlElement)vinos[0]).GetElementsByTagName("vino");

                        foreach (XmlElement nodoVinos in listaVinos)
                        {
                            XmlNodeList nNombre = nodoVinos.GetElementsByTagName("nombre");
                            XmlNodeList nDenominacion = nodo.GetElementsByTagName("denominacion");

                            SqlDataReader midatareaderVinos = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nNombre[0].InnerText + "'");
                            if (!midatareaderVinos.HasRows)
                            {
                                if (objetoMiClase.insertarbasedatos("vinos (nombre, denominacion)", "'" + nNombre[0].InnerText + "','" + nDenominacion + "'"))
                                {
                                    /*OK*/
                                    SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nNombre[0].InnerText + "'");

                                    while (midatareader1.Read())
                                    {
                                        idvinos = midatareader1.GetInt32(0);
                                    }
                                    midatareader1.Close();

                                    if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)", idvinos + "," + idreceta))
                                    {
                                        /*OK*/
                                    }
                                }
                            }
                            else
                            {
                                SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nNombre[0].InnerText + "'");

                                while (midatareader1.Read())
                                {
                                    idvinos = midatareader1.GetInt32(0);
                                }
                                midatareader1.Close();

                                if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)", idvinos + "," + idreceta))
                                {
                                    /*OK*/
                                }
                            }
                            midatareaderVinos.Close();
                        }

                        //Utensilios
                        XmlNodeList utensilios = xDoc.GetElementsByTagName("utensilios");
                        XmlNodeList listaUten = ((XmlElement)utensilios[0]).GetElementsByTagName("utensilio");

                        foreach (XmlElement nodoUten in listaUten)
                        {
                            XmlNodeList nNombre = nodoUten.GetElementsByTagName("nombre");

                            SqlDataReader midatareaderUtensilios = objetoMiClase.leerbasedatos("*", "utensilios", "where nombre='" + nNombre[0].InnerText + "'");
                            if (!midatareaderUtensilios.HasRows)
                            {
                                if (objetoMiClase.insertarbasedatos("utensilios (nombre)", "'" + nNombre[0].InnerText + "'"))
                                {

                                    SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "utensilios", "where nombre='" + nNombre[0].InnerText + "'");

                                    while (midatareader1.Read())
                                    {
                                        idutensilios = midatareader1.GetInt32(0);

                                    }
                                    midatareader1.Close();
                                    if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", idreceta + "," + idutensilios))
                                    {
                                        /*OK*/
                                    }
                                }
                                midatareader.Close();
                            }
                            else
                            {
                                while (midatareaderUtensilios.Read())
                                {
                                    idutensilios = midatareaderUtensilios.GetInt32(0);
                                }
                                if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", idreceta + "," + idutensilios))
                                {
                                    /*OK*/
                                }
                                midatareaderUtensilios.Close();
                            }
                        }
                        //Ingredientes
                        XmlNodeList ingredientes = xDoc.GetElementsByTagName("ingredientes");

                        XmlNodeList listaIngre = ((XmlElement)ingredientes[0]).GetElementsByTagName("ingrediente");
                        foreach (XmlElement nodoIngre in listaIngre)
                        {
                            XmlNodeList nNombre = nodoIngre.GetElementsByTagName("nombre");
                            XmlNodeList nCantidad = nodoIngre.GetElementsByTagName("cantidad");
                            XmlNodeList nCostes = nodoIngre.GetElementsByTagName("coste");
                            XmlNodeList nImagenIngre = nodoIngre.GetElementsByTagName("imagen");

                            SqlDataReader midatareaderIngredientes = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + nNombre[0].InnerText + "'");
                            if (!midatareaderIngredientes.HasRows)
                            {

                                if (objetoMiClase.insertarbasedatos("ingredientes (nombre, cantidad, costes)", "'" + nNombre[0].InnerText + "','" + nCantidad[0].InnerText + "','" + nCostes[0].InnerText + "'"))
                                {
                                    /*OK*/
                                }
                                SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + nNombre[0].InnerText + "'");

                                while (midatareader1.Read())
                                {
                                    idingrediente = midatareader1.GetInt32(0);
                                }
                                midatareader1.Close();
                                //metemos imagen
                                if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagenIngre[0].InnerText + "','" + nImagenIngre[0].InnerText + "'"))
                                {
                                    /*OK*/
                                }
                                SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nImagenIngre[0].InnerText + "'");
                                while (midatareader2.Read())
                                {
                                    idimagenasociada = midatareader2.GetInt32(0);
                                }
                                midatareader2.Close();
                                //relacionamos imagen
                                if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,id_ingrediente)", idimagenasociada + "," + idingrediente))
                                {
                                    /*OK*/
                                }
                                if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", idreceta + "," + idingrediente + "," + nCantidad[0].InnerText))
                                {
                                    /*OK*/
                                }
                                midatareaderIngredientes.Close();
                            }
                            else
                            {

                                while (midatareaderIngredientes.Read())
                                {
                                    idingrediente = midatareader.GetInt32(0);

                                    //metemos imagen

                                    if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagenIngre[0].InnerText + "','" + nImagenIngre[0].InnerText + "'"))
                                    {
                                        /*OK*/
                                    }
                                    SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nImagenIngre[0].InnerText + "'");

                                    while (midatareader2.Read())
                                    {
                                        idimagenasociada = midatareader2.GetInt32(0);
                                    }
                                    midatareader2.Close();
                                    //relacionamos imagen
                                    if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,Id_ingrediente)", idimagenasociada + "," + idingrediente))
                                    {
                                        /*OK*/
                                    }
                                    if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", idreceta + "," + idingrediente + "," + nCantidad[0].InnerText))
                                    {
                                        /*OK*/
                                    }
                                }
                                midatareaderIngredientes.Close();
                            }
                        }
                        //Alergenos
                        XmlNodeList alergenos = xDoc.GetElementsByTagName("alergenos");

                        XmlNodeList listaAler = ((XmlElement)alergenos[0]).GetElementsByTagName("alergeno");
                        foreach (XmlElement nodoAler in listaAler)
                        {
                            XmlNodeList nNombre = nodoAler.GetElementsByTagName("nombre");
                            XmlNodeList nTipo = nodoAler.GetElementsByTagName("tipo");

                            SqlDataReader midatareaderAlergenos = objetoMiClase.leerbasedatos("*", "alergenos", "where nombre='" + nNombre[0].InnerText + "'");
                            if (!midatareaderAlergenos.HasRows)
                            {
                                if (objetoMiClase.insertarbasedatos("alergenos (nombre, tipo)", "'" + nNombre[0].InnerText + "','" + nTipo[0].InnerText + "'"))
                                {
                                    /*OK*/
                                }
                            }

                        }

                        midatareader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al llamar a la funcion insertar desde XML " + ex.Message + ex.StackTrace);
            }
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
                
                MessageBox.Show("Error al llamar a la funcion informe " + ex.Message + ex.StackTrace);
            }
        }
    }
}
