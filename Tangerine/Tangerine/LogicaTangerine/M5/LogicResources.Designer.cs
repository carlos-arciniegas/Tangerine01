﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicaTangerine.M5 {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LogicResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogicResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LogicaTangerine.M5.LogicResources", typeof(LogicResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to TGE_00_001.
        /// </summary>
        internal static string Codigo {
            get {
                return ResourceManager.GetString("Codigo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TGE_00_001.
        /// </summary>
        internal static string Codigo_Error_Formato {
            get {
                return ResourceManager.GetString("Codigo_Error_Formato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error con la Conexion en la Base de Datos, no se pudo abrir la conexion.
        /// </summary>
        internal static string Mensaje {
            get {
                return ResourceManager.GetString("Mensaje", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error de parseo.
        /// </summary>
        internal static string Mensaje_Error_Formato {
            get {
                return ResourceManager.GetString("Mensaje_Error_Formato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se pudo completar la operacion.
        /// </summary>
        internal static string Mensaje_Generico_Error {
            get {
                return ResourceManager.GetString("Mensaje_Generico_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Salida del Método.
        /// </summary>
        internal static string MensajeFinInfoLogger {
            get {
                return ResourceManager.GetString("MensajeFinInfoLogger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entrada en el Método.
        /// </summary>
        internal static string MensajeInicioInfoLogger {
            get {
                return ResourceManager.GetString("MensajeInicioInfoLogger", resourceCulture);
            }
        }
    }
}
