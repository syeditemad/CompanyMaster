//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyMasterList.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileMaster
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Nullable<int> CompanyId { get; set; }
    
        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
