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
    
    public partial class Personnel_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personnel_Table()
        {
            this.LoanRequest_Linker = new HashSet<LoanRequest_Linker>();
            this.personnel_LogIn = new HashSet<personnel_LogIn>();
            this.Personnel_Login_LinkerTable = new HashSet<Personnel_Login_LinkerTable>();
        }
    
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string emailAddress { get; set; }
        public Nullable<long> Telephone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanRequest_Linker> LoanRequest_Linker { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personnel_LogIn> personnel_LogIn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel_Login_LinkerTable> Personnel_Login_LinkerTable { get; set; }

        public string Fullname
        {
            get
            {
                return FirstName + " " + MiddleName+ " " + LastName;
            }
        }
    }
}
