//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raamen.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ramen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ramen()
        {
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }
    
        public int ID { get; set; }
        public int MeatID { get; set; }
        public string Broth { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    
        public virtual Meat Meat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
