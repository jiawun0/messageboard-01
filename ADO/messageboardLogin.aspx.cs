using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADO
{
    public partial class messageboardLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectLogin"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //查詢跟參數的部分很難寫成方法，需自行研究
            string sql = $"select Id, IsManager from Login where Username = @Username and Password = @Password";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@Username", TextBox_Username.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", TextBox_Password.Text.Trim());

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            //int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
            //object result = sqlCommand.ExecuteScalar();

            //用read先叫出來，while也可以
            if (reader.Read())
            {

                //將是否為管理者設為boolean
                bool isManager = Convert.ToBoolean(reader["IsManager"]);

                // 登入成功，取得使用者 ID，並存儲到 Session 中
                Session["LoginId"] = reader["Id"];

                if (isManager)
                {
                    Session["login"] = true;
                    Response.Write("<script>alert('登入成功');</script>");
                    Response.Redirect("messageboardBackstage.aspx");
                }
                else
                {
                    Session["login"] = true;
                    Response.Write("<script>alert('登入成功');</script>");
                    Response.Redirect("messageboardhomepage.aspx");
                }
            }
            else
            {
                // 登入失敗
                Response.Write("<script>alert('帳號或密碼錯誤，請重新輸入');</script>");
            }
            //connection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageboardRegister.aspx");
        }

        protected void HomepageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageboardhomepage.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageboardLogin.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("messageboardhomepage.aspx");
        }
    }
}