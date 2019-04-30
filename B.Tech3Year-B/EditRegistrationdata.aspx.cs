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
    public partial class EditRegistrationdata : System.Web.UI.Page
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
                    txtfirstName.Text =
                        ds.Tables[0].Rows[0]["first_name"].ToString();
                    txtLastName.Text =
                        ds.Tables[0].Rows[0]["last_name"].ToString();
                    txtEmailId.Text =
                        ds.Tables[0].Rows[0]["email_id"].ToString();
                    txtPassword.Text =
                        ds.Tables[0].Rows[0]["password"].ToString();
                    txtMobileNo.Text =
                        ds.Tables[0].Rows[0]["mobile_number"].ToString();
                    txtPincode.Text =
                        ds.Tables[0].Rows[0]["pincode"].ToString();
                    String statename = ds.Tables[0].Rows[0]["state"].ToString();
                    String cityname = ds.Tables[0].Rows[0]["city"].ToString();
                    String gender = ds.Tables[0].Rows[0]["gender"].ToString();
                    String programming = ds.Tables[0].Rows[0]["programming"].ToString();
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ddlState.Items.Add("Select state");
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            ddlState.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                        }
                        ddlState.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                    }

                    ds.Tables.Clear();
                 
                    cmd = new SqlCommand("spGetAllCity", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StateName", statename);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCity.Items.Clear();
                        ddlCity.Items.Add("Select city");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ddlCity.Items.Add(ds.Tables[0].Rows[i]["city_name"].ToString());
                        }
                        ddlCity.SelectedValue = cityname;
                    }
                    //Radio Button 
                    if (gender == "Male")
                    {
                        rdMale.Checked = true;
                    }
                    else
                    {
                        rdFemale.Checked = true;
                    }
                    // Checkbox
                    String [] str = programming.Split(',');
                    if (str.Count() > 0) {
                        for (int i = 0; i < str.Count(); i++)
                        {
                            if (str[i] == "Java")
                            {
                                chkJava.Checked = true;
                            }
                            if (str[i] == "Dot Net")
                            {
                                chkNet.Checked = true;
                            }
                            if (str[i] == "C Programming")
                            {
                                chkCprogramming.Checked = true;
                            }
                            if (str[i] == "C+")
                            {
                                chkCplus.Checked = true;
                            }
                        
                        }
                    
                    
                    }
                }
            }           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(lblId.Text);
            string FirstName = txtfirstName.Text;
            string LastName  = txtLastName.Text;
            string EmailId   = txtEmailId.Text;
            string Password  = txtPassword.Text;
            string MobileNumber = txtMobileNo.Text;
            String statname = ddlState.SelectedValue;
            String city = ddlCity.SelectedValue;
            String gender = string.Empty;
            string pincode = txtPincode.Text;
            string Programming = String.Empty;
            SqlConnection Conn = 
                new SqlConnection(connectionString);
            Conn.Open();
            SqlCommand cmd =
                new SqlCommand("spEditRegistrationData", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            cmd.Parameters.AddWithValue("@State", statname);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Pincode", pincode);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Programming", Programming);
            int Result = cmd.ExecuteNonQuery();

            if (Result == 1){
                Response.Redirect("~/RegistrationData.aspx");
            }
            else{
                lblMessage.Text = "Any error please check.";
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string Statename = ddlState.SelectedValue;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetAllCity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName", Statename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Select city");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlCity.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string Cityname = ddlCity.SelectedValue;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetpincode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@City", Cityname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPincode.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

       
    }
}