using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO
{
    public partial class messageboardPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginId"] != null)
            {
                string LoginId = Session["LoginId"].ToString();
                ShowDB(LoginId);

                string loginId = Session["LoginId"].ToString();
                string userNickname = ShowNickname(loginId);
                Literal2.Text = "歡迎, " + userNickname + "!";

            }
            else                                   //TC：好像缺乏這邊，沒有登入的話會被重新導向
            {
                Response.Redirect(""); //TC：好像缺乏這邊
            }
        }

        void ShowDB(string LoginId)  //叫出暱稱    //TC：應該把暱稱存在session就可以不用這個function了
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
            string sql = $"select post.PostAuthor as 發表人, Login.NickName as 暱稱 " +
             $"from post " +
             $"join Login on post.LoginId = Login.Id " +
             $"where Login.Id = @LoginId ";

            //增加參數並設定值，記得用.叫出來
            sqlCommand.Parameters.AddWithValue("@LoginId", @LoginId);

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
                Literal1.Text = reader["暱稱"].ToString(); // 將 NickName 的值顯示在 Literal1 中
            }

            connection.Close();
        }

        string ShowNickname(string LoginId) //叫出表頭登入者   //TC：應該把暱稱存在session就可以不用這個function了
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

        protected void Button1_Click(object sender, EventArgs e)    //TC：button語意建議調整
        {
            if(Session["LoginId"] != null)                                               //TC：這邊應該可以不用IF，應為page_Load已經確定是可以user登入狀態了
            {
                string LoginId = Session["LoginId"].ToString(); // 取得目前登入的使用者 ID

                // 在此處使用 username 將留言儲存到資料庫，同時將 username 與留言一同儲存
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectPost"].ConnectionString);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                //發送SQL語法，取得結果
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;

                //查詢跟參數的部分很難寫成方法，需自行研究
                string sql = $"insert into post (PostTopic, PostContent, LoginId) values(@PostTopic, @PostContent, @LoginId)";

                //增加參數並設定值，記得用.叫出來
                sqlCommand.Parameters.AddWithValue("@PostTopic", TextBox_Topic.Text);
                sqlCommand.Parameters.AddWithValue("@PostContent", TextBox_Content.Text);
                sqlCommand.Parameters.AddWithValue("@LoginId", LoginId);

                //將準備的SQL指令給操作物件
                sqlCommand.CommandText = sql;

                //int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                // 將使用者 ID 轉換為整數
                //int PostId = Convert.ToInt32(count);
                // 登入成功，取得使用者 ID，並存儲到 Session 中
                //Session["PostId"] = PostId;

                //執行非查詢的資料庫指令，ExecuteNonQuery() 會回傳受影響的資料數目，如果新增一筆卻顯示四筆，就是有誤
                int f = sqlCommand.ExecuteNonQuery();
                if (f != 0)
                {
                    Response.Write("<script>alert('留言新增成功');</script>");
                }
                else
                {
                    Response.Write("<script>alert('留言新增失敗');</script>");
                }

                //執行該SQL查詢，用reader接資料
                //SqlDataReader reader = sqlCommand.ExecuteReader();

                //使用這個reader物件的資料來取得內容
                //GridViewPost.DataSource = reader;

                //GridView進行資料連接
                //GridViewPost.DataBind();

                connection.Close();

                //Response.Redirect("messageboardPost.aspx");
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