//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkConsoleProjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblOrder_Product = new HashSet<tblOrder_Product>();
        }
    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal EntityPrice { get; set; }
        public bool Availability { get; set; }
        public int ManufacturerID { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
    
        public virtual tblManufacturer tblManufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrder_Product> tblOrder_Product { get; set; }
    }
}