﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIDECINEWeb.PeliculaServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PeliculaServiceReference.IPeliculaService")]
    public interface IPeliculaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/listar", ReplyAction="http://tempuri.org/IPeliculaService/listarResponse")]
        FIDECINEService.Dominio.PeliculaBE[] listar(string str_pNombre, string str_pEstado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/InsertarPelicula", ReplyAction="http://tempuri.org/IPeliculaService/InsertarPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE InsertarPelicula(FIDECINEService.Dominio.PeliculaBE entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ObtenerPelicula", ReplyAction="http://tempuri.org/IPeliculaService/ObtenerPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE ObtenerPelicula(string idPelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ModificarPelicula", ReplyAction="http://tempuri.org/IPeliculaService/ModificarPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE ModificarPelicula(FIDECINEService.Dominio.ClienteBE objClienteBE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/EliminarPelicula", ReplyAction="http://tempuri.org/IPeliculaService/EliminarPeliculaResponse")]
        void EliminarPelicula(string idPelicula);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ListarPeliculas", ReplyAction="http://tempuri.org/IPeliculaService/ListarPeliculasResponse")]
        FIDECINEService.Dominio.PeliculaBE[] ListarPeliculas(string nombre, string idCategoria, string idTipo, string idGenero, string estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ListarGeneroPelicula", ReplyAction="http://tempuri.org/IPeliculaService/ListarGeneroPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE[] ListarGeneroPelicula();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ListarTipoPelicula", ReplyAction="http://tempuri.org/IPeliculaService/ListarTipoPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE[] ListarTipoPelicula();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeliculaService/ListarCategoriaPelicula", ReplyAction="http://tempuri.org/IPeliculaService/ListarCategoriaPeliculaResponse")]
        FIDECINEService.Dominio.PeliculaBE[] ListarCategoriaPelicula();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPeliculaServiceChannel : FIDECINEWeb.PeliculaServiceReference.IPeliculaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PeliculaServiceClient : System.ServiceModel.ClientBase<FIDECINEWeb.PeliculaServiceReference.IPeliculaService>, FIDECINEWeb.PeliculaServiceReference.IPeliculaService {
        
        public PeliculaServiceClient() {
        }
        
        public PeliculaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PeliculaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeliculaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeliculaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FIDECINEService.Dominio.PeliculaBE[] listar(string str_pNombre, string str_pEstado) {
            return base.Channel.listar(str_pNombre, str_pEstado);
        }
        
        public FIDECINEService.Dominio.PeliculaBE InsertarPelicula(FIDECINEService.Dominio.PeliculaBE entidad) {
            return base.Channel.InsertarPelicula(entidad);
        }
        
        public FIDECINEService.Dominio.PeliculaBE ObtenerPelicula(string idPelicula) {
            return base.Channel.ObtenerPelicula(idPelicula);
        }
        
        public FIDECINEService.Dominio.PeliculaBE ModificarPelicula(FIDECINEService.Dominio.ClienteBE objClienteBE) {
            return base.Channel.ModificarPelicula(objClienteBE);
        }
        
        public void EliminarPelicula(string idPelicula) {
            base.Channel.EliminarPelicula(idPelicula);
        }
        
        public FIDECINEService.Dominio.PeliculaBE[] ListarPeliculas(string nombre, string idCategoria, string idTipo, string idGenero, string estado) {
            return base.Channel.ListarPeliculas(nombre, idCategoria, idTipo, idGenero, estado);
        }
        
        public FIDECINEService.Dominio.PeliculaBE[] ListarGeneroPelicula() {
            return base.Channel.ListarGeneroPelicula();
        }
        
        public FIDECINEService.Dominio.PeliculaBE[] ListarTipoPelicula() {
            return base.Channel.ListarTipoPelicula();
        }
        
        public FIDECINEService.Dominio.PeliculaBE[] ListarCategoriaPelicula() {
            return base.Channel.ListarCategoriaPelicula();
        }
    }
}
