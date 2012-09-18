
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

 <script type="text/javascript">

     $(document).ready(function () {
         $("#Table1").styleTable();


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

         $("#fechaHora").datetimepicker({
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
             height: 200,
             width: 350,
             modal: true,
             buttons: {
                 "Guardar": function () {
                     var bValid = true;
                     allFields.removeClass("ui-state-error");

                     bValid = bValid && checkLength(name, "username", 3, 16);
                     bValid = bValid && checkLength(email, "email", 6, 80);
                     bValid = bValid && checkLength(password, "password", 5, 16);

                     bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
                     // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/
                     bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");
                     bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");

                     if (bValid) {
                         $("#users tbody").append("<tr>" +
							"<td>" + name.val() + "</td>" +
							"<td>" + email.val() + "</td>" +
							"<td>" + password.val() + "</td>" +
						"</tr>");
                         $(this).dialog("close");
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
                        <option>Los Invencibles</option>
                        <option>El Caballero de la Noche</option>
                        <option>La Era del Rock</option>
                    </select>
                </td> 
                <td>
                Sala :
                </td> 
                <td>
                    <select id="cmbSala" name="D2" style="width: 100px;">
                        <option>Sala 01</option>
                        <option>Sala 02</option>
                        <option>Sala 03</option>
                    </select>
                </td>
            </tr>   
            <tr>
                <td>Fecha y Hora : </td>
                <td>
                    Desde
                    <input id="txtFechaHoraDesde" type="text"/>
                </td>
                <td>
                    Hasta
                </td>
                <td>
                    <input id="txtFechaHoraHasta" type="text"/>
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


    <div  id="dialog_modal" title="Edición de Horario de Proyección de Película">
		<table>
            <tr>
                <td>Película :</td>
                <td>
                    
                    <select id="Select1" name="D1" style="width: 200px;">
                        <option>Los Invencibles</option>
                        <option>El Caballero de la Noche</option>
                        <option>La Era del Rock</option>
                    </select>
                </td> 
            </tr>
            <tr>
                <td>
                Sala :
                </td> 
                <td>
                    <select id="Select2" name="D2" style="width: 100px;">
                        <option>Sala 01</option>
                        <option>Sala 02</option>
                        <option>Sala 03</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Fecha y Hora : </td>
                <td>
                    <input id="fechaHora" type="text"/>
                </td>
            </tr>
        </table>												
	</div>
	
	<button id="create-user" style="display:none;">Create new user</button>


</asp:Content>
