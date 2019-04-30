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
    public partial class DeleteRegistrationData : System.Web.UI.Page
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                DataSet ds = new DataSet();

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd =
      new SqlCommand("spGetRegistrationDataWithId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblId.Text =
                        ds.Tables[0].Rows[0]["Id"].ToString();
                    lblFirstName.Text =
                        ds.Tables[0].Rows[0]["first_name"].ToString();
                    lblLastName.Text =
                        ds.Tables[0].Rows[0]["last_name"].ToString();
                    lblEmailId.Text =
                        ds.Tables[0].Rows[0]["email_id"].ToString();
                    lblPassword.Text =
                        ds.Tables[0].Rows[0]["password"].ToString();
                    lblMobileNumber.Text =
                        ds.Tables[0].Rows[0]["mobile_number"].ToString();
                }
            }           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(lblId.Text);           

            SqlConnection Conn =
                new SqlConnection(connectionString);
            Conn.Open();
            SqlCommand cmd =
                new SqlCommand("spDeleteRegistrationData", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Id);
            int Result = cmd.ExecuteNonQuery();

            if (Result == 1) {
                Response.Redirect("~/RegistrationData.aspx");
            }
            else {
                lblMessage.Text = "Any error please check.";
            }
        }
    }
}