using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
namespace arbolBinario
{
    class Nodo_Arbol
    {
        public string info;

        public Nodo_Arbol Izquierdo;
        public Nodo_Arbol Derecho;
        public Nodo_Arbol Padre;
        
        public int altura;
        public int nivel;
        public Rectangle nodo; // para dibujar arbol

        public bool visitadoIzquierda = false;
        public bool visitadoDerecha = false;
        public bool visitado = false;
        public bool vale = false;
        public bool p = true;
        public Arbol_Binario arbol
        {
            get
            {
                return arbol;
            }
            set
            {
                arbol = value;
            }
        }

        public Nodo_Arbol()
        {

        }
        public Nodo_Arbol(string nueva_info, Nodo_Arbol izquierdo, Nodo_Arbol derecho, Nodo_Arbol padre)
        {
            info = nueva_info;
            Izquierdo = izquierdo;
            Derecho = derecho;
            Padre = padre;
            altura = 0;
        }

        // 
        public Nodo_Arbol Insertar(string x, Nodo_Arbol t, int level, Nodo_Arbol padre = null)
        {

            if (t == null)
            {
                t = new Nodo_Arbol(x, null, null, padre);
                t.nivel = level;
                vale = true;
            }


            else if ( vale == false )
            {

                level++;

                t.Izquierdo = Insertar(x, t.Izquierdo, level, t);

                p = true;

                vale = true;
            }
            
            else if (vale == true  )
            {

                level++;
               
                t.Derecho = Insertar(x, t.Derecho, level, t);
                vale = false;
                
            }
            

            

            return t;

        }

        public static int Alturas(Nodo_Arbol t)
        {
            return t == null ? -1 : t.altura;
        }

        public void Eliminar(string x, ref Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x!=null && x== t.info) // Si el valor elimar es igual que la raiz
                {
                    Eliminar(x, ref t.Izquierdo);
                    vale = false;
                }
                else
                {
                    if (x!=null && x==t.info)
                    {
                        Eliminar(x, ref t.Derecho);
                        vale = true;
                    }
                    else
                    {
                        Nodo_Arbol NodoEliminar = t; // Ya se ubicó el nodo que se desea eliminar
                        if (NodoEliminar.Derecho != null && vale==true)
                        {
                            t = NodoEliminar.Izquierdo;
                        }
                        else
                        {
                            if (NodoEliminar.Izquierdo == null && vale==false)
                            {
                                t = NodoEliminar.Derecho;
                            }
                            else
                            {
                                if (Alturas(t.Izquierdo) - Alturas(t.Derecho) > 0)
                                {
                                    // para verificar que hijo pasa a ser nueva raiz del subarbol
                                    Nodo_Arbol AuxiliarNodo = null;
                                    Nodo_Arbol Auxiliar = t.Izquierdo;
                                    bool bandera = false;

                                    while (Auxiliar.Derecho != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = Auxiliar.Derecho;
                                        bandera = true;
                                    }

                                    t.info = Auxiliar.info;
                                    NodoEliminar = Auxiliar;
                                    if (bandera == true)
                                    {
                                        AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                    }
                                    else
                                    {
                                        t.Izquierdo = Auxiliar.Izquierdo;
                                    }


                                }
                                else
                                {
                                    if (Alturas(t.Derecho) - Alturas(t.Izquierdo) > 0)
                                    {
                                        Nodo_Arbol AuxiliarNodo = null;
                                        Nodo_Arbol Auxiliar = t.Derecho;

                                        bool bandera = false;

                                        while (Auxiliar.Izquierdo != null)
                                        {
                                            AuxiliarNodo = Auxiliar;
                                            Auxiliar = Auxiliar.Izquierdo;
                                            bandera = true;

                                        }

                                        t.info = Auxiliar.info;
                                        NodoEliminar = Auxiliar;

                                        if (bandera == true)
                                        {
                                            AuxiliarNodo.Izquierdo = Auxiliar.Derecho;
                                        }
                                        else
                                        {
                                            t.Derecho = Auxiliar.Derecho;
                                        }
                                    }
                                    else
                                    {
                                        if (Alturas(t.Derecho) - Alturas(t.Izquierdo) == 0)
                                        {
                                            Nodo_Arbol AuxiliarNodo = null;
                                            Nodo_Arbol Auxiliar = t.Izquierdo;
                                            bool Bandera = false;

                                            while (Auxiliar.Derecho != null)
                                            {
                                                AuxiliarNodo = Auxiliar;
                                                Auxiliar = Auxiliar.Derecho;
                                                Bandera = false;
                                            }

                                            t.info = Auxiliar.info;
                                            NodoEliminar = Auxiliar;

                                            if (Bandera == true)
                                            {
                                                AuxiliarNodo.Derecho = Auxiliar.Izquierdo;

                                            }
                                            else
                                            {
                                                t.Izquierdo = Auxiliar.Izquierdo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Nodo No existente en arbol", "Error al eliminar");
            }
        }
        public void buscar(string x, Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x !=null && x!= t.info)
                {
                    // realiza busqueda por el nodo izquierdo
                    buscar(x, t.Izquierdo);
                }
                else
                {
                    if (x !=null && x!= t.info)
                    {
                        buscar(x, t.Derecho);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo No encontrado en el arbol", "Error en la busqueda");
            }
        }

        #region "dibujo"
        private const int Radio = 30;
        private const int DistanciaH = 80;
        private const int DistanciaV = 10;
        private int CoordenadaX;
        private int CoordenadaY;

        // encuentra donde va a dibujar el nodo   
        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            CoordenadaY = (int)(ymin + Radio / 2);

            // obtiene la posicion de sub arbol izquierdo
            if (Izquierdo != null)
            {
                Izquierdo.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if ((Izquierdo != null) && (Derecho != null))
            {
                xmin += DistanciaH;
            }

            if (Derecho != null)
            {
                Derecho.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);

            }

            if (Izquierdo != null && Derecho != null)
            {
                CoordenadaX = (int)((Izquierdo.CoordenadaX + Derecho.CoordenadaX) / 2);

            }
            else if (Izquierdo != null)
            {
                aux1 = Izquierdo.CoordenadaX;
                Izquierdo.CoordenadaX = CoordenadaX - 80;
                CoordenadaX = aux1;
            }
            else if (Derecho != null)
            {
                aux2 = Derecho.CoordenadaX;
                Derecho.CoordenadaX = CoordenadaX + 80;
                CoordenadaX = aux2;

            }
            else
            {
                CoordenadaX = (int)(xmin + Radio / 2);
                xmin += Radio;

            }
        }

        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if (Izquierdo != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Izquierdo.CoordenadaX, Izquierdo.CoordenadaY);
                Izquierdo.DibujarRamas(grafo, Lapiz);
            }

            if (Derecho != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Derecho.CoordenadaX, Derecho.CoordenadaY);
                Derecho.DibujarRamas(grafo, Lapiz);
            }
        }
        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            //prueba
            grafo.FillEllipse(encuentro, rect);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);

            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;

            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);

            // dibuja los nodos hijos derecho e izquierdo
            if (Izquierdo != null)
            {
                Izquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);

            }
            if (Derecho != null)
            {
                Derecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }


        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz)
        {
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            // prueba
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);

            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);

        }

        #endregion
    }
}
