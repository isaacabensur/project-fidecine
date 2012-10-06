
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FIDECINEWeb.Models.HorarioProyeccionModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

 <script type="text/javascript">


     $(document).ready(function () {


         $("#tbCartelera").styleTable();

         $("#txtFechaHoraDesde").datetimepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });
         $("#txtFechaHoraHasta").datetimepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });

         $("#txtFechaHoraEdicion").datetimepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });

         $.datepicker.regional['es'];

         $("#btnBuscar").button({
             icons: {
                 secondary: "ui-icon-circle-zoomin"
             }
         });

         $("#btnNuevo").button({
             icons: {
                 secondary: "ui-icon-circle-plus"
             }
         });


         $("#dialog_EditarCartelera").dialog({
             autoOpen: false,
             height: 210,
             width: 350,
             modal: true,
             resizable: false,
             buttons: {
                 "Guardar": function () {

                     var esValido = true;

                     esValido = $("#frmEdicionCartelera").validationEngine('validate');

                     if (esValido) {

                         $('#btnSi').unbind('click');
                         $("#btnSi").click(function () {

                             $.post('/AdministrarHorario/insertarHorario', $('#frmEdicionCartelera').serializeArray(), function (data) {

                                 informacion(data.Mensaje);
                                 $("#dialog_EditarCartelera").dialog("close");

                             },
                            "json");

                         });

                         confirmacion('¿Desea guardar los datos ingresados?');
                     }

                 },
                 "Cancelar": function () {
                     $(this).dialog("close");
                 }
             },
             close: function () {
                 $("#frmEdicionCartelera").validationEngine('hideAll');
             }
         });

     });

     function nuevoHorario() 
     {
         $.post('/AdministrarHorario/nuevoHorario', function (data) {

             $('#cmbPeliculaEdicion').empty();
             $('#cmbPeliculaEdicion').append($('<option>', { value: '' }).text('---- Seleccione ----'));

             $.each(data.ListaPelicula, function (i, objeto) {
                 $('#cmbPeliculaEdicion').append($('<option>', { value: objeto.IdPelicula }).text(objeto.Nombre));
             });

             $('#cmbSalaEdicion').empty();
             $('#cmbSalaEdicion').append($('<option>', { value: '' }).text('---- Seleccione ----'));

             $.each(data.ListaSala, function (i, objeto) {
                 $('#cmbSalaEdicion').append($('<option>', { value: objeto.IdSala }).text(objeto.Nombre));
             });

             $("#txtFechaHoraEdicion").val('');
             $("#dialog_EditarCartelera").dialog("open");

         },
         "json");

         

         return false;
     }

     function buscar() {

         $.post('/AdministrarHorario/buscar', $('#frmBusqueda').serializeArray(), function (data) {
             $("#tbCartelera > tbody").empty();

             $.each(data, function (i, objeto) {
                 var newRow = '';
                 newRow = "<tr>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.Pelicula + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.Sala + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.FechaHora + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'><img src='../../Content/images/iconos/mantenimiento/eliminar.png'/></td>";
                 newRow = newRow + "</tr>";

                 $("#tbCartelera").append(newRow);

             });
         },
         "json");

         $("#tbCartelera").styleTable();

         return false;
     }


     function validarPelicula() { $("#frmEdicionCartelera").validationEngine("validateField", "#cmbPeliculaEdicion"); }
     function validarSala() { $("#frmEdicionCartelera").validationEngine("validateField", "#cmbSalaEdicion"); }
     function validarFechaHora() { $("#frmEdicionCartelera").validationEngine("validateField", "#txtFechaHoraEdicion"); }

</script>
			
	<div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Administración de Horarios de Proyección de Películas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table width="600px">
            <tr>
                <td>Película :</td>
                <td>                    
                    <select id="cmbPelicula" name="D1" style="width: 200px;">
                        <option>---- Todos ----</option>
                        <% foreach (var item in Model.ListaPelicula)
                        { %>
                            <option><%= item.Nombre %></option>
                        <% } %>
                    </select>
                </td> 
                <td>
                Sala :
                </td> 
                <td>
                    <select id="cmbSala" name="D2" style="width: 120px;">
                        <option>---- Todos ----</option>
                        <% foreach (var item in Model.ListaSala)
                        { %>
                            <option><%= item.Nombre %></option>
                        <% } %>
                    </select>
                </td>
            </tr>   
            <tr>
                <td>Fecha y Hora : </td>
                <td>
                    Desde
                    <input id="txtFechaHoraDesde" type="text" readonly="readonly"/>
                </td>
                <td>
                    Hasta
                </td>
                <td>
                    <input id="txtFechaHoraHasta" type="text" readonly="readonly"/>
                </td>
            </tr>     
        </table>
	</div>
	</div>


	<div class="ui-widget-content ui-corner-all" align="center"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	    <div style="margin: 3px 3px 3px 3px;">

            <button id="btnNuevo" onclick="return nuevoHorario();">Nuevo</button>
            <button id="btnBuscar" onclick="return buscar();">Buscar</button>            
        </div>
	</div>

	    <table  id="tbCartelera" width="790px" class="styleTable">
			<thead>
			<tr>
				<th width="300px">Película</th>
				<th width="300px">Sala</th>
				<th width="170px">Fecha y Hora</th>		
                <th width="20px"></th>	
			</tr>
			</thead>
			<tbody>
            <tr>
                <td>aa</td>
                <td>aaa</td>
                <td>aaaa</td>
                <td><img src="../../Content/images/iconos/mantenimiento/eliminar.png"/></td>
            </tr>
           <tr>
                <td>bbbb</td>
                <td>bbbb</td>
                <td>bbbbbb</td>
                <td><img src="../../Content/images/iconos/mantenimiento/eliminar.png"/></td>
            </tr>
            <tr>
                <td>ccccccc</td>
                <td>cccccc</td>
                <td>cccccccc</td>
                <td><img src="../../Content/images/iconos/mantenimiento/eliminar.png"/></td>
            </tr>
			</tbody>
			<tfoot>
			</tfoot>
	    </table>
    </form>


    <div  id="dialog_EditarCartelera" title="Edición de Horario de Proyección de Película" style="display:none;">
    <form id="frmEdicionCartelera" action="#">    
		<table cellpadding="3" cellspacing="3">
            <tr>
                <td>Película :</td>
                <td>
                    
                    <select id="cmbPeliculaEdicion"  style="width: 200px;" class="validate[required]" onchange="validarPelicula()" name="IdPelicula">
                    </select>
                </td> 
            </tr>
            <tr>
                <td>
                Sala :
                </td> 
                <td>
                    <select id="cmbSalaEdicion" style="width: 200px;" class="validate[required]" onchange="validarSala() " name="IdSala">
                    </select>
                </td>
            </tr>
            <tr>
                <td>Fecha y Hora : </td>
                <td>
                    <input id="txtFechaHoraEdicion" type="text" readonly="readonly" class="validate[required]" onchange="validarFechaHora()" name="FechaHora"/>
                </td>
            </tr>
        </table>												
    </form>
	</div>
	
</asp:Content>
