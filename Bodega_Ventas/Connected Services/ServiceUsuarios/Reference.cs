﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodega_Ventas.ServiceUsuarios {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUsuarios.UsuariosSoap")]
    public interface UsuariosSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento HelloWorldResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        Bodega_Ventas.ServiceUsuarios.HelloWorldResponse HelloWorld(Bodega_Ventas.ServiceUsuarios.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.HelloWorldResponse> HelloWorldAsync(Bodega_Ventas.ServiceUsuarios.HelloWorldRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento serialpc del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerIdUsuario", ReplyAction="*")]
        Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse ObtenerIdUsuario(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerIdUsuario", ReplyAction="*")]
        System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse> ObtenerIdUsuarioAsync(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public Bodega_Ventas.ServiceUsuarios.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(Bodega_Ventas.ServiceUsuarios.HelloWorldRequestBody Body) {
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
        public Bodega_Ventas.ServiceUsuarios.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(Bodega_Ventas.ServiceUsuarios.HelloWorldResponseBody Body) {
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
    public partial class ObtenerIdUsuarioRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerIdUsuario", Namespace="http://tempuri.org/", Order=0)]
        public Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequestBody Body;
        
        public ObtenerIdUsuarioRequest() {
        }
        
        public ObtenerIdUsuarioRequest(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerIdUsuarioRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string serialpc;
        
        public ObtenerIdUsuarioRequestBody() {
        }
        
        public ObtenerIdUsuarioRequestBody(string serialpc) {
            this.serialpc = serialpc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerIdUsuarioResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerIdUsuarioResponse", Namespace="http://tempuri.org/", Order=0)]
        public Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponseBody Body;
        
        public ObtenerIdUsuarioResponse() {
        }
        
        public ObtenerIdUsuarioResponse(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerIdUsuarioResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int ObtenerIdUsuarioResult;
        
        public ObtenerIdUsuarioResponseBody() {
        }
        
        public ObtenerIdUsuarioResponseBody(int ObtenerIdUsuarioResult) {
            this.ObtenerIdUsuarioResult = ObtenerIdUsuarioResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UsuariosSoapChannel : Bodega_Ventas.ServiceUsuarios.UsuariosSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuariosSoapClient : System.ServiceModel.ClientBase<Bodega_Ventas.ServiceUsuarios.UsuariosSoap>, Bodega_Ventas.ServiceUsuarios.UsuariosSoap {
        
        public UsuariosSoapClient() {
        }
        
        public UsuariosSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuariosSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bodega_Ventas.ServiceUsuarios.HelloWorldResponse Bodega_Ventas.ServiceUsuarios.UsuariosSoap.HelloWorld(Bodega_Ventas.ServiceUsuarios.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            Bodega_Ventas.ServiceUsuarios.HelloWorldRequest inValue = new Bodega_Ventas.ServiceUsuarios.HelloWorldRequest();
            inValue.Body = new Bodega_Ventas.ServiceUsuarios.HelloWorldRequestBody();
            Bodega_Ventas.ServiceUsuarios.HelloWorldResponse retVal = ((Bodega_Ventas.ServiceUsuarios.UsuariosSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.HelloWorldResponse> Bodega_Ventas.ServiceUsuarios.UsuariosSoap.HelloWorldAsync(Bodega_Ventas.ServiceUsuarios.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.HelloWorldResponse> HelloWorldAsync() {
            Bodega_Ventas.ServiceUsuarios.HelloWorldRequest inValue = new Bodega_Ventas.ServiceUsuarios.HelloWorldRequest();
            inValue.Body = new Bodega_Ventas.ServiceUsuarios.HelloWorldRequestBody();
            return ((Bodega_Ventas.ServiceUsuarios.UsuariosSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse Bodega_Ventas.ServiceUsuarios.UsuariosSoap.ObtenerIdUsuario(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest request) {
            return base.Channel.ObtenerIdUsuario(request);
        }
        
        public int ObtenerIdUsuario(string serialpc) {
            Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest inValue = new Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest();
            inValue.Body = new Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequestBody();
            inValue.Body.serialpc = serialpc;
            Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse retVal = ((Bodega_Ventas.ServiceUsuarios.UsuariosSoap)(this)).ObtenerIdUsuario(inValue);
            return retVal.Body.ObtenerIdUsuarioResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse> Bodega_Ventas.ServiceUsuarios.UsuariosSoap.ObtenerIdUsuarioAsync(Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest request) {
            return base.Channel.ObtenerIdUsuarioAsync(request);
        }
        
        public System.Threading.Tasks.Task<Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioResponse> ObtenerIdUsuarioAsync(string serialpc) {
            Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest inValue = new Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequest();
            inValue.Body = new Bodega_Ventas.ServiceUsuarios.ObtenerIdUsuarioRequestBody();
            inValue.Body.serialpc = serialpc;
            return ((Bodega_Ventas.ServiceUsuarios.UsuariosSoap)(this)).ObtenerIdUsuarioAsync(inValue);
        }
    }
}