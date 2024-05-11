﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace Uniqlo.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = Global.CS;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniqloConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            if (Page.IsValid)
            {
                //no error
                //retrieve member details
                //validate member details


                string email = txtEmail.Text;
                string password = txtPassword.Text.Trim();

                //check user

                string checkUser = "SELECT Customer_ID,Name,Gender,Contact_No,Email,Password from Customer where email=@email and password=@password";
               
                SqlCommand checkCmd = new SqlCommand(checkUser, con);
                checkCmd.Parameters.AddWithValue("email", email);
                checkCmd.Parameters.AddWithValue("password", password);
                SqlDataReader read = checkCmd.ExecuteReader();

                if (read.Read())
                {
                    Session["Customer_ID"] = read.GetValue(0).ToString();
                    Session["Email"] = read.GetValue(1).ToString();
                    Session["Name"] = read.GetValue(2).ToString();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    errorMSG.Text = "Invalid email or password.";
                    errorMSG.ForeColor = System.Drawing.Color.Red;
                    con.Close();
                }



            }
        }


    }
        
}