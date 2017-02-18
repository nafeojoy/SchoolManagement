<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmAllResult.aspx.cs" Inherits="SchoolManagementProject.Forms.frmAllResult" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="divAddMarks" runat="Server">
        <h2>
            View Marks
        </h2>
        <div class="col-sm-12">
            <div id="clsNameDrp" class="col-sm-4" runat="Server" style="margin: 10px; padding: 10px">
                <h5>
                    Class Name:</h5>
                <asp:DropDownList ID="drpClassName" runat="server" OnSelectedIndexChanged="drpClassName_SelectedIndexChanged"
                    AutoPostBack="true" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-sm-4" id="subNameDrp" runat="server" style="margin: 10px; padding: 10px">
                <h5>
                    Subject Name:</h5>
                <asp:DropDownList ID="drpSubjectName" runat="server" class="form-control" 
                    onselectedindexchanged="drpSubjectName_SelectedIndexChanged"  AutoPostBack="true"> 
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <asp:GridView ID="grdResultAdd" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="false" EmptyDataText="There are no data records to display."
                Style="margin: 10px; padding: 10px">
                <Columns>
                    <asp:TemplateField HeaderText="Student ID">
                        <ItemTemplate>
                            <asp:TextBox ID="txtStdId" runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("stdId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Student Name">
                        <ItemTemplate>
                            <asp:TextBox ID="txtStdName" runat="server" ReadOnly="true" Style="border: none"
                                Text='<%# Eval("stdName")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quiz">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuiz" runat="server"  ReadOnly="true"  Style="border: none" borde Text='<%# Eval("Quiz")%>' /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Final">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFinal" runat="server" ReadOnly="true"  Style="border: none" Text='<%# Eval("Final")%>' /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true"  Style="border: none" Text='<%# Eval("Total")%>' /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("StudentId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnExport" runat="server" Text="Export Result" 
                onclick="btnExport_Click" />
        </div>
  
    </div>
</asp:Content>
