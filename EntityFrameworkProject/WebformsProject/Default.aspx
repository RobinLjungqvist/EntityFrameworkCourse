<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebformsProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Students</h2>
        <p>
            <asp:Label ID="lbl_msg" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="lb_addstudent" runat="server" OnClick="lb_addstudent_Click">Add Student</asp:LinkButton>
        </p>
        <div class="col-md-8">
            <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" CommandArgument='<%# Eval("studentID") %>' OnClick="LinkButton1_Click" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="studentID" Visible="False" />
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                    <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                    <asp:BoundField DataField="classname" HeaderText="Class" />
                    <asp:BoundField DataField="education" HeaderText="Education" />
                    <asp:TemplateField HeaderText="Option">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClick="LinkButtonDelete_Click" OnClientClick="return confirm('Are you sure?')">Delete</asp:LinkButton>
                            <asp:LinkButton ID="lb_edit" runat="server" OnClick="lb_edit_Click">Edit</asp:LinkButton>
                            <asp:HiddenField ID="HiddenFieldStudID" runat="server" Value='<%# Eval("studentID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </div>
    </asp:Content>
