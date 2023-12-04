using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    public partial class messageboardAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button btnNew = new Button();//聲明一個新的按鈕
            //btnNew.Text = "新的按鈕";
            //PlaceHolder1.Controls.Add(btnNew);//添加到控件中

            //Literal litNewHTML = new Literal();//添加<br/>或<p>或普通text使用這種方式
            //litNewHTML.Text = "<p>我是一段HTML代碼</p>";
            //PlaceHolder1.Controls.Add(litNewHTML);
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            FileUpload fileUpload = new FileUpload();
            fileUpload.ID = "FileUploadControl";
            fileUpload.Attributes["accept"] = ".jpg, .jpeg, .png";

            Button saveButton = new Button();
            saveButton.Text = "儲存";
            saveButton.Click += new EventHandler(SaveButton_Click);

            PlaceHolder2.Controls.Add(fileUpload);
            PlaceHolder2.Controls.Add(saveButton);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    string savePath = Server.MapPath("~/UploadedImages/") + filename;
                    FileUploadControl.SaveAs(savePath);
                }
                catch (Exception ex)
                {
                    // 處理檔案儲存時的錯誤
                }
            }
        }
    }
}