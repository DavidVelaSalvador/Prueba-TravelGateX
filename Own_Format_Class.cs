using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Prueba_TravelGateX
{
    /// un enum para distinguir entre los tiopos de habitaciones.
    public enum Room_Type_TypeData   
    {
        standard,
        suite
    }

    /// un enum para distinguis los tipos de servicios para las habitaciones
    public enum Meal_Code_TypeData 
    {
        pc,
        mp,
        sa,
        ad 
    }


    /// clase que hereda de roomtipedatra sus caracteristicas.
    public class Room_TypeData_Extra  : Room_TypeData 
    {
        public int nights { get; set; } 
    }


    /// clase que contendra los datos concretos de cada habitacion.
    public class Room_TypeData  
    {
        public string name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))] // se informa al convertidor json que queremos los enum como string.
        public Room_Type_TypeData room_type { get; set; } // Dato que contiene el tipo de habitacion enumerada por 0=standard y 1= suite.
        [JsonConverter(typeof(StringEnumConverter))]
        public Meal_Code_TypeData meal_plan { get; set; } // aqui ira el regimen de alojamiento: 0=PC(pension completa),1=mp(media pension), 2=sa(Solo alojamiento) y 3= ad(alojamiento y desayuno).
        public double price { get; set; } 

    }


    /// Esta clase tiene una estructura propia y servirá para almacenar todos los datos necesarios que recivamos de las 3 APIS enun solo listado. 
    /// crear este listado y transformarlo en Json es el primer punto del ejercicio.
    class Own_Format_Class  
    {
        public string code { get; set; }  
        public string name { get; set; }  
        public string city { get; set; }  
        public Room_TypeData rooms { get; set; } = new Room_TypeData();



        /// Funcion que convierte un dato de clase tipo Own_Format_Class en uno de la clase Own_Format_Class_Extra
        /// para convertirlo creamos un dato con el formato final en blanco
        /// y vamos rellenando con cada dato su correspondiente valor.
        public Own_Format_Class_Extra Convert_Data() 
        {
            Own_Format_Class_Extra Converted_Data = new Own_Format_Class_Extra(); 
            Converted_Data.city = this.city;                                      
            Converted_Data.code = this.code;                                      
            Converted_Data.name = this.name;
            Converted_Data.rooms.meal_plan = this.rooms.meal_plan;
            Converted_Data.rooms.name = this.rooms.name;
            Converted_Data.rooms.price = this.rooms.price;
            Converted_Data.rooms.room_type = this.rooms.room_type;
            Converted_Data.rooms.nights = 1;
            return (Converted_Data);
        }
    }

    /// Esta clase tiene una estructura propia y servirá para almacenar todos los datos necesarios que recibamos de las 3 APIS en un solo listado. 
    /// crear este listado y transformarlo en Json es el primer punto del ejercicio.
    class Own_Format_Class_Extra  
    {
        public string code { get; set; }  
        public string name { get; set; }  
        public string city { get; set; }  
        public Room_TypeData_Extra rooms { get; set; } = new Room_TypeData_Extra();
        
    }


    /// Clase que almacenará los dias que dure el viaje, todos los requerimientos de cad uno de los dias.
    class Travel 
    {
        public List<Day_On_Travel> Days { get; set; } = new List<Day_On_Travel>(); 
        public double Credit { get; set; }  
    }


    /// Clase que almacenará la informacion deseada para cada dia de viaje, mas tarde se usara para validar si las habitaciones cuadran con los deseos del cliente o no
    class Day_On_Travel 
    {
        public string city { get; set; }  
        public Room_Type_TypeData room_type { get; set; } 
        public Meal_Code_TypeData meal_plan { get; set; } 
    }

}
