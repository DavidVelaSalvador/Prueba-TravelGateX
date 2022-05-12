using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{

    /// Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    public class Resort_Hotel_List_Type
    {
        public List<Resort_hotel> hotels { get; set; } = new List<Resort_hotel>();  
    }



    /// Defino una clase Hotel que contendrá los datos del hotel.
    public class Resort_hotel  
    {
        public string code { get; set; } 
        public string name { get; set; } 
        public string location { get; set; } 
        public List<Resort_rooms_type> rooms { get; set; } = new List<Resort_rooms_type>();  
    }



    /// Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    public class Resort_rooms_type  
    {
        public string code { get; set; } 
        public string name { get; set; } 
    }




    class Resort_Hotel_Manager
    {
        Resort_Hotel_List_Type Hotel_List; // variable creada para almacenar el listado de hoteles.



        /// inicializamos la carga de datos en el constructor de la clase. para que se inicie automaticamente.
        /// creamos y almacenamos un string los datos recibidos de la API.
        public Resort_Hotel_Manager()  
        {
            WebClient Client = new WebClient(); 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4e43272f00006c0016a52b"); 
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Resort_Hotel_List_Type>(Received_Data); 
                }
                catch (Exception e)  
                {
                    MessageBox.Show(e.Message); 
                }
            }
        }



        /// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        /// recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
        public string Hotel_Name_By_Code(string Code)
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) 
            {
                if (Temp_Hotel.code == Code) 
                {
                    return (Temp_Hotel.name);
                }
            }
            return (""); 
        }


        /// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        /// recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
        public string Hotel_Room_Name_By_Code(string Code)         
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) 
            {
                foreach(Resort_rooms_type Temp_Room_Type in Temp_Hotel.rooms )
                {
                    if (Temp_Room_Type.code == Code) 
                    {
                        return (Temp_Room_Type.name);
                    }
                }
                
            }
            return (""); 
        }



        /// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        /// recorremos la lista de hoteles comparando el code de cada hotel con el code que nos pasan por parametros.
        public string Hotel_Location_By_Code(string Code)          
        {
            foreach (Resort_hotel Temp_Hotel in Hotel_List.hotels) 
            {
                if (Temp_Hotel.code == Code) 
                {
                    return (Temp_Hotel.location);  
                }
            }
            return (""); 
        }
    }
}
