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
    
    public partial class PersonnelRoleTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonnelRoleTable()
        {
            this.Personnel_Login_LinkerTable = new HashSet<Personnel_Login_LinkerTable>();
        }
    
        public int id { get; set; }
        public string personnelRole { get; set; }
        public string roleShortName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel_Login_LinkerTable> Personnel_Login_LinkerTable { get; set; }
    }
}
