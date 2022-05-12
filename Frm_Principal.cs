using Prueba_TravelGateX;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Prueba_TravelGateX
{

    public partial class Frm_Principal : Form
    {
        readonly private Atalaya_Meal_Plans_Manager Atalaya_Plans_Manager = new Atalaya_Meal_Plans_Manager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de las habitaciones de los hoteles atalaya
        readonly private Resort_Meal_Plans_Manager Resort_Plans_Manager = new Resort_Meal_Plans_Manager(); //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de las habitaciones de los hoteles resort
        List<Own_Format_Class> Oficial_Room_List = new List<Own_Format_Class>();// lista que contendrá todo los datos ya procesados y organizados bajo nuestro formato.

        public Frm_Principal()
        {
            try
            {
                InitializeComponent(); // se inicializan los componentes.
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);// si hubiese algun error lo presentamos en un mensaje.
            }
        }

        private void Btn_Get_Data_Click(object sender, EventArgs e) // al pulsar el Boton Get data se ejecuta toda la captura y presentacion de los datos en la pantalla.
        {
            Oficial_Room_List.Clear();
            Atalaya_Plans_Manager.Get_Data(Oficial_Room_List);// Invocamos la orden al gestor de los hoteles Atalaya para rellenar la lista de datos
            Resort_Plans_Manager.Get_Data(Oficial_Room_List);// Invocamos la orden al gestor de los hoteles Resort para rellenar la lista de datos

            Lista.Items.Clear(); 
            foreach (Own_Format_Class Room_Data in Oficial_Room_List)  // recorremos la lista de datos para ir presentandolos.
            {
                ListViewItem Nodo = new ListViewItem(); // Creamos un Nodo para la lista y o vamos rellenando de datos.
                Nodo.Text = Room_Data.name;  
                Nodo.SubItems.Add(Room_Data.city);  
                Nodo.SubItems.Add(Room_Data.rooms.name); 
                Nodo.SubItems.Add(Convert.ToString(Room_Data.rooms.room_type)); 
                switch (Convert.ToInt32(Room_Data.rooms.meal_plan)) 
                {
                    case 0: Nodo.SubItems.Add("Pensión Completa");
                        break;
                    case 1: Nodo.SubItems.Add("Media Pensión");
                        break;
                    case 2: Nodo.SubItems.Add("Solo alojamiento");
                        break;
                    case 3: Nodo.SubItems.Add("Alojamiento y desayuno");
                        break;
                }
                Nodo.SubItems.Add(Convert.ToString(Room_Data.rooms.price)); // cargamos el precio
                Lista.Items.Add(Nodo);  // por ultimo añadimos el nodo creado a la lista. 
            }
            Btn_Travel.Enabled = Oficial_Room_List.Count > 0;  // bloqueamos la disponibilidad del boton a haber obtenido informacion de habitaciones.
            // Cargamos en el Cuadro de texto el resultado de convertir la lista a Json con un formateo adecuado para presentarlo.
            Tb_Code.Text = JsonConvert.SerializeObject(Oficial_Room_List, Formatting.Indented);
            if (Lista.Items.Count > 0)   // Si tenemos algo en la lista seleccionamos el primer elemento
            {
                Lista.Items[0].Selected = true; 
            }
        }

        private Travel Set_Up_Travel() /// Funcion que prepara un viaje y lo devuelve al sistema para calcular el presupuesto del mismo.
        {
            Day_On_Travel Day_1 = new Day_On_Travel();                   /// Vamos a ir dando de alta varios dias de viaje 
            Travel Programmed_Travel = new Travel();                     /// y configurando los deseos de la prueba uno por
            Programmed_Travel.Credit = 700;                              ///  uno para ir generando una lista de dias viajando.
            Day_1.city = "Malaga";
            Day_1.meal_plan = Meal_Code_TypeData.pc;
            Day_1.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_1);
            Day_On_Travel Day_2 = new Day_On_Travel();
            Day_2.city = "Malaga";
            Day_2.meal_plan = Meal_Code_TypeData.pc;
            Day_2.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_2);
            Day_On_Travel Day_3 = new Day_On_Travel();
            Day_3.city = "Malaga";
            Day_3.meal_plan = Meal_Code_TypeData.pc;
            Day_3.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_3);
            Day_On_Travel Day_4 = new Day_On_Travel();
            Day_4.city = "Cancun";
            Day_4.meal_plan = Meal_Code_TypeData.ad;
            Day_4.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_4);
            Day_On_Travel Day_5 = new Day_On_Travel();
            Day_5.city = "Cancun";
            Day_5.meal_plan = Meal_Code_TypeData.ad;
            Day_5.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_5);
            Day_On_Travel Day_6 = new Day_On_Travel();
            Day_6.city = "Cancun";
            Day_6.meal_plan = Meal_Code_TypeData.ad;
            Day_6.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_6);
            Day_On_Travel Day_7 = new Day_On_Travel();
            Day_7.city = "Cancun";
            Day_7.meal_plan = Meal_Code_TypeData.ad;
            Day_7.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_7);
            Day_On_Travel Day_8 = new Day_On_Travel();
            Day_8.city = "Cancun";
            Day_8.meal_plan = Meal_Code_TypeData.ad;
            Day_8.room_type = Room_Type_TypeData.standard;
            Programmed_Travel.Days.Add(Day_8);
            return Programmed_Travel;                       /// Cuando tenemos la lista de dias generada, la devolvemos.
        }

        private void Btn_Travel_Click(object sender, EventArgs e) // este proceso asignará habitaciones a cada dia de viaje segun el criterio que el cliente ha deseado y el limite de credito
        {
            Travel Days_On_Travel = Set_Up_Travel(); // lista que contendrá todo los datos del viaje completo deseo del cliente dia a dia.
            List<Own_Format_Class_Extra> My_Travel = new List<Own_Format_Class_Extra>();// List que contendra las habitaciones donde se alojará el cliente dia a dia según los criterior del viaje.
            foreach (Day_On_Travel Day in Days_On_Travel.Days)  // procesamos los dias uno por uno buscando una habitacion que encaje con los deseos del cliente.
            {
                foreach (Own_Format_Class Room_Data in Oficial_Room_List)  // recorremos la lista de habitaciones para comparar y decidir.
                {
                    if (Valid_Room(Room_Data,Day) && Days_On_Travel.Credit>0) //  Le pasamos a una funcion los datos del dia que buscamos
                                                                              //  y la habitacion que estamos mirando para que evalue si es correcta o no
                    {
                        Days_On_Travel.Credit -= (Room_Data.rooms.price * 2); // si la habitacion es correcta restamos del credito el costo de la habitacion *2 personas y la añadimos a nuestro viaje.
                        My_Travel.Add(Convert_Data(Room_Data));  // como el tipo de dato pedido es diferente aunque ha heredado la mayoria de sus caracteristicas tenemos que hacer una conversion
                        break;   // este punto de ruptura lo pongo para que no siga buscando habitaciones una vez hemos encontrado la que buscamos y con esto salte al siguiente dia.
                    }
                }
            }
            Tb_Travel.Text=("Viaje Solicitado:" + Environment.NewLine + JsonConvert.SerializeObject(My_Travel, Formatting.Indented));  // Una vez tenemos el viaje por completo configurado generamos
                                                                                                                                       // el Json y lo presentamos al cliente.
        }

        private Own_Format_Class_Extra Convert_Data(Own_Format_Class Original_Data) // Funcion que convierte un dato de clase tipo Own_Format_Class en uno de la clase Own_Format_Class_Extra
        {
            Own_Format_Class_Extra Converted_Data = new Own_Format_Class_Extra(); // para convertirlo creamos un dato con el formato final en blanco
            Converted_Data.city = Original_Data.city;                             // y vamos rellenando con cada dato su correspondiente valor.
            Converted_Data.code = Original_Data.code;                             // existe el clonado de objetos pero como son objetos diferentes no puedo usarlo.
            Converted_Data.name = Original_Data.name;
            Converted_Data.rooms.meal_plan = Original_Data.rooms.meal_plan;
            Converted_Data.rooms.name = Original_Data.rooms.name;
            Converted_Data.rooms.price = Original_Data.rooms.price;
            Converted_Data.rooms.room_type = Original_Data.rooms.room_type;
            Converted_Data.rooms.nights = 1;
            return (Converted_Data);
        }

        private bool Valid_Room(Own_Format_Class Room_Data, Day_On_Travel Day)   // Funcion que valida si una habitacion cumple con los requerimientos del cliente para el dia en que se esta buscando.
        {
            bool Resultado = false; // inicializamos la busqueda negando el resultado
            if (Room_Data.city == Day.city  &&  Room_Data.rooms.meal_plan== Day.meal_plan && Room_Data.rooms.room_type == Day.room_type ) // si se cumplen las exigencias del cliente
            {
                Resultado = true;   
            }
            return(Resultado); 
        }
    }
}
