//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LukieAnnLoansAndFinancialServicesApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class personnel_LogIn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personnel_LogIn()
        {
            this.Login_DateTimeTable = new HashSet<Login_DateTimeTable>();
        }
    
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Personel_ID { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login_DateTimeTable> Login_DateTimeTable { get; set; }
        public virtual Personnel_Table Personnel_Table { get; set; }
    }
}
