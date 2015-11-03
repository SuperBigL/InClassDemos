using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace eRestaurantSystem.DAL.Entities
{
    public class Reservation
    {
        //constant strings for code readibility
        public const string Booked = "B";
        public const string Arrived = "A";
        public const string Complete = "C";
        public const string NoShow = "N";
        public const string Cancelled = "X";
        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(40)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Range(1,16, ErrorMessage="Party size is limited to 1 - 16")]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required, StringLength(1,MinimumLength=1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
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
       
        public virtual ICollection<Bill> Bills { get; set; }
       
    }
}
