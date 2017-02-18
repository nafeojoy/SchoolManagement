<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmAttendanceHistory.aspx.cs" Inherits="SchoolManagementProject.Forms.frmAttendanceHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>    


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
    <div class="container">
        <div class="row">
        <h1 class="well">   
            Attendance History/Summary</h1>
            <form class="form">
            <h3>
                Select Option:</h3>
            <div class="btn-group">
                <asp:Button ID="btnAttendanceHistory" runat="server" class="btn btn-default" Text="Daily Attendance
                    History" OnClick="btnAttendanceHistory_Click" />
                <asp:Button ID="btnAttendanceSummary" runat="server" class="btn btn-default" Text="Attendance
                    Summary" OnClick="btnAttendanceSummary_Click" />
            </div>
        </div>
    </div>
    <br />
    <div id="divAttendanceCount" runat="server">
        
        <asp:GridView ID="grdAttendaceCount" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False" 
            onrowcancelingedit="grdAttendaceCount_RowCancelingEdit" 
            onrowediting="grdAttendaceCount_RowEditing" 
            onrowupdating="grdAttendaceCount_RowUpdating">
            <Columns>
                <asp:BoundField DataField="stdId" HeaderText="Student ID" ReadOnly="True" SortExpression="StudentID" />
                <asp:BoundField DataField="stdName" HeaderText="Student Name" SortExpression="StudentName" />
               
                <asp:TemplateField HeaderText="Present">
                    <ItemTemplate>
                        <%# Eval("TotalPresent")%>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Absent">
                    <ItemTemplate>
                        <%# Eval("TotalAbsent")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%# Eval("result")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtResult" Text='<%# Eval("result")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="headchk" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("StudentId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <div id="divAttendanceCountDate" runat="server">

    <div class="col-sm-3 form-group">
            <label>Search By Date</label>
  

            <asp:TextBox ID="DateTextbox1" class="form-control" ClientIDMode="Static" 
                runat="server" AutoPostBack="true"
            CssClass="m-wrap span12 date form_datetime" 
                Style="display: block; width: 100%;
            height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555;
            background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;" 
                ontextchanged="DateTextbox1_TextChanged">
        </asp:TextBox>


        </div>
        <div class="col-sm-2 form-group">
            <label>Search By Name</label>
           
   <asp:TextBox ID="txtName" runat="server" class="form-control" 
                ontextchanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox>


   
    <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtName" 
                ServicePath="~/NameSearch.asmx" MinimumPrefixLength="1" EnableCaching="true" 
                CompletionSetCount="15" CompletionInterval="1000" ServiceMethod="GetName"   >
    </ajax:AutoCompleteExtender>

        </div>
        <div class="col-sm-3 form-group" visible="false" runat="server">
              <label>Search By Class</label>
            <asp:DropDownList ID="drpClassFilter" runat="server" class="form-control" 
                  onselectedindexchanged="drpClassFilter_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </div>

        <asp:GridView ID="grdAttendanceCountDate" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <%# Eval("Date2")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtDate" Text='<%# Eval("Date2")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="stdId" HeaderText="Student ID" ReadOnly="True" SortExpression="StudentID" />
                <asp:BoundField DataField="stdName" HeaderText="Student Name" SortExpression="StudentName" />
                <asp:BoundField DataField="className" HeaderText="Class Name" SortExpression="ClassName" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%# Eval("Stat")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtResult" Text='<%# Eval("Stat")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblACId" runat="server" Text='<%# Eval("ACId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
