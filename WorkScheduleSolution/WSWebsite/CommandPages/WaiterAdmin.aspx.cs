using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eRestaurantSystem.BLL; //controller
using eRestaurantSystem.DAL.Entities; //controller
using EatIn.UI; //message user control

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            RefreshWaiterList("0");
            DateHired.Text = DateTime.Today.ToShortDateString();
        }

        //initalize date hired to today
        

    }

    protected void RefreshWaiterList(string selectedvalue)
    {
        WaiterList.DataBind();
        WaiterList.Items.Insert(0, "Select a waiter");
        WaiterList.SelectedValue = selectedvalue;
    }




    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0)
        {
            MessageUserControl.ShowInfo("Select a waiter before you click");
        }
        else
        {
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }
        public void GetWaiterInfo()
        {
            AdminController sysmgr = new AdminController();
            var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
            WaiterID.Text = waiter.WaiterID.ToString();
            FirstName.Text = waiter.FirstName;
            LastName.Text = waiter.LastName;
            Address.Text = waiter.Address;
            Phone.Text = waiter.Phone;
            DateHired.Text = waiter.HireDate.ToShortDateString();
            if(waiter.ReleaseDate.HasValue)
            {
                Released.Text = waiter.ReleaseDate.ToString(); 
            }

        }


    protected void Insert_Click(object sender, EventArgs e)
{
    MessageUserControl.TryRun(() =>
        {
            Waiter item = new Waiter();
            item.FirstName = FirstName.Text;
            item.LastName = LastName.Text;
            item.Address = Address.Text;
            item.Phone = Phone.Text;
            item.HireDate = DateTime.Parse(DateHired.Text);
            if (string.IsNullOrEmpty(Released.Text))
                item.ReleaseDate = null;
            else
                item.ReleaseDate = DateTime.Parse(Released.Text);
            item.ReleaseDate = null;
            AdminController sysgmr = new AdminController();
            WaiterID.Text = sysgmr.Waiters_Add(item).ToString();
            MessageUserControl.ShowInfo("Waiter Added");
            RefreshWaiterList(WaiterID.Text);
        }
    );
}




}
