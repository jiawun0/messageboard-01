<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageboardhomepage.aspx.cs" Inherits="ADO.messageboardhomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>jiawun0的留言板</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous" />
    <!-- Custom Styles -->
    <style>
        /* Your custom styles go here */
        /* Example: */
        .navbar-nav.ml-auto .nav-item {
            flex: 1;
            text-align: center;
        }

        .navbar-nav.ml-auto .nav-item+.nav-item {
            margin-left: 10px; /* Adjust the margin as needed */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <a class="navbar-brand" href="#">留言板</a>
    <div>
        <ul class="navbar-nav ml-auto">
            <li>
                <asp:Label ID="Label1" runat="server" Text="目前登入者: "></asp:Label>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </li>
        </ul>
        <ul class="navbar-nav ml-auto">
            <li class="nav-item">
                <asp:LinkButton ID="LoginButton" runat="server" Text="登入" OnClick="LoginButton_Click"></asp:LinkButton>
            </li>
            <li class="nav-item">
                <asp:LinkButton ID="LogoutButton" runat="server" Text="登出" OnClick="LogoutButton_Click"></asp:LinkButton>
            </li>
            <li class="nav-item">
                <asp:LinkButton ID="HomepageButton" runat="server" Text="首頁" OnClick="HomepageButton_Click" ></asp:LinkButton>
            </li>
        </ul>
    </div>
</nav>
        <div class="container">
            <asp:GridView ID="GridViewHyperLink" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" >
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="messageboardReply.aspx?Id={0}" DataTextField="主題" HeaderText="主題" />
                    <asp:BoundField DataField="主題" HeaderText="主題" SortExpression="主題" Visible="False" />
                    <asp:BoundField DataField="發表人" HeaderText="發表人" SortExpression="發表人" />
                    <asp:BoundField DataField="發表日期" HeaderText="發表日期" SortExpression="發表日期" />
                    <asp:BoundField DataField="最後回覆時間" HeaderText="最後回覆時間" SortExpression="最後回覆時間" />
                    <asp:BoundField DataField="回應數量" HeaderText="回應數量" SortExpression="回應數量" />
                    <asp:BoundField DataField="IsCheck" HeaderText="IsCheck" SortExpression="IsCheck" Visible="False" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="發表留言" />

        </div>
    </form>
</body>
</html>
