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
        string dato1, dato2;
        static int idreceta,contador=0;
        private void Form2_Load(object sender, EventArgs e)
        {
            objetoMiClase.conectar();
            
                SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "");

                while (midatareader.Read() && contador<4)
                {
                    idreceta = midatareader.GetInt32(0);
                    dato1 = midatareader.GetString(6);
                    dato2 = midatareader.GetString(4);
                    MessageBox.Show("hola");

                    switch (contador)
                    {
                        case 0:
                            ltituloreceta1.Text = dato1;
                            ldescripcionreceta1.Text = dato2;

                            break;
                        case 1:
                            ltituloreceta2.Text = dato1;
                            ldescripcionreceta2.Text = dato2;
                            break;
                        case 2:
                            ltituloreceta3.Text = dato1;
                            ldescripcionreceta3.Text = dato2;
                            break;
                        case 3:
                            ltituloreceta4.Text = dato1;
                            ldescripcionreceta4.Text = dato2;
                            break;

                    }
                    contador++;


                }
                midatareader.Close();
         




        }

        private void btnsiguienete_Click(object sender, EventArgs e)
        {
            contador = 0;
            this.Form2_Load(null,null);
                

        }
    }
}
