using Prueba_TravelGateX;
using System;
using System.Windows.Forms;


namespace Prueba_TravelGateX
{
    public partial class Frm_Principal : Form
    {
        readonly private Hotel_Manager Hotel_Manager = new Hotel_Manager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de los hoteles
        readonly private Rooms_Manager Room_Manager = new Rooms_Manager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de las habitaciones
        readonly private Meal_Plans_Manager Plans_Manager = new Meal_Plans_Manager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de las habitaciones
        private static Log_Manager Log = new Log_Manager(); // Objeto encargado de escribir el log y anotar todo lo que ocurre.

        public Frm_Principal()
        {
            try
            {
                InitializeComponent(); // se inicializan los componentes.
                                       // no incluyo aqui el borrado de los combobox para prepararlos para el llenado de datos porque prefiero hacerlo en el
                                       // momento adecuado justo antes de ser llenados con los datos correspondientes.
                Log.Append("Inicio de la aplicación correcta.");
            }
            catch(Exception e)
            {
                Log.Append(e.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log_Append( Hotel_Manager.Get_Data()); // inicializamos el gestor de hoteles enviando cualquier respuesta al log para anotarla.
            Log_Append( Room_Manager.Get_Data()); // inicializamos el gestor de habitaciones enviando cualquier respuesta al log para anotarla.
        }


        public string Hotel_Code_By_Name(string Name)// Funcion que devuelve el codigo del hotel seleccionado comparandolo con el nombre pasandole la ejecucion al gestor de hoteles.
        {
            return(Hotel_Manager.Hotel_Code_By_Name(Name));  // devolvemos los datos que el el gestor de hoteles nos ha dado.
        }

        public string Hotel_Name_By_Code(string Code)// Funcion que devuelve el codigo del hotel seleccionado comparandolo con el nombre pasandole la ejecucion al gestor de hoteles.
        {
            return (Hotel_Manager.Hotel_Name_By_Code(Code));  // devolvemos los datos que el el gestor de hoteles nos ha dado.
        }
        public string Hotel_City_By_Code(string Code)// Funcion que devuelve el codigo del hotel seleccionado comparandolo con el nombre pasandole la ejecucion al gestor de hoteles.
        {
            return (Hotel_Manager.Hotel_City_By_Code(Code));  // devolvemos los datos que el el gestor de hoteles nos ha dado.
        }

        public string Room_Name(string room)// Funcion que devuelve el codigo del hotel seleccionado comparandolo con el nombre pasandole la ejecucion al gestor de hoteles.
        {
            return (Room_Manager.Room_Name(room));  // devolvemos los datos que el el gestor de hoteles nos ha dado.
        }

        public void Log_Append(string Texto) // procedimiento para traspasar un mensaje o cualquier anotacion al log_manager para que lo anote.
        {
            Log.Append(Texto); // envio al logManager de la informacion recibida.
            Tb_Log.Text = Log.Buffer; //  anotamos en el cuadro de texto del log el contenido del log.
        }

        private void Btn_Get_Data_Click(object sender, EventArgs e)
        {
            Plans_Manager.Get_Data(this);// enviamos al gestor correspondiente la orden de cargar los datos solicitados.
            if (Lista.Items.Count >0)// valoramos la cantidad de Items contenidos en el listview para evitar intentar ejecutar la seleccion teniendo el combo vacio.
            {
                 Lista.Items[0].Selected = true; // seleciconamos el primer elemento de la lista.
            }
        }
        //public void Set_Code_Text(string text)
        //{
        //    Tb_Code.Text = text;
        //}
    }
}
