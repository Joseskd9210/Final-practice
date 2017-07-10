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
    public partial class eliminar : Form1
    {
        conexion objetoMiClase = new conexion();
        public eliminar()
        {
            InitializeComponent();
        }

        private void eliminar_Load(object sender, EventArgs e)
        {
            lbtitulo.Text = "ELIMINAR DE BBDD";
            string dato1;
            int ides;
            string dato2;
            SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "receta", "");
            while (midatareader2.Read())
            {
                ides = midatareader2.GetInt32(0);
                dato1 = Convert.ToString(ides);
                dato2 = midatareader2.GetString(6);
                clbeliminareceta.Items.Add(dato1 + "." + dato2);
            }
            midatareader2.Close();
            SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "ingredientes", "");
            while (midatareader.Read())
            {
                ides = midatareader.GetInt32(0);
                dato1 = Convert.ToString(ides);
                dato2 = midatareader.GetString(1);
                clbeliminaringrediente.Items.Add(dato1 + "." + dato2);
            }
            midatareader.Close();
            SqlDataReader midatareader3 = objetoMiClase.leerbasedatos("*", "utensilios", "");
            while (midatareader3.Read())
            {
                ides = midatareader3.GetInt32(0);
                dato1 = Convert.ToString(ides);
                dato2 = midatareader3.GetString(1);
                clbeliminautensilios.Items.Add(dato1 + "." + dato2);
            }
            midatareader3.Close();
            SqlDataReader midatareader4 = objetoMiClase.leerbasedatos("*", "vinos", "");
            while (midatareader4.Read())
            {
                ides = midatareader4.GetInt32(0);
                dato1 = Convert.ToString(ides);
                dato2 = midatareader4.GetString(1);
                clbeliminavino.Items.Add(dato1 + "." + dato2);
            }
            midatareader4.Close();
            SqlDataReader midatareader5 = objetoMiClase.leerbasedatos("*", "alergenos", "");
            while (midatareader5.Read())
            {
                ides = midatareader5.GetInt32(0);
                dato1 = Convert.ToString(ides);
                dato2 = midatareader5.GetString(1);
                clbeliminaalergenos.Items.Add(dato1 + "." + dato2);
            }
            midatareader5.Close();
        }

        private void btneliminareceta_Click(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
             int i=0;
            while (i < clbeliminareceta.CheckedItems.Count)
            {
                var x = clbeliminareceta.CheckedItems[i].ToString().Split('.');
                if (objetoMiClase.eliminarbasedatos("receta", "where id =" + x[0]))
                { 
                    MessageBox.Show("RECETA BORRADA CORRECTAMENTE"); 
                    if (objetoMiClase.eliminarbasedatos("recomienda", "where id_receta =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("usa", "where Id_receta =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("esdereceta", "where id_receta =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("tiene", "where Id_receta =" + x[0])) { /*OK*/ }
                }
                i++;
            }
            Close();
        }

        private void btneliminaringredientes_Click(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
            int i = 0;
            while (i < clbeliminaringrediente.CheckedItems.Count)
            {
                var x = clbeliminaringrediente.CheckedItems[i].ToString().Split('.');
                if (objetoMiClase.eliminarbasedatos("ingredientes", "where ingrediente_Id =" + x[0])) 
                { 
                    MessageBox.Show("INGREDIENTE BORRADO CORRECTAMENTE");
                    if (objetoMiClase.eliminarbasedatos("contiene", "where Id_ingrediente =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("esdeingrediente", "where id_ingrediente =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("tiene", "where id_ingrediente =" + x[0])) { /*OK*/ }
                }
                i++;
            }
            Close();
        }

        private void btneliminavino_Click(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
            int i = 0;

            while (i < clbeliminavino.CheckedItems.Count)
            {
                var x = clbeliminavino.CheckedItems[i].ToString().Split('.');
                if (objetoMiClase.eliminarbasedatos("vinos", "where vinos_Id =" + x[0])) 
                { 
                    MessageBox.Show("VINO BORRADO CORRECTAMENTE");
                    if (objetoMiClase.eliminarbasedatos("recomienda", "where id_vino =" + x[0])) { /*OK*/ }
                }
               i++;
            }
            Close();
        }

        private void btneliminarutensilios_Click(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
            int i = 0;
            
            while (i < clbeliminautensilios.CheckedItems.Count)
            {
                var x = clbeliminautensilios.CheckedItems[i].ToString().Split('.');
                if (objetoMiClase.eliminarbasedatos("utensilios", "where utensilios_Id =" + x[0])) 
                { 
                    MessageBox.Show("UTENSILIO BORRADO CORRECTAMENTE");
                    if (objetoMiClase.eliminarbasedatos("usa", "where id_utensilios =" + x[0])) { /*OK*/ }
                 }
                i++;
            }
            Close();
        }

        private void btneliminaalergenenos_Click(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
            int i = 0;

            while (i < clbeliminaalergenos.CheckedItems.Count)
            {
                var x = clbeliminaalergenos.CheckedItems[i].ToString().Split('.');
                if (objetoMiClase.eliminarbasedatos("alergenos", "where alergeno_Id =" + x[0])) 
                { 
                    MessageBox.Show("ALERGENO BORRADO CORRECTAMENTE");
                    if (objetoMiClase.eliminarbasedatos("contiene", "where id_alergeno =" + x[0])) { /*OK*/ }
                    if (objetoMiClase.eliminarbasedatos("esdealergenos", "where id_alergeno =" + x[0])) { /*OK*/ }
                }
                i++;
            }
            Close();
        }
    }
}
