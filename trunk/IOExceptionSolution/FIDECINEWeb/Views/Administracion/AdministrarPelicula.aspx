
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

     function Select1_onclick() {

     }

 </script>
			
	<div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Administración de Películas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table style="width: 783px">
            <tr>
                <td>Nombre :</td>
                <td>                    
                    <input type="text" style="width: 200px;"/>
                </td>
                <td style="width: 125px">Genero :</td>
                <td>                    
                    <select id="Select4" name="D2" style="width: 130px;">
                        <option>Terror</option>
                        <option>Comedia</option> 
                        <option>Accion</option>  
                        <option>Drama</option> 
                                               
                    </select>
                </td> 
            </tr>   
            <tr>
                <td>Categoría :</td>
                <td>                    
                    <select id="Select5" name="D2" style="width: 130px;">
                        <option>HD</option>
                        <option>3D</option> 
                        <option>Subtitulada</option> 
                        <option>Español</option>                        
                    </select>
                </td>

                
                <td style="width: 125px">Trailer de la pelicula :</td>
                <td>                    
                    <input type="text" style="width: 200px; height: 27px;"/>
                </td>
                <td>&nbsp;</td>
                <td>                    
                    &nbsp;</td> 
            </tr>   
            <tr>
             <td style="width: 125px; height: 27px;">Descripcion de la pelicula :</td>
                <td style="height: 27px">                    
                    &nbsp;<input type="text" style="width: 200px; height: 27px;"/></td>
                <td style="height: 27px"></td>
                <td style="height: 27px">                    
                    &nbsp;</td> 
            </tr>   
           <tr>
           
                
                <td>Tipo :</td>
                <td>                    
                    <select id="Select2" name="D2" style="width: 130px;">
                        <option>Apta todo público</option>
                        <option>Mayor a 18</option>   
                         <option>Mayor a 14</option>                          
                    </select>
                </td> 
            </tr>  
            <tr>
                <td>Estado :</td>
                <td>                    
                    <select id="Select8" name="D2" style="width: 130px;">
                        <option>Activo</option>
                        <option>Inactivo</option>                        
                    </select>
                </td>
                <td style="width: 125px"></td>
                <td>                    
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
				<th width="185px">Nombre</th>
				<th width="100px">Genero</th>
				<th width="100px">Categoría</th>	
                <th width="100px">Tipo</th>		
                <th width="185px">Página Web</th>   
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
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr>   
            <tr>
                <td>bbbb</td>
                <td>bbb</td>
                <td>bbbb</td>
                <td>bbbbbb</td>
                <td>bbbbbbbbb</td>
                <td>bbbbbbbbb</td>
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr> 
            <tr>
                <td>cccccccccc</td>
                <td>ccccccccccc</td>
                <td>ccccccccccc</td>
                <td>ccccccccccc</td>
                <td>cccccccccccccc</td>
                <td>cccccccccccccc</td>
                <td><img src="../../Content/images/iconos/mantenimiento/editar.png"/></td>
            </tr>         
			</tbody>
			<tfoot>
			</tfoot>
	    </table>
    </form>


    <div  id="dialog_modal" title="Edición de Película">
		<table>
            <tr>
                <td>Nombre :</td>
                <td>
                    <input type="text" style="width: 200px;"/>
                </td> 
            </tr>
            
            <tr>
                <td>Descripcion :</td>
                <td>
                    <input type="text" style="width: 200px;"/>
                </td> 
            </tr>
            
            <tr>
                <td>Trailer (Página Web) :</td>
                <td>
                    <input type="text" style="width: 300px;"/>
                </td> 
            </tr>           
            <tr>
                <td>Género: </td>
                <td>
                    <select id="Select1" name="D2" style="width: 130px;" onclick="return Select1_onclick()">
                        <option>Terror</option>
                        <option>Comedia</option> 
                         <option>Accion</option>  
                        <option>Drama</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>Categoría :</td>
                <td>                    
                    <select id="Select6" name="D2" style="width: 130px;">
                        <option>HD</option>
                        <option>3D</option> 
                        <option>Subtitulada</option> 
                        <option>Español</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>Tipo :</td>
                <td>                    
                    <select id="Select7" name="D2" style="width: 130px;">
                        <option>Apta todo público</option>
                        <option>Mayor a 18</option>   
                         <option>Mayor a 14</option>                  
                    </select>
                </td> 
            </tr>
            <tr>
                <td>Estado : </td>
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
