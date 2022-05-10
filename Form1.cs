using System;
using System.Windows.Forms;


namespace Prueba_TrAvelGateX
{
    public partial class Frm_Principal : Form
    {
        private HotelManager Gestor = new HotelManager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de los hoteles
        public Frm_Principal()
        {
            InitializeComponent(); // se inicializan los componentes.
            // no incluyo aqui el borrado de los combobox para prepararlos para el llenado de datos porque prefiero hacerlo en el
            // momento adecuado justo antes de ser llenados con los datos correspondientes.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch(Gestor.Fill_Hotel_Names(Cmb_Hotels)) // invocamos la carga de datos y le pasamos el objeto Cmb_hotels para que lo rellene
                                                        // con los datos que encuentre.
                                                        // prefiero pasar el control solo en lugar del formulario.
                                                        // al ejecutar la funcion ésta devuelve un número que indica el error que se ha producido.
            {
                case 0: // No se han producido errores.
                    break;
                case 1: MessageBox.Show("No se recibieron datos de hoteles!");// descripcion del error tipo 1;
                    break;
                case 2: MessageBox.Show("Error al convertir los datos Json."); // Descripcion del error tipo 2;
                    break;
                default: MessageBox.Show("Error no definido."); // Descripcion de un error no definido;
                    break;

            }
            if (Cmb_Hotels.Items.Count>0 ) // valoramos la cantidad de objetos contenidos en el combo para evitar
                                           // intentar ejecutar la seleccion teniendo el combo vacio.
            {
                Cmb_Hotels.SelectedIndex = 0; // seleccionamos el primer elemento del combobox, provocando lanzar el evento correspondiente.
            }
        }
        private void Cmb_Hotels_SelectedIndexChanged(object sender, EventArgs e) // evento producido al seleccionar o cambiar el elemento seleccionado en el combobox.
        {
            Gestor.Fill_Room_Info(Convert.ToString(Cmb_Hotels.SelectedItem), Cmb_RoomType);// enviamos al gestor la orden de rellenar el combo con la informacion
                                                                                           // de las habitaciones correspodiendes al hotel seleccionado.
            if (Cmb_RoomType.Items.Count > 0) // valoramos la cantidad de objetos contenidos en el combo para evitar
                                            // intentar ejecutar la seleccion teniendo el combo vacio.
            {
                Cmb_RoomType.SelectedIndex = 0; // seleccionamos el primer elemento del combobox, provocando lanzar el evento correspondiente.
            }
        }

        private void Cmb_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gestor.Fill_Meal_Plans(Lista,Tb_Code);
            if (Lista.Items.Count >0 )
            {
                Lista.Items[0].Selected = true;
            }
        }
    }
}
