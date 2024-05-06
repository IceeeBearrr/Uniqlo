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
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Discounts = new HashSet<Discount>();
            this.OrderLists = new HashSet<OrderList>();
            this.Quantities = new HashSet<Quantity>();
            this.WishlistItems = new HashSet<WishlistItem>();
        }
    
        public int Product_ID { get; set; }
        public Nullable<int> Category_ID { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quantity> Quantities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WishlistItem> WishlistItems { get; set; }

        public class ProductDbContext : DbContext
        {
            public ProductDbContext() : base("name=UniqloEntities") // Ensure this matches your connection string in Web.config
            {
            }
            public DbSet<Category> category { get; set; }
            public DbSet<Product> product { get; set; }
            public DbSet<Quantity> quantity { get; set; }
            public DbSet<Image> image { get; set; }


        }
    }
}
