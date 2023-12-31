//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommerceSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Basket()
        {
            this.Edu_Saled_Prod = new HashSet<Edu_Saled_Prod>();
            this.Tech_Saled_Prod = new HashSet<Tech_Saled_Prod>();
            this.Text_Saled_Prod = new HashSet<Text_Saled_Prod>();
        }
    
        public int Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public decimal Total_Price { get; set; }
        public string Payment_Method { get; set; }
        public System.DateTime Created_At { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Edu_Saled_Prod> Edu_Saled_Prod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tech_Saled_Prod> Tech_Saled_Prod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Text_Saled_Prod> Text_Saled_Prod { get; set; }
    }
}
