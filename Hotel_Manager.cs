using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System; 

namespace Prueba_TravelGateX
{
    public class Hotel_List_Type
    {
        public List<hotel> hotels { get; set; } = new List<hotel>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }
    public class hotel  // Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; } // variable que almacenará el codigo del hotel
        public string name { get; set; } // variable que almacenará el nombre del hotel
        public string city { get; set; } // variable que almacenará la ciudad del hotel
    }



    class Hotel_Manager
    {
        Hotel_List_Type Hotel_List; // variable creada para almacenar el listado de hoteles.
        
        public string Get_Data()
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"); // creamos y almacenamos un string los datos recibidos de la API.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Hotel_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                    return("Datos de hoteles cargados correctamente"); // devolvemos el mensaje de que todo ha ido bien para anotarlo en la vitacora.
                }
                catch (Exception e)  // capturamos errores en el proceso de deserializacion.
                {
                    return(e.Message); // devolvemos el error para anotarlo en el log.
                }
            }
            else
            {
                return ("No se han recibido datos."); // devolvemos el error para anotarlo en el log.
            }
        }
        public string Hotel_Code_By_Name(string Name)// Funcion que devuelve el codigo del hotel seleccionado comparandolo con el nombre
        {   
            foreach (hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el nombre de cada hotel con el nombre que nos pasan por parametros.
            {
                if (Temp_Hotel.name==Name) // si coinciden los nombres
                {
                    return (Temp_Hotel.code);  // devolvemos como respuesta el codigo del hotel.
                }
            }
            return (""); // si llegamos hasta aqui es porque no hemos encontrado nada y devolvemos una cadena vacia.
        }
        public string Hotel_Name_By_Code(string Code)// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        {
            foreach (hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
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
            foreach (hotel Temp_Hotel in Hotel_List.hotels) // recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
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
