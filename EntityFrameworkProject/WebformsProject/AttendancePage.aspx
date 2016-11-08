<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttendancePage.aspx.cs" Inherits="WebformsProject.AttendancePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <h2>Attendance</h2>
            <asp:GridView ID="GridViewAllAttendance" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowCancelingEdit="GridViewAllAttendance_RowCancelingEdit" OnRowEditing="GridViewAllAttendance_RowEditing" OnRowUpdating="GridViewAllAttendance_RowUpdating" DataKeyNames="AttendanceID">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="StudentName" HeaderText="Student" ReadOnly="True" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course" ReadOnly="True" />
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Attendance">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxAttendance" runat="server" Text='<%# Bind("Attendance") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Attendance") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AttendanceID" HeaderText="AttendanceID" Visible="False" />
                    <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            <asp:LinkButton ID="lb_delete" runat="server" OnClick="lb_delete_Click" CommandArgument='<%# Eval("AttendanceID") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <br />
            <div id="AddAttendanceDiv" runat="server">
               <asp:Calendar ID="calendar_date" runat="server"></asp:Calendar>
                <label>Student: </label><asp:DropDownList ID="ddl_student" runat="server"></asp:DropDownList>
                <label>Course: </label><asp:DropDownList ID="ddl_courses" runat="server"></asp:DropDownList>
                <label>Attendance: </label><asp:DropDownList ID="ddl_addAtt" runat="server"></asp:DropDownList>
                <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_Click" />
            </div>
        </div>
    </div>
</asp:Content>