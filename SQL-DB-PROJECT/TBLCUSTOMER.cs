//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL_DB_PROJECT
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLCUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCUSTOMER()
        {
            this.TBLACTIONs = new HashSet<TBLACTION>();
        }
    
        public int CUSTOMERID { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string SURENAME { get; set; }
        public string CITY { get; set; }
        public Nullable<decimal> CASH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLACTION> TBLACTIONs { get; set; }
    }
}
