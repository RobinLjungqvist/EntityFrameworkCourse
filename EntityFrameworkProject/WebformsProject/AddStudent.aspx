<%@ Page Title="Add Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="WebformsProject.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Student</h2>
    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
    <table style="width: 43%; height: 51px;">
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_firstname" runat="server" Text="First Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbox_firstname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_lastname" runat="server" Text="Last Name: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbox_lastname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_adress" runat="server" Text="Adress: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbox_adress" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_email" runat="server" Text="E-mail: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbox_email" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_Education" runat="server" Text="Education "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_education" runat="server" AppendDataBoundItems="true"></asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="lbl_class" runat="server" Text="Class:  "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_class" runat="server" AppendDataBoundItems="true"></asp:DropDownList>

            </td>
        </tr>
         <tr>
            <td style="width: 182px">
            </td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" Width="81px" />

            </td>
        </tr>

        </table>
    
    
</asp:Content>
