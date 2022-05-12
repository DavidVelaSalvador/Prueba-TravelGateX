using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    /// tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    public class Resort_Meal_Plans_List     
    {
        public List<Resort_Meal_Plans_Type> regimenes { get; set; } = new List<Resort_Meal_Plans_Type>();  
    }


    /// Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    public class Resort_Meal_Plans_Type     
    {
        public string code { get; set; } 
        public string name { get; set; }  
        public string hotel { get; set; } 
        public string room_type { get; set; }  
        public string price { get; set; }  
    }



    class Resort_Meal_Plans_Manager
    {
        Resort_Meal_Plans_List Meal_Plan_List_Received;                         // variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.
        Resort_Hotel_Manager Resort_Hotel_Helper = new Resort_Hotel_Manager();  // Me creo un Onjeto que me ayudara ofreciendome datos de los hoteles.



        /// funcion que recoge de la api los datos y los va cargando a una lista que se le ha pasado por parámetro con nuestro formato propio.
        /// recorremos la lista de regímenes recibidos.
        /// me creo un objeto con caracter temporal para almacenar los datos de este hotel.
        /// Le pedimos a los ayudantes que nos traduzcan los datos que necesitemos y los asignamos.
        /// convertimos el precio a double y se lo asignamos.
        /// hacemos una distincion por cada valor enumerado 0= st(Standard), 1=su(Suite);
        /// de nuevo distincion pero en esta ocasion para el tipo de pension que tiene cada habitacion.
        /// Añadimos a la lista que se nos paso por parametro el registro que acabamos de crear y rellenar.
        public void Get_Data(List<Own_Format_Class> Oficial_List)               
        {
            WebClient Client = new WebClient();      
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7dd02f0000290097d24b"); 
            if (Received_Data.Trim() != "")     // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                try 
                {
                    Meal_Plan_List_Received = JsonConvert.DeserializeObject<Resort_Meal_Plans_List>(Received_Data); 
                    foreach (Resort_Meal_Plans_Type Temp_Meal_Plan in Meal_Plan_List_Received.regimenes)  
                    {
                        Own_Format_Class Temp_Own_Data = new Own_Format_Class();     
                        Temp_Own_Data.code = Temp_Meal_Plan.hotel;   
                        Temp_Own_Data.name = Resort_Hotel_Helper.Hotel_Name_By_Code(Temp_Meal_Plan.hotel);      
                        Temp_Own_Data.city = Resort_Hotel_Helper.Hotel_Location_By_Code(Temp_Meal_Plan.hotel);  
                        Temp_Own_Data.rooms.name = Resort_Hotel_Helper.Hotel_Room_Name_By_Code(Temp_Meal_Plan.room_type);  
                        Temp_Own_Data.rooms.price = Convert.ToDouble(Temp_Meal_Plan.price);     
                        switch (Temp_Meal_Plan.room_type)    
                        {
                            case "st":
                                Temp_Own_Data.rooms.room_type = Room_Type_TypeData.standard; // standard
                                break;
                            case "su":
                                Temp_Own_Data.rooms.room_type = Room_Type_TypeData.suite;    // suite
                                break;
                        }
                        switch (Temp_Meal_Plan.code) 
                        {
                            case "pc":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.pc;   // Pension Completa
                                break;
                            case "mp":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.mp;   // Media Pension
                                break;
                            case "sa":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.sa;   // Solo alojamiento
                                break;
                            case "ad":
                                Temp_Own_Data.rooms.meal_plan = Meal_Code_TypeData.ad;   // Alojamiento y desayuno
                                break;
                        }
                        Oficial_List.Add(Temp_Own_Data);       
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); 
                }
            }
        }
    }

}
