<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.cs" Inherits="web_1.WebForm1"Async="true"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body, html {
            margin: 0;
            padding: 0;
            overflow: hidden;
            align-content:center;
        }
        .wrapper {
             display: flex;
             width:2500px;
             height: 2500px;
             grid-template-rows: 2fr 5fr; 
             grid-template-columns: 1fr 5fr;
             position:relative;
        }
        .Button1{/*走廊*/
            position: absolute; 
            top:190px; 
            left: 380px; 
        }
        .Button2{/*房間*/
            position: absolute; 
            top:170px; 
            left: 40px; 
        }
        .Button7{/*廚房*/
            position: absolute; 
            top:80px; 
            left: 400px; 
        }
        .Button8{/*客廳*/
            position: absolute; 
            top:230px; 
            left: 200px; 
        }
        .Button9{/*玄關*/
            position: absolute; 
            top:270px; 
            left: 420px; 
        }
        .Button10{/*飯廳*/
            position: absolute; 
            top:25px; 
            left: 200px; 
        }
        .Button11{/*警報1*/
            position: absolute; 
            top:400px; 
            left: 20px; 
        }
        .Button13{/*警報2*/
            position: absolute; 
            top:400px; 
            left: 80px; 
        }
        .image-container {
            position: absolute;
            width:500px;
            height:500px;
            overflow: hidden;
        }
        .image-container img {
            width: 500px;
            height: 400px;
        }
        .video-container {
            position: relative;
            width: 50%;
            overflow: hidden;
            padding: 10px;
            margin-left: 500px;
        }      
        .alert{
            position: absolute;
            top:380px;
            left:510px;
            width:50px;
            height:30px;
            background-color:aquamarine;
        }
       .btn-twinke{
            color: #fff;
            border:none;
            animation: twinkle 1s alternate infinite;
            /*動畫的名稱 1秒 兩種狀態交替 無限重複*/
       }
       @keyframes twinkle{
           from{background: #16e2eb;}
           to{background: #3b6e99;}
       }
    </style>
    <script type="text/javascript">
        function startTwinkling() {
            var button = document.getElementById('<%= Button1.ClientID %>');
            button.classList.add('btn-twinke');
        }
    </script>
    <main aria-labelledby="title"> 
        <div class="wrapper">
            <div class="image-container">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/螢幕擷取畫面 2024-08-06 200944.png" Width="100%"/>
            </div>
            <div class="video-container"> 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <video id="videoPlayer" runat="server" width="420" height="340" controls>
                    <source id="videoSource" runat="server"  src="tes.mp4" type="video/mp4">Your browser does not support the video tag.
                </video>
            </div>
            <div class="button">
                    <table style="border:none">
                        <tr>
                            <td><asp:Button ID="Button1" runat="server" Text="走廊" Width="50px" OnClick="Button1_Click" CssClass="Button1" /></td>
                            <td><asp:Button ID="Button2" runat="server" Text="房間" Width="50px" OnClick="Button2_Click" CssClass="Button2" /></td>
                            <td><asp:Button ID="Button7" runat="server" Text="廚房" Width="50px" OnClick="Button7_Click" CssClass="Button7" /></td>
                        </tr>
                        <tr>
                            <td> <asp:Button ID="Button8" runat="server" Text="客廳" Width="50px" OnClick="Button8_Click" CssClass="Button8"/></td>
                            <td><asp:Button ID="Button9" runat="server" Text="玄關" Width="50px" OnClick="Button9_Click" CssClass="Button9"/></td>
                            <td> <asp:Button ID="Button10" runat="server" Text="飯廳" Width="50px" OnClick="Button10_Click" CssClass="Button10"/></td>
                        </tr>
                    </table>
                <br />
                <asp:Button ID="Button11" runat="server" Text="警報" OnClick="Button11_Click" CssClass="Button11" OnClientClick="startTwinkling();" />
                <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="警報2" CssClass="Button13"/>
            </div>
            <asp:Panel ID="Panel1" runat="server" class="alert" Visible="false" BackColor="#FF5050" ForeColor="White" Height="160px" Width="300px">
                在<asp:Label ID="PlaceText" runat="server" Text="" BackColor="#FF5050" BorderColor="#FF5050" BorderStyle="None" BorderWidth="30px" ForeColor="White" Width="42px"></asp:Label>發生跌倒事件<br /> 請立即派人前往救助<br /> 請至通報系統填寫資料<br /> &nbsp;<asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="事件完成" OnClientClick="return confirm('確認通報單填寫完畢，要關閉視窗嗎？');" />
                
            </asp:Panel>
        </div>
    </main>
</asp:Content>