<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageboardPost.aspx.cs" Inherits="ADO.messageboardPost" %>

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
    <a class="navbar-brand" href="#">留言板貼文</a>
    <div>
        <ul class="navbar-nav ml-auto">
            <li>
                <asp:Label ID="Label1" runat="server" Text="目前登入者: "></asp:Label>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
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
            <asp:GridView ID="GridViewPost" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="PostTopic" HeaderText="PostTopic" SortExpression="PostTopic" />
                    <asp:BoundField DataField="PostAuthor" HeaderText="PostAuthor" SortExpression="PostAuthor" />
                    <asp:BoundField DataField="PostContent" HeaderText="PostContent" SortExpression="PostContent" />
                    <asp:BoundField DataField="PostDate" HeaderText="PostDate" SortExpression="PostDate" />
                    <asp:BoundField DataField="LoginId" HeaderText="LoginId" SortExpression="LoginId" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label_Topic" runat="server" Text="*標題: "></asp:Label>
            <asp:TextBox ID="TextBox_Topic" runat="server" required="" aria-required="true" Placeholder="請輸入標題" oninput="setCustomValidity('');" oninvalid="setCustomValidity('標題不得為空')" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label_Author" runat="server" Text="暱稱: "></asp:Label>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Label_Content" runat="server" Text="*內容: "></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_Content" runat="server" TextMode="MultiLine" Height="230px" Width="230px" required="" aria-required="true" Placeholder="請輸入內容" oninput="setCustomValidity('');" oninvalid="setCustomValidity('內容不得為空')" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確定送出" />
            <br />
        </div>
    </form>
</body>
</html>
