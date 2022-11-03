using Neptuno.Libreria.Business;
using Neptuno.Libreria.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno.Libreria.View
{
    public partial class ProductoView : Form
    {
        public ProductoView()
        {
            InitializeComponent();
            cargaCombos();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            procesar(1);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            procesar(2);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            procesar(3);
        }        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ProductoView_Load(object sender, EventArgs e)
        {
            listar();
        }
        //instanciar objeto de la clase ProductoBll
        ProductoBLL obj = new ProductoBLL();
        ProductoTO pro;

        private void listar()
        {
            try
            {
                dgvProducto.DataSource = obj.productoListar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void consultar()
        {
            pro = new ProductoTO();            
            pro = obj.productoBuscar(txtCodigo.Text);
            if (pro!=null)
            {
                txtNombre.Text = pro.NombreProducto;
                cboProveedor.SelectedValue = pro.IdProveedor;
                cboCategoria.SelectedValue = pro.IdCategoria;
                txtPrecio.Text = pro.Precio.ToString();
                txtCantidad.Text = pro.Stock.ToString();
            }
            else
            {
                MessageBox.Show("Producto no existe");
            }
        }

        private void procesar(int op)
        {
            pro = leerDatos();
            try
            {
                string msj = obj.productoProcesar(pro,op);
                MessageBox.Show(msj, "exito",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error");
            }
        }

        private ProductoTO leerDatos()
        {
            pro = new ProductoTO()
            {
                IdProducto = int.Parse(txtCodigo.Text),
                NombreProducto = txtNombre.Text,
                IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue),
                IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue),               
                Precio = decimal.Parse(txtPrecio.Text),
                Stock=Int16.Parse(txtCantidad.Text)
            };
            return pro;
        }

        ProveedorBLL opro = new ProveedorBLL();
        CategoriaBLL ocat = new CategoriaBLL();
        private void cargaCombos()
        {
            cboProveedor.DataSource = opro.proveedorListar();
            cboProveedor.DisplayMember = "NombreProveedor";
            cboProveedor.ValueMember = "IdProveedor";

            cboCategoria.DataSource = ocat.categoriaListar();
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "IdCategoria";
        }

    }
}
