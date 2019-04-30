using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B.Tech3Year_B
{
    public partial class LoginForm : System.Web.UI.Page
    {
        string connectionString = 
            ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string EmailId = txtEmailId.Text;
            string Password = txtPassword.Text;

            if(string.IsNullOrEmpty(EmailId))
            {
                lblMessage.Text = "Please insert Email Id.";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                lblMessage.Text = "Please insert Password.";
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spLoginData",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                Session["EmailId"] = EmailId;
                Response.Redirect("~/RegistrationData.aspx");
            }
            else {
                lblMessage.Text = "Wrong EmailId or Password.";
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyFirstWebForm.aspx");
        }
    }
}