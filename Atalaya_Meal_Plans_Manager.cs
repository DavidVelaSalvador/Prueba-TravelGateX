using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    /// tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    public class Atalaya_Meal_Plans_List 
    {
        public List<Atalaya_Meal_Plans_Type> meal_plans { get; set; } = new List<Atalaya_Meal_Plans_Type>();  
    }


    /// Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    public class Atalaya_Meal_Plans_Type  
    {
        public string code { get; set; } 
        public string name { get; set; }  
        public Atalaya_Hotel_Details hotel { get; set; } = new Atalaya_Hotel_Details();  
        
    }

    public class Atalaya_Hotel_Details
    {
        public List<room_details> ave { get; set; } = new List<room_details>();  
        public List<room_details> acs { get; set; } = new List<room_details>();  
    }


    /// Defino una clase para almacenar los precios y tipo de una habitacion.
    public class room_details  
    {
        public string room { get; set; } 
        public int price { get; set; }  
    }



    class Atalaya_Meal_Plans_Manager
    { 
        Atalaya_Meal_Plans_List Meal_Plan_List_Received;                      // variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.
        Atalaya_Hotel_Manager Hotel_Helper = new Atalaya_Hotel_Manager();     // Me creo un Onjeto que me ayudara ofreciendome datos de los hoteles.
        Atalaya_Rooms_Manager Rooms_Helper = new Atalaya_Rooms_Manager();     // Me creo un objeto que me ayudara pasandome los datos de las habitaciones



        /// funcion que generará la lista a partir de la API solicitando a cada helper la informacion que requiera.
        /// recorremos la lista de regímenes recibidos.
        /// voy a hacer un foreach para cada uno de los tipos de hotel. "ave" y "acs"
        /// en cada paso me creo un objeto para almacenar los datos
        /// enviamos los datos a la funcion para que rellene los campos correspondientes.
        /// y lo añadimos a la lista definitiva.
        public void Get_Data(List<Own_Format_Class> Oficial_List)
        {
            List<Own_Format_Class>Own_List = new List<Own_Format_Class>();     // lista que contendrá todas las habitaciones localizadas.
            WebClient Client = new WebClient(); 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e282f0000490097d252"); 
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try 
                {
                    Meal_Plan_List_Received = JsonConvert.DeserializeObject<Atalaya_Meal_Plans_List>(Received_Data); 
                    foreach (Atalaya_Meal_Plans_Type Temp_Meal_Plan in Meal_Plan_List_Received.meal_plans)  
                    {
                        
                        foreach (room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.ave) 
                        {
                            Own_Format_Class Temp_Own_Data = new Own_Format_Class();       
                            Process_Room(Temp_Own_Data,"ave", Temp_Room_Detail, Convert.ToString(Temp_Meal_Plan.code)); 
                            Oficial_List.Add(Temp_Own_Data); 
                        }
                        foreach (room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.acs) 
                        {
                            Own_Format_Class Temp_Own_Data = new Own_Format_Class();       
                            Process_Room(Temp_Own_Data, "acs", Temp_Room_Detail, Convert.ToString(Temp_Meal_Plan.code));
                            Oficial_List.Add(Temp_Own_Data); 
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message); 
                }
            }
        }


        /// Funcion que recibe los datos de las habitaciones y construye el objeto con el modelo de datos nuestro propio
        /// le damos valor a las distintas variables de nuestro objeto.
        /// Le pedimos al ayudante de hoteles que me de el nombre del hotel y se lo asignamos a la variable que corresponde.
        /// le asinnamos el nombre que el ayudante nos da para la habitacion 
        /// hacemos una distincion por cada valor enumerado 0= standard, 1=suite;
        /// de nuevo distincion pero en esta ocasion para el tipo de pension que tiene cada habitacion.
        /// guardamos el precio convirtiendolo en un dato de tipo double.
        private void Process_Room(Own_Format_Class Room,string Code,room_details Received_Details, string Service_Code) {
            Room.code = Code;      
            Room.name = Hotel_Helper.Hotel_Name_By_Code(Code); 
            Room.city = Hotel_Helper.Hotel_City_By_Code(Code); 
            Room.rooms.name = Rooms_Helper.Room_Name(Received_Details.room);  
            switch (Received_Details.room)  
            {
                case "standard":
                    Room.rooms.room_type = Room_Type_TypeData.standard; // standard
                    break;
                case "suite":
                    Room.rooms.room_type = Room_Type_TypeData.suite;    // suite
                    break;
            }
            switch (Service_Code) 
            {
                case "pc":
                    Room.rooms.meal_plan = Meal_Code_TypeData.pc;   // Pension Completa
                    break;
                case "mp":
                    Room.rooms.meal_plan = Meal_Code_TypeData.mp;   // Media Pension
                    break;
                case "sa":
                    Room.rooms.meal_plan = Meal_Code_TypeData.sa;   // Solo alojamiento
                    break;
                case "ad":
                    Room.rooms.meal_plan = Meal_Code_TypeData.ad;   // Alojamiento y desayuno
                    break;
            }
            Room.rooms.price = Convert.ToDouble(Received_Details.price);  
        }
    }
}
