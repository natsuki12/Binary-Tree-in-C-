#include <iostream>
#include <string>
#include <stdlib.h>
#include <fstream>
using namespace std;
 

string contenido;
int dato=0;
int monto=0;
int familias=0;
int pagod=0;
int opcion; 

int main()
{

    do
    {
        // Menu principal
        cout << endl;
        system("cls"); //Limpia la pantalla con ms dos.
        cout << "BIENVENIDO AL SISTEMA DE MUSIPAN, SELECIONE UNA OPCION PARA COMENZAR:" << endl;
        cout << "1.- PARQUE TEMATICO 'MUSIPAN EL REINO!'" << endl;
        cout << "2.- HOTEL MUSIPAN VILLAS" << endl;
        cout << "3.- HOTEL LA POSADA DEL REINO" << endl;
        cout << "4.- Salir" << endl;
        cout << "Numero de familiares en las instalaciones es..."<<familias<<endl; 
        cout << "El dinero Total Recaudado Por Pago en las instalaciones es..."<<pagod;
 
        cin >> opcion;
        // Hacemos una cosa u otra según la opción escogida
        switch(opcion)
        {
            case 1: do
            {
                 cout<<endl;
                 system("cls"); //Limpia la pantalla con ms dos.
                 cout<<"PORFAVOR SELECIONE UNA OPCION"<<endl;//SE CREA UN MENU PARA ELEGIR QUE SE HARA EN LA INSTALACION//
                 cout<<"1  CREAR FACTURA"<<endl;
                 cout<<"2  MOSTRAR TODAS LAS FACTURAS"<<endl;
                 cout<<"3  MODIFICAR FACTURA"<<endl;
                 cout<<"4  SALIR"<<endl;
                 
                 cin>>opcion;
                 switch(opcion)
                 {
                               case 1:{
  system("cls"); //Limpia la pantalla con ms dos.
  cout << "POR FAVOR INGRESA EL CONTENIDO DE SU FACTURA: ";
  cin.ignore();
  getline(cin, contenido);
  ofstream fs("Parque.txt");
  fs << contenido << endl;
  fs.close();
  cout << "El archivo ha sido creado correctamente " << endl;
  cout <<"PORFAVOR INGRESE NUMERO DE FAMILIARES QUE LO ACOMPAÑARON (SI LO ANTERIORMENTE INGRESE 0) ";
  cin>>dato;
  cout<<"INGRESE NUEVAMENTE MONTO A PAGAR ";
  cin>>monto;
  pagod=pagod+monto;
  familias=familias+dato;
  system("pause");
  break;
}
                               break;
                               case 2:{
                               system("cls"); //Limpia la pantalla con ms dos.
                               ifstream fs("Parque.txt", ios::in);
                               char linea[128];
                               long contador = 0L;
                               if(fs.fail())
                               cerr << "El fichero no existe" << endl;
                               else
                               while(!fs.eof())
                               {
                               fs.getline(linea, sizeof(linea));
                               cout << linea << endl;
                               if((++contador % 24)==0)
                               {
                               cout << "continuar...";
                               cin.get();
                               }
                               }
                            fs.close();
                           system("pause");
                          break;
                         }
                                case 3:{
                                string buscar;      // texto a buscar
                                string reemplazar;  // reemplazar por

                                                    //ingresa textos
                                cout << "Ingresa el texto a buscar: ";
                                cin.ignore();
                                getline(cin, buscar);
                                cout << "Ingresa el texto para reemplazarlo ''porfavor antes de escribir presione la tecla espacio'': ";
                                cin.ignore();
                                getline(cin, reemplazar);


                                ifstream fs("parque.txt"); //leer de este archivo
                                ofstream fstemp("parquetemp.txt"); //escribir en este archivo
                                if(!fs || !fstemp) //no se pudo abrir alguno de los 2
                                {
                                  cout << "Error al abrir el archivo!" << endl;
                                     break;
                               }

                                //modificar linea a linea
                              while(fs >> contenido)
                               {
                                if(contenido == buscar){  //se encontro
                                       contenido = reemplazar; //reemplazar
                                                       }
                                       fstemp << contenido << endl;
                                                      }

                                    //reemplazar un archivo por otro
                                    fs.close();
                                    fstemp.close();
                                    remove("parque.txt");                    // borrar el original
                                    rename("parquetemp.txt", "parque.txt");  // renombrar el temporal

                                    //siguiendo la logica que usaste en el resto
                                    cout << "El archivo ha sido modificado correctamente" << endl;
                                    system("pause");
                                    break;
                                 }
                               }
                               break;
                               
                               
                                    
                                    
                 } while (opcion != 4);  // Si la opcion es 11, terminamos
                 break;
 
            case 2: do
            {
                 cout<<endl;
                 cout<<"porfavor selecione una opcion"<<endl;//SE CREA UN MENU PARA ELEGIR QUE SE HARA EN LA INSTALACION//
                 cout<<"1  CREAR FACTURA"<<endl;
                 cout<<"2  MOSTRAR TODAS LAS FACTURAS"<<endl;
                 cout<<"3  MODIFICAR FACTURA"<<endl;
                 cout<<"4  SALIR"<<endl;
                 cin>>opcion;
                 switch(opcion)
                 {
        case 1:{
  cout << "Ingresa el contenido del archivo: ";
  cin.ignore();
  getline(cin, contenido);
  ofstream fs("hotel.txt");
  fs << contenido << endl;
  fs.close();
  cout << "El archivo ha sido creado correctamente" << endl;
  cout <<"PORFAVOR INGRESE NUMERO DE FAMILIARES QUE LO ACOMPAÑARON (SI LO ANTERIORMENTE INGRESE 0) ";
  cin>>dato;
  cout<<" INGRESE NUEVAMENTE MONTO A PAGAR ";
  cin>>monto;
  pagod=pagod+monto;
  familias=familias+dato;
  system("pause");
  break;
}
                               break;
       case 2:{
  ifstream fs("hotel.txt", ios::in);
  char linea[128];
  long contador = 0L;
  if(fs.fail())
  cerr << "El fichero no existe" << endl;
  else
  while(!fs.eof())
  {
      fs.getline(linea, sizeof(linea));
      cout << linea << endl;
      if((++contador % 24)==0)
      {
          cout << "continuar...";
          cin.get();
      }
  }
  fs.close();
  system("pause");
  break;
}
       case 3:{
  string buscar;      // texto a buscar
  string reemplazar;  // reemplazar por

  //ingresa textos
  cout << "Ingresa el texto a buscar: ";
  cin.ignore();
  getline(cin, buscar);
  cout << "Ingresa el texto para reemplazarlo ''porfavor antes de escribir presione la tecla espacio'': ";
  cin.ignore();
  getline(cin, reemplazar);


  ifstream fs("hotel.txt"); //leer de este archivo
  ofstream fstemp("hoteltemp.txt"); //escribir en este archivo
  if(!fs || !fstemp) //no se pudo abrir alguno de los 2
  {
    cout << "Error al abrir el archivo!" << endl;
    break;
  }

  //modificar linea a linea
  while(fs >> contenido)
  {
    if(contenido == buscar){  //se encontro
      contenido = reemplazar; //reemplazar
    }
    fstemp << contenido << endl;
  }

  //reemplazar un archivo por otro
  fs.close();
  fstemp.close();
  remove("hotel.txt");                    // borrar el original
  rename("hoteltemp.txt", "hotel.txt");  // renombrar el temporal

  //siguiendo la logica que usaste en el resto
  cout << "El archivo ha sido modificado correctamente" << endl;
  system("pause");
  break;
}
}
break;
                               
                               
                                    
                                    
} while (opcion != 4);  // Si la opcion es 11, terminamos
                 break;
 
            case 3: do
            {
                 cout<<endl;
                 cout<<"selecione opcion"<<endl;//SE CREA UN MENU PARA ELEGIR QUE SE HARA EN LA INSTALACION//
                 cout<<"1  CREAR FACTURA"<<endl;
                 cout<<"2  MOSTRAR TODAS LAS FACTURAS"<<endl;
                 cout<<"3  MODIFICAR FACTURA"<<endl;
                 cout<<"4  SALIR"<<endl;
                 
                 cin>>opcion;
                 switch(opcion)
                 {
            case 1:{
  cout << "Ingresa el contenido del archivo: ";
  cin.ignore();
  getline(cin, contenido);
  ofstream fs("posada.txt");
  fs << contenido << endl;
  fs.close();
  cout << "El archivo ha sido creado correctamente" << endl;
  cout <<"PORFAVOR INGRESE NUMERO DE FAMILIARES QUE LO ACOMPAÑARON (SI LO ANTERIORMENTE INGRESE 0) ";
  cin>>dato;
  cout<<" INGRESE NUEVAMENTE MONTO A PAGAR";
  cin>>monto;
  pagod=pagod+monto;
  familias=familias+dato;
  system("pause");
  break;
}
                               break;
            case 2:{
  ifstream fs("posada.txt", ios::in);
  char linea[128];
  long contador = 0L;
  if(fs.fail())
  cerr << "El fichero no existe" << endl;
  else
  while(!fs.eof())
  {
      fs.getline(linea, sizeof(linea));
      cout << linea << endl;
      if((++contador % 24)==0)
      {
          cout << "continuar...";
          cin.get();
      }
  }
  fs.close();
  system("pause");
  break;
}
            case 3:{
  string buscar;      // texto a buscar
  string reemplazar;  // reemplazar por

  //ingresa textos
  cout << "Ingresa el texto a buscar: ";
  cin.ignore();
  getline(cin, buscar);
  cout << "Ingresa el texto para reemplazarlo ''porfavor antes de escribir presione la tecla espacio'': ";
  cin.ignore();
  getline(cin, reemplazar);


  ifstream fs("posada.txt"); //leer de este archivo
  ofstream fstemp("posadatemp.txt"); //escribir en este archivo
  if(!fs || !fstemp) //no se pudo abrir alguno de los 2
  {
    cout << "Error al abrir el archivo!" << endl;
    break;
  }

  //modificar linea a linea
  while(fs >> contenido)
  {
    if(contenido == buscar){  //se encontro
      contenido = reemplazar; //reemplazar
    }
    fstemp << contenido << endl;
  }

  //reemplazar un archivo por otro
  fs.close();
  fstemp.close();
  remove("posada.txt");                    // borrar el original
  rename("posadatemp.txt", "posada.txt");  // renombrar el temporal

  //siguiendo la logica que usaste en el resto
  cout << "El archivo ha sido modificado correctamente" << endl;
  system("pause");
  break;
}
                               }
                               break;
                               
                               
                                    
                                    
                 } while (opcion != 3);  // Si la opcion es 4, terminamos
                 break;
                }
    } while (opcion != 4);  // Si la opcion es 4, terminamos

    return 0; //CODIGO CREADO POR CESAR REQUENA PARA LA MATERIA PORGRAMACION 2 PROFESORA GEORGELYS MARCANO//
}




