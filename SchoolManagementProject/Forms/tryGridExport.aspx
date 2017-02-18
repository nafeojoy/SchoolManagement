<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="tryGridExport.aspx.cs" Inherits="SchoolManagementProject.Forms.tryGridExport"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:GridView ID="grdAssign" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
             >
      
        <Columns>
          

            <asp:TemplateField HeaderText="Class Name">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1"  runat="server" ReadOnly="true" style="border:none" Text='<%# Eval("className")%>' />
                </ItemTemplate>
                <EditItemTemplate>

             <asp:DropDownList ID="drpClassName" runat="server" >
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subject Code">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"  ReadOnly="true" Style="border: none" Text='<%# Eval("subjectCode")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drpSubjectCode" runat="server" >
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Teacher ID">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("tchProfileId")%>' />
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
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click1" />
</asp:Content>
