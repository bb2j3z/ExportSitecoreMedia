<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportMedia.aspx.cs" Inherits="ExportMedia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .input_text {
            width: 350px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>


            <asp:TextBox ID="txtFolder" Text="/CSI/Images" runat="server" CssClass="input_text"/><br />
            <br />
            <asp:Button ID="myButton" Text="Export Images" OnClick="ExportMediaAction" runat="server" />


            <br /><br />
            <a href="ExportMedia.aspx">Restart</a>
    </div>
    </form>
</body>
</html>
