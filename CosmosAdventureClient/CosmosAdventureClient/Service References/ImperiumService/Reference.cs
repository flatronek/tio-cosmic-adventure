﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CosmosAdventureClient.ImperiumService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImperiumService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMoneyFromImperium", ReplyAction="http://tempuri.org/IService1/GetMoneyFromImperiumResponse")]
        int GetMoneyFromImperium();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMoneyFromImperium", ReplyAction="http://tempuri.org/IService1/GetMoneyFromImperiumResponse")]
        System.Threading.Tasks.Task<int> GetMoneyFromImperiumAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : CosmosAdventureClient.ImperiumService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<CosmosAdventureClient.ImperiumService.IService1>, CosmosAdventureClient.ImperiumService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetMoneyFromImperium() {
            return base.Channel.GetMoneyFromImperium();
        }
        
        public System.Threading.Tasks.Task<int> GetMoneyFromImperiumAsync() {
            return base.Channel.GetMoneyFromImperiumAsync();
        }
    }
}
