<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageboardRegister.aspx.cs" Inherits="ADO.messageboardRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>jiawun0的留言板</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <a class="navbar-brand" href="#">留言板註冊</a>
    <div>
        <ul class="navbar-nav ml-auto">
            <li>
                目前登入者: <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </li>
            <li class="nav-item">
                <asp:LinkButton ID="LoginButton" runat="server" Text="登入" OnClick="LoginButton_Click"></asp:LinkButton>
            </li>
            <li class="nav-item">
                <asp:LinkButton ID="LogoutButton" runat="server" Text="登出" OnClick="LogoutButton_Click"></asp:LinkButton>
            </li>
        </ul>
    </div>
</nav>
        <div class="container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:BoundField DataField="CreatDate" HeaderText="CreatDate" SortExpression="CreatDate" />
                    <asp:BoundField DataField="NickName" HeaderText="NickName" SortExpression="NickName" />
                    <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                </Columns>
            </asp:GridView>
            
            <br />
            <asp:Label ID="Label1" runat="server" Text="帳號: "></asp:Label>
            <asp:TextBox ID="TextBox_Username" runat="server" Placeholder="請輸入Email" TextMode="Email"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="密碼: "></asp:Label>
            <asp:TextBox ID="TextBox_Password" runat="server" Placeholder="請輸入6位以上字元" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="密碼: "></asp:Label>
            <asp:TextBox ID="TextBox_pwCheck" runat="server" Placeholder="請再次輸入密碼" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="暱稱: "></asp:Label>
            <asp:TextBox ID="TextBox_NickName" runat="server" Placeholder="中、英皆可"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="確認註冊" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="回首頁" OnClick="Button2_Click" />
            
        </div>
    </form>
</body>
</html>
