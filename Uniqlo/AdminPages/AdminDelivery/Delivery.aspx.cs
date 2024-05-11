﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Uniqlo.Product;
using Uniqlo.Pages;

namespace Uniqlo.AdminPages.AdminDelivery
{
    public partial class Delivery : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                bindRepeater();
            }

        }
        private void bindRepeater()
        {
            string connString = cs;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
            SELECT 
                d.Delivery_ID,
                sa.Address + ', ' + sa.State + ', ' + sa.City + ', ' + sa.Postcode + ', ' + sa.Country AS DeliveryAddress,
                d.Delivery_Status,
                p.Order_ID
            FROM 
                Delivery d
            INNER JOIN 
                Shipping_Address sa ON d.Address_ID = sa.Address_ID
            INNER JOIN 
                Payment p ON d.Delivery_ID = p.Delivery_ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptDeliveries.DataSource = dt;
                        rptDeliveries.DataBind();
                    }
                }
            }
        }
        protected void btnRemoveDelivery_Click(object sender, EventArgs e)
        {
            int deliveryId = Convert.ToInt32(hiddenDeliveryId.Value); // Retrieve the Delivery ID
            string connectionString = cs;

            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                // Step 1: Retrieve the Address_ID associated with the given Delivery_ID
                int addressId = 0;
                string getAddressIdQuery = "SELECT Address_ID FROM Delivery WHERE Delivery_ID = @DeliveryID";
                using (var getAddressIdCmd = new SqlCommand(getAddressIdQuery, connection))
                {
                    getAddressIdCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
                    using (var reader = getAddressIdCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            addressId = Convert.ToInt32(reader["Address_ID"]);
                        }
                    }
                }

                // Step 2: Set the Address_ID in the Delivery table to null for the corresponding Delivery_ID
                string updateDeliveryQuery = "UPDATE Delivery SET Address_ID = NULL WHERE Delivery_ID = @DeliveryID";
                using (var updateDeliveryCmd = new SqlCommand(updateDeliveryQuery, connection))
                {
                    updateDeliveryCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
                    updateDeliveryCmd.ExecuteNonQuery();
                }

                // Step 3: Delete the Address record associated with the retrieved Address_ID
                string deleteAddressQuery = "DELETE FROM Shipping_Address WHERE Address_ID = @AddressID";
                using (var deleteAddressCmd = new SqlCommand(deleteAddressQuery, connection))
                {
                    deleteAddressCmd.Parameters.AddWithValue("@AddressID", addressId);
                    deleteAddressCmd.ExecuteNonQuery();
                }

                // Step 4: Set the Delivery_ID in the Payment table to null for the corresponding Delivery_ID
                string updatePaymentQuery = "UPDATE Payment SET Delivery_ID = NULL WHERE Delivery_ID = @DeliveryID";
                using (var updatePaymentCmd = new SqlCommand(updatePaymentQuery, connection))
                {
                    updatePaymentCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
                    updatePaymentCmd.ExecuteNonQuery();
                }

                // Step 5: Delete the Delivery record associated with the given Delivery_ID
                string deleteDeliveryQuery = "DELETE FROM Delivery WHERE Delivery_ID = @DeliveryID";
                using (var deleteDeliveryCmd = new SqlCommand(deleteDeliveryQuery, connection))
                {
                    deleteDeliveryCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
                    deleteDeliveryCmd.ExecuteNonQuery();
                }
            }
            Response.Redirect(Request.RawUrl);
           
        }

        protected void addDeliveryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDelivery.aspx");
        }
    }
}
