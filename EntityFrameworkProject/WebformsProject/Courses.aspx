<%@ Page Title="Courses" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Courses.aspx.cs" Inherits="WebformsProject.Courses" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="studentinfo" runat="server">
    <h2 runat="server">Student</h2>

        <label>Name: </label><asp:Label ID="lbl_FullName" runat="server"></asp:Label>
        <label>Class: </label><asp:Label ID="lbl_Class" runat="server"></asp:Label>
        <label>Education: </label><asp:Label ID="lbl_Education" runat="server"></asp:Label>

    </div>
    <div class="row">
        <div class="col-md-8">
            <h3>Courses</h3>
        <asp:GridView ID="GridViewCourses" runat="server" CellPadding="4" ForeColor="#333333" Width="645px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:BoundField HeaderText="Grade" DataField="Grade" />
                <asp:BoundField DataField="Teacher" HeaderText="Teacher" />
                <asp:BoundField DataField="Completed" HeaderText="Completed" />
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
            <div id="addgradediv" runat="server">
                <asp:Label ID="lbl_Course" runat="server" Text="Course: "></asp:Label>
                    <asp:DropDownList ID="ddl_studCourse" runat="server"></asp:DropDownList>
                 <asp:Label ID="label_Completed" runat="server" Text="Completed: "></asp:Label>
                    <asp:CheckBox ID="chkbox_completed" runat="server" OnCheckedChanged="chkbox_completed_CheckedChanged" AutoPostBack="True" />
                <asp:Label ID="lbl_Grade" runat="server" Text="Grade: "></asp:Label>
                    <asp:DropDownList ID="ddl_studGrade" runat="server"></asp:DropDownList>
               
                <asp:Button ID="btn_addCourse" runat="server" Text="Add/Update Course" OnClick="btn_addCourse_Click" />
            </div>
            <br />
        <asp:GridView ID="GridViewAllCourses" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="539px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:BoundField DataField="GradeRange" HeaderText="Grade Range" />
                <asp:BoundField DataField="Teacher" HeaderText="Teacher" />
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
            <div id="AddNewCourses"></div>
        </div>
    </div>
    </asp:Content>

