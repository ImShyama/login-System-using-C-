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
    public partial class MyFirstWebForm : System.Web.UI.Page
    {
        string connectionString = 
            ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetAllState", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlState.Items.Add("Select state");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ddlState.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtfirstName.Text;
            string lastName = txtLastName.Text;
            string emailId = txtEmailId.Text;
            string password = txtPassword.Text;
            string mobileNo = txtMobileNo.Text;
            String statname = ddlState.SelectedValue;
            String city = ddlCity.SelectedValue;
            String gender = string.Empty;
            string pincode = txtPincode.Text;
            string Programming = String.Empty;
            if (rdMale.Checked)
            {
                gender = rdMale.Text;
            }
            if (rdFemale.Checked)
            {
                gender = rdFemale.Text;
            }
            if (chkCprogramming.Checked) {
                Programming = chkCprogramming.Text + ",";
            }
            if (chkCplus.Checked)
            {
                Programming = Programming+chkCplus.Text + ",";
            }
            if (chkJava.Checked)
            {
                Programming = Programming+chkJava.Text+"," ;
            }
            if (chkNet.Checked)
            {
                Programming = Programming+chkNet.Text + ",";
            }
            int ab= Programming.LastIndexOf(",");
            Programming = Programming.Remove(ab);
            //Programming = Programming.Substring(0, Programming.Length - 1);
            if(string.IsNullOrEmpty(firstName)){
                lblMessage.Text = "Please insert First Name.";
                return;
            }
            else if(firstName.Length > 50){
                lblMessage.Text = "First Name length must be less than 50.";
                return;
            }
            if (string.IsNullOrEmpty(lastName)){
                lblMessage.Text = "Please insert Last Name.";
                return;
            }
            else if (lastName.Length > 50){
                lblMessage.Text = "Last Name length must be less than 50.";
                return;
            }
            if (string.IsNullOrEmpty(emailId)){
                lblMessage.Text = "Please insert Email Id.";
                return;
            }
            else if (emailId.Length > 50){
                lblMessage.Text = "Email Id length must be less than 50.";
                return;
            }
            if (string.IsNullOrEmpty(password)){
                lblMessage.Text = "Please insert Password.";
                return;
            }
            else if (password.Length > 10){
                lblMessage.Text = "Password length must be less than 10.";
                return;
            }
            if (string.IsNullOrEmpty(mobileNo)){
                lblMessage.Text = "Please insert Mobile Number";
                return;
            }
            else if (mobileNo.Length > 10){
                lblMessage.Text = "Mobile No. length must be less than 10.";
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into registration values('"+firstName +"', '"+lastName +"','"+ emailId+"', '"+password+"', '"+mobileNo+"')",conn);
            SqlCommand cmd = 
                new SqlCommand("spInsertRegistrationData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@EmailId", emailId);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
            cmd.Parameters.AddWithValue("@State", statname);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Pincode", pincode);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Programming",Programming);

            int Result = cmd.ExecuteNonQuery();

            if (Result == 1)
             {
                 lblMessage.Text = "Registration done successfully!";
                 Clear();
             }
            conn.Close();
        }

        void Clear()
        {
            txtfirstName.Text = String.Empty;
            txtLastName.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtPassword.Text = string.Empty;
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
                txtPincode.Text =ds.Tables[0].Rows[0][0].ToString();
            }
        }

       

       

       
    }
}