<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferConfirmation.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
        <fieldset style="width: 300px; border-width: medium; border-color: black; background-color: aliceblue;">
            <asp:Label ID="Label1" runat="server" CssClass="LargeDistinct" Text="Review and Complete"></asp:Label>
            <br />

            <p style="font-weight:bold;">Transferor</p>
           
            <asp:Label ID="transferorName" runat="server" Text="Name:" style="margin-left:20px;"></asp:Label>
            <br />
            <asp:Label ID="transferorAccount" runat="server" Text="Account:" style="margin-left:20px;"></asp:Label>
            <br />
            <asp:Label ID="transferorAmount" runat="server" Text="Amount:" style="margin-left:20px;"></asp:Label>
            <br />
            <br />
            <p style="font-weight:bold;">Transferee</p>
            
            <asp:Label ID="transfereeName" runat="server" Text="Name:" style="margin-left:20px;"></asp:Label>
            <br />
            <asp:Label ID="transfereeAccount" runat="server" Text="Account:" style="margin-left:20px;"></asp:Label>

            <p>

                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Back" 
                    Style="margin-left: 20px; margin-right: 40px" OnClick="Return_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="button" Text="Complete" OnClick="Complete_Click" />
            </p>
        </fieldset>


    </form>

</body>
</html>
