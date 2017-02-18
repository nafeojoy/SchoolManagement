<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmAllResultStudent.aspx.cs" Inherits="SchoolManagementProject.Forms.frmAllResultStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="divButtons" runat="server">
    <asp:Button ID="btnStudent" runat="server" Text="Student 1" 
        onclick="btnStudent_Click" />
    <asp:Button ID="btnStudent2" runat="server" Text="Student 2" 
        onclick="btnStudent2_Click" />
    <asp:Button ID="btnStudent3" runat="server" Text="Student 3" 
        onclick="btnStudent3_Click" />
    <asp:Button ID="btnStudent4" runat="server" Text="Student 4" 
        onclick="btnStudent4_Click" />
    <asp:Button ID="btnStudent5" runat="server" Text="Student 5" 
        onclick="btnStudent5_Click" />
</div>


<div  id="divClassName" runat="server" style="font-size:medium">

<h1 class="well">   
            Individual Class Result</h1>
Class Name: 
    <asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label><br />

</div>
<div  id="divStudentName" runat="server" style="font-size:medium">
<h1 class="well">   
            Individual Student Result</h1>
Student Name:
<asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
</div>

    <div>
        <asp:GridView ID="grdAllResult" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowEditButton="false" ShowCancelButton="false"
                    ShowDeleteButton="false" />
                
                <asp:BoundField DataField="stdId" HeaderText="Student Id" ReadOnly="True"
                    SortExpression="StudentID" />

                    <asp:TemplateField>
                    
                    <ItemTemplate>

                    <a href='../ReportUI/WebForm1.aspx?../ReportUI/WebForm1.aspx=<%# Eval("StudentId") %> '>
                               Details Report                                           
                               </a>

                     </ItemTemplate>
                    
                    </asp:TemplateField>
                  
                <asp:BoundField DataField="subjectCode" HeaderText="Subject Code" ReadOnly="True"
                    SortExpression="SubjectCode" />
                <asp:TemplateField HeaderText="Subject Name">
                    <ItemTemplate>
                        <%# Eval("subjectName")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStdName" Text='<%# Eval("subjectName")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quiz">
                    <ItemTemplate>
                        <%# Eval("Quiz")%>
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Final">
                    <ItemTemplate>
                        <%# Eval("Final")%>
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%# Eval("Total")%>
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblResultId" runat="server" Text='<%# Eval("ResultId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
