using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Resort_Meal_Plans_List // tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    {
        public List<Resort_Meal_Plans_Type> regimenes { get; set; } = new List<Resort_Meal_Plans_Type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }
    public class Resort_Meal_Plans_Type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public string code { get; set; } // variable para almacenar el codigo de lRegimen
        public string name { get; set; }  // variable para almacenar el nombre del Regimen
        public string hotel { get; set; }  // variable para almacenar el codigo del hotel
        public string room_type { get; set; }  // variable para almacenar el tipo de la habitacion
        public string price { get; set; }  // variable para almacenar el precio de la habitacion
    }
    class Resort_Meal_Plans_Manager
    {
        Resort_Meal_Plans_List Meal_Plan_List_Received;// variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.
        Resort_Hotel_Manager Resort_Hotel_Helper = new Resort_Hotel_Manager();  // Me creo un Onjeto que me ayudara ofreciendome datos de los hoteles.

        public void Get_Data(List<Own_Format_Class> Oficial_List)// funcion que recoge de la api los datos y los va cargando a una lista que se le ha pasado por parámetro con nuestro formato propio.
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la tercera API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7dd02f0000290097d24b"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel y los regimenes de cada uno.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try // metemos un try por si falla la deserializacion.
                {
                    Meal_Plan_List_Received = JsonConvert.DeserializeObject<Resort_Meal_Plans_List>(Received_Data); // Deserializamos los datos Json en el objeto Meal_list para generar la lista de regimenes asignados a cada habitacion de cada hotel.
                    foreach (Resort_Meal_Plans_Type Temp_Meal_Plan in Meal_Plan_List_Received.regimenes)  // recorremos la lista de regímenes recibidos.
                    {
                        Own_Format_Class Temp_Own_Data = new Own_Format_Class(); // me creo un objeto del tipo formato nuestro para almacenar los datos que me hayan llegado de este hotel.
                        Temp_Own_Data.code = Temp_Meal_Plan.hotel;   // asignamos el codigo del hotel.
                        Temp_Own_Data.name = Resort_Hotel_Helper.Hotel_Name_By_Code(Temp_Meal_Plan.hotel);   // Le pedimos al ayudante que nos traduzca el nombre del hotel y lo asignamos.
                        Temp_Own_Data.city = Resort_Hotel_Helper.Hotel_Location_By_Code(Temp_Meal_Plan.hotel);  // Le pedimos al ayudante que nos traduzca la ciudad del hotel y lo asignamos.
                        Temp_Own_Data.rooms.name = Resort_Hotel_Helper.Hotel_Room_Name_By_Code(Temp_Meal_Plan.room_type);  // le asinnamos el nombre que el ayudante nos da para la habitacion 
                        Temp_Own_Data.rooms.price = Convert.ToDouble(Temp_Meal_Plan.price);  // convertimos el precio a dopuble y se lo asignamos.
                        switch (Temp_Meal_Plan.room_type)  // hacemos una distincion por cada valor enumerado 0= st(Standard), 1=su(Suite);
                        {
                            case "st":
                                Temp_Own_Data.rooms.room_type = Room_Type_TypeData.standard; // value 0
                                break;
                            case "su":
                                Temp_Own_Data.rooms.room_type = Room_Type_TypeData.suite;    // value 1
                                break;
                        }
                        switch (Temp_Meal_Plan.code) // de nuevo distincion pero en esta ocasion para el tipo de pension que tiene cada habitacion.
                        {
                            case "pc":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.pc;   // 0 = Pension Completa
                                break;
                            case "mp":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.mp;   // 1 = Media Pension
                                break;
                            case "sa":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.sa;   // 2 Solo alojamiento
                                break;
                            case "ad":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.ad;   // Alojamiento y desayuno
                                break;
                        }
                        Oficial_List.Add(Temp_Own_Data); // Añadimos a la lista que se nos paso por parametro el registro que acabamos de crear y rellenar.
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); // si no se deserializo bien o se ha producido algun problema Mostramos un mensaje.
                }
            }
        }
    }

}
