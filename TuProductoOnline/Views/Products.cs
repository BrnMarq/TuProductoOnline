using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline
{

    public partial class Products : Form
    {
   
        public List<Hardware> hardware = new List<Hardware>();
        public List<Software> software = new List<Software>();
        public List<Devices> device = new List<Devices>();


        public Products()
        {
            InitializeComponent();
            fillOutGrid();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        public  void  fillOutGrid() 
        {

            
            hardware.Add(new Hardware("Disco duro SSD", 30, "Kingston", "Lugar de almacenamiento de un ordenador", "Hardware"));
            hardware.Add(new Hardware("Tarjeta madre", 500, "ASUS", "Se encarga la comunicación de datos, el control y el monitoreo, la administración o la gestión de la energía eléctrica así como la distribución de la misma por todo el computador, la conexión física de los diversos componentes del citado y, por supuesto, la temporización y el sincronismo.", "Hardware"));
            hardware.Add(new Hardware("Memoria RAM", 80, "Corsair", "Su función principal es recordar la información que tienes en cada una de las aplicaciones abiertas en el computador, mientras este se encuentre encendido. Esta memoria de corto plazo solo actúa cuando el computador esté encendido.", "Hardware"));
            hardware.Add(new Hardware("CPU", 15, "Intel", "Se encarga de procesar todas las instrucciones del dispositivo, leyendo las órdenes y requisitos del sistema operativo, así como las instrucciones de cada uno de los componentes y las aplicaciones", "Hardware"));
            hardware.Add(new Hardware("Fuente de alimentación", 17, "Seasonic", "dispositivo que convierte la corriente alterna, en una o varias corrientes continuas, que alimentan los distintos circuitos del aparato electrónico al que se conecta.", "Hardware"));
           
            device.Add(new Devices("Teclado", 74, "Keychron", "En informática, un teclado es un dispositivo de entrada, en parte inspirado en el teclado de las máquinas de escribir, que utiliza un sistema de puntadas o márgenes","Devices"));
            device.Add(new Devices("Mouse", 35, "Redragon", "El ratón o mouse es un dispositivo apuntador utilizado para facilitar el manejo de un entorno gráfico en una computadora.","Devices"));
            device.Add(new Devices("Auriculares", 150, "Sony", "Los auriculares se conectan a través de un teléfono oa una computadora, lo que permite al usuario hablar y escuchar mientras mantiene ambas manos libres.", "Devices"));
            device.Add(new Devices("Audífonos", 39, "Xiaomi", "Aparato que consta de dos piezas con unos dispositivos capaces de transformar ondas eléctricas en ondas sonoras y que, unidas por una tira generalmente curva y ajustable a la cabeza, se acoplan a los oídos para la recepción del sonido.", "Devices"));
            device.Add(new Devices("Webcam", 90, "ElGato", "Cámara de vídeo miniaturizada que se puede conectar a un ordenador para grabar imágenes o emitirlas en directo a través de Internet.", "Devices"));

            software.Add(new Software("VSCode",10, "Microsoft", "Programa para editar código","Software"));
            software.Add(new Software("Ubuntu", 20, "Software Libre", "Sistema Operativo basado en UNIX flexible y ligero", "Software"));
            software.Add(new Software("League Of Legends", 1000, "Riot Games", "Juego estilo MOBA con una gran cantidad de jugadores activos", "Software"));
            software.Add(new Software("Advanced System Care", 15, "IOBit", "Programa para optimizar el funcionamiento del ordenador", "Software"));
            software.Add(new Software("WinRAR", 17, "Eugene Roshal", "Programa para descomprimir archivos comprimidos, con mayor uso en los formatos de tipo.rar", "Software"));

            foreach (Hardware i in hardware) 
            {
                int rowIndex = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[rowIndex];
                row.Cells[1].Value = i.Type;
                row.Cells[2].Value = i.Name;
                row.Cells[3].Value = i.Brand;
                row.Cells[4].Value = i.Description;
                row.Cells[5].Value = i.Price;
                

            }
            foreach (Software i in software)
            {
                int rowIndex = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[rowIndex];
                row.Cells[1].Value = i.Type;
                row.Cells[2].Value = i.Name;
                row.Cells[3].Value = i.Brand;
                row.Cells[4].Value = i.Description;
                row.Cells[5].Value = i.Price;

            }
            foreach (Devices i in device)
            {
                int rowIndex = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[rowIndex];
                row.Cells[1].Value = i.Type;
                row.Cells[2].Value = i.Name;
                row.Cells[3].Value = i.Brand;
                row.Cells[4].Value = i.Description;
                row.Cells[5].Value = i.Price;

            }

           

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}


