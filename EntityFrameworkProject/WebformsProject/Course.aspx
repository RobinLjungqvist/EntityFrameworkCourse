<%@ Page Title="Courses" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Course.aspx.cs" Inherits="WebformsProject.Course" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="studentinfo" runat="server">
    <h2 runat="server">Student</h2>

        <label>Name: </label><asp:Label ID="lbl_FullName" runat="server"></asp:Label>
        <label>Class: </label><asp:Label ID="lbl_Class" runat="server"></asp:Label>
        <label>Education: </label><asp:Label ID="lbl_Education" runat="server"></asp:Label>
        <br />
        <label>Adress: </label><asp:Label ID="lbl_adress" runat="server" ></asp:Label>
        <label>Email: </label><asp:Label ID="lbl_email" runat="server" ></asp:Label>


    </div>
    <div class="row">
        <div class="col-md-8">
            <h3>Courses</h3>
        <asp:GridView ID="GridViewCourses" runat="server" CellPadding="4" ForeColor="#333333" Width="645px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:BoundField HeaderText="Grade" DataField="Grade" />
                <asp:BoundField DataField="Teacher" HeaderText="Teacher" />
                <asp:BoundField DataField="Completed" HeaderText="Completed" />
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("CourseID") %>' OnClick="LinkButton1_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CourseiD" HeaderText="CourseID" Visible="False" />
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
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:BoundField DataField="GradeRange" HeaderText="Grade Range" />
                <asp:BoundField DataField="Teacher" HeaderText="Teacher" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_studdelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Eval("CourseID") %>' OnClick="lb_studdelete_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" Visible="False" />
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
            <br />
            <div id="AddNewCoursesDiv" runat="server">
                <asp:Label ID="lbl_newcourse" runat="server" Text="Course: "></asp:Label>
                <asp:TextBox ID="txtbox_newcourse" runat="server"></asp:TextBox>
                 <asp:Label ID="lbl_newcourseteacher" runat="server" Text="Teacher: "></asp:Label>
                    <asp:DropDownList ID="ddl_teachers" runat="server"></asp:DropDownList>
                <asp:Label ID="lbl_newcourseeducation" runat="server" Text="Education: "></asp:Label>
                    <asp:DropDownList ID="ddl_education" runat="server"></asp:DropDownList>
                
                <asp:Button ID="btn_savenewcourse" runat="server" Text="Add" OnClick="btn_savenewcourse_Click" />
            </div>
        </div>
    </div>
    </asp:Content>

