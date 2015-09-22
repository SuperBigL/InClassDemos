using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel; //Use for ODS access

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvent table on sql
                // in order to do that, we will use the DBSet in eRestaurantContext
                // call SpecialEvents (done by Mapping)

                //method syntax
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();

            }
        }
    }
}
