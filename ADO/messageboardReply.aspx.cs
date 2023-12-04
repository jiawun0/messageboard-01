using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO
{
    public partial class messageboardReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    string postId = Request.QueryString["Id"];
                    // 使用從 GridView 傳遞過來的 topicID 進行相應的資料庫查詢或操作

                    ShowDB(postId);
                    ShowDB2(postId);
                }
            }

            if (Session["LoginId"] != null)
            {
                string LoginId = Session["LoginId"].ToString();
                ShowDB3(LoginId);

                string loginId = Session["LoginId"].ToString();
                string userNickname = ShowNickname(loginId);
                Literal5.Text = "歡迎, " + userNickname + "!";
            }
        }
        void ShowDB(string postId) //叫出此篇post
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectReply"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //string sql = $"select PostTopic, PostAuthor, PostDate, ReplyDate from post, reply where post.Id = reply.postId";
            string sql = $"select post.PostTopic as 主題, post.PostContent as 內容, reply.ReplyAuthor as 回覆者, reply.ReplyDate as 回覆時間, reply.ReplyContent as 回應內容 " +
             $"from post " +
             $"left join reply on post.Id = reply.postId " +
             $"where post.Id = @postId " +
             $"order by post.PostTopic desc ";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@postId", postId);

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            //GridViewReplytopic.DataSource = reader;

            //GridView進行資料連接
            //GridViewReplytopic.DataBind();

            if (reader.HasRows)
            {
                reader.Read();
                Literal1.Text = reader["主題"].ToString();
                Literal2.Text = reader["內容"].ToString();
            }

            connection.Close();
        }

        void ShowDB2(string postId) //叫出此篇post的reply
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectReplytwo"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //string sql = $"select PostTopic, PostAuthor, PostDate, ReplyDate from post, reply where post.Id = reply.postId";
            //string sql = $"select post.PostTopic as 主題, post.PostContent as 內容, reply.ReplyAuthor as 回覆者, reply.ReplyDate as 回覆時間, reply.ReplyContent as 回應內容 " +
            // $"from post, reply " +
            // $"where post.Id = reply.postId and post.Id = @topicID " +
            // $"order by post.PostTopic desc ";
            string sql = "select post.PostTopic as 主題, post.PostContent as 內容, Login.NickName as 回覆者, reply.ReplyDate as 回覆時間, reply.ReplyContent as 回應內容 from post inner join reply on post.Id = reply.postId inner join Login on reply.LoginId = Login.Id where post.Id = reply.postId and post.Id = @postId order by post.Id desc";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@postId", postId);

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            //GridViewReplytopic.DataSource = reader;

            //GridView進行資料連接
            //GridViewReplytopic.DataBind();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string replyText = "回覆者：" + reader["回覆者"].ToString() + "<br>";
                    replyText += "回覆時間：" + reader["回覆時間"].ToString() + "<br>";
                    replyText += "回應內容：" + reader["回應內容"].ToString() + "<br>" + "<br>";
                    Literal3.Text += replyText;
                }
            }


            connection.Close();
        }

        void ShowDB3(string LoginId)  //叫出暱稱
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectReply"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //string sql = $"select PostTopic, PostAuthor, PostDate, ReplyDate from post, reply where post.Id = reply.postId";
            string sql = $"select reply.ReplyAuthor as 回覆者, Login.NickName as 暱稱 " +
             $"from reply " +
             $"join Login on reply.LoginId = Login.Id " +
             $"where Login.Id = @LoginId ";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@LoginId", LoginId);

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            //GridViewReplytopic.DataSource = reader;

            //GridView進行資料連接
            //GridViewReplytopic.DataBind();

            if (reader.HasRows)
            {
                reader.Read();
                Literal4.Text = reader["暱稱"].ToString(); // 將 NickName 的值顯示在 Literal1 中
            }

            connection.Close();
        }
        string ShowNickname(string LoginId) //叫出表頭登入者
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
            if (Session["LoginId"] != null)
            {
                string LoginId = Session["LoginId"].ToString(); // 取得目前登入的使用者 ID

                // 在此處使用 username 將留言儲存到資料庫，同時將 username 與留言一同儲存
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectReplytwo"].ConnectionString);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                // 取得postId
                string postId = Request.QueryString["Id"];

                //發送SQL語法，取得結果
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;

                //查詢跟參數的部分很難寫成方法，需自行研究
                string sql = $"insert into reply (ReplyContent, LoginId, postId) values(@ReplyContent, @LoginId, @postId)";

                //增加參數並設定值，記得用.叫出來
                sqlCommand.Parameters.AddWithValue("@ReplyContent", TextBox_Content.Text);
                sqlCommand.Parameters.AddWithValue("@LoginId", LoginId);
                sqlCommand.Parameters.AddWithValue("@postId", postId);

                //將準備的SQL指令給操作物件
                sqlCommand.CommandText = sql;

                //執行非查詢的資料庫指令，ExecuteNonQuery() 會回傳受影響的資料數目，如果新增一筆卻顯示四筆，就是有誤
                int f = sqlCommand.ExecuteNonQuery();
                if (f != 0)
                {
                    Response.Write("<script>alert('回覆新增成功');</script>");
                }
                else
                {
                    Response.Write("<script>alert('回覆新增失敗');</script>");
                }

                //執行該SQL查詢，用reader接資料
                //SqlDataReader reader = sqlCommand.ExecuteReader();

                //使用這個reader物件的資料來取得內容
                //GridViewPost.DataSource = reader;

                //GridView進行資料連接
                //GridViewPost.DataBind();

                connection.Close();

                //Response.Redirect("messageboardPost.aspx");
                //string postId = Request.QueryString["Id"];
                ShowDB2(postId);
            }

            else
            {
                Response.Redirect("messageboardLogin.aspx");
            }
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