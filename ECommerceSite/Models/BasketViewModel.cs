using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSite.Models
{
    public class BasketViewModel
    {
        public List<Tech_Prod> TechProducts { get; set; }
        public List<Edu_Prod> EduProducts { get; set; }
        public List<Text_Prod> TextProducts { get; set; }

        public BasketViewModel()
        {
            TechProducts = new List<Tech_Prod>();
            EduProducts = new List<Edu_Prod>();
            TextProducts = new List<Text_Prod>();
        }
    }
}