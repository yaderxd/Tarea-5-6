using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_5_6
{
    public partial class fmrCine : Form
    {
        double precio = 0;
        String categoria = "";
        
        public fmrCine()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bniño.Visible = false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            categoria =lblCategoria.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            double subtotal = precio*cantidad;
            double descuento = 0;
            switch(categoria)
            {
                case "Niño":descuento=20.0/100*subtotal;break;
                case "Joven 1": descuento=10.0/100*subtotal; break;
                case "Joven 2": descuento=5.0/100*subtotal; break;
                case "Adulto 1": descuento=10.0/100*subtotal; break;
                case "Adulto 2": descuento=20.0/100*subtotal; break;
            }
            double importe = subtotal-descuento;

            ListViewItem fila = new ListViewItem(categoria);
            fila.SubItems.Add(precio.ToString("0.00"));
            fila.SubItems.Add(cantidad.ToString());
            fila.SubItems.Add(subtotal.ToString("0.00"));
            fila.SubItems.Add(descuento.ToString("0.00"));
            fila.SubItems.Add(importe.ToString("0.00"));
            lvRegistro.Items.Add(fila);

            lvEstadisticas.Items.Clear();
        }
        private void CboEdad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int edad = cboEdad.SelectedIndex;
            switch(edad)
            {
                case 0: precio=10;categoria="Niño";break;
                case 1: precio=15; categoria="Joven 1"; break;
                case 2: precio=25; categoria="Joven 2"; break;
                case 3: precio=15; categoria="Adulto 1"; break;
                case 4: precio=10; categoria="Adulto 2"; break;
            }
            if (cboEdad.SelectedItem.Equals("Niño"))
            {
                bniño.Visible = true;
            }
            lblPrecio.Text=precio.ToString("C");
            lblCategoria.Text=categoria;
        }
        private void BtnEstadistica_Click(object sender, EventArgs e)
        {
            lvEstadisticas.Items.Clear();
            double tSubtotal=0;
            int i;
            for (i=0;i<lvRegistro.Items.Count; i++)
            {
                tSubtotal+=double.Parse(lvRegistro.Items[i].SubItems[3].Text);
            }
            double tDescuento = 0;
            i=0;
            while(i<lvRegistro.Items.Count)
            {
                tDescuento+=double.Parse(lvRegistro.Items[i].SubItems[0].Text);
                i++;
            }
            double aNiño = 0, aJoven1 = 0, aJoven2 = 0, aAdulto1 = 0, aAdulto2 = 0;
            i=0;
            do
            {
                string categoria = lvRegistro.Items[i].SubItems[0].Text;
                switch(categoria)
                {
                    case"Niño":
                        aNiño+=double.Parse(lvRegistro.Items[i].SubItems[5].Text);break;
                    case "Joven 1":
                        aJoven1+=double.Parse(lvRegistro.Items[i].SubItems[5].Text); break;
                    case "Joven 2":
                        aJoven2+=double.Parse(lvRegistro.Items[i].SubItems[5].Text); break;
                    case "Adulto 1":
                        aAdulto1+=double.Parse(lvRegistro.Items[i].SubItems[5].Text); break;
                    case "Adulto 2":
                        aAdulto2+=double.Parse(lvRegistro.Items[i].SubItems[5].Text); break;
                }
                i++;
            } while (i<lvRegistro.Items.Count);
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            elementosFila[0]="Monto total sin descuento";
            elementosFila[1]=tSubtotal.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto total que la empresa no percibe";
            elementosFila[1]=tDescuento.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto acumulado por categoria Niño";
            elementosFila[1]=aNiño.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto acumulado por categoria Joven 1";
            elementosFila[1]=aJoven1.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto acumulado por categoria Joven 2";
            elementosFila[1]=aJoven2.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto acumulado por categoria Adulto 1";
            elementosFila[1]=aAdulto1.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0]="Monto acumulado por categoria Adulto 2";
            elementosFila[1]=aAdulto2.ToString("C");
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
        }
    }
}
