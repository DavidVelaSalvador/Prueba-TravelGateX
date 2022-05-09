using System;
using System.Windows.Forms;


namespace Prueba_TrAvelGateX
{
    public partial class Form1 : Form
    {
        private HotelManager Gestor = new HotelManager();  //Definimos un objeto de tipo gestor que será el encargado de traernos los datos de los hoteles
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch(Gestor.Fill_Hotel_Names(Cmb_Hotels)) // invocamos la carga de datos.
            {
                case 1: MessageBox.Show("No se recibieron datos de hoteles!");// descripcion del error tipo 1;
                    break;
                case 2: MessageBox.Show("Error al convertir los datos Json."); // Descripcion del error tipo 2;
                    break;
                default:
                break;

            }
            if (Cmb_Hotels.Items.Count>0 )
            {
                Cmb_Hotels.SelectedIndex = 0;
            }
        }
        private void Cmb_Hotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Name;
            Name = Convert.ToString (Cmb_Hotels.SelectedItem);
            Gestor.Fill_Room_Info(Name, Cmb_RoomType);
        }
    }
}
