using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel; //Use for ODS access
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.POCOs;

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

                

            

            }
        }
         [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservations> ReservationsbyCode(string EventCode)
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Reservations
                              where item.Event.Equals(EventCode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();


            }


        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ReservationByDate> GetReservationsByDate(string reservationdate)
         {
            using (var context = new eRestaurantContext())
            {
                //remember Linq does not like using DateTime casting
                int theYear = (DateTime.Parse(reservationdate)).Year;
                int theMonth = (DateTime.Parse(reservationdate)).Month;
                int theDay = (DateTime.Parse(reservationdate)).Day;

                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate()//DTO
                              {
                                  Description = item.Description,
                                  Reservation = from row in item.Reservations //collection of navigated rows of collection
                                                 where row.ReservationDate.Year == theYear 
                                                   && row.ReservationDate.Month == theMonth 
                                                   && row.ReservationDate.Day == theDay
                                                   select new ReservationDetail() //POCO
                                                   {
                                                       CustomerName = row.CustomerName,
                                                       ReservationDate = row.ReservationDate,
                                                       NumberInParty = row.NumberInParty,
                                                       ContactPhone = row.ContactPhone,
                                                       ReservationStatus = row.ReservationStatus
                                                   }
                              };
                return results.ToList();
            }

         }
    }
}
