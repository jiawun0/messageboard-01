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
    public partial class test1109 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDB();
        }

        void ShowDB()
        {
            //建立SQL連線的物件~透過SqlConnection
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlhw-1ConnectionString"].ConnectionString);

            //跟資料庫建立連線
            connection.Open();

            //建立要操作SQL的指令物件~透過SqlCommand
            SqlCommand sqlCommand = new SqlCommand();

            //連接到哪個資料庫
            sqlCommand.Connection = connection;

            //SQL語法
            string sql = "select * from Album";//選取哪張表

            //將準備好的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //查詢資料庫，Datareader速度快只能逐筆單向由上往下而且不能計算，適合拿來抓資料
            SqlDataReader reader = sqlCommand.ExecuteReader(); //執行該筆資料查詢

            //使用這個reader物件的資料來取得內容
            GridView1.DataSource = reader;

            //GridView控制項進行資料連結(data binding)綁定資料
            GridView1.DataBind();

            connection.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //建立SQL連線的物件
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlhw-1ConnectionString"].ConnectionString);

            //建立SQL連線的物件
            //SqlConnection connection = new SqlConnection();
            //設定連接物件參數~要額外連到另外資料庫~不用
            //connection.ConnectionString = @"Data Source=USER;Initial Catalog=sqlhw-1;Integrated Security=True";

            //跟資料庫建立連線
            connection.Open();

            //判斷是否連線成功
            if(connection.State == System.Data.ConnectionState.Open)
            {
                Response.Write("<script>alert('資料庫連接成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('資料庫連接失敗');</script>");
            }

            //關閉連線
            connection.Close();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //建立SQL連線的物件~透過SqlConnection
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlhw-1ConnectionString"].ConnectionString);

            //判斷是否已經連線，如果沒有連線再連
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //建立要操作SQL的指令物件~透過SqlCommand
            SqlCommand sqlCommand = new SqlCommand();

            //連接到哪個資料庫
            sqlCommand.Connection = connection;

            //SQL語法//插入哪張表，哪幾個欄位
            //string sql = $"insert into Album (AlbumName, AlbumDescription) values('{TextBox1.Text}','{TextBox2.Text}')";

            //SQL語法參數化
            string sql = "insert into Album (AlbumName) values(@AlbumName)";

            //增加參數設定值
            sqlCommand.Parameters.AddWithValue("@AlbumName", TextBox1.Text);

            //將準備好的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行非查詢的資料庫指令，ExecuteNonQuery() 會回傳受影響的資料數目，如果新增一筆卻顯示四筆，就是有誤
            int f = sqlCommand.ExecuteNonQuery();
            if (f !=0)
            {
                Response.Write("<script>alert('資料新增成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('資料新增失敗');</script>");
            }

            //關閉連線
            connection.Close();

            ShowDB();
        }
    }
}