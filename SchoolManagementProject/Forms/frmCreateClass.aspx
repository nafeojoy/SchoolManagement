<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmCreateClass.aspx.cs" Inherits="SchoolManagementProject.Forms.frmCreatClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).keypress(function (event) {
            if (event.keyCode == 13) {
                $("#<%= Button1.ClientID%>").click();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <h2>
            Class Creation:
        </h2>
        <br />
    </div>
    <div class="col-sm-4 form-group">
        <label style="font-size: small">
            Class Name</label>
        <asp:TextBox ID="txtClassName" runat="server" placeholder="Enter Class Name Here.."
           ClientIDMode="Static" onkeypress="return EnterEvent(event)" class="form-control" ></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-md btn-info" Style="float: right"
            OnClick="Button_Click_Add_Class" />
    </div>

    <div>
    
    <div>
        <asp:GridView ID="grdClass" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False" onrowdeleting="grdClass_RowDeleting">
            <Columns>
             <asp:CommandField ButtonType="Button" ShowEditButton="false" ShowCancelButton="false" ShowDeleteButton="true" />

             
                <asp:TemplateField HeaderText="Class Name">
                    <ItemTemplate>
                        <%# Eval("className")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtClassName" Text='<%# Eval("className")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                
                
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblClassId" runat="server" Text='<%# Eval("Classid")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    
    </div>

</asp:Content>
