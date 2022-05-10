using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System; 

namespace Prueba_TrAvelGateX
{
    public class hotel  // Defino una clase Hotel que contendrá los datos del hotel.
    {
        public string code { get; set; } // variable que almacenará el codigo del hotel
        public string name { get; set; } // variable que almacenará el nombre del hotel
        public string city { get; set; } // variable que almacenará la ciudad del hotel
    }
    public class Hotel_List_Type
    {
        public List<hotel> hotels { get; set; } = new List<hotel>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class rooms_type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public List<string> hotels { get; set; } = new List<string>();  // listado para los hoteles que contienen habitaciones de este tipo.
        public string code { get; set; } // variable para almacenar el codigo de la habitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
    }
    
    public class Rooms_List_Type
    {
        public List<rooms_type> rooms_type { get; set; } = new List<rooms_type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class room_details  // Defino una clase para almacenar los precios y tipo de una habitacion.
    {
        public string room { get; set; } // variable para almacenar el tipo de la habitacion
        public string price { get; set; }  // variable para almacenar el precio por noche y persona de la habitacion
    }

    public class room_details_list
    {
        public List<room_details> code_hotel { get; set; } = new List<room_details>(); // variable que almacena un listado de regimenes de habitaciones aceptados en el hotel.
    }

    public class Meal_Plans  // Defino una clase Regimen para almacenar la informacion de cada régimen disponible.
    {
        public string code { get; set; } // variable para almacenar el codigo del régimen
        public string name { get; set; }  // variable para almacenar el nombre del régimen
        public List<room_details_list> hotel { get; set; } = new List<room_details_list>();  // list que almacenara los diferentes regimenes por hotel y tipo de habitacion
    }

    class HotelManager
    {
        Hotel_List_Type Hotel_List; // variable creada para almacenar el listado de hoteles.
        Rooms_List_Type Rooms_List; // variable creada para almacenar el listado de Habitaciones que cada hotel usa.
        Meal_Plans Meal_List;// variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.



        public int Fill_Hotel_Names(ComboBox CmbHoteles)
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"); // creamos y almacenamos un string los datos recibidos de la API.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                CmbHoteles.Items.Clear(); // preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Hotel_List = JsonConvert.DeserializeObject<Hotel_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                }
                catch // capturamos errores en el proceso de deserializacion.
                {
                    return (2); // cerramos devolviendo un estado de error tipo "2".
                }
                foreach (hotel H in Hotel_List.hotels) // recorremos las lista de hoteles
                {
                    CmbHoteles.Items.Add(H.name); // y agregamos al combobox los nombres que vayamos encontrando.
                }
                return (0); // cerramos devolviendo un estado sin errores.
            }
            else
            {
                
                return (1); // cerramos devolviendo un estado de error tipo "1".
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

        public void Fill_Room_Info(string Hotel_Name,ComboBox Cmb_Rooms)
        {
            string Hotel_Code = Hotel_Code_By_Name(Hotel_Name); // variable que contiene el codigo del hotel seleccionado.
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la segunda API 
            string Received_Data = Client.DownloadString("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel.
            if (Received_Data.Trim() != "" && Hotel_Name != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                Cmb_Rooms.Items.Clear();// preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Rooms_List = JsonConvert.DeserializeObject<Rooms_List_Type>(Received_Data); // Deserializamos los datos Json en el objeto Hotel_List_Type para generar la lista de hoteles.
                    foreach (rooms_type Temp_Room in Rooms_List.rooms_type) // recorremos la lista de habitaciones existentes para verificar una por una si pertenecen a ese hotel.
                    {
                        foreach (string Temp_Hotel in Temp_Room.hotels) // recorremos la lista de hoteles con los que la habitacion esta relacionado.
                        if (Temp_Hotel == Hotel_Code) // si el codigo del hotel se corresponde con alguno de los codigos de hotel existentes para esa habitacion.
                        {
                            Cmb_Rooms.Items.Add(Temp_Room.name); // lo añadimos al Combobox para que se muestre.
                        }
                    }
                }
                catch  // capturamos errores en el proceso de deserializacion.
                {

                }
            }
        }

        public void Fill_Meal_Plans(ListView Lista,TextBox Tb_Code )
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la tercera API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e282f0000490097d252"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel y los regimenes de cada uno.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                Tb_Code.Text = FormattingJsonData(Received_Data);

                Lista.Items.Clear();// preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Meal_List = JsonConvert.DeserializeObject<Meal_Plans>(Received_Data); // Deserializamos los datos Json en el objeto Meal_list para generar la lista de regimenes asignados a cada habitacion de cada hotel.
                    foreach(room_details_list Temp_Meal in Meal_List.hotel)
                    {
                        ListViewItem Nodo = new ListViewItem();
                        string Temp_Code = Temp_Meal.code_hotel.ToString(); 
                        Nodo.Text = Hotel_Code_By_Name(Temp_Code);
                        Nodo.SubItems.Add (Meal_List.name);
                        Lista.Items.Add(Nodo);
                    }
                }
                catch
                {
                }
            }
        }

        private string FormattingJsonData(string Cadena)
        {
            string Aux = Cadena;
            Aux = Aux.Replace("[", Environment.NewLine + "[");
            Aux = Aux.Replace("]", Environment.NewLine + "]");
            Aux = Aux.Replace("{", Environment.NewLine + "{");
            Aux = Aux.Replace("}", Environment.NewLine + "}");
            Aux = Aux.Replace(",", "," + Environment.NewLine);
            return (Aux);
        }
    }
}
