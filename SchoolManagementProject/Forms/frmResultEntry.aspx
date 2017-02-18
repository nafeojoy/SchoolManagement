<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true"
    CodeBehind="frmResultEntry.aspx.cs" Inherits="SchoolManagementProject.Forms.frmResultEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script type="text/javascript" src="../Scripts/InlineEdit1.js"></script>
    <script type="text/javascript">
        var replaceWith = $('<input name="temp" type="text" />'),
    connectWith = $('input[name="hiddenField"]');

        $('#xyz').inlineEdit(replaceWith, connectWith);
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <h1 class="well">   
            Result Entry</h1>
        <div class="row">
            <h3>
                Select Option:</h3>
            <div class="btn-group">
                <asp:Button ID="btnAddMarks" runat="server" class="btn btn-default" Text="Add Marks"
                    OnClick="btnAddMarks_Click" />
                <asp:Button ID="btnUpdagteMarks" runat="server" class="btn btn-default" Text="Update Marks"
                    OnClick="btnUpdagteMarks_Click" />
            </div>
        </div>
    </div>
    <div id="divEditMarks" runat="server">
        <h2>
            Edit Marks
        </h2>
        <div class="col-sm-12">
            <div id="clsNameDrp1" class="col-sm-4" runat="Server" style="margin: 10px; padding: 10px">
                <h5>
                    Class Name:</h5>
                <asp:DropDownList ID="drpClassName1" runat="server" 
                    class="form-control" 
                    onselectedindexchanged="drpClassName1_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
            <div class="col-sm-4" id="subNameDrp1" runat="server" style="margin: 10px; padding: 10px">
                <h5>
                    Subject Name:</h5>
                <asp:DropDownList ID="drpSubName1" runat="server" class="form-control" 
                    onselectedindexchanged="drpSubName1_SelectedIndexChanged" AutoPostBack="true" required>
                </asp:DropDownList>
            </div>
        </div>
        <asp:GridView ID="grdResult" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
            AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
            OnRowCancelingEdit="grdResult_RowCancelingEdit" OnRowEditing="grdResult_RowEditing"
            OnRowUpdating="grdResult_RowUpdating">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" />
                <asp:BoundField DataField="stdId" HeaderText="Student ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Student Name">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("stdName")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Class Name">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("className")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject Code">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("subjectCode")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject Name">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("subjectName")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quiz">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("Quiz")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtQuiz" Text='<%# Eval("Quiz")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Final">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("Final")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtFinal" Text='<%# Eval("Final")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("Total")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtTotal" Text='<%# Eval("Total")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblResultId" runat="server" Text='<%# Eval("ResultId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <div id="divAddMarks" runat="Server">
        <h2>
            Add Marks
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
                    >
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <asp:GridView ID="grdResultAdd" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
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
                            <asp:TextBox ID="txtQuiz" runat="server" Style="" text="0" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Final">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFinal" runat="server" Style="" text="0"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("StudentId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnAddResult" runat="server" Text="Add Student Result" class="form-control btn-info"
            OnClick="btnAddResult_Click" />
    </div>
    <asp:HiddenField ID="hdcomid" runat="server" />
</asp:Content>
