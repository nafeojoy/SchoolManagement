<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmGuardianInfo.aspx.cs" Inherits="SchoolManagementProject.Forms.frmGuardianInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--Client Edit--%>

    <script type="text/javascript" src="../Scripts/textBoxReadOnly.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="form-group">
        <h2>
            Guardian Info:
        </h2>
        <br />
    </div>
    
    <div id="studentDiv" class="col-lg-12 well" style="font-size: small" runat="server">

      <div class="controls">
                    <a class="edit" href="#">Edit</a>
                </div>

        <div class="row">
            <div class="col-sm-6 form-group">
                <label>
                    Guardian Name</label>
                   <asp:TextBox ID="txtGuardianName" runat="server" CssClass="myclass form-control" placeholder="Enter Name Here.."></asp:TextBox>
              
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Corresponding Student's ID</label>
                  <asp:TextBox ID="txtGuardStdId" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Enter Address Here.."></asp:TextBox>
                
            </div>
            
            <div class="col-sm-6 form-group">
                <label>
                    Guardian E-mail</label>
                   <asp:TextBox runat="server" placeholder="Enter E-mail Here.." Rows="3" CssClass="myclass form-control"
                    ID="txtGuardianEmail"></asp:TextBox>
                
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Guardian Phone
                </label>
                 <asp:TextBox runat="server" type="text" placeholder="Enter Student's Email Address Here.."
                    CssClass="myclass form-control" ID="txtGuardianPhone"></asp:TextBox>
               
            </div>
        </div>
        <asp:Button ID="btnGuardianUpdate" runat="server" Text="Update" class="btn btn-lg btn-info"
            OnClick="btnGuardianUpdate_Click" />
    </div>

</asp:Content>
