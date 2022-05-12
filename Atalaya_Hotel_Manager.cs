using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Atalaya_Hotel_List_Type  /// Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    {
        public List<Atalaya_hotel> hotels { get; set; } = new List<Atalaya_hotel>();  
    }
    public class Atalaya_hotel   /// Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; } 
        public string name { get; set; } 
        public string city { get; set; } 
    }

    class Atalaya_Hotel_Manager
    {
        Atalaya_Hotel_List_Type Hotel_List; /// variable creada para almacenar el listado de hoteles.

        public Atalaya_Hotel_Manager()   /// cargamos los datos en el constructor para que se carge de datos conforme se crea.
        {
            WebClient Client = new WebClient(); 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"); 
            if (Received_Data.Trim() != "") /// esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Atalaya_Hotel_List_Type>(Received_Data); 
                }
                catch (Exception e)  
                {
                    MessageBox.Show(e.Message); 
                }
            }
        }

        public string Hotel_Name_By_Code(string Code)  /// Funcion que devuelve el nombre del hotel seleccionado comparandolo con el code
        {
            foreach (Atalaya_hotel Temp_Hotel in Hotel_List.hotels) 
            {
                if (Temp_Hotel.code == Code) 
                {
                    return (Temp_Hotel.name);  
                }
            }
            return (""); 
        }


        public string Hotel_City_By_Code(string Code)  /// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        {
            foreach (Atalaya_hotel Temp_Hotel in Hotel_List.hotels) 
            {
                if (Temp_Hotel.code == Code) 
                {
                    return (Temp_Hotel.city);  
                }
            }
            return (""); 
        }
    }
}
