using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eRestaurantSystem.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required, Range(1,25)]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        //Navigation property
        //the reservations tables is a many to many relationship to the tables table.
        //The SQL ReservationsTable resolves this problem
        //However REservationsTable holds only a compound primary key.
        //We will NOT create a ReservationsTable entity in our project
        //but we will handle in via navigation mapping.
        //Thus we will place a ICollection properties in
        //this entity refering to the Reservation table
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Table()
        {
            Available = true;
        }

    }
}
