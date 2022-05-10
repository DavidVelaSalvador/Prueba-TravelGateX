using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using Prueba_TrAvelGateX;

namespace Prueba_TravelGateX
{
    public class Rooms_Type_List // tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    {
        public List<rooms_type> rooms_type { get; set; } = new List<rooms_type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class rooms_type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public List<string> hotels { get; set; } = new List<string>();  // listado para los hoteles que contienen habitaciones de este tipo.
        public string code { get; set; } // variable para almacenar el codigo de la habitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
    }
    class Rooms_Manager
    {
        Rooms_Type_List Rooms_List; // variable creada para almacenar el listado de Habitaciones que cada hotel usa.

        public string Get_Data()
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la segunda API 
            string Received_Data = Client.DownloadString("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel.
            if (Received_Data.Trim() != "" ) // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Rooms_List = JsonConvert.DeserializeObject<Rooms_Type_List>(Received_Data); // Deserializamos los datos Json en el objeto Rooms_List_Type para generar la lista de hoteles.
                    return ("Datos de Habitaciones cargadas correctamente");
                }
                catch (Exception e)  // capturamos errores en el proceso de deserializacion.
                {
                    return (e.Message);
                }
            }
            else
            {
                return ("No se han recibido datos.");
            }
        }

        public string Room_Name(string room)// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        {
            foreach (rooms_type Temp_Room in Rooms_List.rooms_type) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
            {
                if (Temp_Room.code == room) // si coinciden los codes
                {
                    return (Temp_Room.name);  // devolvemos como respuesta el nombre de la ciudad.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }
    }
}
