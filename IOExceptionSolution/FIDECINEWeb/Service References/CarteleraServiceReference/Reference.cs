﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIDECINEWeb.CarteleraServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarteleraServiceReference.ICarteleraService")]
    public interface ICarteleraService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarteleraService/insertar", ReplyAction="http://tempuri.org/ICarteleraService/insertarResponse")]
        void insertar(int int_pIdPelicula, int int_pIdSala, string str_pFechaHora);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICarteleraServiceChannel : FIDECINEWeb.CarteleraServiceReference.ICarteleraService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CarteleraServiceClient : System.ServiceModel.ClientBase<FIDECINEWeb.CarteleraServiceReference.ICarteleraService>, FIDECINEWeb.CarteleraServiceReference.ICarteleraService {
        
        public CarteleraServiceClient() {
        }
        
        public CarteleraServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CarteleraServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarteleraServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarteleraServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void insertar(int int_pIdPelicula, int int_pIdSala, string str_pFechaHora) {
            base.Channel.insertar(int_pIdPelicula, int_pIdSala, str_pFechaHora);
        }
    }
}