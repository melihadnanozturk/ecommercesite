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
    
    public partial class Edu_Saled_Prod
    {
        public int Id { get; set; }
        public int Edu_Prod_Id { get; set; }
        public int Basket_Id { get; set; }
        public int Saled_Number { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Edu_Prod Edu_Prod { get; set; }
    }
}
