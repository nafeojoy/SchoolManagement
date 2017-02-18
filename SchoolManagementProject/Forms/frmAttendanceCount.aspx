<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmAttendanceCount.aspx.cs" Inherits="SchoolManagementProject.Forms.frmAttendanceCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $('#<%=DateTextbox1.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 class="well">   
            Daily Attendance Entry</h1>
            <div style="font-size:medium; font-family:Comic Sans MS">
                <label id="lblClassName" runat="server">
                    
                </label>
            </div>
<div class="col-sm-4 form-group">
        <label style="font-size: medium">
            Select Date</label>
        <asp:TextBox ID="DateTextbox1" class="form-control" ClientIDMode="Static" runat="server"
            CssClass="m-wrap span12 date form_datetime" Style="display: block; width: 100%;
            height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555;
            background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;" required>
        </asp:TextBox>

        

    </div>
    <asp:GridView ID="grdAttendaceCount" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="stdId" HeaderText="Student ID" ReadOnly="True" SortExpression="StudentID" />
            <asp:BoundField DataField="stdName" HeaderText="Student Name" SortExpression="StudentName" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="headchk" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkSelect" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("StudentId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAttendaceCount" runat="server" Text="Absent" class="btn btn-lg btn-info"
        OnClick="Button_Click_Attendace_Count" Style="float: right" />
</asp:Content>
