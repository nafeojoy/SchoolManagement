<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmRegistration.aspx.cs" Inherits="SchoolManagementProject.Forms.frmRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    <script type="text/javascript">
        function CheckAll(oCheckbox) {
            var grdApprovalGuardian = document.getElementById("<%=grdApprovalGuardian.ClientID %>");
            for (i = 1; i < grdApprovalGuardian.rows.length; i++) {
                grdApprovalGuardian.rows[i].cells[3].getElementsByTagName("INPUT")[3].checked = oCheckbox.checked;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="well">
            Registration Form</h1>
        <div class="row">
            <div class="col-sm-12" style="font-size: small">
                <div class="col-sm-12" style="font-size: small">
                    <div class="row">
                        <div id="divUser" runat="server">
                            <div class="col-sm-6 form-group">
                                <label>
                                    User Name</label>
                                <asp:TextBox runat="server" type="text" placeholder="Enter User Name Here.." class="form-control"
                                    ID="txtUserNameStudent" required></asp:TextBox>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>
                                    Password</label>
                                <asp:TextBox runat="server" type="text" placeholder="Enter Password Here.." class="form-control"
                                    ID="txtPasswordStudent" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:DropDownList ID="drpType" class="form-control" runat="server" placeholder="Select Type Here.."
                                OnSelectedIndexChanged="drpType_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Teacher</asp:ListItem>
                                <asp:ListItem>Student</asp:ListItem>
                                <asp:ListItem>Guardian</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<form>--%>
        <div>
            <%-- Teacher Div --%>
            <div id="teacherDiv" class="col-lg-12 well" style="font-size: small" runat="server">
                <div class="row">
                    <div class="col-sm-4 form-group">
                        <label>
                            Teacher ID</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Teacher Id Here ..." class="form-control"
                            ID="txtTeacherId" required></asp:TextBox>
                    </div>
                    <div class="col-sm-4 form-group">
                        <label>
                            Teacher's Name</label>
                        <asp:TextBox ID="txtTeacherName" runat="server" placeholder="Enter Teacher's Name Here.."
                            class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 form-group">
                        <label>
                            Class Teacher
                        </label>
                        <asp:DropDownList ID="drpClassTeacher" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Designation</label>
                        <asp:TextBox ID="txtTeacherDesignation" runat="server" placeholder="Enter Designation Here.."
                            class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 form-group">
                        <label>
                            Contact No</label>
                        <asp:TextBox ID="txtTeacherContactNo" runat="server" placeholder="Enter Contact Number Here.."
                            class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Email Address</label>
                        <asp:TextBox ID="txtTeacherEmail" runat="server" placeholder="Enter Email Address Here.."
                            class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            SSC</label>
                        <asp:TextBox ID="txtSSC" runat="server" CssClass="myclass form-control" placeholder="Enter SSC Result Here.."></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            HSC</label>
                        <asp:TextBox ID="txtHSC" runat="server" CssClass="myclass form-control" placeholder="Enter HSC Result Here.."></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Honors</label>
                        <asp:TextBox ID="txtHonors" runat="server" CssClass="myclass form-control" placeholder="Enter Honors Result Here.."></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Masters</label>
                        <asp:TextBox ID="txtMasters" runat="server" CssClass="myclass form-control" placeholder="Enter Masters Result Here.."></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Others</label>
                        <asp:TextBox ID="txtOtherDegree" runat="server" CssClass="myclass form-control" placeholder="Enter Other Degree Name/Names Here.."></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnTeacherRegister" runat="server" Text="Register" class="btn btn-lg btn-info"
                    OnClick="Button_Click_Teacher_Register" />
            </div>
            <%-- Student Div --%>
            <div id="studentDiv" class="col-lg-12 well" style="font-size: small" runat="server">
                <div class="row">
                    <div class="col-sm-4 form-group">
                        <label>
                            Student ID</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Student Roll Here ..."
                            class="form-control" ID="txtStudentId"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 form-group">
                        <label>
                            Student's Name</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Student's Name Here.."
                            class="form-control" ID="txtStudentName">
                        </asp:TextBox>
                    </div>
                    <div class="col-sm-4 form-group">
                        <label>
                            Class</label>
                        <asp:DropDownList ID="drpStdClass" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <%--<div class="col-sm-6 form-group">
                        <label>
                            Birth Date</label>
                        <br />
                        <asp:TextBox ID="txtERDate" runat="server" class="form-control" CssClass="DatePicker1"
                            Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px;
                            line-height: 1.42857143; color: #555; background-color: #fff; background-image: none;
                            border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075); -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
                            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;">
                        </asp:TextBox>
                    </div>--%>
                </div>
                <div class="form-group">
                    <label>
                        Address</label>
                    <asp:TextBox runat="server" placeholder="Enter Address Here.." Rows="3" class="form-control"
                        ID="txtAddress"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-sm-6 form-group">
                        <label>
                            Student's Email Address</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Student's Email Address Here.."
                            class="form-control" ID="txtStudentEmail"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Birth Date</label>
                        <asp:TextBox ID="DateTextbox" class="form-control" ClientIDMode="Static" runat="server"
                            CssClass="m-wrap span12 date form_datetime" Style="display: block; width: 100%;
                            height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555;
                            background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px;
                            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
                            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;">
                        </asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 form-group">
                        <label>
                            Father's Name</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Father's Name Here.."
                            class="form-control" ID="txtFatherName"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>
                            Mother's Name</label>
                        <asp:TextBox runat="server" type="text" placeholder="Enter Mother's Name Here.."
                            class="form-control" ID="txtMotherName"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnStudentRegister" runat="server" Text="Register" class="btn btn-lg btn-info"
                    OnClick="Button_Click_Student_Register" />
            </div>
            <%--Guardian Div--%>
            <div class="col-lg-12 well" id="guardianDiv" runat="server">
                <div class="row">
                    <div class="col-sm-12" style="font-size: small">
                        <div class="col-sm-12" style="font-size: small">
                            <asp:GridView ID="grdApprovalGuardian" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:TemplateField HeaderText="Guardian Name">
                                        <ItemTemplate>
                                            <%# Eval("guardName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Guardian Contact">
                                        <ItemTemplate>
                                            <%# Eval("guardPhone")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Guardian Email">
                                        <ItemTemplate>
                                            <%# Eval("guardEmail")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                      
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSelect" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLoginId" runat="server" Text='<%# Eval("LoginId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Button ID="btnGuardianRegistration" runat="server" Text="Approve" class="btn btn-lg btn-info"
                            OnClick="Button_Click_Guardian_Register" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
