using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Atalaya_Meal_Plans_List // tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    {
        public List<Atalaya_Meal_Plans_Type> meal_plans { get; set; } = new List<Atalaya_Meal_Plans_Type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class Atalaya_Meal_Plans_Type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public string code { get; set; } // variable para almacenar el codigo de la habitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
        public Atalaya_Hotel_Details hotel { get; set; } = new Atalaya_Hotel_Details();  // listado para los hoteles que contienen habitaciones de este tipo.
        
    }

    public class Atalaya_Hotel_Details
    {
        public List<room_details> ave { get; set; } = new List<room_details>();  // listado para los hoteles que contienen habitaciones de este tipo.
        public List<room_details> acs { get; set; } = new List<room_details>();  // listado para los hoteles que contienen habitaciones de este tipo.
    }

    public class room_details  // Defino una clase para almacenar los precios y tipo de una habitacion.
    {
        public string room { get; set; } // variable para almacenar el tipo de la habitacion
        public int price { get; set; }  // variable para almacenar el precio por noche y persona de la habitacion
    }

    class Atalaya_Meal_Plans_Manager
    { 
        Atalaya_Meal_Plans_List Meal_Plan_List_Received;// variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.
        Atalaya_Hotel_Manager Hotel_Helper = new Atalaya_Hotel_Manager();  // Me creo un Onjeto que me ayudara ofreciendome datos de los hoteles.
        Atalaya_Rooms_Manager Rooms_Helper = new Atalaya_Rooms_Manager(); // Me creo un objeto que me ayudara pasandome los datos de las habitaciones

        public void Get_Data(List<Own_Format_Class> Oficial_List)
        {
            List<Own_Format_Class>Own_List = new List<Own_Format_Class>(); // lista que contendrá todas las habitaciones localizadas.
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la tercera API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e282f0000490097d252"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel y los regimenes de cada uno.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try // metemos un try por si falla la deserializacion.
                {
                    Meal_Plan_List_Received = JsonConvert.DeserializeObject<Atalaya_Meal_Plans_List>(Received_Data); // Deserializamos los datos Json en el objeto Meal_list para generar la lista de regimenes asignados a cada habitacion de cada hotel.
                    foreach (Atalaya_Meal_Plans_Type Temp_Meal_Plan in Meal_Plan_List_Received.meal_plans)  // recorremos la lista de regímenes recibidos.
                    {
                        
                        foreach (room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.ave) // voy a hacer un for each para cada uno de los tipos de hotel.
                        {
                            Own_Format_Class Temp_Own_Data = new Own_Format_Class(); // me creo un objeto del tipo formato nuestro para almacenar los datos que me hayan llegado de este hotel.
                            Process_Room(Temp_Own_Data,"ave", Temp_Room_Detail, Convert.ToString(Temp_Meal_Plan.code));// enviamos los datos a la fucion para que rellene los campos correspondientes.
                            Oficial_List.Add(Temp_Own_Data); // Añadimos a la lista definitiva los datos recogidos de habitaciones del hotel ave
                        }
                        foreach (room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.acs) // Repetimos el mismo proceso para las habitaciones de tipo "acs" 
                        {
                            Own_Format_Class Temp_Own_Data = new Own_Format_Class(); // me creo un objeto del tipo formato nuestro para almacenar los datos que me hayan llegado de este hotel.
                            Process_Room(Temp_Own_Data, "acs", Temp_Room_Detail, Convert.ToString(Temp_Meal_Plan.code));
                            Oficial_List.Add(Temp_Own_Data); // Añadimos a la lista definitiva los datos recogidos de habitaciones del hotel ave
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message); // si no se deserializo bien o se ha producido algun problema Mostramos un mensaje.
                }
            }
        }

        private void Process_Room(Own_Format_Class Room,string Code,room_details Received_Details, string Service_Code) // Funcion que recibe los datos de las habitaciones y construye
                                                                                                                        // el objeto con el modelo de datos nuestro propio
        {
            Room.code = Code;      // le damos valor a las distintas variables de nuestro objeto habitacion_ave.
            Room.name = Hotel_Helper.Hotel_Name_By_Code(Code); // Le pedimos al ayudante de hoteles que me de el nombre del hotel y se lo asignamos a la variable que corresponde.
            Room.city = Hotel_Helper.Hotel_City_By_Code(Code); // idem para el nombre de la ciudad.
            Room.rooms.name = Rooms_Helper.Room_Name(Received_Details.room);  // le asinnamos el nombre que el ayudante nos da para la habitacion 
            switch (Received_Details.room)  // hacemos una distincion por cada valor enumerado 0= standard, 1=suite;
            {
                case "standard":
                    Room.rooms.room_type = Room_Type_TypeData.standard; // value 0
                    break;
                case "suite":
                    Room.rooms.room_type = Room_Type_TypeData.suite;    // value 1
                    break;
            }
            switch (Service_Code) // de nuevo distincion pero en esta ocasion para el tipo de pension que tiene cada habitacion.
            {
                case "pc":
                    Room.rooms.meal_plan = Meal_Code_TypeData.pc;   // 0 = Pension Completa
                    break;
                case "mp":
                    Room.rooms.meal_plan = Meal_Code_TypeData.mp;   // 1 = Media Pension
                    break;
                case "sa":
                    Room.rooms.meal_plan = Meal_Code_TypeData.sa;   // 2 Solo alojamiento
                    break;
                case "ad":
                    Room.rooms.meal_plan = Meal_Code_TypeData.ad;   // Alojamiento y desayuno
                    break;
            }
            Room.rooms.price = Convert.ToDouble(Received_Details.price);  // guardamos el precio en la variable correspondiente convirtiendolo en un dato de tipo double.
        }
    }
}
