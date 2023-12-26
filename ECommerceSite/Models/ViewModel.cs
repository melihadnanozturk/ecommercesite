using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceSite.Models
{
    public class ViewModel
    {

        public List<Tech_Prod> Tech_Prod_List { get; set; }
        public List<Edu_Prod> Edu_Prod_List { get; set; }
        public List<Text_Prod> Text_Prod_List { get; set; }

        public BasketViewModel BasketViewModel { get; set; }

    }
}