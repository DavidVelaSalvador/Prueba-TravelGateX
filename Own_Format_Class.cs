using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Prueba_TravelGateX
{
    public enum Room_Type_TypeData   /// un enum para distinguir entre los tiopos de habitaciones.
    {
        standard=0 ,
        suite=1
    }
    public enum Meal_Code_TypeData /// un enum para distinguis los tipos de servicios para las habitaciones
    {
        pc = 0,
        mp = 1,
        sa = 2,
        ad = 3
    }

    public class Room_TypeData_Extra  : Room_TypeData // clase que hereda de roomtipedatra sus caracteristicas.
    {
        public int nights { get; set; } 
    }

    public class Room_TypeData  /// clase que contendra los datos concretos de cada habitacion.
    {
        public string name { get; set; } 
        public Room_Type_TypeData room_type { get; set; } /// Dato que contiene el tipo de habitacion enumerada por 0=standard y 1= suite.
        public Meal_Code_TypeData meal_plan { get; set; } /// aqui ira el regimen de alojamiento: 0=PC(pension completa),1=mp(media pension), 2=sa(Solo alojamiento) y 3= ad(alojamiento y desayuno).
        public double price { get; set; } 

    }
    class Own_Format_Class  /// Esta clase tiene una estructura propia y servirá para almacenar todos los datos necesarios que recivamos de las 3 APIS enun solo listado. 
                            ///crear este listado y transformarlo en Json es el primer punto del ejercicio.
    {
        public string code { get; set; }  
        public string name { get; set; }  
        public string city { get; set; }  
        public Room_TypeData rooms { get; set; } = new Room_TypeData(); 
    }

    class Own_Format_Class_Extra  /// Esta clase tiene una estructura propia y servirá para almacenar todos los datos
                                  /// necesarios que recivamos de las 3 APIS enun solo listado. 
                                  ///crear este listado y transformarlo en Json es el primer punto del ejercicio.
    {
        public string code { get; set; }  
        public string name { get; set; }  
        public string city { get; set; }  
        public Room_TypeData_Extra rooms { get; set; } = new Room_TypeData_Extra(); 
    }

    class Travel /// Clase que almacenará los dias que dure el viaje, todos los requerimientos de cad uno de los dias.
    {
        public List<Day_On_Travel> Days { get; set; } = new List<Day_On_Travel>(); 
        public double Credit { get; set; }  
    }

    class Day_On_Travel /// Clase que almacenará la informacion deseada para cada dia de viaje, mas tarde se usara 
                        /// para validar si las habitaciones cuadran con los deseos del cliente o no
    {
        public string city { get; set; }  
        public Room_Type_TypeData room_type { get; set; } 
        public Meal_Code_TypeData meal_plan { get; set; } 
    }

}
