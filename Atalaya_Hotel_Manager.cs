using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Atalaya_Hotel_List_Type
    {
        public List<Atalaya_hotel> hotels { get; set; } = new List<Atalaya_hotel>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }
    public class Atalaya_hotel  // Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; } // variable que almacenará el codigo del hotel
        public string name { get; set; } // variable que almacenará el nombre del hotel
        public string city { get; set; } // variable que almacenará la ciudad del hotel
    }

    class Atalaya_Hotel_Manager
    {
        Atalaya_Hotel_List_Type Hotel_List; // variable creada para almacenar el listado de hoteles.

        public Atalaya_Hotel_Manager()// cargamos los datos en el constructor para que se carge de datos conforme se crea.
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"); // creamos y almacenamos un string los datos recibidos de la API.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Atalaya_Hotel_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                }
                catch (Exception e)  // capturamos errores en el proceso de deserializacion.
                {
                    MessageBox.Show(e.Message); // Pasamos al Log el error para anotarlo en el log.
                }
            }
        }

        public string Hotel_Name_By_Code(string Code)// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        {
            foreach (Atalaya_hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                if (Temp_Hotel.code == Code) // si coinciden los codes
                {
                    return (Temp_Hotel.name);  // devolvemos como respuesta el nombre del hotel.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }


        public string Hotel_City_By_Code(string Code)// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        {
            foreach (Atalaya_hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                if (Temp_Hotel.code == Code) // si coinciden los codes
                {
                    return (Temp_Hotel.city);  // devolvemos como respuesta el nombre de la ciudad.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }
    }
}
