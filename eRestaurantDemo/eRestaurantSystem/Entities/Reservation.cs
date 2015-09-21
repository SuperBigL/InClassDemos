using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace eRestaurantSystem.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(40)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }

        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string EventCode { get; set; }

        //Navigation properties
        public virtual SpecialEvent Event { get; set; }
        //the reservations tables is a many to many relationship to the tables table.
        //The SQL ReservationsTable resolves this problem
        //However REservationsTable holds only a compound primary key.
        //We will NOT create a ReservationsTable entity in our project
        //but we will handle in via navigation mapping.
        //Thus we will place a ICollection properties in
        //this entity refering to the Tables table
        public virtual ICollection<Table> Tables { get; set; }

    }
}
