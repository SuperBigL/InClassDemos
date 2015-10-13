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
        #region Query Samples
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetCategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                //remember Linq does not like using DateTime casting
 
                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new CategoryMenuItems()//DTO
                              {
                                  Description = category.Description,
                                  MenuItems = from row in category.MenuItems //collection of navigated rows of collection
                                                
                                                select new MenuItem() //POCO
                                                {
                                                    Description = row.Description,
                                                    Price = row.CurrentPrice,
                                                    Calories = row.Calories,
                                                    Comment = row.Comment
                                                }
                              };
                return results.ToList();
            }

        }
        #endregion
        #region CRUD Insert, Update Delete
    [DataObjectMethod(DataObjectMethodType.Insert, false)]
    public void SpecialEvents_Add(SpecialEvent item)
        {
        using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                SpecialEvent added = null;

                //set up the add request for the dbcontext
                added = context.SpecialEvents.Add(item);

                //saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the annotations (validation) on your entity
                context.SaveChanges();

            }
        }
    [DataObjectMethod(DataObjectMethodType.Update, false)]
    public void SpecialEvents_Update(SpecialEvent item)
    {
        using (eRestaurantContext context = new eRestaurantContext())
        {
            context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

        }
    }


        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public void SpecialEvents_Delete(SpecialEvent item)
    {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //look the item instance on the database to determine if it exists
                //on the delete ensure you reference the P-Key 
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                //set up the data request command
                context.SpecialEvents.Remove(existing);
                //commit the action to happen
                context.SaveChanges();
            }
    }

        #endregion
    }//eofClass



}//eof Namespace
