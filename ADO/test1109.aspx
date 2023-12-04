<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1109.aspx.cs" Inherits="ADO.test1109" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="AlbumName" HeaderText="AlbumName" SortExpression="AlbumName" />
                    <asp:BoundField DataField="AlbumDescription" HeaderText="AlbumDescription" SortExpression="AlbumDescription" />
                    <asp:BoundField DataField="AlbumPath" HeaderText="AlbumPath" SortExpression="AlbumPath" />
                    <asp:BoundField DataField="AlbumCreatTime" HeaderText="AlbumCreatTime" SortExpression="AlbumCreatTime" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="Button2" runat="server" Text="連接測試" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label_Name" runat="server" Text="AlbumName"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label_Description" runat="server" Text="AlbumDescription"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_sent" runat="server" Text="資料送出" OnClick="Button3_Click" />


            
         </div>   
    </form>
</body>
</html>
