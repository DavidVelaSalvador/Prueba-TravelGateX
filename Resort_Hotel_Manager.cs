using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Resort_Hotel_List_Type
    {
        public List<Resort_hotel> hotels { get; set; } = new List<Resort_hotel>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }
    public class Resort_hotel  // Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; } // variable que almacenará el codigo del hotel
        public string name { get; set; } // variable que almacenará el nombre del hotel
        public string location { get; set; } // variable que almacenará el nombre del hotel
        public List<Resort_rooms_type> rooms { get; set; } = new List<Resort_rooms_type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class Resort_rooms_type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public string code { get; set; } // variable para almacenar el codigo de la habitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
    }

    class Resort_Hotel_Manager
    {
        Resort_Hotel_List_Type Hotel_List; // variable creada para almacenar el listado de hoteles.

        public Resort_Hotel_Manager()// inicializamos la carga de datos en el constructor de la clase. para que se inicie automaticamente.
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4e43272f00006c0016a52b"); // creamos y almacenamos un string los datos recibidos de la API.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Resort_Hotel_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Resort_Hotel_List_Type para generar la lista de hoteles.
                }
                catch (Exception e)  // capturamos errores en el proceso de deserializacion.
                {
                    MessageBox.Show(e.Message); // Pasamos al Log el error para anotarlo en el log.
                }
            }
        }

        public string Hotel_Name_By_Code(string Code)// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                if (Temp_Hotel.code == Code) // si coinciden los codes
                {
                    return (Temp_Hotel.name);  // devolvemos como respuesta el nombre del hotel.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }

        public string Hotel_Room_Name_By_Code(string Code)// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                foreach(Resort_rooms_type Temp_Room_Type in Temp_Hotel.rooms )
                {
                    if (Temp_Room_Type.code == Code) // si coinciden los codes
                    {
                        return (Temp_Room_Type.name);  // devolvemos como respuesta el nombre del hotel.
                    }
                }
                
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }

        public string Hotel_Location_By_Code(string Code)// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                if (Temp_Hotel.code == Code) // si coinciden los codes
                {
                    return (Temp_Hotel.location);  // devolvemos como respuesta el nombre de la ciudad.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }
    }
}
