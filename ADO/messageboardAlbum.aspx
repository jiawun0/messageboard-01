<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageboardAlbum.aspx.cs" Inherits="ADO.messageboardAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 260px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="UploadButton" runat="server" Text="上傳圖片" OnClick="UploadButton_Click" />
        <br />
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        <br />
        <asp:FileUpload ID="FileUploadControl" runat="server" Visible="False" />
    </div>
    </form>
</body>
</html>
