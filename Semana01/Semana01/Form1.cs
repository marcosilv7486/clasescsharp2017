using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Semana01
{
    public partial class Form1 : Form
    {
        private List<Producto> productos;
        private String nombreArchivo = "productos_vencidos.txt";
    
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            productos = new List<Producto>();
            Producto p1 = new Producto();
            p1.numero = 15;
            p1.codigoLab = "ABE";
            p1.desProd = "ATIDEM 10 MG";
            p1.present = "10 CAPS"; 
            p1.precioVentaFarm = new Decimal(7.49);
            p1.cantidad = 1;
            p1.fechaProduccion = DateTime.Now;
            p1.fechaVencimiento = DateTime.Now;
            productos.Add(p1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rutaArchivo = "C:" + Path.DirectorySeparatorChar + "Semana01" + Path.DirectorySeparatorChar + nombreArchivo;
            StringBuilder builder = new StringBuilder();
            String separador = ",";
            foreach (Producto producto in productos)
            {
                if( (producto.fechaVencimiento - DateTime.Now).TotalDays <= 120)
                {
                    builder.Append(producto.numero.ToString());
                    builder.Append(separador);
                    builder.Append(producto.codigoLab.ToString());
                    builder.Append(separador);
                    builder.Append(producto.desProd.ToString());
                    builder.Append(separador);
                    builder.Append(producto.present.ToString());
                    builder.Append(separador);
                    builder.Append(producto.precioVentaFarm.ToString("F"));
                    builder.Append(separador);
                    builder.Append(producto.cantidad.ToString());
                    builder.Append(separador);
                    builder.Append(producto.fechaProduccion.ToString("yyyy/dd/MM"));
                    builder.Append(separador);
                    builder.Append(producto.fechaVencimiento.ToString("yyyy/dd/MM"));
                    builder.Append(separador);
                    builder.Append(producto.cantidad.ToString());
                    builder.Append(Environment.NewLine);
                }
            }

            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
            FileStream fs = new FileStream(rutaArchivo, FileMode.OpenOrCreate);
            StreamWriter str = new StreamWriter(fs);
            str.BaseStream.Seek(0, SeekOrigin.End);
            str.WriteLine(builder.ToString());
            str.Flush();
            str.Close();
            fs.Close();
            MessageBox.Show("Se genero correctamente el archivo !!!");
        }
    }
}
