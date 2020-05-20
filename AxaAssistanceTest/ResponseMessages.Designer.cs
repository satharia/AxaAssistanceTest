﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AxaAssistanceTest {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResponseMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResponseMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AxaAssistanceTest.ResponseMessages", typeof(ResponseMessages).Assembly);
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
        ///   Looks up a localized string similar to The resource was not found, Book with ID: {0}.
        /// </summary>
        internal static string BookNotFound {
            get {
                return ResourceManager.GetString("BookNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully closed the Reservation, this Customer may open a new one now.
        /// </summary>
        internal static string CloseReservationOk {
            get {
                return ResourceManager.GetString("CloseReservationOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully created the Reservation, this Customer may not open a new one until this is closed.
        /// </summary>
        internal static string CreateReservationOk {
            get {
                return ResourceManager.GetString("CreateReservationOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The resource was not found, Customer with ID: {0}.
        /// </summary>
        internal static string CustomerNotFound {
            get {
                return ResourceManager.GetString("CustomerNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully deleted the Book object.
        /// </summary>
        internal static string DeleteBookOk {
            get {
                return ResourceManager.GetString("DeleteBookOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully deleted the Customer object.
        /// </summary>
        internal static string DeleteCustomerOk {
            get {
                return ResourceManager.GetString("DeleteCustomerOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Reservation is already closed, the closed Reservation&apos;s ID is: {0}.
        /// </summary>
        internal static string ReservationAlreadyClosed {
            get {
                return ResourceManager.GetString("ReservationAlreadyClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Customer already has an open Book Reservation, the open Reservation&apos;s ID is: {0}.
        /// </summary>
        internal static string ReservationAlreadyOpen {
            get {
                return ResourceManager.GetString("ReservationAlreadyOpen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing Reserved Books list, cannot create a Reservation without specifying the Reserved Books.
        /// </summary>
        internal static string ReservationMissingBook {
            get {
                return ResourceManager.GetString("ReservationMissingBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing Customer ID, cannot create a Reservation without assigning a Customer.
        /// </summary>
        internal static string ReservationMissingCustomer {
            get {
                return ResourceManager.GetString("ReservationMissingCustomer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing Reservation ID, cannot close a Reservation without it&apos;s identifyer.
        /// </summary>
        internal static string ReservationMissingID {
            get {
                return ResourceManager.GetString("ReservationMissingID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The resource was not found, Reservation with ID: {0}.
        /// </summary>
        internal static string ReservationNotFound {
            get {
                return ResourceManager.GetString("ReservationNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully saved the Book object.
        /// </summary>
        internal static string SaveBookOk {
            get {
                return ResourceManager.GetString("SaveBookOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully saved the Customer object.
        /// </summary>
        internal static string SaveCustomerOk {
            get {
                return ResourceManager.GetString("SaveCustomerOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully updated the Book object.
        /// </summary>
        internal static string UpdateBookOk {
            get {
                return ResourceManager.GetString("UpdateBookOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully updated the Customer object.
        /// </summary>
        internal static string UpdateCustomerOk {
            get {
                return ResourceManager.GetString("UpdateCustomerOk", resourceCulture);
            }
        }
    }
}
