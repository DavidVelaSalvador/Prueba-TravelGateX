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
        readonly private Resort_Meal_Plans_Manager Resort_Plans_Manager = new Resort_Meal_Plans_Manager();     //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de las habitaciones de los hoteles resort
        List<Own_Format_Class> Oficial_Room_List = new List<Own_Format_Class>();                               // lista que contendrá todo los datos ya procesados y organizados bajo nuestro formato.

        public Frm_Principal()
        {
            try
            {
                InitializeComponent(); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        /// al pulsar el Boton Get data se ejecuta toda la captura y presentacion de los datos en la pantalla.
        /// El proceso es el siguiente:
        /// Obtenemos los datos de las apis correspondientes.
        /// recorremos la lista de datos recibidos y ya construidos por cada manager.
        /// Creamos un Nodo para la lista y o vamos rellenando de datos.
        /// por ultimo añadimos el nodo creado a la lista. 
        /// Mostramos los resultados.
        private void Btn_Get_Data_Click(object sender, EventArgs e) 
        {
            Oficial_Room_List.Clear();
            Atalaya_Plans_Manager.Get_Data(Oficial_Room_List);// Invocamos la orden al gestor de los hoteles Atalaya para rellenar la lista de datos
            Resort_Plans_Manager.Get_Data(Oficial_Room_List);// Invocamos la orden al gestor de los hoteles Resort para rellenar la lista de datos

            Lista.Items.Clear(); 
            foreach (Own_Format_Class Room_Data in Oficial_Room_List)  
            {
                ListViewItem Nodo = new ListViewItem(); 
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
                Nodo.SubItems.Add(Convert.ToString(Room_Data.rooms.price)); 
                Lista.Items.Add(Nodo);  
            }
            Btn_Travel.Enabled = Oficial_Room_List.Count > 0;  // bloqueamos la disponibilidad del boton a haber obtenido informacion de habitaciones.
            
            /// Cargamos en el Cuadro de texto el resultado de convertir la lista a Json con un formateo adecuado para presentarlo.
            Tb_Code.Text = JsonConvert.SerializeObject(Oficial_Room_List, Formatting.Indented);
            if (Lista.Items.Count > 0)   // Si tenemos algo en la lista seleccionamos el primer elemento
            {
                Lista.Items[0].Selected = true; 
            }
        }


        /// Funcion que prepara un viaje y lo devuelve al sistema para calcular el presupuesto del mismo.
        private Travel Set_Up_Travel() 
        {
            Day_On_Travel Day_1 = new Day_On_Travel();                   // Vamos a ir dando de alta varios dias de viaje 
            Travel Programmed_Travel = new Travel();                     // y configurando los deseos de la prueba uno por
            Programmed_Travel.Credit = 700;                              //  uno para ir generando una lista de dias viajando.
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
            return Programmed_Travel;                       // Cuando tenemos la lista de dias generada, la devolvemos.
        }


        ///  Este proceso asignará habitaciones a cada dia de viaje segun el criterio que el cliente ha deseado y el limite de credito
        ///  procesamos los dias uno por uno buscando una habitacion que encaje con los deseos del cliente.
        ///  recorremos la lista de habitaciones para comparar y decidir.
        ///  Le pasamos a una funcion los datos del dia que buscamos y la habitacion que estamos mirando para que evalue si es correcta o no,
        ///  si la habitacion es correcta restamos del credito el costo de la habitacion y la añadimos a nuestro viaje.
        ///  Una vez tenemos el viaje por completo configurado generamos el Json y lo presentamos al cliente.
        private void Btn_Travel_Click(object sender, EventArgs e) 
        {
            Travel Days_On_Travel = Set_Up_Travel();                                         // lista que contendrá todo los datos del viaje completo deseo del cliente dia a dia.
            List<Own_Format_Class_Extra> My_Travel = new List<Own_Format_Class_Extra>();     // List que contendra las habitaciones donde se alojará el cliente dia a dia según los criterior del viaje.
            foreach (Day_On_Travel Day in Days_On_Travel.Days)  
            {
                foreach (Own_Format_Class Room_Data in Oficial_Room_List)  
                {
                    if (Valid_Room(Room_Data,Day) && Days_On_Travel.Credit>0) 
                    {
                        Days_On_Travel.Credit -= (Room_Data.rooms.price * 2);                // 2 personas por dia y noche
                        My_Travel.Add(Room_Data.Convert_Data());                             // como el tipo de dato pedido es diferente aunque ha heredado la mayoria de sus caracteristicas tenemos que hacer una conversion
                        break;   /// este punto de ruptura lo pongo para que no siga buscando habitaciones una vez hemos encontrado la que buscamos y con esto salte al siguiente dia.
                    }
                }
            }
            Tb_Travel.Text=("Viaje Solicitado:" + Environment.NewLine + JsonConvert.SerializeObject(My_Travel, Formatting.Indented));  
        }


        /// Funcion que valida si una habitacion cumple con los requerimientos del cliente para el dia en que se esta buscando.
        /// inicializamos la busqueda negando el resultado
        /// si se cumplen las exigencias del cliente devolvemos un resultado positivo.
        private bool Valid_Room(Own_Format_Class Room_Data, Day_On_Travel Day)  
        {
            bool Resultado = false; 
            if (Room_Data.city == Day.city  &&  Room_Data.rooms.meal_plan== Day.meal_plan && Room_Data.rooms.room_type == Day.room_type ) 
            {
                Resultado = true;   
            }
            return(Resultado); 
        }
    }
}
