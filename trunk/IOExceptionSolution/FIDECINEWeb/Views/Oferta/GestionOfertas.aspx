<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Gestion de Ofertas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table width="600px">
            <tr>
                <td>Codigo Promocion :</td>
                <td>                
                    <input  type="text" />    
                </td> 
                <td>
                    Nombre Promocion :
                </td> 
                <td>
                    <input  type="text" />    
                </td> 
            </tr>   
            <tr>
                <td>Vigencia Fecha : </td>
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
            <tr>
                <td colspan="4" >
                    <div class="ui-widget-header ui-corner-all"><label>Detalle de Oferta</label></div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" >Por cada 
                    <select id="cmbCantidad" name="D2" style="width: 50px;">
                        <option>01</option>
                        <option>02</option>
                        <option>03</option>
                        <option>04</option>
                        <option>05</option>
                        <option>06</option>
                        <option>07</option>
                        <option>08</option>
                        <option>09</option>
                        <option>10</option>
                    </select>
                    puntos de consumos, se obsequia un(a)
                    <select id="cmbProductos" name="D2" >
                        <option>Entrada General</option>
                        <option>Entrada 3D</option>
                        <option>Pop Corn</option>
                        <option>Peluche</option>
                        <option>Gafas</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="4" ><button id="btnRegistrar" >Registrar Oferta</button>
                <button id="Button1" >Cancelar</button></td>
            </tr>
             
        </table>
	</div>
	</div>
</asp:Content>
