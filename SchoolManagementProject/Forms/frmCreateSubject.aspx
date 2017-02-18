<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmCreateSubject.aspx.cs" Inherits="SchoolManagementProject.Forms.frmCreateSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).keypress(function (event) {
            if (event.keyCode == 13) {
                $("#<%= btnAddSubject.ClientID%>").click();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <h2>
            Subject Creation:
        </h2>
        <br />
    </div>
    <div class="row">
        <div class="col-sm-6 form-group">
            <label style="font-size: small">
                Subject Code</label>
            <asp:TextBox ID="txtSubjectCode" runat="server" placeholder="Enter Subject ID Here.."
                class="form-control" ></asp:TextBox>
        </div>
        <div class="col-sm-6 form-group">
            <label style="font-size: small">
                Subject Name</label>
            <asp:TextBox ID="txtSubjectName" runat="server" placeholder="Enter Subject Name Here.."
                class="form-control" ClientIDMode="Static" onkeypress="return EnterEvent(event)" ></asp:TextBox>
        </div>
        <asp:Button ID="btnAddSubject" runat="server" Text="Add" class="btn btn-lg btn-info"
            Style="float: right" OnClick="Button_Click_Add_Subject" />
    </div>
    <br />
    <div>
        <asp:GridView ID="grdSubject" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False" 
            onrowcancelingedit="grdSubject_RowCancelingEdit" 
            onrowediting="grdSubject_RowEditing" onrowupdating="grdSubject_RowUpdating">
            <Columns>
             <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="false" />


                 <asp:TemplateField HeaderText="Subject Code">
                    <ItemTemplate>
                        <%# Eval("subjectCode")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtSubCode" Text='<%# Eval("subjectCode")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>


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

        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
</asp:Content>
