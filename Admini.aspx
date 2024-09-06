<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admini.aspx.cs" Inherits="web_1.Web.Admini" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
         .panel-common{
             border-radius: 10px;
             box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
             padding:10px;
         }
        
     </style>



    <main aria-labelledby="title">
         <h1>管理員資料</h1>

  <asp:Panel ID="Panel2" runat="server" BackColor="powderblue" CssClass="panel-common"> <!--BackColor="#FFFFCC"-->
      管理員資料<br /> 管理員編號:&nbsp; &nbsp;
      <asp:Label ID="cId_Text" runat="server"></asp:Label>
      <br />
      管理員姓名:<asp:TextBox ID="cName_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;身分證字號:<asp:TextBox ID="cIdCard_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;性別:&nbsp;&nbsp;<asp:DropDownList ID="cGender_list" runat="server" ReadOnly="True" Enabled="False">
          <asp:ListItem>male</asp:ListItem>
          <asp:ListItem>female</asp:ListItem>
      </asp:DropDownList>
      &nbsp;生日:<asp:TextBox ID="cBirth_Text" runat="server" Width="160px" TextMode="Date" ReadOnly="True"></asp:TextBox>
      <br />
      電話:<asp:TextBox ID="cPhone_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;通訊地址:
      <asp:TextBox ID="cAddress_Text" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
      &nbsp;<br />
      <br />
  </asp:Panel>
        <Br />
  <asp:Panel ID="Panel3" runat="server" BackColor="powderblue" CssClass="panel-common"><!--BackColor="#99FFCC"-->
      負責的長者<br /> 
      <asp:GridView ID="GridView2" runat="server">
      </asp:GridView>
      <br /> 
     
      <asp:Button ID="edit" runat="server" OnClick="edit_Click1" Text="編輯" />
     
      <asp:Button ID="save" runat="server" Text="儲存" OnClick="save_Click" Visible="False" />
      <asp:Button ID="changePW" runat="server" OnClick="changePW_Click" Text="更改密碼" />
  </asp:Panel>
    </main>
</asp:Content>
