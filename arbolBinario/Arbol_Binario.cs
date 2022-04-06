using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace arbolBinario
{
    class Arbol_Binario
    {
        public Nodo_Arbol Raiz;
        public Nodo_Arbol aux;
        


        public Arbol_Binario()
        {
            aux = new Nodo_Arbol();
        }

        public Arbol_Binario(Nodo_Arbol nueva_raiz)
        {
            Raiz = nueva_raiz;
        }

        public void Insertar( string x)
        {
           
            if (Raiz == null)
            {
                Raiz = new Nodo_Arbol(x, null, null,null);
                Raiz.nivel = 0;
                
            }
            else
            {
                Raiz = Raiz.Insertar(x, Raiz, Raiz.nivel);

            }
        }
        public void Eliminar(string x)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo_Arbol(x, null,null, null);
            }
            else
            {
                Raiz.Eliminar(x, ref Raiz);
            }
        }

        public List<string> recorrido = new List<string>();
        public bool finalizo = false;
        public void inOrden(Nodo_Arbol nodoEvaluar)
        {
            // izquierda, raiz, derecha 
            if (nodoEvaluar == null || finalizo)
            {
                nodoEvaluar = null;
                finalizo = true;
                return;
            }
            else
            {
                if (nodoEvaluar.visitadoDerecha && nodoEvaluar.visitadoIzquierda && nodoEvaluar.visitado && !finalizo)
                {
                    nodoEvaluar.visitadoIzquierda = false;
                    nodoEvaluar.visitadoDerecha = false;
                    nodoEvaluar.visitado = false;
                    inOrden(nodoEvaluar.Padre);
                }
                if (nodoEvaluar.Izquierdo != null && nodoEvaluar.visitadoIzquierda == false && !finalizo)
                {
                    nodoEvaluar.visitadoIzquierda = true;
                    inOrden(nodoEvaluar.Izquierdo);
                }


                if ((nodoEvaluar.Izquierdo == null || nodoEvaluar.visitadoIzquierda) && !finalizo)
                {
                    if (nodoEvaluar.Izquierdo == null && !finalizo)
                    {
                        nodoEvaluar.visitadoIzquierda = true;
                    }
                    recorrido.Add(nodoEvaluar.info);
                    nodoEvaluar.visitado = true;
                    if (nodoEvaluar.Derecho != null && !nodoEvaluar.visitadoDerecha && !finalizo)
                    {
                        nodoEvaluar.visitadoDerecha = true;
                        inOrden(nodoEvaluar.Derecho);
                    }
                    if (nodoEvaluar.Padre != null && !finalizo)
                    {
                        if (nodoEvaluar.Derecho == null)
                        {
                            nodoEvaluar.visitadoDerecha = true;
                        }
                        inOrden(nodoEvaluar.Padre);
                    }
                    else
                    {
                        inOrden(nodoEvaluar.Padre);
                    }
                    /*else
                    {
                        nodoEvaluar.visitadoDerecha = true;

                        inOrden(nodoEvaluar.Derecho);
                    }*/
                }
            }



        }
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            int x = 400;
            int y = 75;

            if (Raiz == null)
            {
                return;
            }

            Raiz.PosicionNodo(ref x, y);
            Raiz.DibujarRamas(grafo, Lapiz);
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);

        }
        public int x1 = 400;
        public int y2 = 75;

        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Nodo_Arbol Raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                }
            }
            else if (preor)
            {
                Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                Thread.Sleep(1000);
                Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);


            }
            else if (post)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);

                }
            }
        }

    }
}
