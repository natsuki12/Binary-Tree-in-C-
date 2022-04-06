using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arbolBinario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Dato = "";
        string cont = "";

        Arbol_Binario mi_Arbol = new Arbol_Binario(null);
        Graphics g;
        string texto = "";

        Boolean existe(Nodo_Arbol nodo)
        {
            try { string x =nodo.info; return true; }
            catch { return false; }
        }


        void preOrden(Nodo_Arbol nodo)
        {
            if (existe(nodo))
            {
                texto += texto.Equals("") ? nodo.info + "" : " - " + nodo.info;
                preOrden(nodo.Izquierdo);
                preOrden(nodo.Derecho);
            }
        }


        void enOrden(Nodo_Arbol nodo)
        {
            if (existe(nodo))
            {
                enOrden(nodo.Izquierdo);
                texto += texto.Equals("") ? nodo.info + "" : " - " + nodo.info;
                enOrden(nodo.Derecho);
            }
        }

        void postOrden(Nodo_Arbol nodo)
        {
            if (existe(nodo))
            {
                postOrden(nodo.Izquierdo);
                postOrden(nodo.Derecho);
                texto += texto.Equals("") ? nodo.info + "" : " - " + nodo.info;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g = e.Graphics;
            mi_Arbol.DibujarArbol(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, Brushes.White);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor");
            }
            else
            {
                Dato = Convert.ToString(txtDato.Text);
                if (Dato == Convert.ToString(20))
                {
                    MessageBox.Show("Solo recibe valores desde 1 hasta 99", "Error de ingreso");
                }
                else
                {
                    mi_Arbol.Insertar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();

                    
                    Refresh();
                    Refresh();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (txtEliminarNodo.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor");
            }
            else
            {
                Dato = Convert.ToString(txtEliminarNodo.Text);
                mi_Arbol.Eliminar(Dato);
                txtEliminarNodo.Clear();
                txtEliminarNodo.Focus();

               
                Refresh();
                Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mi_Arbol.inOrden(mi_Arbol.Raiz);
            mi_Arbol.finalizo = false;
            mi_Arbol.recorrido = new List<string>();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
