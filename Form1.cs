using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace Prueba_TrAvelGateX
{
    public partial class Form1 : Form
    {
     
        public class Hotel_List
        {
            public List<hotel> hotels { get; set; }= new List<hotel>();  // new List<hotel>(); // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
        }

      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosHoteles(); // invocamos la carga de datos.
        }
        private string ObtenerDatosHotelesAtalaya() // funcion que obtiene y devuelve los datos de los diferentes hoteles Atalaya,
                                                    // devuelve un dato Json con toda la informacion obtenida o una cadena vacia si no recibe nada.
        {
            try
            {
                WebClient Client = new WebClient();   // Creamos un objeto webclient para almacenar la respuesta de la API 
                return (Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"));
            }
            catch
            {
                MessageBox.Show("No se recibieron datos de hoteles!");
                return ("");
            }
        }

        private void CargarDatosHoteles()
        {
          try 
            {
               Hotel_List Hotels = new Hotel_List(); // variable creada para almacenar el listado de hoteles una vez convertido.
               string Datos= ObtenerDatosHotelesAtalaya(); // creamos y almacenamos en un string los datos recibidos de la API.
                if (Datos != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta.
                {
                    Hotels = JsonConvert.DeserializeObject<Hotel_List>(Datos);
                    CmbHoteles.Items.Clear();
                    foreach (hotel H in Hotels.hotels)
                    {
                        CmbHoteles.Items.Add(H.name);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al convertir los datos Json.");
            }
        }
    }
}
