using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            this.correo = new Correo();
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text,this.mtxtTrackingID.Text);
                nuevoPaquete.InformarEstado += paq_InformaEstado;
                this.correo += nuevoPaquete;
                this.ActualizarEstado();
            }
            catch(TrackingIdRepetidoException error)
            {
                MessageBox.Show(error.Message,"Paquete Repetido",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        private void paq_InformaEstado(object sender)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegateEstado d = new Paquete.DelegateEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender });
            }
            else
            {
                this.ActualizarEstado();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void ActualizarEstado()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach(Paquete auxPaquete in this.correo.Paquetes)
            {
                if(auxPaquete.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(auxPaquete);
                }
                else if(auxPaquete.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(auxPaquete);
                }
                else if(auxPaquete.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(auxPaquete);
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostrar.Clear();
                if(elemento is Correo)
                {
                    rtbMostrar.Text = elemento.MostrarDatos(elemento);
                }
                else if(elemento is Paquete)
                {
                    rtbMostrar.Text = elemento.ToString();
                }
                elemento.MostrarDatos(elemento).Guardar("Salida.txt");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
