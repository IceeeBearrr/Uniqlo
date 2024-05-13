﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Uniqlo.Staff;

namespace Uniqlo.AdminPages.AdminStaff
{
    public partial class DeleteStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                staffIdlbl.Text = Request.QueryString["StaffId"];
            }
            

        }




        protected void btnCheckCode_Click(object sender, EventArgs e)
        {
            string inputCode = txtVerificationCode.Text;
            string storedCode = Session["VerificationCode"] as string;

            if (string.IsNullOrWhiteSpace(storedCode))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Session expired. Please resend the verification code.";
                return;
            }

            if (inputCode == storedCode)
            {
                int staffId;
                if (!int.TryParse(Request.QueryString["StaffId"], out staffId))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid staff ID.";
                    return;
                }

                try
                {
                    using (var db = new StaffDbContext())
                    {
                        var staff = db.Staff.Find(staffId);
                        if (staff != null)
                        {
                            db.Staff.Remove(staff);
                            db.SaveChanges();
                            Response.Redirect("StaffHome.aspx");
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Staff not found.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Failed to remove staff. Please try again. Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid verification code. Please try again.";
                txtVerificationCode.Text = ""; // Optionally clear the incorrect code
            }
        }




        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            string userEmailText = userEmail.Text;
            string verificationCode = GenerateVerificationCode();
            Session["VerificationCode"] = verificationCode;

            try
            {

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential("jefferozf-pm21@student.tarc.edu.my", "030116070949")
                };

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("jefferozf-pm21@student.tarc.edu.my");
                    mail.To.Add(userEmailText);
                    mail.Subject = "Verification Code";
                    mail.Body = "Your verification code is: " + verificationCode;
                    smtp.Send(mail);
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Verification code sent to your email.";
                btnRemoveStaff.Enabled = true;
                txtVerificationCode.Visible = true; // Show the verification code TextBox
              
                
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Failed to send verification code. Error: " + ex.Message;
            }

        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}