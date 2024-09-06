using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using System.Net;


namespace web_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //private List<string> activeAlerts;
        //private string alertMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // 初始化活躍警報列表
            /*if (Session["ActiveAlerts"] != null)
            {
                activeAlerts = (List<string>)Session["ActiveAlerts"];
            }
            else
            {
                activeAlerts = new List<string>();
            }
            Panel1.Visible = activeAlerts.Count > 0;
            if (Panel1.Visible)
            {
                PlaceText.Text = string.Join(", ", activeAlerts);
            }*/

            if (Session["ShowPanel"] != null && (bool)Session["ShowPanel"] == true)
            {
                Panel1.Visible = true;
            }
            if (!IsPostBack)
            {
                string cameraID = Request.QueryString["CameraID"];
                if (!string.IsNullOrEmpty(cameraID))
                {
                    ShowCameraView(cameraID);
                }
            }
        }
        private void ShowCameraView(string cameraID)
        {
            switch (cameraID)
            {
                case "1": // 假設cameraID為1對應Button1的影片
                    videoPlayer.Attributes["src"] = "test.mp4";
                    break;
                case "2": // 假設cameraID為2對應Button2的影片
                    videoPlayer.Attributes["src"] = "test3.mp4";
                    break;
                case "3": // 假設cameraID為3對應Button7的影片
                    videoPlayer.Attributes["src"] = "test3.mp4";
                    break;
                // 可以根據需要添加更多的cameraID對應的情況
                default:
                    //SetVideoSource("default.mp4"); // 如果沒有對應，顯示預設影片
                    break;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test.mp4";
            Label1.Text = "走廊";

            //if (!activeAlerts.Contains(alertMessage))
            //{
                //activeAlerts.Add(alertMessage);
            //}

            //UpdateAlertPanel();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test3.mp4";
            Label1.Text = "房間 ";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test2.mp4";
            Label1.Text = "廚房";
            //if (!activeAlerts.Contains(alertMessage))
            //{
                //activeAlerts.Add(alertMessage);
            //}

            //UpdateAlertPanel();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test.mp4";
            Label1.Text = "客廳";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test3.mp4";
            Label1.Text = "玄關";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test2.mp4";
            Label1.Text = "飯廳";
        }

        protected async void Button11_Click(object sender, EventArgs e)//一樓走廊
        {
            Panel1.Visible = true;
            Session["ShowPanel"] = true;
            Button1.CssClass += " btn-twinke";
            PlaceText.Text = "走廊";
            
            //if (!activeAlerts.Contains(alertMessage))
            //{
                //activeAlerts.Add(alertMessage);
            //}

            //UpdateAlertPanel();
            if (Session["LoginType"] == "Home")
            {     
                string message = "警報：走廊發生跌倒事件，請立即處理。";
                FileStream file = File.OpenRead(@"C:\Users\user\Desktop\web240703\web-1\Images\t.png");
                await SendLineNotify(message,file);
            }
        }
        protected async void Button13_Click(object sender, EventArgs e)//廚房
        {
            Panel1.Visible = true;
            Session["ShowPanel"] = true;
            Button7.CssClass += " btn-twinke";
            PlaceText.Text = "廚房";
                
            //if (!activeAlerts.Contains(alertMessage))
            //{
                //activeAlerts.Add(alertMessage);
            //}

            //UpdateAlertPanel();
            if (Session["LoginType"] == "Home")
            {
                string message = "警報：廚房發生跌倒事件，請立即處理。";
                FileStream file = File.OpenRead(@"C:\Users\user\Desktop\web240703\web-1\Images\t.png");
                await SendLineNotify(message,file);
            }
        }
        private async Task SendLineNotify(string message,FileStream file)
        {
            string token = "6Oxe8CZCWSWkMWsnrXgmNP2Mxed5WbyN9amXlzniM5m"; // 您的 LINE Notify 權杖
            string url = "https://notify-api.line.me/api/notify";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var content = new StringContent($"message={message}", Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (file != Stream.Null)
                {
                    var imgFile = new StringContent($"message={file}", Encoding.UTF8, "application/x-www-form-urlencoded");
                    HttpResponseMessage response2 = await client.PostAsync(url, imgFile);
                    
                    //body.Add(imgFile, "imageFile", "*");
                }
            }
        }
        
        protected void Button12_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Session["ShowPanel"] = false;
            Button1.CssClass = Button1.CssClass.Replace("btn-twinke", "").Trim();
            Button7.CssClass = Button7.CssClass.Replace("btn-twinke", "").Trim();

        }
        /*private void UpdateAlertPanel()
        {
            Panel1.Visible = true;
            Session["ShowPanel"] = true;
            Session["ActiveAlerts"] = activeAlerts;
            PlaceText.Text = string.Join(", ", activeAlerts);
        }*/
    }
} 