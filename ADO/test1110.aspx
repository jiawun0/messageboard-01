<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1110.aspx.cs" Inherits="ADO.test1110" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1110" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />
                    <asp:BoundField DataField="CreatDate" HeaderText="CreatDate" SortExpression="CreatDate" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="Button_test" runat="server" Text="Button" OnClick="Button_test_Click" />
            <br />
            <br />
            <asp:Label ID="Label_Name" runat="server" Text="學生姓名"></asp:Label>
&nbsp;:
            <asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label_Number" runat="server" Text="成績"></asp:Label>
&nbsp;:
            <asp:TextBox ID="TextBox_Number" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
