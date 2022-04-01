using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1_Guía_7
{
    public partial class Form1 : Form
    {
        Hashtable datos = new Hashtable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitulo.Text == "" || txtDefCompleto.Text == "" || txtDefCompleto.Text == "Inserte la definición" || txtTitulo.Text == "Inserte el título")
                {
                    MessageBox.Show("Debes de llenar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    //Para instancear el objeto
                    Definición Concepto = new Definición()
                    {
                        Definicion = txtTitulo.Text,
                        ConceptoCompleto = txtDefCompleto.Text
                    };

                    //Agregandolo al mapa
                    datos.Add(Concepto.Definicion, Concepto);
                    //Agregando los datos al listBox
                    lstBox.Items.Add(Concepto.Definicion + " " + Concepto.ConceptoCompleto);
                    txtTitulo.Clear();
                    txtDefCompleto.Clear();
                    btnAgregar.Focus();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Rey ese dato ya esta registrado, prueba con otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //============================================//
            //Forma para crear una clase anónima
            /*var prueba = new
            {
                Nombre = "Halfonso Banderas",
                Edad = 23
            };*/
            //============================================//


        }

        private void lstBox_Click(object sender, EventArgs e)
        {



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(lstBox.SelectedIndex >= 0)
            {
                string conceptoSeccionado = lstBox.SelectedItem.ToString();
                datos.Remove(conceptoSeccionado);
                lstBox.Items.Remove(conceptoSeccionado);
                
            }
            else
            {
                MessageBox.Show("Tenes que seleccionar un concepto si quieres eliminarlo","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }


        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string DatoBuscar = txtTitulo.Text;

            if(lstBox.Contains(txtTitulo))
            {
                MessageBox.Show("La definción completa es");
            }

            MessageBox.Show("La definición completa es:", datos[datos.ContainsValue(Menu)] + "");

        }

        private void txtConcepto_Enter(object sender, EventArgs e)
        {
            if(txtTitulo.Text == "Inserte el título")
            {
                txtTitulo.Text = "";
            }
        }

        private void txtConcepto_Leave(object sender, EventArgs e)
        {
            if(txtTitulo.Text == "")
            {
                txtTitulo.Text = "Inserte el título";
            }
        }

        private void txtDefCompleto_Enter(object sender, EventArgs e)
        {
            if(txtDefCompleto.Text == "Inserte la definición")
            {
                txtDefCompleto.Text = "";
            }
        }

        private void txtDefCompleto_Leave(object sender, EventArgs e)
        {
            if(txtDefCompleto.Text == "")
            {
                txtDefCompleto.Text = "Inserte la definición";
            }
        }
    }
}
