<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmAllTeacherInfo.aspx.cs" Inherits="SchoolManagementProject.Forms.frmAllTeacherInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Client Edit--%>
    <script type="text/javascript" src="../Scripts/textBoxReadOnly.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group col-sm-4">
        <h2>
            Select Teacher:
        </h2>
        <asp:DropDownList ID="drpSelectTeacher" runat="server" class="form-control" 
            onselectedindexchanged="drpSelectTeacher_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <br />
    </div>
    <div id="teacherDiv" class="col-lg-12 well" style="font-size: small" runat="server">
       
        <div class="row">
            <div class="col-sm-6 form-group">
                <label>
                    Teacher Name</label>
                <asp:TextBox ID="txtTeacherName" runat="server" CssClass="myclass form-control" placeholder="Enter Your Name Here.."></asp:TextBox>
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Teacher ID</label>
                <asp:TextBox ID="txtTeacherId" runat="server" ReadOnly="true" CssClass="form-control"
                    placeholder="Enter Your ID Here.."></asp:TextBox>
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    Teacher Designation</label>
                <asp:TextBox ID="txtTeacherDes" runat="server" ReadOnly="true" CssClass="form-control"
                    placeholder="Enter Address Here.."></asp:TextBox>
            </div>
          
               <div class="col-sm-6 form-group">
                <label>
                    Teacher Phone
                </label>
                <asp:TextBox runat="server" type="text" placeholder="Enter Your Phone No. Here.."
                    CssClass="myclass form-control" ID="txtTeacherPhone"></asp:TextBox>
            </div>
              <div class="col-sm-6 form-group">
                <label>
                    Teacher E-mail</label>
                <asp:TextBox runat="server" placeholder="Enter Your E-mail Here.." Rows="3" CssClass="myclass form-control"
                    ID="txtTeacherEmail"></asp:TextBox>
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    SSC</label>
                <asp:TextBox ID="txtSSC" runat="server" CssClass="myclass form-control" placeholder="Enter Your Name Here.."></asp:TextBox>
            </div>
            <div class="col-sm-6 form-group">
                <label>
                    HSC</label>
                <asp:TextBox ID="txtHSC" runat="server" CssClass="myclass form-control" placeholder="Enter Your ID Here.."></asp:TextBox>
            </div>
         
       
        <div class="col-sm-6 form-group">
            <label>
                Honors</label>
            <asp:TextBox ID="txtHonors" runat="server" CssClass="myclass form-control" placeholder="Enter Your Name Here.."></asp:TextBox>
        </div>
        <div class="col-sm-6 form-group">
            <label>
                Masters</label>
            <asp:TextBox ID="txtMasters" runat="server" CssClass="myclass form-control" placeholder="Enter Your ID Here.."></asp:TextBox>
        </div>
        <div class="col-sm-6 form-group">
            <label>
                Others</label>
            <asp:TextBox ID="txtOtherDegree" runat="server" CssClass="myclass form-control" placeholder="Enter Your ID Here.."></asp:TextBox>
        </div>
    </div>

   </div>
</asp:Content>
