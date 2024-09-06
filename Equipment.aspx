<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Equipment.aspx.cs" Inherits="web_1.Equipment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .gridview tr:hover {
            background-color: #ccffff; /* 懸停時的背景顏色 */
            color: white; /* 懸停時的文字顏色 */
        }
        .panel-common {
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 10px;
            min-height:300px;
        }
    </style>
    <main aria-labelledby="title">
            <h1>設備</h1>
        <asp:Panel ID="Panel1" CssClass="panel-common" runat="server" BackColor="PowderBlue">
            <asp:GridView ID="GridView1" CssClass="gridview" runat="server"  OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="查看畫面"  CommandName="View"/>
                </Columns>
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
