﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region More Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL.POCOs;
#endregion

public partial class UXPages_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        AdminController sysgmr = new AdminController();
        DateTime info = sysgmr.GetLastBillDateTime();
        SearchDate.Text = info.ToString("yyyy-mm-dd");
        SearchTime.Text = info.ToString("hh:mm:ss");

    }
}