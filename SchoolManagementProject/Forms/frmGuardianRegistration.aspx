<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmGuardianRegistration.aspx.cs" Inherits="SchoolManagementProject.Forms.frmGuardianRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1 class="well">
            Guardian Registration Form</h1>
        <div class="row">
            <div class="col-sm-12" style="font-size: small">
                <div class="col-sm-12" style="font-size: small">
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <label>
                                User Name</label>
                            <asp:TextBox runat="server" type="text" placeholder="Enter User Name Here.." class="form-control"
                                ID="txtUserNameStudent"></asp:TextBox>
                        </div>
                        <div class="col-sm-6 form-group">
                            <label>
                                Password</label>
                            <asp:TextBox runat="server" type="text" placeholder="Enter Password Here.." class="form-control"
                                ID="txtPasswordStudent"></asp:TextBox>
                        </div>
                    
                    </div>
                </div>
            </div>
        </div>

<div class="col-lg-12 well" id="guardianDiv" runat="server">
                <div class="row">
                    <div class="col-sm-12" style="font-size: small">
                        <div class="col-sm-12" style="font-size: small">
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>
                                        Guardian's Name</label>
                                    <asp:TextBox ID="txtGuardianName" runat="server" type="text" placeholder="Enter Guardian's Name Here.."
                                        class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>
                                        Email Address</label>
                                    <asp:TextBox ID="txtGuardianEmail" runat="server" type="text" placeholder="Enter Guardian's Email Address Here.."
                                        class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>
                                        Guardian's Contact No</label>
                                    <asp:TextBox ID="txtGuardianContactNo" runat="server" type="text" placeholder="Enter Guardian's Contact Number Here.."
                                        class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Student ID
                                </label>
                                <asp:DropDownList ID="drpStudentId" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Student ID 2</label>
                                <asp:DropDownList ID="drpStudentId2" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Student ID 3</label>
                                <asp:DropDownList ID="drpStudentId3" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Student ID 4</label>
                                <asp:DropDownList ID="drpStudentId4" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Student ID 5</label>
                                <asp:DropDownList ID="drpStudentId5" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                           
                        </div>
                        <asp:Button ID="btnGuardianRegistration" runat="server" Text="Submit" class="btn btn-lg btn-info"
                            OnClick="Button_Click_Guardian_Register" />
                    </div>
                </div>
            </div>
        

</asp:Content>
