﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClUnit.Runner {
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
    internal class OutputMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OutputMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClUnit.Runner.OutputMessages", typeof(OutputMessages).Assembly);
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
        ///   Looks up a localized string similar to The assembly could not be opened: {exceptionMessage}.
        /// </summary>
        internal static string AssemblyLoadFailure {
            get {
                return ResourceManager.GetString("AssemblyLoadFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test &apos;{0}&apos; will be skipped due to a creation exception: {1}.
        /// </summary>
        internal static string CreationException {
            get {
                return ResourceManager.GetString("CreationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected a file ({0} does not exist)..
        /// </summary>
        internal static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input assembly does not use ClUnit (or has a differing version)..
        /// </summary>
        internal static string InvalidAssembly {
            get {
                return ResourceManager.GetString("InvalidAssembly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test Run Result: {0} Succeeded, {0} Failed, {0} Skipped.
        /// </summary>
        internal static string RunResult {
            get {
                return ResourceManager.GetString("RunResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test &apos;{0}&apos; failed..
        /// </summary>
        internal static string TestFailure {
            get {
                return ResourceManager.GetString("TestFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test &apos;{0}&apos; succeeded..
        /// </summary>
        internal static string TestSuccess {
            get {
                return ResourceManager.GetString("TestSuccess", resourceCulture);
            }
        }
    }
}