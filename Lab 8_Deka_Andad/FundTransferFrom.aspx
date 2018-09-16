<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferFrom.aspx.cs" Inherits="FundTransferFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="padding-left: 30px; height: 390px;">
        <fieldset style="width: 220px; border-width: medium; border-color: black; background-color:aliceblue;">
            <asp:Label ID="Label1" runat="server" Text="Transfer From" CssClass="LargeDistinct"></asp:Label>
            <br />
            <br />

            <asp:RequiredFieldValidator ID="rfvTransferer" runat="server"
                ErrorMessage="Must Select One"
                CssClass="error" ControlToValidate="drpTransferor"
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <asp:DropDownList ID="drpTransferor" runat="server" CssClass="dropdown" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="-1">Select Transferor ...</asp:ListItem>
            </asp:DropDownList>


            <br />
            <br />

            <asp:Label ID="lblSending" runat="server" Text="From Account:"></asp:Label>

            <br />
            <br />

            <asp:RadioButtonList ID="RadioButtonListAccounts" runat="server" Visible="True"
                OnSelectedIndexChanged="RadioButtonListAccounts_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>Checking</asp:ListItem>
                <asp:ListItem>Saving</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonListAccounts"
                CssClass="error" Display="Dynamic">Must select an account!</asp:RequiredFieldValidator>
            <br />

            <br />

            <asp:Label ID="transferFromAmount" runat="server" Text="Amount:"></asp:Label>
            <asp:TextBox ID="txtAmountFrom" runat="server" CssClass="input"></asp:TextBox>

            &nbsp;<asp:RangeValidator ID="rvAmount" runat="server" ControlToValidate="txtAmountFrom"
                ErrorMessage="Please enter valid amount" MinimumValue="1" MaximumValue="99999" Type="Double"
                ForeColor="Red" Display="Dynamic"></asp:RangeValidator>

            <br />
            <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmountFrom"
                CssClass="error" ToolTip="Please Enter a Number" Display="Dynamic">Can not be blank</asp:RequiredFieldValidator>

            <br />
            <br />

            <br />
            <br />

            <asp:Button ID="Next" runat="server" CssClass="button" Text="Next"
                Style="margin-left: 190px;" OnClick="Next_Click" />

            <br />
            <br />
        </fieldset>


    </form>
</body>
</html>
