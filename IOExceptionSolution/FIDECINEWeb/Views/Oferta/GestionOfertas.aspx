<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div class="ui-widget-content ui-corner-all"
		style="width: 99%; margin: 3px 3px 3px 3px;">
	<div class="ui-widget-header ui-corner-all"><label>Gestion de Ofertas</label></div>
	<div align="left" style="margin: 5px 5px 5px 5px;">
	     <table style="width: 783px">
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
                    <div ><label>Detalle de Oferta :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Por cada 
                    <select id="cmbCantidad" name="D3" style="width: 50px;">
                        <option>100</option>
                        <option>150</option>
                        <option>200</option>
                        <option>220</option>
                        <option>230</option>
                        <option>240</option>
                        <option>260</option>
                        <option>280</option>
                        <option>300</option>
                        <option>350</option>
                    </select>
                    puntos de consumos, se obsequia un(a)
                    <select id="cmbProductos" name="D2" >
                        <option>Entrada General</option>
                        <option>Entrada 3D</option>
                        <option>Pop Corn</option>
                        <option>Vasos</option>
                        <option>Peluche</option>
                        <option>Gafas</option>
                    </select>
                </label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" >&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" ><button id="btnRegistrar" >Registrar Oferta</button>
                <button id="Button1" >Cancelar</button></td>
            </tr>
            <tr>
                <td colspan="4" >
                        <div class="ui-widget-header ui-corner-all"><label>Ofertas Registradas</label></div>
                 </td>
            </tr>
            <tr>
                
                <td colspan="4" >
                    <table width="100%" border="0">
                  <tr>
                    <th width="64" scope="col"><div align="center">Código</div></th>
                    <th width="580" scope="col"><div align="left">Promoción</div></th>
                    <th width="100" scope="col" style="text-align: left"><div align="center">Vigencia Ini</div></th>
                    <th width="100" scope="col" style="text-align: left"><div align="center">Vigencia fin</div></th>
                  </tr>
                  <tr>
                    <th scope="row"><div align="center">Pr-001</div></th>
                    <td><div align="left">Por cada 100 puntos de consumo, gratis por 1 Entraga General</div></td>
                    <td><div align="center">10/09/2012</div></td>
                    <td><div align="left">10/10/2012</div></td>
                  </tr>
                  <tr>
                    <th scope="row"><div align="center">Pr-002</div></th>
                    <td><div align="left">Por cada 150 puntos de consumo, gratis por 1 Entraga 3D</div></td>
                    <td><div align="center">10/09/2012</div></td>
                    <td><div align="left">10/10/2012</div></td>
                  </tr>
                  <tr>
                    <th scope="row"><p align="center">Pr-003</p></th>
                    <td><div align="left">Por cada 350 puntos de consumo, gratis por 1 Peluchin</div></td>
                    <td><div align="center">10/09/2012</div></td>
                    <td><div align="left">10/10/2012</div></td>
                  </tr>
                </table>
                </td>
            </tr>
        </table>
	</div>
	</div>
    </form>
</asp:Content>
