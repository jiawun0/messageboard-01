using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace ADO
{
    public partial class messageboardhomepage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowDB();

                if (Session["LoginId"] != null)
                {
                    string loginId = Session["LoginId"].ToString(); 

                    string userNickname = ShowNickname(loginId); 

                    Literal1.Text = "歡迎, " + userNickname + "!"; 
                }
            }
        }
        void ShowDB()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnecthyperlinkNew"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //string sql = $"select PostTopic, PostAuthor, PostDate, ReplyDate from post, reply where post.Id = reply.postId";
            //string sql = $"select post.Id as Id, post.PostTopic as 主題, post.PostAuthor as 發表人, post.PostDate as 發表日期, max(reply.ReplyDate) as 最後回覆時間, count(reply.postId) as 回應數量 " +
             //$"from post " +
             //$"left join reply on post.Id = reply.postId " +
             //$"group by post.Id, post.PostTopic, post.PostAuthor, post.PostDate " +
             //$"order by post.PostDate desc ";

            string sql = $"select post.Id as Id, post.PostTopic as 主題, Login.NickName as 發表人, post.PostDate as 發表日期, max(reply.ReplyDate) as 最後回覆時間, count(reply.postId) as 回應數量, post.IsCheck " +
             $"from post " +
             $"left join reply on post.Id = reply.postId " +
             $"join Login on post.LoginId = Login.Id " +
             $"where post.IsCheck = 1 " +
             $"group by post.Id, post.PostTopic, Login.NickName, post.PostDate, post.IsCheck " +
             $"order by post.PostDate desc ";

            //使用子查詢
            //string sql = $"SELECT * FROM post Left Join(SELECT postId, max(reply.ReplyDate) as 最後回覆時間, count(reply.postId) as 回應數量 FROM reply GROUP BY postId) as P on post.Id = P.postId";

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行非查詢的資料庫指令，ExecuteNonQuery() 會回傳受影響的資料數目，如果新增一筆卻顯示四筆，就是有誤
            //int f = sqlCommand.ExecuteNonQuery();

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            GridViewHyperLink.DataSource = reader;

            //GridView進行資料連接
            GridViewHyperLink.DataBind();

            connection.Close();
        }

        string ShowNickname(string LoginId)
        {
            string userNickname = "";
            
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnecthyperlinkNew"].ConnectionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string sql = "select NickName from Login where Id = @LoginId";

            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@LoginId", LoginId);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userNickname = reader["NickName"].ToString();
                    break;
                }
            }

            connection.Close();

            return userNickname;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageboardPost.aspx");
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

        protected void HomepageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("messageboardhomepage.aspx");
        }
    }
}
