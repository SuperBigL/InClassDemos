using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace eRestaurantSystem.DAL.DTOs
{
    public class CategoryMenuItems
    {
        public string Description { get; set; }
        public IEnumerable MenuItems { get; set; }

    }
}
