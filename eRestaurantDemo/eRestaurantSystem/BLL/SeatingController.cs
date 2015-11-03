using eRestaurantSystem.DAL;
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class SeatingController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReservationCollection> ReservationByTime(DateTime date)
        {
            using (var context = new eRestaurantContext())
            {
                var result = (from data in context.Reservations
                              where data.ReservationDate.Year == date.Year &&
                                    data.ReservationDate.Month == date.Month
                                    && data.ReservationDate.Day == date.Day
                                  //&& data.ReservationDate.Hour == ti
                                    && data.ReservationStatus == Reservation.Booked
                              select new ReservationSummary()
                              {
                                  ID = data.ReservationID,
                                  Name = data.CustomerName,
                                  Date = data.ReservationDate,
                                  NumberInParty = data.NumberInParty,
                                  Status = data.ReservationStatus,
                                  Event = data.Event.Description,
                                  Contact = data.ContactPhone
                              }).ToList();
                var finalREsult = from item in result
                                  orderby item.NumberInParty
                                  group item by item.Date.Hour into itemGroup
                                  select new ReservationCollection()
                                  {
                                      Hour = itemGroup.Key,
                                      Reservations = itemGroup.ToList()
                                  };
                return finalREsult.OrderBy(x => x.Hour).ToList();
            }
        }
    }
}
