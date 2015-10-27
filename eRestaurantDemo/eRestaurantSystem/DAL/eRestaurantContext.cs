using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eRestaurantSystem.DAL.Entities;


namespace eRestaurantSystem.DAL
{
    //This class should be restricted to access by ONLY
    //BLL methods.
    //this class should NOT be accessable outside of the
    //component library.

    //this class inherits DbContext



    public class eRestaurantContext: DbContext
    {
        public eRestaurantContext() : base ("name=EatIn")
        {
            //constructor is used to pass web config string name

        }

        //Setip the DbSet Mappings
        //One DBSet for each entity I create.
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        //When overriding OnModelCreating(), it is important to remember
        //to call the base method's implementation before you exit the method.
        //The ManyToManyNavigationPropertyConfig.Map lets you
        //configure the tables and clumns used for many to many relationships.
        //It takes a ManytoManNavigationPropertyConfiguration instance in which
        //you specificy the column names b calling MapLeftKey, MalpRightKey,
        //and ToTable Method.



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("Tables");
                    mapping.MapRightKey("ReservationID");


                });

        }

    }
}
