<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferTo.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>

    <form id="form1" runat="server" style="padding-left: 30px; height: 390px;">
        <fieldset style="width: 220px; border-width: medium; border-color: black; height: 294px; background-color:aliceblue;">

            <asp:Label ID="Label1" runat="server" Text="Transferee" CssClass="LargeDistinct"></asp:Label>
            <br />
            <br />

            <asp:RequiredFieldValidator ID="rfvTransferee" runat="server"
                ErrorMessage="Must Select One"
                CssClass="error" ControlToValidate="drpTransferee"
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <asp:DropDownList ID="drpTransferee" runat="server" CssClass="dropdown" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="-1">Select Transferee ...</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <br />

            <asp:Label ID="lblReceiving" runat="server" Text="To Account:"></asp:Label>

            <br />

            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Visible="True"
                OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                <asp:ListItem>Checking</asp:ListItem>
                <asp:ListItem>Saving</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="RadioButtonList2" CssClass="error"
                Display="Dynamic">Must select and account!</asp:RequiredFieldValidator>


            <br />
            <br />

            <%-- Got turning off validation for back button from here: --%>
            <%--https://stackoverflow.com/questions/29599455/redirecting-to-previous-page-by-avoiding-required-field-validation?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa--%>

            <br />


            <asp:Button ID="btnBack" runat="server" CausesValidation="false" CssClass="button" Text="Back"
                Style="margin-left: 20px; margin-right: 40px" OnClick="btnBack_Click" />
            <asp:Button ID="btnNext" runat="server" CssClass="button" Text="Next" OnClick="btnNext_Click" />

            <br />

        </fieldset>

    </form>
</body>
</html>
