using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Prueba_TravelGateX
{

    //[DataContract]
    //public class Own_Format_Json
    //{
    //    [DataMember] public string code { get; set; }
    //    [DataMember] public string name { get; set; }
    //    [DataMember] public string city { get; set; }
    //    [DataMember] public Own_Sub_Format_Json Rooms { get; set; }
    //}

    //public class Own_Sub_Format_Json
    //{
    //    [DataMember] public string name { get; set; }
    //    [DataMember] public Room_Type_TypeData room_type { get; set; }
    //    [DataMember] public Meal_Code_TypeData meal_plan { get; set; }
    //    [DataMember] public double price { get; set; }
    //}

    public enum Room_Type_TypeData
    {
        standard=0 ,
        suite=1
    }
    public enum Meal_Code_TypeData
    {
        pc = 0,
        mp = 1,
        sa = 2,
        ad = 3
    }

    public class Room_TypeData_Extra  : Room_TypeData // clase que hereda de roomtipedatra sus caracteristicas.
    {
        public int nights { get; set; } // aqui guardaremos el precio con un dato double.
    }

    public class Room_TypeData  // clase que contendra los datos concretos de cada habitacion.
    {
        public string name { get; set; } // aqui ira el nombre de la habitacion
        public Room_Type_TypeData room_type { get; set; } // Dato que conteiene el tipo de habitacion enumerada por 0=standard y 1= suite.
        public Meal_Code_TypeData meal_plan { get; set; }// aqui ira el regimen de alojamiento: 0=PC(pension completa),1=mp(media pension), 2=sa(Solo alojamiento) y 3= ad(alojamiento y desayuno).
        public double price { get; set; } // aqui guardaremos el precio con un dato double.

    }
    class Own_Format_Class  // Esta clase tiene una estructura propia y servirá para almacenar todos los datos necesarios que recivamos de las 3 APIS enun solo listado. 
                            //crear este listado y transformarlo en Json es el primer punto del ejercicio.
    {
        public string code { get; set; }  // se guardara el codigo del hotel aqui
        public string name { get; set; }  // aqui se guardara el nombre del hotel
        public string city { get; set; }  // aqui se guardara el nombre de la ciudad donde esta el hotel.
        public Room_TypeData rooms { get; set; } = new Room_TypeData(); // una lista de las habitaciones que hay por cada hotel. esta lista tambien tiene un formato propio nuestro. 
    }

    class Own_Format_Class_Extra  // Esta clase tiene una estructura propia y servirá para almacenar todos los datos necesarios que recivamos de las 3 APIS enun solo listado. 
                            //crear este listado y transformarlo en Json es el primer punto del ejercicio.
    {
        public string code { get; set; }  // se guardara el codigo del hotel aqui
        public string name { get; set; }  // aqui se guardara el nombre del hotel
        public string city { get; set; }  // aqui se guardara el nombre de la ciudad donde esta el hotel.
        public Room_TypeData_Extra rooms { get; set; } = new Room_TypeData_Extra(); // una lista de las habitaciones que hay por cada hotel. esta lista tambien tiene un formato propio nuestro. 
    }

    class Travel 
    {
        public List<Day_On_Travel> Days { get; set; } = new List<Day_On_Travel>(); // una lista de los dias que se va a estar de viaje. 
        public double Credit { get; set; }  // aqui se guardara el Credito para el viaje.
    }

    class Day_On_Travel
    {
        public string city { get; set; }  // aqui se guardara el nombre de la ciudad donde se viaja.
        public Room_Type_TypeData room_type { get; set; } // Dato que contiene el tipo de habitacion solicitada.
        public Meal_Code_TypeData meal_plan { get; set; }// aqui ira el regimen de alojamiento solicitado
    }

}
