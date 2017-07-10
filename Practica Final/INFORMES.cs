using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Final
{
    public partial class INFORMES : Form
    {
        public INFORMES()
        {
            InitializeComponent();
        }

        private void INFORMES_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recetarioDataSet1.alergenos' Puede moverla o quitarla según sea necesario.
            this.alergenosTableAdapter.Fill(this.recetarioDataSet1.alergenos);
            // TODO: esta línea de código carga datos en la tabla 'recetarioDataSet1.ingredientes' Puede moverla o quitarla según sea necesario.
            this.ingredientesTableAdapter.Fill(this.recetarioDataSet1.ingredientes);
            // TODO: esta línea de código carga datos en la tabla 'recetarioDataSet1.receta' Puede moverla o quitarla según sea necesario.
            this.recetaTableAdapter.Fill(this.recetarioDataSet1.receta);
            // TODO: esta línea de código carga datos en la tabla 'recetarioDataSet1.asocia' Puede moverla o quitarla según sea necesario.
            this.asociaTableAdapter.Fill(this.recetarioDataSet1.asocia);

            this.reportViewer1.RefreshReport();
        }
    }
}
