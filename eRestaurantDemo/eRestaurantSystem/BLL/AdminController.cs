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
        public List<SpecialEvent> SpecialEventsList()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvent table on sql
                // in order to do that, we will use the DBSet in eRestaurantContext
                // call SpecialEvents (done by Mapping)

                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();

                //method syntax

                

               

                //query syntax
                //var results = from item in context.Reservations
                              //orderby item.Description
                              //select item;

                //return results.ToList();

            }
        }
         [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> ReservationsbyCode(string EventCode)
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Reservation
                              where item.Event.Equals(EventCode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                              return results.ToList();


            }


        }
    }
}
