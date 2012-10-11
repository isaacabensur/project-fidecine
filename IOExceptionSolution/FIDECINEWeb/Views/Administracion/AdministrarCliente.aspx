
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

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
                            .success(function () { buscarHorarios() });
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

     function buscar() {

         $.post('/AdministrarHorario/buscar', $('#frmBusqueda').serializeArray(), function (data) {
             $("#Table1 > tbody").empty();

             $.each(data, function (i, objeto) {
                 var newRow = '';
                 newRow = "<tr>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.Pelicula + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.Sala + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.FechaHora + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'><img src='../../Content/images/iconos/mantenimiento/eliminar.png'/></td>";
                 newRow = newRow + "</tr>";

                 $("#Table1").append(newRow);

             });
         },
         "json");

         $("#Table1").styleTable();

         return false;
     }

     function cmbSala_onclick() {

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
                    <input type="text" style="width: 200px;"/>
                </td>
                <td>DNI :</td>
                <td>                    
                    <input type="text" style="width: 100px;"/>
                </td> 
            </tr>   
            <tr>
                <td>Tipo : </td>
                <td>
                    <select id="cmbSala" name="D2" style="width: 100px;" onclick="return cmbSala_onclick()">
                        <option>Premiun</option>
                        <option>Oro</option>                        
                        <option>Corporativo</option>                        
                    </select>
                </td>
                <td>Estado : </td>
                <td>
                    <select id="Select2" name="D2" style="width: 100px;">
                        <option>Activo</option>
                        <option>Inactivo</option>                        
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
            <button id="btnBuscar" onclick="return buscar();">Buscar</button>            
        </div>
	</div>

	    <table  id="Table1" width="790px" class="styleTable">
			<thead>
			<tr>
				<th width="140px">Nombre</th>
				<th width="120px">Apellito Paterno</th>
				<th width="130px">Apellido Materno</th>	
                <th width="80px">DNI</th>		
                <th width="150px">Fecha de Nacimiento</th>
                <th width="80px">Tipo</th> 
                <th width="100px">Estado</th>                
                <th width="20px"></th>	
			</tr>
			</thead>
			<tbody>
            <tr>
                <td>aa</td>
                <td>aaa</td>
                <td>aaaa</td>
                <td>aaaa</td>
                <td>aaaa</td>
                <td>aaaa</td>
                 <td>aaaa</td>
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr>   
            <tr>
                <td>bbbb</td>
                <td>bbb</td>
                <td>bbbb</td>
                <td>bbbbbb</td>
                <td>bbbbbbbbb</td>
                <td>bbbbbbbbbbb</td>
                <td>bbbbbbbbbbb</td>
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr> 
            <tr>
                <td>cccccccccc</td>
                <td>ccccccccccc</td>
                <td>ccccccccccc</td>
                <td>ccccccccccc</td>
                <td>cccccccccccccc</td>
                <td>ccccccccccccc</td>
                <td>ccccccccccccc</td>
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr>         
			</tbody>
			<tfoot>
			</tfoot>
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
