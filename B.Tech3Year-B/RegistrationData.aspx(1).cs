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
    public partial class RegistrationData : System.Web.UI.Page
    {
        string connectionString = 
            ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        protected List<registration> registrationObj =
                new List<registration>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string EmailId = string.Empty;
            if (Session["EmailId"] != null)
                EmailId = Session["EmailId"].ToString();
            else
                Response.Redirect("~/LoginForm.aspx");

            DataSet ds = new DataSet();            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //SqlCommand cmd = new SqlCommand("select * from registration",conn);
            SqlCommand cmd =
            new SqlCommand("spGetRegistrationData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Text =  "Welcome " 
                    + ds.Tables[0].Rows[0]["first_name"].ToString();
                for (int i=0;i <ds.Tables[0].Rows.Count;i++)
                {
                    registrationObj.Add(new registration {
                        Id = 
                        Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].
                        ToString()),
                        firstName = ds.Tables[0].Rows[i]["first_name"].
                        ToString(),
                        lastName = ds.Tables[0].Rows[i]["last_name"].
                        ToString(),
                        emailId = ds.Tables[0].Rows[i]["email_id"].
                        ToString(),
                        password = ds.Tables[0].Rows[i]["password"].
                        ToString(),
                        mobileNo = ds.Tables[0].Rows[i]["mobile_number"].
                        ToString(),
                        state = ds.Tables[0].Rows[i]["state"].
                        ToString(),
                        city = ds.Tables[0].Rows[i]["city"].
                        ToString(),
                        pincode = ds.Tables[0].Rows[i]["pincode"].
                        ToString(),
                        gender = ds.Tables[0].Rows[i]["gender"].
                        ToString(),
                        programming = ds.Tables[0].Rows[i]["programming"].
                        ToString(),
                        
                    });
                }
            }
            else
            {

            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyFirstWebForm.aspx");
        }
    }
}