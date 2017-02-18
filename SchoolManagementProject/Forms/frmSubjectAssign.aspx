<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmSubjectAssign.aspx.cs" Inherits="SchoolManagementProject.Forms.frmSubjectAssign" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).keypress(function (event) {
            if (event.keyCode == 13) {
                $("#<%= drpTeacher.ClientID%>").click();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="form-group">

<h2> Subject Selection: </h2>

<br />
</div>

    <div class="col-sm-4 form-group">
    <label style="font-size:small">Class</label>
        <asp:DropDownList ID="drpClass" class="form-control" runat="server" placeholder="Select Type Here.."
            AutoPostBack="false" required>
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>Teacher</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-sm-4 form-group">
    <label style="font-size:small">Subject</label>
        <asp:DropDownList ID="drpSubject" class="form-control" runat="server" placeholder="Select Type Here.."
             AutoPostBack="false" required>
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>Teacher</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-sm-4 form-group">
    <label style="font-size:small">Teacher</label>
        <asp:DropDownList ID="drpTeacher" class="form-control" runat="server" placeholder="Select Type Here.."
           AutoPostBack="false"  ClientIDMode="Static" onkeypress="return EnterEvent(event)" required>
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>Teacher</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="col-sm-12 form-group">
    <br />
        
        <asp:Button ID="btnSubjectAssign" runat="server" Text="Assign" class="btn btn-md btn-info"
           style="float:right" OnClick="Button_Click_Subject_Select" />
    </div>
    <br />
    <br />

    <div class="col-sm-2">
    <h5>Subject List</h5>
    <asp:GridView ID="grdSubject" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
        <Columns>
                <asp:BoundField DataField="subjectCode" HeaderText="Subject Code" ReadOnly="True"
                    SortExpression="StudentID" />
                <asp:TemplateField HeaderText="Subject Name">
                    <ItemTemplate>
                        <%# Eval("subjectName")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStdName" Text='<%# Eval("subjectName")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblSubjectId" runat="server" Text='<%# Eval("SubjectId")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
        
        </asp:GridView>
    
    </div>

    <div class="col-sm-2">
    <h5>Teacher List</h5>
    <asp:GridView ID="grdTeacher" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
        <Columns>
                <asp:BoundField DataField="tchProfileId" HeaderText="Teacher Id" ReadOnly="True"
                    SortExpression="StudentID" />
                <asp:TemplateField HeaderText="Teacher Name">
                    <ItemTemplate>
                        <%# Eval("tchName")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtTchName" Text='<%# Eval("tchName")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblTeacherId" runat="server" Text='<%# Eval("TeacherId")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
        
        </asp:GridView>
    
    </div>

    <div class="col-sm-8">
    <form>
     <h5>Edit Subject Assignment</h5>
    
    <asp:GridView ID="grdAssign" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
  
        onrowcancelingedit="grdResult_RowCancelingEdit" 
        onrowediting="grdResult_RowEditing" onrowupdating="grdResult_RowUpdating" onrowdeleting="grdAssign_RowDeleting"
            onrowdatabound="grdAssign_RowDataBound" 
             >
      
        <Columns>
            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" />

            <asp:TemplateField HeaderText="Class Name">
                <ItemTemplate>
                    <asp:TextBox  runat="server" ReadOnly="true" style="border:none" Text='<%# Eval("className")%>' />
                </ItemTemplate>
                <EditItemTemplate>

             <asp:DropDownList ID="drpClassName" runat="server" >
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subject Code">
                <ItemTemplate>
                    <asp:TextBox runat="server"  ReadOnly="true" Style="border: none" Text='<%# Eval("subjectCode")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drpSubjectCode" runat="server" >
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Teacher ID">
                <ItemTemplate>
                    <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("tchProfileId")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drpTeacher1" runat="server" >
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblAssignId" runat="server" Text='<%# Eval("AssignId")%>' />
                </ItemTemplate>
            </asp:TemplateField>




        </Columns>
    </asp:GridView>
    </form>
        <asp:Button ID="btnSubAssignExport" runat="server" Text="Export Assignments" 
            onclick="btnSubAssignExport_Click" />

    
    </div>

</asp:Content>
