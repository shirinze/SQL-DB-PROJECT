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
    
    public partial class TBLEMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLEMPLOYEE()
        {
            this.TBLACTIONs = new HashSet<TBLACTION>();
        }
    
        public short EMPLOYEEID { get; set; }
        public string EMPLOYEENAMESURENAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLACTION> TBLACTIONs { get; set; }
    }
}