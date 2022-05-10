using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace Prueba_TravelGateX
{
    public class Meal_Plans_List // tipo de dato que almacenara un listado de todas las habitaciones y los hoteles donde podemos localizarlas.
    {
        public List<Meal_Plans_Type> meal_plans { get; set; } = new List<Meal_Plans_Type>();  // Creo un listado de objetos Hotel para almacenar la informacion de todos los hoteles recibidos por la API.
    }

    public class Meal_Plans_Type  // Defino una clase Tipo_Habitacion que contendrá los datos de las habitaciones y en que hoteles se encuentran.
    {
        public string code { get; set; } // variable para almacenar el codigo de la habitacion
        public string name { get; set; }  // variable para almacenar el nombre de la habitacion
        public Hotel_Details hotel { get; set; } = new Hotel_Details();  // listado para los hoteles que contienen habitaciones de este tipo.
        
    }

    public class Hotel_Details
    {
        public List<room_details> ave { get; set; } = new List<room_details>();  // listado para los hoteles que contienen habitaciones de este tipo.
        public List<room_details> acs { get; set; } = new List<room_details>();  // listado para los hoteles que contienen habitaciones de este tipo.
    }

    public class room_details  // Defino una clase para almacenar los precios y tipo de una habitacion.
    {
        public string room { get; set; } // variable para almacenar el tipo de la habitacion
        public int price { get; set; }  // variable para almacenar el precio por noche y persona de la habitacion
    }

    class Meal_Plans_Manager
    { 
        Meal_Plans_List Meal_Plan_List_Received;// variable creada para almacenar el listado de regimenes de habitacion disponible en cada hotel.

        public void Get_Data(Frm_Principal Form )
        {
            WebClient Client = new WebClient(); // Creamos un objeto webclient para almacenar la respuesta de la tercera API 
            string Received_Data = Client.DownloadString("http://www.mocky.io/v2/5e4a7e282f0000490097d252"); // creamos y almacenamos la respuesta con los tipos de habitaciones disponibles para cada hotel y los regimenes de cada uno.
            if (Received_Data.Trim() != "") // esta condicion la pongo para evitar el procesamiento si no hemos tenido respuesta, evitando así errores.
            {
                Form.Tb_Code.Text = JToken.Parse(Received_Data).ToString();
                Form.Lista.Items.Clear();// preparamos el objeto combobox recibido para alojar mas datos.
                try
                {
                    Meal_Plan_List_Received = JsonConvert.DeserializeObject<Meal_Plans_List>(Received_Data); // Deserializamos los datos Json en el objeto Meal_list para generar la lista de regimenes asignados a cada habitacion de cada hotel.
                    foreach (Meal_Plans_Type Temp_Meal_Plan in Meal_Plan_List_Received.meal_plans)
                    {
                        foreach(room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.ave)
                        {
                            ListViewItem Nodo = new ListViewItem();
                            Nodo.Text = Form.Hotel_Name_By_Code("ave");
                            Nodo.SubItems.Add(Form.Hotel_City_By_Code("ave"));
                            Nodo.SubItems.Add(Form.Room_Name(Temp_Room_Detail.room));
                            
                            Nodo.SubItems.Add(Convert.ToString (Temp_Room_Detail.price));
                            Form.Lista.Items.Add(Nodo);
                        }
                        foreach (room_details Temp_Room_Detail in Temp_Meal_Plan.hotel.acs )
                        {
                            ListViewItem Nodo = new ListViewItem();
                            Nodo.Text = Form.Hotel_Name_By_Code("acs");
                            Nodo.SubItems.Add(Form.Hotel_City_By_Code("acs"));
                            Nodo.SubItems.Add(Form.Room_Name(Temp_Room_Detail.room));

                            Nodo.SubItems.Add(Convert.ToString(Temp_Room_Detail.price));
                            Form.Lista.Items.Add(Nodo);
                        }

                    }
                }
                catch(Exception e)
                {
                    Form.Log_Append(e.Message);
                }
            }
        }
    }
}
