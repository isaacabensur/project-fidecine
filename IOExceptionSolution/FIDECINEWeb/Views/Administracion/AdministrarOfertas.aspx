<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FIDECINEWeb.Models.OfertaPromocionModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <script type="text/javascript">


     $(document).ready(function () {

         $("#tbCartelera").styleTable();

         $("#txtFechaDesde").datepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });
         $("#txtFechaHasta").datepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });

         $("#txtFechaVigenciaInicioEdicion").datepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });

         $("#txtFechaVigenciaFinEdicion").datepicker({
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


         $("#dialog_EditarOferta").dialog({
             autoOpen: false,
             height: 250,
             width: 400,
             modal: true,
             resizable: false,
             buttons: {
                 "Guardar": function () {

                     var esValido = true;

                     esValido = $("#frmEdicionOferta").validationEngine('validate');

                     if (esValido) {

                         $('#btnSi').unbind('click');
                         $("#btnSi").click(function () {

                             $.post('/AdministrarHorario/insertarHorario', $('#frmEdicionCartelera').serializeArray(), function (data) {

                                 informacion(data.Mensaje);
                                 $("#dialog_EditarCartelera").dialog("close");

                             },
                            "json")
                            .success(function () { buscarHorarios() });

                         });

                         confirmacion('¿Desea guardar los datos ingresados?');
                     }

                 },
                 "Cancelar": function () {
                     $(this).dialog("close");
                 }
             },
             close: function () {
                 $("#frmEdicionOferta").validationEngine('hideAll');
             }
         });

     });

     function nuevaOferta() {

         $.post('/AdministrarOferta/nuevaOferta', function (data) {  

             $('#cmbProductoEdicion').empty();
             $('#cmbProductoEdicion').append($('<option>', { value: '' }).text('---- Seleccione ----'));

             $.each(data.ListaProducto, function (i, objeto) {
                 $('#cmbProductoEdicion').append($('<option>', { value: objeto.IdProducto }).text(objeto.Nombre));
             });

             $("#txtPuntajeEdicion").val('');
             $("#txtFechaVigenciaInicioEdicion").val('');
             $("#txtFechaVigenciaFinEdicion").val('');
             $("#dialog_EditarOferta").dialog("open");

         },
         "json");



         return false;
     }

     function eliminarHorario(idCartelera) {

         $('#btnSi').unbind('click');
         $("#btnSi").click(function () {

             $.post('/AdministrarHorario/eliminarHorario', { 'IdCartelera': idCartelera }, function (data) {

                 informacion(data.Mensaje);
                 $("#dialog_EditarCartelera").dialog("close");

             },
             "json")
             .success(function () { buscarHorarios() });

         });

         confirmacion('¿Desea eliminar el Horario de Proyección seleccionado?');

     }

     function buscarHorarios() {

         $.post('/AdministrarHorario/buscarHorario', $('#frmBuscarCartelera').serializeArray(), function (data) {

             procesarLista(data.ListaCartelera);

         },
         "json");

         $("#tbCartelera").styleTable();

         return false;
     }

     function procesarLista(lista) {

         $("#tbCartelera > tbody").empty();

         $.each(lista, function (i, objeto) {
             var newRow = '';
             newRow = "<tr>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.PeliculaNombre + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.SalaNombre + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.FechaHora + "</td>";
             newRow = newRow + "<td class='ui-widget-content' align='center' valign='middle'><img src='../../Content/images/iconos/mantenimiento/eliminar.png' onclick='eliminarHorario(" + objeto.IdCartelera + ");' title='eliminar' style='cursor:hand;'/></td>";
             newRow = newRow + "</tr>";

             $("#tbCartelera").append(newRow);

         });
     }

     function validarProducto() { $("#frmEdicionOferta").validationEngine("validateField", "#cmbProductoEdicion"); }
     function validarPuntaje() { $("#frmEdicionOferta").validationEngine("validateField", "#txtPuntajeEdicion"); }
     function validarFechaVigenciaInicio() { $("#frmEdicionOferta").validationEngine("validateField", "#txtFechaVigenciaInicioEdicion"); }
     function validarFechaVigenciaFin() { $("#frmEdicionOferta").validationEngine("validateField", "#txtFechaVigenciaFinEdicion"); }

</script>
			
	<div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Gestión de Ofertas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
    <form id="frmBuscarCartelera" action="#"> 
	     <table width="600px">  
            <tr>
                <td>Fecha de Vigencia : </td>
                <td>Desde </td>
                <td>
                    
                    <input id="txtFechaDesde" type="text" readonly="readonly" name="FechaInicio"/>
                </td>
                <td>
                    Hasta
                </td>
                <td>
                    <input id="txtFechaHasta" type="text" readonly="readonly" name="FechaFin"/>
                </td>
            </tr>    
        </table>
    </form>
	</div>
	</div>


	<div class="ui-widget-content ui-corner-all" align="center"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	    <div style="margin: 3px 3px 3px 3px;">

            <button id="btnNuevo" onclick="return nuevaOferta();">Nuevo</button>
            <button id="btnBuscar" onclick="return buscarHorarios();">Buscar</button>            
        </div>
	</div>

	    <table  id="tbCartelera" width="790px" class="styleTable">
			<thead>
			<tr>
				<th width="270px">Producto</th>
                <th width="100px">Puntaje</th>
				<th width="200px">Vigencia Inicio</th>
                <th width="200px">Vigencia Fin</th>
                <th width="20px"></th>	
			</tr>
			</thead>
			<tbody>            
			</tbody>
	    </table>

    <div  id="dialog_EditarOferta" title="Edición de Oferta" style="display:none;">
    <form id="frmEdicionOferta" action="#">    
		<table cellpadding="3" cellspacing="3">
            <tr>
                <td>Producto :</td>
                <td>                    
                    <select id="cmbProductoEdicion"  style="width: 200px;" class="validate[required]" onchange="validarProducto()" name="IdProducto">
                    </select>
                </td> 
            </tr>
            <tr>
                <td>Puntaje :</td>
                <td>                    
                    <input id="txtPuntajeEdicion" class="validate[required]" name="Puntaje" onchange="validarPuntaje()"/>
                </td> 
            </tr>
            <tr>
                <td>Fecha de Vigencia - Inicio : </td>
                <td>
                    <input id="txtFechaVigenciaInicioEdicion" type="text" readonly="readonly" class="validate[required]" onchange="validarFechaVigenciaInicio()" name="vigenciaInicio"/>
                </td>
            </tr>
            <tr>
                <td>Fecha de Vigencia - Fin : </td>
                <td>
                    <input id="txtFechaVigenciaFinEdicion" type="text" readonly="readonly" class="validate[required]" onchange="validarFechaVigenciaFin()" name="vigenciaFin"/>
                </td>
            </tr>
        </table>												
    </form>
	</div>

</asp:Content>
