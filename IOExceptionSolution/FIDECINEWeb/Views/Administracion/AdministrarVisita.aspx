﻿
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

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
             height: 250,
             width: 500,
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
	<div class="ui-widget-header ui-corner-all"><label>Administración de Visitas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table width="600px">
            <tr>
                <td style="width: 68px">DNI :</td>
                <td>                    
                    <input type="text" style="width: 156px;" maxlength="8"/>&nbsp;<button id="btnBuscar" onclick="return buscar();">Buscar</button>   
                </td>
            </tr>   
            </table>
	</div>
	</div>

 

    <div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
    <div class="ui-widget-header ui-corner-all"><label>Datos de Cliente</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table width="400px">
            <tr>
                <td>DNI :</td>
                <td>                    
                    <input type="text" maxlength="8" readonly="readonly"/>  
                </td>
            </tr> 
            <tr>
                <td>Nombres :</td>
                <td>                    
                    <input type="text" readonly="readonly"/>  
                </td>
            </tr>  
            <tr>
                <td>Apellido Paterno :</td>
                <td>                    
                    <input type="text" readonly="readonly"/>  
                </td>
            </tr> 
             <tr>
                <td>Apellido Materno :</td>
                <td>                    
                    <input type="text" readonly="readonly"/>  
                </td>
            </tr> 
            <tr>
                <td>Tipo de Cliente :</td>
                <td>                    
                    <input type="text" maxlength="8" readonly="readonly"/>  
                </td>
            </tr> 
         </table>
	</div>
	</div>

	<div class="ui-widget-content ui-corner-all" align="center"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	    <div style="margin: 3px 3px 3px 3px;">

            <button id="btnNuevo" onclick="return nuevoHorario();">Nuevo</button>
                     
        </div>
	</div>

	    <table  id="Table1" width="790px" class="styleTable">
			<thead>
			<tr>
				<th width="185px">Pelicula</th>
				<th width="100px">Sala</th>
				<th width="100px">Fcha y Hora</th>	
                <th width="100px">Entradas</th>		
                <th width="20px"></th>	
			</tr>
			</thead>
			<tbody>                   
			</tbody>
			<tfoot>
			</tfoot>
	    </table>
    </form>


    <div  id="dialog_modal" title="Nueva Visita">
		<table>
            <tr>
                <td>DNI Cliente:</td>
                <td>
                    <input type="text" style="width: 82px; text-align: left;"/>
                </td> 
            </tr>
            <tr>
                <td>Película :</td>
                <td>
                    <input type="text" style="width: 200px;"/>
                </td> 
            </tr>
            <tr>
                <td>Página Web :</td>
                <td>
                    <input type="text" style="width: 300px;"/>
                </td> 
            </tr>           
            <tr>
                <td>Género: </td>
                <td>
                    <select id="Select1" name="D2" style="width: 130px;">
                        <option>Terror</option>
                        <option>Comedia</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>Categoría :</td>
                <td>                    
                    <select id="Select6" name="D2" style="width: 130px;">
                        <option>Terror</option>
                        <option>Comedia</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>Tipo :</td>
                <td>                    
                    <select id="Select7" name="D2" style="width: 130px;">
                        <option>Apta todo público</option>
                        <option>Mayor a 18</option>                        
                    </select>
                </td> 
            </tr>
            <tr>
                <td>Sala : </td>
                <td>
                    <select id="Select8" name="D3" style="width: 100px;">
                        <option>Activo</option>
                        <option>Inactivo</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>Fecha y Hora : </td>
                <td>
                    <select id="Select3" name="D2" style="width: 100px;">
                        <option>Activo</option>
                        <option>Inactivo</option>                        
                    </select>
                </td>
            </tr>
        </table>												
	</div>
	
	<button id="create-user" style="display:none;">Create new user</button>


</asp:Content>
