<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageboardReply.aspx.cs" Inherits="ADO.messageboardReply" %>

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
    <a class="navbar-brand" href="#">留言板貼文回覆</a>
    <div>
        <ul class="navbar-nav ml-auto">
            <li>
                <asp:Label ID="Label2" runat="server" Text="目前登入者: "></asp:Label>
                <asp:Literal ID="Literal5" runat="server"></asp:Literal>
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
            <asp:GridView ID="GridViewReplytopic" runat="server" AutoGenerateColumns="False" DataKeyNames="主題" >
                <Columns>
                    <asp:BoundField DataField="主題" HeaderText="主題" SortExpression="主題" />
                    <asp:BoundField DataField="內容" HeaderText="內容" SortExpression="內容" />
                    <asp:BoundField DataField="回覆者" HeaderText="回覆者" SortExpression="回覆者" />
                    <asp:BoundField DataField="回覆時間" HeaderText="回覆時間" SortExpression="回覆時間" />
                    <asp:BoundField DataField="回應內容" HeaderText="回應內容" SortExpression="回應內容" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="GridViewReplytwo" runat="server" AutoGenerateColumns="False" DataKeyNames="主題" >
                <Columns>
                    <asp:BoundField DataField="主題" HeaderText="主題" SortExpression="主題" />
                    <asp:BoundField DataField="內容" HeaderText="內容" SortExpression="內容" />
                    <asp:BoundField DataField="回覆者" HeaderText="回覆者" SortExpression="回覆者" />
                    <asp:BoundField DataField="回覆時間" HeaderText="回覆時間" SortExpression="回覆時間" />
                    <asp:BoundField DataField="回應內容" HeaderText="回應內容" SortExpression="回應內容" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="RE: "></asp:Label>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="內容: "></asp:Label>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="回覆區: "></asp:Label>
            <br />
            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="我要回覆: "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label_Author" runat="server" Text="暱稱: "></asp:Label>

            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Label_Content" runat="server" Text="內容"></asp:Label>
&nbsp;:
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_Content" runat="server" TextMode="MultiLine" Height="230px" Width="230px" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('內容不得為空')" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回覆留言" />
            <br />
        </div>
    </form>
</body>
</html>
