using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO
{
    public partial class messageboardBackstage : System.Web.UI.Page
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

            string sql = $"select post.Id as Id, post.PostTopic as 主題, Login.NickName as 發表人, post.PostContent as 發表內容, post.PostDate as 發表日期, max(reply.ReplyDate) as 最後回覆時間, count(reply.postId) as 回應數量, post.IsCheck " +
             $"from post " +
             $"left join reply on post.Id = reply.postId " +
             $"join Login on post.LoginId = Login.Id " +
             $"group by post.Id, post.PostTopic, Login.NickName, post.PostContent, post.PostDate, post.IsCheck " +
             $"order by post.PostDate desc ";

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行非查詢的資料庫指令，ExecuteNonQuery() 會回傳受影響的資料數目，如果新增一筆卻顯示四筆，就是有誤
            //int f = sqlCommand.ExecuteNonQuery();

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            GridViewBackstage.DataSource = reader;

            //GridView進行資料連接
            GridViewBackstage.DataBind();

            connection.Close();
        }

        string ShowNickname(string LoginId)
        {
            string userNickname = "";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectBackstage"].ConnectionString);
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
        protected void GridViewBackstage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBackstage.EditIndex = e.NewEditIndex;
            ShowDB();
        }

        protected void GridViewBackstage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewBackstage.Rows[e.RowIndex]; //找到目前gridview的編輯行數
            //DropDownList dropDownList = (DropDownList)row.FindControl("dropDownList");

            //string isActive = dropDownList.SelectedValue;
            int boardId = Convert.ToInt32(GridViewBackstage.DataKeys[e.RowIndex].Value); //取得資料表ID

            TextBox textBox = row.FindControl("TextBox1") as TextBox;
            string changeText = textBox.Text;

            DropDownList textBox2 = row.FindControl("DropDownList1") as DropDownList;
            bool isCheck = Convert.ToBoolean(textBox2.SelectedValue);

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectBackstage"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //發送SQL語法，取得結果
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            string sql = $"update post set PostTopic = @PostTopic, IsCheck = @IsCheck where Id = @BoardId";


            sqlCommand.Parameters.AddWithValue("@PostTopic", changeText);
            sqlCommand.Parameters.AddWithValue("@IsCheck", isCheck); // 修改為適當的布林值
            sqlCommand.Parameters.AddWithValue("@BoardId", boardId);
            sqlCommand.CommandText = sql;

            //int s = helper.ExecuteSQL(sql);
            //if (s > 0) Response.Write("<script>alert('更新成功');</script>");
            //else Response.Write("<script>alert('更新失敗');</script>");
            
            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //使用這個reader物件的資料來取得內容
            GridViewBackstage.DataSource = reader;

            //GridView進行資料連接
            GridViewBackstage.DataBind();

            connection.Close();

            GridViewBackstage.EditIndex = -1;
            ShowDB();

        }
        protected void GridViewBackstage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int boardId = Convert.ToInt32(GridViewBackstage.DataKeys[e.RowIndex].Value);

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectBackstage"].ConnectionString);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            //string sql = $"delete from post where Id = @boardId";
            //sqlCommand.Parameters.AddWithValue("@boardId", boardId);
            //sqlCommand.CommandText = sql;

            string deleteReplySql = $"delete from reply where postId = @boardId";
            SqlCommand deleteReplyCommand = new SqlCommand(deleteReplySql, connection);
            deleteReplyCommand.Parameters.AddWithValue("@boardId", boardId);
            deleteReplyCommand.ExecuteNonQuery();

            string deletePostSql = $"delete from post where Id = @boardId";
            SqlCommand deletePostCommand = new SqlCommand(deletePostSql, connection);
            deletePostCommand.Parameters.AddWithValue("@boardId", boardId);
            deletePostCommand.ExecuteNonQuery();

            connection.Close();

            Response.Write("<script>alert('資料刪除成功');</script>");

            ShowDB();
        }
    }
}