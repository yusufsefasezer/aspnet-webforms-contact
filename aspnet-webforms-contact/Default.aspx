<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aspnet_webforms_contact.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET WebForms Contact</title>
    <style>
        body {
            background-color: whitesmoke;
        }

        fieldset {
            border: 1px solid gray;
        }

        td {
            text-align: right;
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="PanelContact" runat="server" GroupingText="Contacts">
                            <asp:ListBox AutoPostBack="True" ID="ListBoxContactList" runat="server" Height="281px" Width="144px" OnSelectedIndexChanged="ChangeContact"></asp:ListBox>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="PanelInformation" runat="server" GroupingText="Contact Information">
                            <table>
                                <%--FirstName--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelFirstName" runat="server" Text="First Name:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxFirstName" runat="server" Style="width: 100%"></asp:TextBox></td>
                                </tr>

                                <%--LastName--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelLastName" runat="server" Text="Last Name:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxLastName" runat="server" Style="width: 100%"></asp:TextBox></td>
                                </tr>

                                <%--Email--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelEmail" runat="server" Text="E-mail:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEmail" runat="server" Style="width: 100%"></asp:TextBox></td>
                                </tr>

                                <%--PhoneNumber--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelPhoneNumber" runat="server" Text="Phone Number:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPhoneNumber" runat="server" Style="width: 100%"></asp:TextBox></td>
                                </tr>

                                <%--Web Address--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelWebAddress" runat="server" Text="Web Address:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxWebAddress" runat="server" Style="width: 100%"></asp:TextBox></td>
                                </tr>

                                <%--Address--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelAddress" runat="server" Text="Address:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine" Style="width: 100%; resize: none;"></asp:TextBox></td>
                                </tr>

                                <%--Notes--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelNotes" runat="server" Text="Notes:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxNotes" runat="server" TextMode="MultiLine" Style="width: 100%; resize: none;"></asp:TextBox></td>
                                </tr>

                                <%--Operations--%>
                                <tr>
                                    <td colspan="2" style="text-align: right;">
                                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="AddContact" />
                                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="UpdateContact" />
                                        <asp:Button ID="ButtonRemove" runat="server" Text="Remove" OnClick="RemoveContact" />
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
