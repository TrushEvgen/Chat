﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClientWPF.ChatWCFService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatWCFService.IChat", CallbackContract=typeof(ChatClientWPF.ChatWCFService.IChatCallback))]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Send")]
        void Send(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Send")]
        System.Threading.Tasks.Task SendAsync(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Join")]
        void Join(ChatClientWPF.ChatWCFService.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Join")]
        System.Threading.Tasks.Task JoinAsync(ChatClientWPF.ChatWCFService.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Whisper")]
        void Whisper(ChatClientWPF.ChatWCFService.User toUser, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Whisper")]
        System.Threading.Tasks.Task WhisperAsync(ChatClientWPF.ChatWCFService.User toUser, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Leave")]
        void Leave(ChatClientWPF.ChatWCFService.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Leave")]
        System.Threading.Tasks.Task LeaveAsync(ChatClientWPF.ChatWCFService.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/GetMessages")]
        void GetMessages(ChatClientWPF.ChatWCFService.User user, string text);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/GetUserList")]
        void GetUserList(ChatClientWPF.ChatWCFService.User[] users);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserJoined")]
        void UserJoined(ChatClientWPF.ChatWCFService.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserLeave")]
        void UserLeave(ChatClientWPF.ChatWCFService.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveWhisper")]
        void ReceiveWhisper(ChatClientWPF.ChatWCFService.User fromUser, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : ChatClientWPF.ChatWCFService.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.DuplexClientBase<ChatClientWPF.ChatWCFService.IChat>, ChatClientWPF.ChatWCFService.IChat {
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Send(string message) {
            base.Channel.Send(message);
        }
        
        public System.Threading.Tasks.Task SendAsync(string message) {
            return base.Channel.SendAsync(message);
        }
        
        public void Join(ChatClientWPF.ChatWCFService.User user) {
            base.Channel.Join(user);
        }
        
        public System.Threading.Tasks.Task JoinAsync(ChatClientWPF.ChatWCFService.User user) {
            return base.Channel.JoinAsync(user);
        }
        
        public void Whisper(ChatClientWPF.ChatWCFService.User toUser, string message) {
            base.Channel.Whisper(toUser, message);
        }
        
        public System.Threading.Tasks.Task WhisperAsync(ChatClientWPF.ChatWCFService.User toUser, string message) {
            return base.Channel.WhisperAsync(toUser, message);
        }
        
        public void Leave(ChatClientWPF.ChatWCFService.User user) {
            base.Channel.Leave(user);
        }
        
        public System.Threading.Tasks.Task LeaveAsync(ChatClientWPF.ChatWCFService.User user) {
            return base.Channel.LeaveAsync(user);
        }
    }
}
