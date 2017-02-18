<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmHome.aspx.cs" Inherits="SchoolManagementProject.Forms.frmHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../Scripts/jquery-2.1.4.js"></script>
 
    
    <script type="text/javascript">
        $(document).keypress(function (event) {
            if (event.keyCode == 13) {
                $("#<%= btnStudentLogin.ClientID%>").click();
            }
        });
    </script>
    <%--// Enter Press == Button Click--%>
    <style type="text/css">
        .carousel-inner > .item > img, .carousel-inner > .item > a > img
        {
            width: 70%;
            margin: auto;
        }
    </style>
    <%--Slider image--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="LoginDiv" runat="server">
        <div class="col-sm-12" style="font-size: small">
            <%-- <form data-toggle="validator" role="form">--%>
            <div class="row">
                <div class="col-sm-6 form-group">
                    <label>
                        User Name</label>
                    <asp:TextBox runat="server" type="text" placeholder="Enter User Name Here.." class="form-control"
                        ID="txtUserNameStudent" name="UserName" required></asp:TextBox>
                    <label id="lblUserMessagae" runat="server" style="color: Red">
                    </label>
                </div>
                <div class="col-sm-6 form-group">
                    <label>
                        Password</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" onkeypress="return EnterEvent(event)"
                        type="password" placeholder="Enter Password Here.." class="form-control" ID="txtPasswordStudent"
                        name="Password" required></asp:TextBox>
                    <label id="lblPassMessagae" runat="server" style="color: Red">
                    </label>
                </div>
                <div class="col-sm-2 form-group" style="float: right">
                    <asp:Button ID="btnStudentLogin" runat="server" Text="Login" class="btn btn-info form-control col-sm-2"
                        OnClick="Button1_Click" />
                </div>
                <%--   </form>--%>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="../Images/s1.jpg" alt="Chania" width="200" height="150"/>
                </div>
                <div class="item">
                    <img src="../Images/s2.jpg" alt="Chania" width="200" height="150"/>
                </div>
                <div class="item">
                    <img src="../Images/s3.jpg" alt="Flower" width="200" height="150"/>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                    Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                        data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                        </span><span class="sr-only">Next</span> </a>
        </div>
    </div>
</asp:Content>
