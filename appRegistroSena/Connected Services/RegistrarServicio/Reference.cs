﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appRegistroSena.RegistrarServicio {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RegistrarServicio.ServicioSoap")]
    public interface ServicioSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento HelloWorldResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        appRegistroSena.RegistrarServicio.HelloWorldResponse HelloWorld(appRegistroSena.RegistrarServicio.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.HelloWorldResponse> HelloWorldAsync(appRegistroSena.RegistrarServicio.HelloWorldRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento tipoVehiculo del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/mtdRegistrar", ReplyAction="*")]
        appRegistroSena.RegistrarServicio.mtdRegistrarResponse mtdRegistrar(appRegistroSena.RegistrarServicio.mtdRegistrarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/mtdRegistrar", ReplyAction="*")]
        System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.mtdRegistrarResponse> mtdRegistrarAsync(appRegistroSena.RegistrarServicio.mtdRegistrarRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public appRegistroSena.RegistrarServicio.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(appRegistroSena.RegistrarServicio.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public appRegistroSena.RegistrarServicio.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(appRegistroSena.RegistrarServicio.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class mtdRegistrarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="mtdRegistrar", Namespace="http://tempuri.org/", Order=0)]
        public appRegistroSena.RegistrarServicio.mtdRegistrarRequestBody Body;
        
        public mtdRegistrarRequest() {
        }
        
        public mtdRegistrarRequest(appRegistroSena.RegistrarServicio.mtdRegistrarRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class mtdRegistrarRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string tipoVehiculo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string placa;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string color;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string marca;
        
        public mtdRegistrarRequestBody() {
        }
        
        public mtdRegistrarRequestBody(string tipoVehiculo, string placa, string color, string marca) {
            this.tipoVehiculo = tipoVehiculo;
            this.placa = placa;
            this.color = color;
            this.marca = marca;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class mtdRegistrarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="mtdRegistrarResponse", Namespace="http://tempuri.org/", Order=0)]
        public appRegistroSena.RegistrarServicio.mtdRegistrarResponseBody Body;
        
        public mtdRegistrarResponse() {
        }
        
        public mtdRegistrarResponse(appRegistroSena.RegistrarServicio.mtdRegistrarResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class mtdRegistrarResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string mtdRegistrarResult;
        
        public mtdRegistrarResponseBody() {
        }
        
        public mtdRegistrarResponseBody(string mtdRegistrarResult) {
            this.mtdRegistrarResult = mtdRegistrarResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServicioSoapChannel : appRegistroSena.RegistrarServicio.ServicioSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioSoapClient : System.ServiceModel.ClientBase<appRegistroSena.RegistrarServicio.ServicioSoap>, appRegistroSena.RegistrarServicio.ServicioSoap {
        
        public ServicioSoapClient() {
        }
        
        public ServicioSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        appRegistroSena.RegistrarServicio.HelloWorldResponse appRegistroSena.RegistrarServicio.ServicioSoap.HelloWorld(appRegistroSena.RegistrarServicio.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            appRegistroSena.RegistrarServicio.HelloWorldRequest inValue = new appRegistroSena.RegistrarServicio.HelloWorldRequest();
            inValue.Body = new appRegistroSena.RegistrarServicio.HelloWorldRequestBody();
            appRegistroSena.RegistrarServicio.HelloWorldResponse retVal = ((appRegistroSena.RegistrarServicio.ServicioSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.HelloWorldResponse> appRegistroSena.RegistrarServicio.ServicioSoap.HelloWorldAsync(appRegistroSena.RegistrarServicio.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.HelloWorldResponse> HelloWorldAsync() {
            appRegistroSena.RegistrarServicio.HelloWorldRequest inValue = new appRegistroSena.RegistrarServicio.HelloWorldRequest();
            inValue.Body = new appRegistroSena.RegistrarServicio.HelloWorldRequestBody();
            return ((appRegistroSena.RegistrarServicio.ServicioSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        appRegistroSena.RegistrarServicio.mtdRegistrarResponse appRegistroSena.RegistrarServicio.ServicioSoap.mtdRegistrar(appRegistroSena.RegistrarServicio.mtdRegistrarRequest request) {
            return base.Channel.mtdRegistrar(request);
        }
        
        public string mtdRegistrar(string tipoVehiculo, string placa, string color, string marca) {
            appRegistroSena.RegistrarServicio.mtdRegistrarRequest inValue = new appRegistroSena.RegistrarServicio.mtdRegistrarRequest();
            inValue.Body = new appRegistroSena.RegistrarServicio.mtdRegistrarRequestBody();
            inValue.Body.tipoVehiculo = tipoVehiculo;
            inValue.Body.placa = placa;
            inValue.Body.color = color;
            inValue.Body.marca = marca;
            appRegistroSena.RegistrarServicio.mtdRegistrarResponse retVal = ((appRegistroSena.RegistrarServicio.ServicioSoap)(this)).mtdRegistrar(inValue);
            return retVal.Body.mtdRegistrarResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.mtdRegistrarResponse> appRegistroSena.RegistrarServicio.ServicioSoap.mtdRegistrarAsync(appRegistroSena.RegistrarServicio.mtdRegistrarRequest request) {
            return base.Channel.mtdRegistrarAsync(request);
        }
        
        public System.Threading.Tasks.Task<appRegistroSena.RegistrarServicio.mtdRegistrarResponse> mtdRegistrarAsync(string tipoVehiculo, string placa, string color, string marca) {
            appRegistroSena.RegistrarServicio.mtdRegistrarRequest inValue = new appRegistroSena.RegistrarServicio.mtdRegistrarRequest();
            inValue.Body = new appRegistroSena.RegistrarServicio.mtdRegistrarRequestBody();
            inValue.Body.tipoVehiculo = tipoVehiculo;
            inValue.Body.placa = placa;
            inValue.Body.color = color;
            inValue.Body.marca = marca;
            return ((appRegistroSena.RegistrarServicio.ServicioSoap)(this)).mtdRegistrarAsync(inValue);
        }
    }
}