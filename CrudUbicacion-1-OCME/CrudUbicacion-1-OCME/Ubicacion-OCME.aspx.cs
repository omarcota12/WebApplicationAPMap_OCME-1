using BLL;
using DAL;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudUbicacion_1_OCME
{
    public partial class Ubicacion_OCME : System.Web.UI.Page
    {
        Ubicaciones_BLL oUbicacionesBLL;
        ubicaciones_DAL oUbicacionesDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }

        public void ListarUbicaciones()
        {
          oUbicacionesDAL = new ubicaciones_DAL();
          DataTable dt = oUbicacionesDAL.Listar();
          gvUbicaciones.DataSource = dt;
          gvUbicaciones.DataBind();
            
        }

        public Ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new Ubicaciones_BLL();

            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicaciones = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();
        }

       
        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {

            oUbicacionesDAL = new ubicaciones_DAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void SeleccionRegistros(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            // Verifica que el comando sea de tipo 'btnSeleccionar'
            if (e.CommandName == "btnSeleccionar")
            {
                int FilaSeleccionada = Convert.ToInt32(e.CommandArgument);

                // Obtener las celdas del GridView (asegúrate de que el índice de las celdas es correcto)
                string ubicacion = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text; // Columna 2: Nombre de la ubicación
                string latitud = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;  // Columna 3: Latitud
                string longitud = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;  // Columna 4: Longitud
                string id = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;       // Columna 1: ID

                // Asignar los valores a los controles de texto en el formulario
                txtID.Value = id;
                txtUbicacion.Text = ubicacion;
                txtLat.Text = latitud;  // Asignar latitud
                txtLong.Text = longitud; // Asignar longitud

                // Activar/desactivar los botones de modificar y eliminar
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;

                // Actualizar el mapa con las nuevas coordenadas (latitud y longitud)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "actualizarMapa",
                    "$('#ModalMapPreview').locationpicker('location', {latitude: " + latitud + ", longitude: " + longitud + "});", true);
            }
        }

        protected void LimpiarFormulario_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();  // Llamar al método que limpia el formulario
        }

        public void LimpiarFormulario()
        {
            txtID.Value = string.Empty;
            txtUbicacion.Text = string.Empty;
            txtLat.Text = "27.365938954017043";  // Valor inicial de latitud
            txtLong.Text = "-109.93136356074504";  // Valor inicial de longitud

            // Resetear el mapa
            ScriptManager.RegisterStartupScript(this, this.GetType(), "resetMap", "$('#ModalMapPreview').locationpicker('reset');", true);
        }
    }
}