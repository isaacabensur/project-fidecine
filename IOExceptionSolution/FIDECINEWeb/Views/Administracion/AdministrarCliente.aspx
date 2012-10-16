
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="frmBuscarClientes" runat="server">

 <script type="text/javascript">

     $(document).ready(function () {
         $("#Table1").styleTable();

         $("#fechaHora").datepicker({
             showOn: "button",
             buttonImage: "../Content/images/calendar.gif",
             buttonImageOnly: true
         });



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

         // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
         $("#dialog:ui-dialog").dialog("destroy");

         var name = $("#name"),
			email = $("#email"),
			password = $("#password"),
			allFields = $([]).add(name).add(email).add(password),
			tips = $(".validateTips");

         function updateTips(t) {
             tips
				.text(t)
				.addClass("ui-state-highlight");
             setTimeout(function () {
                 tips.removeClass("ui-state-highlight", 1500);
             }, 500);
         }

         function checkLength(o, n, min, max) {
             if (o.val().length > max || o.val().length < min) {
                 o.addClass("ui-state-error");
                 updateTips("Length of " + n + " must be between " +
					min + " and " + max + ".");
                 return false;
             } else {
                 return true;
             }
         }

         function checkRegexp(o, regexp, n) {
             if (!(regexp.test(o.val()))) {
                 o.addClass("ui-state-error");
                 updateTips(n);
                 return false;
             } else {
                 return true;
             }
         }

         $("#dialog_modal").dialog({
             autoOpen: false,
             height: 350,
             width: 600,
             modal: true,
             buttons: {
                 "Guardar": function () {
                     var esValido = true;
                     esValido = $("#frmClienteRegistro").validationEngine('validate');
                     if (esValido) {
                         $('#btnSi').unbind('click');
                         $("#btnSi").click(function () {
                             $.post('/AdministrarCliente/insertarCliente', $('#frmClienteRegistro').serializeArray(), function (data) {
                                 informacion(data.Mensaje);
                                 $("#dialog_modal").dialog("close");
                             },
                            "json")
                            .success(function () { buscarClientes() });
                         });
                         confirmacion('¿Desea guardar los datos ingresados?');
                     }
                 },
                 Cancel: function () {
                     $(this).dialog("close");
                 }
             },
             close: function () {
                 allFields.val("").removeClass("ui-state-error");
             }
         });

         $("#create-user")
			.button()
			.click(function () {
			    $("#dialog_modal").dialog("open");
			});

     });

     function nuevoHorario() {
         $("#create-user").click();
         return false;
     }

     function buscarClientes() {

         $.post('/AdministrarCliente/buscarCliente', $('#frmBuscarClientes').serializeArray(), function (data) {
             procesarLista(data.lstClientes);
         },
         "json");

         $("#tbClientes").styleTable();

         return false;
     }
     function procesarLista(lista) {

         $("#tbClientes > tbody").empty();

         $.each(lista, function (i, objeto) {
             var newRow = '';
             newRow = "<tr>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.idcliente + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.nombre + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.apellidoPaterno + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.apellidoMaterno + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.dni + "</td>";
             newRow = newRow + "<td class='ui-widget-content'>" + objeto.tipocliente + "</td>";
             newRow = newRow + "<td class='ui-widget-content' align='center' valign='middle'><img src='../../Content/images/iconos/mantenimiento/eliminar.png' onclick='eliminarCliente(" + objeto.idcliente + ");' title='eliminar' style='cursor:hand;'/></td>";
             newRow = newRow + "</tr>";

             $("#tbClientes").append(newRow);

         });
     }
     function cmbSala_onclick() {

     }

     function eliminarCliente(idCliente) {

         $('#btnSi').unbind('click');
         $("#btnSi").click(function () {

             $.post('/AdministrarCliente/eliminarCliente', { 'IdCliente': idCliente }, function (data) {

                 informacion(data.Mensaje);

             },
             "json")
             .success(function () { buscarClientes() });

         });

         confirmacion('¿Desea eliminar el Cliente seleccionado?');

     }

 </script>
			
	<div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Administración de Clientes</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table width="600px">
            <tr>
                <td>Nombre o Apellidos :</td>
                <td>                    
                    <input type="text" style="width: 200px;" name="strNombre" />
                </td>
                <td>DNI :</td>
                <td>                    
                    <input type="text" style="width: 100px;" name="strDNI" />
                </td> 
            </tr>   
            <tr>
                <td>Tipo : </td>
                <td>
                    <select id="cmbSala" name="strTipoCliente" style="width: 100px;" onclick="return cmbSala_onclick()">
                        <option value="T">Todos</option>
                        <option value="P">Premiun</option>
                        <option value="O">Oro</option>
                        <option value="C">Corporativo</option>                      
                    </select>
                </td>
                <td>Estado : </td>
                <td>
                    <select id="Select2" name="strEstado" style="width: 100px;">
                        <option value="A" >Activo</option>
                        <option value="I" >Inactivo</option>                        
                    </select>
                </td>
            </tr>     
        </table>
	</div>
	</div>


	<div class="ui-widget-content ui-corner-all" align="center"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	    <div style="margin: 3px 3px 3px 3px;">

            <button id="btnNuevo" onclick="return nuevoHorario();">Nuevo</button>
            <button id="btnBuscar" onclick="return buscarClientes();">Buscar</button>            
        </div>
	</div>

	    <table  id="tbClientes" width="790px" class="styleTable" >
			<thead>
			<tr>
				<th width="300px">ID Cliente</th>
				<th width="300px">Nombre</th>
                <th width="300px">Apellido Parterno</th>
                <th width="300px">Apellido Marterno</th>
				<th width="170px">Dni</th>		
                <th width="20px">Tipo Cliente</th>
                <th width="20px"></th>
			</tr>
			</thead>
			<tbody>            
			</tbody>
	    </table>
    </form>


    <div  id="dialog_modal" title="Edición de Cliente" style="height: 325px">
        <form id="frmClienteRegistro" action="#">  
		    <table>
                <tr>
                    <td>Nombres :</td>
                    <td>
                        <input type="text" style="width: 200px;" name="nombre" />
                    </td> 
                </tr>
                <tr>
                    <td>Apellido Paterno :</td>
                    <td>
                        <input type="text" style="width: 200px;" name="apellidoPaterno" />
                    </td> 
                </tr>
                <tr>
                    <td>Apellido Materno :</td>
                    <td>
                        <input type="text" style="width: 200px;" name="apellidoMaterno" />
                    </td> 
                </tr>
                <tr>
                    <td>Correo Electrónico :</td>
                    <td>
                        <input type="text" style="width: 200px;" name="correo" />
                    </td> 
                </tr>
                <tr>
                    <td>Dirección:</td>
                    <td>
                        <input type="text" style="width: 300px;" name="direccion" />
                    </td> 
                </tr>
                <tr>
                    <td>DNI :</td>
                    <td>
                        <input type="text" style="width: 100px;" name="dni" />
                    </td>
                </tr>
                
                <tr>
                    <td>Fecha de Nacimiento : </td>
                    <td>
                        <input id="fechaHora" type="text" name="fechaNacimiento" />
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cliente : </td>
                    <td>
                        <select id="cmbTipoCliente" style="width: 100px;" name="tipocliente" >
                            <option value="P" >Premiun</option>
                            <option value="O">Oro</option>
                            <option value="C">Corporativo</option>                        
                        </select>
                    </td>
                </tr>
                
            </table>												
        </form>
	</div>
	
	<button id="create-user" style="display:none;">Create new user</button>


</asp:Content>
