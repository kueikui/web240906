<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NotificationInfo.aspx.cs" Inherits="web_1.NotificationInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #Panel1{
            padding:10px;
        }
        .panel-common{
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding:10px;
            min-height:300px;
        }
         /* 設置表格行的懸停效果 */
        .gridview tr:hover {
            background-color: #ccffff; /* 懸停時的背景顏色 */
            color: white; /* 懸停時的文字顏色 */
        }
    </style>
    <main aria-labelledby="title">
        <h2 id="title">通報系統 </h2>
        <asp:Panel ID="Panel1" runat="server" BackColor="#FF9999" CssClass="panel-common">
            通報單
         
            <br />
            長&nbsp; 者&nbsp; ID:<asp:TextBox ID="Noti_eId" runat="server"></asp:TextBox>
            <br />
            長者姓名:<asp:TextBox ID="Noti_eName" runat="server"></asp:TextBox>
            <br />
            跌倒地點:<asp:Label ID="Noti_pId" runat="server" Text="P01"></asp:Label>
            <br />
            跌倒時間:<asp:Label ID="Noti_fTime" runat="server" Text="Label"></asp:Label>
            <br />
            跌倒原因:<asp:TextBox ID="Noti_fwhy" runat="server"></asp:TextBox>
            <br />
            是否送醫:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                醫院名稱:<asp:TextBox ID="Noti_hId" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" ControlToValidate="Noti_eId" ErrorMessage="請輸入長者ID" ForeColor="#FF3300" ValidationGroup="noti" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BackColor="White" ControlToValidate="Noti_eName" ErrorMessage="請輸入長者姓名" ForeColor="Red" ValidationGroup="noti" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="White" ControlToValidate="Noti_fwhy" Display="Dynamic" ErrorMessage="請輸入跌倒原因" ForeColor="Red" ValidationGroup="noti"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" ValidationGroup="noti" Text="送出" />
            <br />
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server" BackColor="PowderBlue" CssClass="panel-common">
            歷史資料
            <asp:GridView ID="GridView1"  CssClass="gridview" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </asp:Panel>
    </main>
</asp:Content>
