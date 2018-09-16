<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferResult.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
        <p>Thank you for using our Online Fund Transfer Service.</p>

        <p>Amount: $<asp:Label ID="lblTransferredAmount" runat="server"></asp:Label>
            has been transferred.</p>

        <p style="font-weight: bold;">From</p>

        <p>
            <asp:Label ID="lblTransferor" runat="server" Text="Name: " Style="margin-left: 20px;"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblAccountFrom" runat="server" Text="Account: " Style="margin-left: 20px;"></asp:Label>

        </p>
        <p>

            <p style="font-weight: bold;">To</p>
        </p>
        <p>
            <asp:Label ID="lblTransferee" runat="server" Text="Name: " Style="margin-left: 20px;"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblAccountTo" runat="server" Text="Account: " Style="margin-left: 20px;"></asp:Label>

        </p>
        <p>
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="Start a New Transfer" Width="138px"
                Style="margin-left: 40px;" OnClick="Restart_Click" />
        </p>

    </form>
</body>
</html>
