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
    
    public partial class Repayment
    {
        public int Id { get; set; }
        public Nullable<int> loanIssuance_Id { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> totalRepayment { get; set; }
        public Nullable<decimal> balance { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    
        public virtual loanIssueance loanIssueance { get; set; }
    }
}
