<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmStudentInfo.aspx.cs" Inherits="SchoolManagementProject.Forms.frmStudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    <%--Client Edit--%>

    <script type="text/javascript" src="../Scripts/textBoxReadOnly.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                var dp = $('#<%=DateTextbox.ClientID%>');
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
    <div class="form-group">
        <h2>
            Edit Student Info:
        </h2>
        <br />
    </div>
    
    <div id="studentDiv" class="col-lg-12 well" style="font-size: small" runat="server">

    <div class="col-sm-12 form-group" id="divButtons" runat="server">
        <asp:Button ID="btnstudentId" runat="server" Text="Student 1" 
            style="float:left; margin:10px" onclick="btnstudentId_Click" />
        <asp:Button ID="btnstudentId2" runat="server" Text="Student 2" 
            style="float:left; margin:10px" onclick="btnstudentId2_Click" />
        <asp:Button ID="btnstudentId3" runat="server" Text="Student 3" 
            style="float:left; margin:10px" onclick="btnstudentId3_Click" />
        <asp:Button ID="btnstudentId4" runat="server" Text="Student 4" 
            style="float:left; margin:10px" onclick="btnstudentId4_Click" />
        <asp:Button ID="btnstudentId5" runat="server" Text="Student 5" 
            style="float:left; margin:10px" onclick="btnstudentId5_Click" />
    </div>

    <div class="controls" id="divEdit" runat="server">
                    <a class="edit" href="#">Edit</a>
                </div>

        <div class="row">
            <div class="col-sm-6 form-group">
                <label>
                    Student Name</label>
                <asp:TextBox ID="txtStdName" runat="server" CssClass="myclass form-control" placeholder="Enter Name Here.."></asp:TextBox>
               
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Student ID</label>
              
                <asp:TextBox ID="txtStdId" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Enter ID Here.."></asp:TextBox>
                
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Student Address</label>
                
                <asp:TextBox ID="txtStdAdd" runat="server" CssClass="myclass form-control" placeholder="Enter Address Here.."></asp:TextBox>
                
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Birth Date</label>
                
              <%--  <asp:TextBox ID="DateTextbox" CssClass="myclass form-control" runat="server" placeholder="Enter Birth Date Here..">
                </asp:TextBox>--%>
                <asp:TextBox ID="DateTextbox" class="form-control" ClientIDMode="Static" runat="server" ReadOnly="true"
                            CssClass="myclass form-control" >
                        </asp:TextBox>
               
            </div>
        
        <div class="col-sm-12 form-group">
            <label>
                Student E-mail</label>
           
            <asp:TextBox runat="server"  placeholder="Enter E-mail Here.." Rows="3" CssClass="myclass form-control"
                ID="txtStdEmail"></asp:TextBox>
            
        </div>
       
            <div class="col-sm-6 form-group">
                <label>
                    Student's Father Name
                </label>
               
                <asp:TextBox runat="server" type="text" placeholder="Enter Father Name Here.."
                    CssClass="myclass form-control" ID="txtStdFatherName"></asp:TextBox>
              
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Student's Mother Name</label>
              
                <asp:TextBox runat="server" type="text" placeholder="Enter Mother Name Here ..."
                    CssClass="myclass form-control" ID="txtMotherName"></asp:TextBox>

            </div>
        </div>

        
        <asp:Button ID="btnStudentUpdate" runat="server" Text="Update" class="btn btn-lg btn-info"
            OnClick="btnStudentUpdate_Click"  />
    </div>

 
</asp:Content>
