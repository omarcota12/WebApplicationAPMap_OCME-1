<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ubicacion-OCME.aspx.cs" Inherits="CrudUbicacion_1_OCME.Ubicacion_OCME" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script type="text/javascript" src='https://maps.google.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyDlv2PNwLztXH4VUYD9J9jW5vuv-T6YzRs'></script>    
    <script src="js/locationpicker.jquery.js"></script>
    <title>Control de ubicaciones</title>
      
</head>
<body>
<label>Omar Cota Medina Eliezer</label>   
    <form id="form1" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                    <div class="form-group">
                        <style>
                            -pac-container {
                                z-index: 99999;
                            }
                        </style>

                        <label for="exampleInputEmail1">Ubicacion</label>
                        <asp:HiddenField ID="txtID" runat="server" />
                        <asp:TextBox ID="txtUbicacion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                        <div class="form-group">
                            <label for="ExampleInputPassword1>">Lat.:</label>
                            <asp:TextBox ID="txtLat" Text="27.365938954017043" CssClass="form-control" runat="server"></asp:TextBox>
                             <label for="ExampleInputPassword1>">Long.:</label>
                            <asp:TextBox ID="txtLong" Text="-109.93136356074504" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                            <div class="form-group">
                       <asp:Button ID="btnAgregar" CssClass="btn btn-success" runat="server" Text="Agregar" UseSubmitBehavior="false" OnClick="AgregarRegistro" />
                       <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar" UseSubmitBehavior="false" OnClick="ModificarRegistro" Enabled="false"/>
                       <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarRegistro" Enabled="false" />
                       <asp:Button ID="btnLimpiar" CssClass="btn btn-default" runat="server" Text="Limpiar" OnClick="LimpiarFormulario_Click" />

                   </div>
                        
                         </div>
                        
                        </div>
                <div class="col-md-8">
                    <br />
                    <h1>Ubicaciones</h1>
  <asp:GridView ID="gvUbicaciones" runat="server" CssClass="table-responsive table table-bordered" OnRowCommand="SeleccionRegistros">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnSeleccionar" runat="server" CommandName="btnSeleccionar" Text="Seleccionar" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' CssClass="btn btn-info" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                    
                </div>
            </div>

            </div>
<script>
    // Cuando la página se cargue, se configura el mapa con las coordenadas iniciales
    $('#ModalMapPreview').locationpicker({
        radius: 0,
        location: {
            latitude: parseFloat($('#<%= txtLat.ClientID %>').val()),
            longitude: parseFloat($('#<%= txtLong.ClientID %>').val())
        },
        inputBinding: {
            latitudeInput: $('#<%= txtLat.ClientID %>'),
            longitudeInput: $('#<%= txtLong.ClientID %>'),
            locationNameInput: $('#<%= txtUbicacion.ClientID %>') // Se vincula la ubicación al input
        },
        enableAutocomplete: true
    });

    // Actualización dinámica del mapa después de seleccionar una ubicación en el GridView
    function actualizarMapa(lat, lon) {
        $('#ModalMapPreview').locationpicker('location', {
            latitude: lat,
            longitude: lon
        });
    }
</script>
           
    </form>
    </body>
</html>
