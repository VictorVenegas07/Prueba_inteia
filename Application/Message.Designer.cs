﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Message {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Message() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Application.Message", typeof(Message).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Usuario autenticado.
        /// </summary>
        internal static string AuthenticatedUser {
            get {
                return ResourceManager.GetString("AuthenticatedUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se eliminó correctamente.
        /// </summary>
        internal static string DeletedSuccessfully {
            get {
                return ResourceManager.GetString("DeletedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Las credenciales del usuario no son validas.
        /// </summary>
        internal static string InvalidCredentials {
            get {
                return ResourceManager.GetString("InvalidCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El registro ya existe.
        /// </summary>
        internal static string ItAlreadyExists {
            get {
                return ResourceManager.GetString("ItAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No se encontro este registro.
        /// </summary>
        internal static string ItWasNotFound {
            get {
                return ResourceManager.GetString("ItWasNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No se encontraron registros.
        /// </summary>
        internal static string NoRecordsFound_ {
            get {
                return ResourceManager.GetString("NoRecordsFound.", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se registró exitosamente.
        /// </summary>
        internal static string RegisteredSuccessfully {
            get {
                return ResourceManager.GetString("RegisteredSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El registro ha sido activado.
        /// </summary>
        internal static string RegistrationIsActivated_ {
            get {
                return ResourceManager.GetString("RegistrationIsActivated.", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Consulta exitosa.
        /// </summary>
        internal static string SuccessfulQuery {
            get {
                return ResourceManager.GetString("SuccessfulQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se actualizó correctamente.
        /// </summary>
        internal static string UpdatedSuccessfully {
            get {
                return ResourceManager.GetString("UpdatedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Nombre de usuario no existe.
        /// </summary>
        internal static string UsernameDoesNotExist {
            get {
                return ResourceManager.GetString("UsernameDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Erorres de validacion.
        /// </summary>
        internal static string ValidationErrors {
            get {
                return ResourceManager.GetString("ValidationErrors", resourceCulture);
            }
        }
    }
}
