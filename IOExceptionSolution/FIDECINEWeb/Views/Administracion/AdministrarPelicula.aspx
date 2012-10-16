
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FIDECINEWeb.Models.PeliculaModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="frmBusqueda" runat="server">

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

                     var esValido = true;
                     esValido = $("#frmPeliculaRegistro").validationEngine('validate');
                     if (esValido) {
                         $('#btnSi').unbind('click');
                         $("#btnSi").click(function () {
                             $.post('/AdministrarPelicula/insertarPelicula', $('#frmPeliculaRegistro').serializeArray(), function (data) {
                                 informacion(data.Mensaje);
                                 $("#dialog_modal").dialog("close");
                             },
                            "json")
                            .success(function () { buscarPeliculas() });
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

     });re

     function nuevoHorario() {
         $("#create-user").click();
         return false;
     }
     
     function buscarPeliculas() {

         $.post('/AdministrarPelicula/buscarPelicula', $('#frmBusqueda').serializeArray(), function (data) {
             $("#Table1 > tbody").empty();

             $.each(data, function (i, objeto) {
                 var newRow = '';
                 newRow = "<tr>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.IdPelicula + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.nombre + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.trailer + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.estado + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.idTipo + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.IdGenero + "</td>";
                 newRow = newRow + "<td class='ui-widget-content'>" + objeto.idCategoria + "</td>";
                                  newRow = newRow + "<td class='ui-widget-content'><img src='../../Content/images/iconos/mantenimiento/eliminar.png'/></td>";
                 newRow = newRow + "</tr>";


                 $("#tbClientes").append(newRow);

             });
         },
         "json");

         $("#tbClientes").styleTable();

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
                
            </tr>
            <tr>
                <td style="width: 125px">Genero :</td>
                <td>                    
                    <select id="Select4" name="D2" style="width: 130px;">
                        <option value="T" >Todos</option>
                        
                        <% if (Model.lstGenero != null)
                           {
                               foreach (var item in Model.lstGenero)
                               { %>
                            <option value="<%= item.IdGenero %>"><%= item.descGenero%></option>
                        <% }
                           }%>                                       
                    </select>
                </td> 
            </tr>   
            <tr>
                <td>Tipo :</td>
                <td>                    
                    <select id="Select2" name="D2" style="width: 130px;">
                        <option value="T" >Todos</option>
                        <% if (Model.lstTipo != null)
                           {
                               foreach (var item in Model.lstTipo)
                               { %>
                            <option value="<%= item.IdTipo %>"><%= item.descTipo%></option>
                        <% }
                           }%>
                    </select>
                </td> 
            </tr>  
            <tr>
                <td>Categoría :</td>
                <td>                    
                    <select id="Select5" name="D2" style="width: 130px;">
                        <option value="T" >Todos</option>
                        <% if (Model.lstCategoria != null)
                           {
                               foreach (var item in Model.lstCategoria)
                               { %>
                            <option value="<%= item.IdCategoria %>"><%= item.descCategoria%></option>
                        <% }
                           }%>                        
                    </select>
                </td>
            </tr>
                <tr>
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

	    <table  id="tbClientes" width="790px" class="styleTable" >
			<thead>
			<tr>
				<th width="300px">ID Pelicula</th>
				<th width="300px">Nombre</th>
                <th width="300px">trailer</th>
                <th width="300px">Estado</th>
				<th width="170px">Tipo</th>		
                <th width="20px">Genero</th>
                <th width="20px">Categoria</th>
                <th width="20px"></th>
			</tr>
			</thead>
			<tbody>            
			</tbody>
	    </table>
    </form>


    <div  id="dialog_modal" title="Edición de Película">
        <form id="frmPeliculaRegistro" action="#">  
        
		<table>
            <tr>
                <td>Nombre :</td>
                <td>
                    <input type="text" style="width: 200px;" name="nombre" />
                </td> 
            </tr>
            
            <tr>
                <td>Descripcion :</td>
                <td>
                    <input type="text" style="width: 200px;" name="descripcion" />
                </td> 
            </tr>
            
            <tr>
                <td>Trailer (Página Web) :</td>
                <td>
                    <input type="text" style="width: 300px;" name="trailer" />
                </td> 
            </tr>
            <tr>
                <td>Duracion :</td>
                <td>
                    <input type="text" style="width: 200px;" name="duracion" />
                </td> 
            </tr>           
            <tr>
                <td>Género: </td>
                <td>
                    <select id="Select1" name="cboGenero" style="width: 130px;" onclick="return Select1_onclick()">
                        <% if (Model.lstGenero != null)
                           {
                               foreach (var item in Model.lstGenero)
                               { %>
                            <option value="<%= item.IdGenero %>"><%= item.descGenero%></option>
                        <% }
                           }%>                                       
                    </select>
                </td>
            </tr>
            <tr>
                <td>Categoría :</td>
                <td>                    
                    <select id="Select6" name="cboCategoria" style="width: 130px;">
                        <% if (Model.lstCategoria != null)
                           {
                               foreach (var item in Model.lstCategoria)
                               { %>
                            <option value="<%= item.IdCategoria %>"><%= item.descCategoria%></option>
                        <% }
                           }%>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Tipo :</td>
                <td>                    
                    <select id="Select7" name="cboTipo" style="width: 130px;">
                        <% if (Model.lstTipo != null)
                           {
                               foreach (var item in Model.lstTipo)
                               { %>
                            <option value="<%= item.IdTipo %>"><%= item.descTipo%></option>
                        <% }
                           }%>                                       
                    </select>
                </td> 
            </tr>
            <tr>
                <td>Estado : </td>
                <td>
                    <select id="Select3" name="cboestado" style="width: 100px;">
                        <option value="A" >Activo</option>
                        <option value="I" >Inactivo</option>                        
                    </select>
                </td>
            </tr>
        </table>												
        </form>
	</div>
	
	<button id="create-user" style="display:none;">Create new user</button>


</asp:Content>
