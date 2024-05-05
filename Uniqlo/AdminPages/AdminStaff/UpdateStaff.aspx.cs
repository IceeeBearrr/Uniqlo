﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uniqlo.AdminPages
{
    public partial class UpdateStaff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string staffId = Request.QueryString["StaffID"];
                if (!string.IsNullOrEmpty(staffId))
                {
                    LoadStaffDetails(int.Parse(staffId));
                }
            }
        }

        private void LoadStaffDetails(int staffId)
        {
            using (var db = new StaffDbContext())
            {
                var staff = db.Staffs.FirstOrDefault(s => s.Staff_ID == staffId);
                if (staff != null)
                {
                    staffID.Text = staff.Staff_ID.ToString();
                    staffName.Text = staff.Name;
                    email.Text = staff.Email;
                    contactNumber.Text = staff.Contact_No;
                    // Populate other fields like Gender and Role if they are included in your model
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (var db = new StaffDbContext())
                {
                    int staffId = int.Parse(staffID.Text);
                    var staff = db.Staffs.FirstOrDefault(s => s.Staff_ID == staffId);
                    if (staff != null)
                    {
                        staff.Name = staffName.Text;
                        staff.Email = email.Text;
                        staff.Contact_No = contactNumber.Text;
                        // Update other fields like Gender and Role if they are editable

                        db.SaveChanges();
                        Response.Redirect("Staff.aspx");
                    }
                }
            }
        }
    }
}