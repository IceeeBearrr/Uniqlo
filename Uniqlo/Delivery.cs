//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uniqlo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            this.Payments = new HashSet<Payment>();
        }
    
        public int Delivery_ID { get; set; }
        public int Address_ID { get; set; }
        public string Delivery_Note { get; set; }
        public string Delivery_Status { get; set; }
    
        public virtual Shipping_Address Shipping_Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

    }

    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext() : base("name=UniqloEntities") 
        {
        }

        public DbSet<Delivery> delivery { get; set; } 
    }
}
