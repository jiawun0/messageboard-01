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
    public partial class test1110 : System.Web.UI.Page
    {
        DbHelper helper = new DbHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDB();
        }

        private void ShowDB()
        {
            //DbHelper helper = new DbHelper();
            string sql = $"select * from Student";

            //helper.SerchDB(sql); 這行會傳出reader
            //使用這個reader物件的資料來取得內容
            GridView1110.DataSource = helper.SerchDB(sql);

            GridView1110.DataBind();

            helper.CloseDB();
        }


        //void ShowDB()
        //{
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString);

        //    if(connection.State != System.Data.ConnectionState.Open)
        //    {
        //        connection.Open();
        //    }

        //    //發送SQL語法，取得結果
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Connection = connection;

        //    string sql = $"select * from Student";

        //    //將準備的SQL指令給操作物件
        //    sqlCommand.CommandText = sql;

        //    //執行該SQL查詢，用reader接資料
        //    SqlDataReader reader = sqlCommand.ExecuteReader();

        //    //使用這個reader物件的資料來取得內容
        //    GridView1110.DataSource = reader;

        //    //GridView進行資料連接
        //    GridView1110.DataBind();

        //    connection.Close();
        //}

        protected void Button_test_Click(object sender, EventArgs e)
        {
            #region "連線資料庫"
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString);

            connection.Open();

            if(connection.State == System.Data.ConnectionState.Open)
            {
                Response.Write("<script>alert('資料庫連線成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('資料庫連線失敗');</script>");
            }

            #endregion "連線資料庫"
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //查詢跟參數的部分很難寫成方法，需自行研究
            string sql = $"insert into Student(Name) values(@Name)";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@Name", TextBox_Name.Text);

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行非查詢的資料庫指令
            int f = sqlCommand.ExecuteNonQuery();
            if (f != 0)
            {
                Response.Write("<script>alert('資料新增成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('資料新增失敗');</script>");
            }

            ShowDB();

            connection.Close();
        }
    }
}