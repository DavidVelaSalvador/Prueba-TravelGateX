using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Atalaya_Rooms_Type_List /// tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    {
        public List<Atalaya_rooms_type> rooms_type { get; set; } = new List<Atalaya_rooms_type>();  
    }

    public class Atalaya_rooms_type  /// Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public List<string> hotels { get; set; } = new List<string>();  
        public string code { get; set; } 
        public string name { get; set; }  
    }
    class Atalaya_Rooms_Manager
    {
        Atalaya_Rooms_Type_List Rooms_List; /// variable creada para almacenar el listado de Habitaciones que cada hotel usa.

        public Atalaya_Rooms_Manager()  /// cargamos los datos tal y como se crea el objeto para tenerlo disponible en el momento que se necesite.
        {
            WebClient Client = new WebClient(); 
            string Received_Data = Client.DownloadString("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036"); /// creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel.
            if (Received_Data.Trim() != "") /// esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try
                {
                    Rooms_List = JsonConvert.DeserializeObject<Atalaya_Rooms_Type_List>(Received_Data); 
                }
                catch (Exception e)  
                {
                    MessageBox.Show(e.Message); 
                }
            }
        }

        public string Room_Name(string room)  /// Funcion que devuelve el nombre de la ciudad del hotel seleccionado buscandolo por el code
        {
            foreach (Atalaya_rooms_type Temp_Room in Rooms_List.rooms_type) 
            {
                if (Temp_Room.code == room) 
                {
                    return (Temp_Room.name); 
                }
            }
            return (""); 
        }
    }
}
