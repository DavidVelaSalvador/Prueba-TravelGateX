using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Prueba_TrAvelGateX
{
    public class hotel  // Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }
    public class Hotel_List_Type
    {
        public List<hotel> hotels { get; set; } = new List<hotel>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class rooms_type  // Defino una clase Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public List<string> hotels { get; set; } = new List<string>();  // listado para los hoteles que contienen habitaciones de este tipo.
        public string code { get; set; } // variable para almacenar el codigo de  lahabitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
    }
    
    public class Rooms_List_Type
    {
        public List<rooms_type> rooms_type { get; set; } = new List<rooms_type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }


    class HotelManager
    {
        Hotel_List_Type Hotel_List;                      // variable creada para almacenar el listado de hoteles.
        Rooms_List_Type Rooms_List;
        public int Fill_Hotel_Names(ComboBox CmbHoteles)
        {
            
            WebClient Client = new WebClient();              // Creamos un objeto webclient para almacenar la respuesta de la API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"); // creamos y almacenamos un string los datos recibidos de la API.
            if (Received_Data.Trim() != "")                  // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                CmbHoteles.Items.Clear();                    // preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Hotel_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                }
                catch                                        // capturamos errores en el proceso de deserializacion.
                {
                    return (2);                              // cerramos devolviendo un estado de error tipo "2".
                }
                
                foreach (hotel H in Hotel_List.hotels)
                {
                    CmbHoteles.Items.Add(H.name);
                }
                return (0);                                  // cerramos devolviendo un estado sin errores.
            }
            else
            {
                
                return (1);                                  // cerramos devolviendo un estado de error tipo "1".
            }
        }

        public string Hotel_Code_By_Name(string Name)
        {
            foreach (hotel H in Hotel_List.hotels)
            {
                if (H.name==Name)
                {
                    return (H.code);
                }
            }
            return ("");
        }

        public void Fill_Room_Info(string Hotel_Name,ComboBox Cmb_Rooms)
        {
            string Hotel_Code = Hotel_Code_By_Name(Hotel_Name); // variable que contiene el codigo del hotel seleccionado.
            WebClient Client = new WebClient();              // Creamos un objeto webclient para almacenar la respuesta de la segunda API 
            string Received_Data = Client.DownloadString("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel.
            if (Received_Data.Trim() != "" && Hotel_Name != "")                  // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                Cmb_Rooms.Items.Clear();                     // preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Rooms_List = JsonConvert.DeserializeObject<Rooms_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                    foreach (rooms_type R in Rooms_List.rooms_type) // recorremos la lista de habitaciones existentes para verificar una por una si pertenecen a ese hotel.
                    {
                        foreach (string H in R.hotels)// recorremos la lista de hoteles con los que la habitacion esta relacionado.
                        if (H == Hotel_Code) // si el codigo del hotel se corresponde con alguno de los codigos de hotel existentes para esa habitacion.
                        {
                            Cmb_Rooms.Items.Add(R.name); // lo añadimos al Combobox para que se muestre.
                        }
                    }
                }
                catch                   // capturamos errores en el proceso de deserializacion.
                {

                }
            }
        }
    }
}
