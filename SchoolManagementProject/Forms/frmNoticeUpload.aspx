<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student.Master" AutoEventWireup="true" CodeBehind="frmNoticeUpload.aspx.cs" Inherits="SchoolManagementProject.Forms.frmNoticeUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
     $(document).ready(function () {
         var dp = $('#<%=DateTextbox1.ClientID%>');
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1 class="well">   
            Notice Board</h1>
<div id="uploadNotice" style="margin:10px; padding:10px" runat="server" class="col-sm-4 form-group">
    <asp:FileUpload ID="fileNoticeBoard" runat="server"  class="form-control" required />

    <asp:TextBox ID="txtFileName" runat="server" class="form-control" placeholder="Enter File Name" required></asp:TextBox>
    
    <div class="col-sm-4 form-group">

        <asp:TextBox ID="DateTextbox1" class="form-control" ClientIDMode="Static" runat="server" placeholder="Select Date"
            CssClass="m-wrap span12 date form_datetime" Style="display: block; width: 200%%;
            height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555;
            background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;" required>
        </asp:TextBox>

    </div>

    <br />
  
    <br />
    <asp:Button ID="btnNoticeBoardUpload" runat="server" Text="Upload" Style="float: right;
        top: 0px; left: 51px;" class="form-control btn-primary" 
        onclick="btnNoticeBoardUpload_Click" Width="120px" />

                <asp:Button ID="btnNoticeBoardCancel" runat="server" Text="Cancel" Style="float: right; top: 0px;
        left: 51px; " class="form-control btn-danger" 
        onclick="btnNoticeBoardCancel_Click" Width="120px" />
       


    <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false" style="font-size:medium; color:Red; padding:15px; margin:10px" ></asp:Label>

    <br />

</div>

<div id="viewNotice" style="margin:10px; padding:10px">

    <asp:GridView ID="grdViewNotice" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover"
        OnRowDeleting="grdViewNotice_RowDeleting" Width="538px">
        <Columns>
            <asp:TemplateField HeaderText="Notices">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("upFile")%>' Text='<%#Eval("upName")%>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("Date")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Notices" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblUploadId" runat="server" Text='<%# Eval("UploadId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
          
                    

            <asp:CommandField ButtonType="Button" ShowEditButton="false" ShowCancelButton="false"
                ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

    <asp:GridView ID="grdViewNoticeNonEditable" runat="server" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="False" OnRowDeleting="grdViewNotice_RowDeleting" 
        Width="370px">
        <Columns>
        <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:TextBox ID="txtDate1" runat="server" ReadOnly="true" Style="border: none" Text='<%# Eval("Date")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Notices">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("upFile")%>' Text='<%#Eval("upName")%>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</div>
</asp:Content>
