﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace web_1
{
    public partial class Statistic : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["LoginType"] == "System")
            {
                Panel4.Visible = true;

                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand("SELECT COUNT(Eid) AS TotalCount, SUM(CASE WHEN eGender = 'male' THEN 1 ELSE 0 END) AS MaleCount, SUM(CASE WHEN eGender = 'female' THEN 1 ELSE 0 END) AS FemaleCount FROM Elder", connection);
                MySqlDataReader reader;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Label1.Text = "總人數 " + reader["TotalCount"].ToString();
                        Label2.Text = "  男   " + reader["MaleCount"].ToString();
                        Label3.Text = "女 " + reader["FemaleCount"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
            else if (Session["LoginType"] == "Home")
            {
                Panel4.Visible = false;
            }
        }
        
        protected void Chart1_Load(object sender, EventArgs e)//跌倒次數
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand("SELECT DATE_FORMAT(fTime, '%Y-%m') AS Month, COUNT(*) AS FallCount FROM Fall GROUP BY DATE_FORMAT(fTime, '%Y-%m')", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart1.DataSource = dataset;
                Chart1.Series[0].XValueMember = "Month";
                Chart1.Series[0].YValueMembers = "FallCount";
                Chart1.DataBind();
            }
            else if (Session["LoginType"] == "Home")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand("SELECT DATE_FORMAT(hfTime, '%Y-%m') AS Month, COUNT(*) AS FallCount FROM HomeElderFall GROUP BY DATE_FORMAT(hfTime, '%Y-%m')", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart1.DataSource = dataset;
                Chart1.Series[0].XValueMember = "Month";
                Chart1.Series[0].YValueMembers = "FallCount";
                Chart1.DataBind();
            }
        }
        //Response.Write($"<script>alert('Error: {ex.Message}');</script>");

        protected void Chart2_Load(object sender, EventArgs e)//跌倒地點
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Place.pName, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Place ON Fall.pId = Place.pId GROUP BY Place.pName ", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart2.DataSource = dataset;
                Chart2.Series[0].XValueMember = "pName";
                Chart2.Series[0].YValueMembers = "FallCount";
                // Insert code for additional chart formatting here.
                Chart2.DataBind();
                connection.Close();
            }
            else if (Session["LoginType"] == "Home")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Place.pName, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Place ON Fall.pId = Place.pId GROUP BY Place.pName ", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart2.DataSource = dataset;
                Chart2.Series[0].XValueMember = "pName";
                Chart2.Series[0].YValueMembers = "FallCount";
                // Insert code for additional chart formatting here.
                Chart2.DataBind();
                connection.Close();
            }
        }

        protected void Chart3_Load(object sender, EventArgs e)//男女
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Elder.eGender, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Elder ON Fall.eId = Elder.eId GROUP BY Elder.eGender ", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart3.DataSource = dataset;
                Chart3.Series[0].XValueMember = "eGender";
                Chart3.Series[0].YValueMembers = "FallCount";
                // Insert code for additional chart formatting here.
                Chart3.DataBind();
                connection.Close();
            }
            else if (Session["LoginType"] == "Home")
            {

            }
        }

        protected void Chart4_Load(object sender, EventArgs e)//原因
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT fWhy , COUNT(*) AS FallCount FROM Fall GROUP BY fWhy", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                da.Fill(dataset);

                Chart4.DataSource = dataset;
                Chart4.Series[0].XValueMember = "fWhy";
                Chart4.Series[0].YValueMembers = "FallCount";
                // Insert code for additional chart formatting here.
                Chart4.DataBind();
                connection.Close();
            }
            else if (Session["LoginType"] == "Home")
            {

            }
        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                return;
            }
            if (DropDownList1.Text.ToString() == "長者ID")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Elder.eId, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Elder ON Fall.eId = Elder.eId GROUP BY Elder.eId ", connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (TextBox1.Text == reader.GetString("eId"))//如果沒有資料要顯示label
                        {
                            if (Session["LoginType"] == "System")
                            {
                                reader.Close();
                                MySqlCommand command2 = new MySqlCommand("SELECT Elder.*, DATE_FORMAT(fTime, '%Y-%m') AS Month, COUNT(*) AS FallCount FROM Fall INNER JOIN Elder ON Fall.eId = Elder.eId WHERE Fall.eId = @eId GROUP BY DATE_FORMAT(fTime, '%Y-%m')", connection);
                                command2.Parameters.AddWithValue("@eId", TextBox1.Text);
                                MySqlDataAdapter adapter = new MySqlDataAdapter(command2);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                Chart5.DataSource = dt;
                                Chart5.Series[0].XValueMember = "Month";
                                Chart5.Series[0].YValueMembers = "FallCount";
                                Chart5.DataBind();

                                MySqlCommand command3 = new MySqlCommand("SELECT Place.pName, COUNT(Fall.fId) AS FallCount " +
                                        "FROM Fall JOIN Place ON Fall.pId = Place.pId JOIN Elder ON Fall.eId = Elder.eId " +
                                        "WHERE Elder.eId = @eId GROUP BY Place.pName", connection);
                                command3.Parameters.AddWithValue("@eId", TextBox1.Text);
                                MySqlDataAdapter adapter2 = new MySqlDataAdapter(command3);
                                DataTable dt2 = new DataTable();
                                adapter2.Fill(dt2);

                                Chart6.DataSource = dt2;
                                Chart6.Series[0].XValueMember = "pName";
                                Chart6.Series[0].YValueMembers = "FallCount";
                                Chart6.DataBind();
                                connection.Close();

                                MySqlCommand command4 = new MySqlCommand("SELECT fWhy , COUNT(*) AS FallCount FROM Fall JOIN Elder ON Fall.eId = Elder.eId WHERE Elder.eId = @eId GROUP BY fWhy", connection);
                                command4.Parameters.AddWithValue("@eId", TextBox1.Text);
                                MySqlDataAdapter adapter3 = new MySqlDataAdapter(command4);
                                DataTable dt3 = new DataTable();
                                adapter3.Fill(dt3);

                                Chart7.DataSource = dt3;
                                Chart7.Series[0].XValueMember = "fWhy";
                                Chart7.Series[0].YValueMembers = "FallCount";
                                Chart7.DataBind();
                                connection.Close();

                                Panel2.Visible = false;
                                Panel3.Visible = true;
                                Panel5.Visible = false;
                                Label4.Visible = false;
                                break;
                            }
                            else if (Session["LoginType"] == "Home")
                            {

                            }
                        }
                        else
                        {
                            Label4.Visible = true;
                            Label4.Text = "查詢失敗";
                        }
                    }
                }
                connection.Close();
            }
            else if (DropDownList1.Text.ToString() == "地點")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Place.pId, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Place ON Fall.pId = Place.pId GROUP BY Place.pId ", connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (TextBox1.Text == reader.GetString("pId"))//如果沒有資料要顯示label
                        {
                            if (Session["LoginType"] == "System")
                            {
                                reader.Close();
                                MySqlCommand command2 = new MySqlCommand("SELECT Place.*, DATE_FORMAT(fTime, '%Y-%m') AS Month, COUNT(*) AS FallCount FROM Fall INNER JOIN Place ON Fall.pId = Place.pId WHERE Fall.pId = @pId GROUP BY DATE_FORMAT(fTime, '%Y-%m')", connection);
                                command2.Parameters.AddWithValue("@pId", TextBox1.Text);
                                MySqlDataAdapter adapter = new MySqlDataAdapter(command2);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                Chart8.DataSource = dt;
                                Chart8.Series[0].XValueMember = "Month";
                                Chart8.Series[0].YValueMembers = "FallCount";
                                Chart8.DataBind();


                                MySqlCommand command4 = new MySqlCommand("SELECT fWhy , COUNT(*) AS FallCount FROM Fall JOIN Place ON Fall.pId = Place.pId WHERE Place.pId = @pId GROUP BY fWhy", connection);
                                command4.Parameters.AddWithValue("@pId", TextBox1.Text);
                                MySqlDataAdapter adapter3 = new MySqlDataAdapter(command4);
                                DataTable dt3 = new DataTable();
                                adapter3.Fill(dt3);

                                Chart9.DataSource = dt3;
                                Chart9.Series[0].XValueMember = "fWhy";
                                Chart9.Series[0].YValueMembers = "FallCount";
                                Chart9.DataBind();

                                MySqlCommand command1 = new MySqlCommand("SELECT Place.*, Elder.eGender, COUNT(Fall.fId) AS FallCount FROM Fall JOIN Place ON Fall.pId = Place.pId JOIN Elder ON Fall.eId = Elder.eId WHERE Place.pId = @pId GROUP BY Elder.eGender", connection);
                                command1.Parameters.AddWithValue("@pId", TextBox1.Text);
                                MySqlDataAdapter da1 = new MySqlDataAdapter(command1);
                                DataSet dataset1 = new DataSet();
                                da1.Fill(dataset1);

                                Chart10.DataSource = dataset1;
                                Chart10.Series[0].XValueMember = "eGender";
                                Chart10.Series[0].YValueMembers = "FallCount";
                                // Insert code for additional chart formatting here.
                                Chart10.DataBind();
                                connection.Close();
                                connection.Close();

                                Panel2.Visible = false;
                                Panel3.Visible = false;
                                Panel5.Visible = true;
                                Label4.Visible = false;
                                break;
                            }
                            else if (Session["LoginType"] == "Home")
                            {

                            }
                        }
                        else
                        {
                            Label4.Visible = true;
                            Label4.Text = "查詢失敗";
                        }
                    }
                }
                connection.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = DropDownList1.SelectedValue;

            DropDownList2.Visible = false;
            TextBox1.Visible = false;
            TextBox1.Text = "";
            if (selectedValue == "長者ID"|| selectedValue == "地點") // 長者ID
            {
                TextBox1.Visible = true;
                
                //DropDownList2.Visible = false;
            }
            else
            {
                Chart1_Load(null, EventArgs.Empty);
            }
        }
    }
}