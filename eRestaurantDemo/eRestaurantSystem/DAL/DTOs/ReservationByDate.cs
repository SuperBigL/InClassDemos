using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections; //IEnumerable


namespace eRestaurantSystem.DAL.DTOs
{
    public class ReservationByDate
    {
        public string Description { get; set; }
        //the rest of the data will be a collection of POCO rows
        //the actual POCO will be defined in the Linq query
        public IEnumerable Reservation { get; set; }
    }
}
