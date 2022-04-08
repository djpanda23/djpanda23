// Decompiled with JetBrains decompiler
// Type: DoubleBot.Form1
// Assembly: DoubleBot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52D8D89B-EC7B-458B-BF01-A0F1BC02C29E
// Assembly location: C:\Users\Lenovo\Downloads\bot\DoubleBot\DoubleBot.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleBot
{
  public class Form1 : Form
  {
    private Cookie attack = new Cookie("clickcoords", "0", "/", ".bgmafia.com");
    private Cookie mashine = new Cookie("machine_id", "3606758506", "/", ".bgmafia.com");
    private Cookie ses = new Cookie("sess3", "", "/", ".bgmafia.com");
    private Cookie world_id = new Cookie(nameof (world_id), "4", "/", ".bgmafia.com");
    private Cookie auth = new Cookie(nameof (auth), "mH%2Bll7iTmWOgobB5X7NanqPJpOfFypyp5X94k5lkoKGwgGmbmXyflqOm05ZZgNuXb2XSbZZomHxRtLU%3D", "/", ".bgmafia.com");
    private Cookie arp_srcoll = new Cookie("arp_scroll_position", "0", "/", ".bgmafia.com");
    private Cookie login = new Cookie(nameof (login), "1", "/", ".bgmafia.com");
    private Cookie max_level = new Cookie("fight_finder[max_level]", "95", "/", "bgmafia.com");
    private Cookie min_level = new Cookie("fight_finder[min_level]", "15", "/", "bgmafia.com");
    private Cookie max_respect = new Cookie("fight_finder[max_respect]", "34100000", "/", "bgmafia.com");
    private Cookie online = new Cookie("fight_finder[online]", "off", "/", "bgmafia.com");
    private Cookie lc = new Cookie(nameof (lc), "1649012247", "/", "bgmafia.com");
    private Cookie registered = new Cookie(nameof (registered), "1", "/", "bgmafia.com");
    private Cookie tab = new Cookie("my-application-browser-tab", "", "/", "bgmafia.com");
    private Cookie terms_accepted = new Cookie(nameof (terms_accepted), "1", "/", "bgmafia.com");
    private string itemType;
    private string refBuf;
    private string tmp;
    private string end_s;
    private HtmlDocument hdoc;
    private HtmlElementCollection script;
    private IContainer components = (IContainer) null;
    private Button button1;
    private GroupBox groupBox1;
    private Label label4;
    private Label label3;
    private Label label2;
    private TextBox textBox4;
    private Label label1;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private TextBox textBox5;
    private Label label5;
    private Button button2;
    private Button button3;

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    internal static extern bool SetProcessWorkingSetSize(
      IntPtr pProcess,
      int dwMinimumWorkingSetSize,
      int dwMaximumWorkingSetSize);

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    internal static extern IntPtr GetCurrentProcess();

    private void GatherCookies(CookieCollection ccP)
    {
      ccP.Add(this.attack);
      ccP.Add(this.max_level);
      ccP.Add(this.min_level);
      ccP.Add(this.max_respect);
      ccP.Add(this.mashine);
      ccP.Add(this.registered);
      ccP.Add(this.ses);
      ccP.Add(this.terms_accepted);
      ccP.Add(this.world_id);
      ccP.Add(this.online);
      ccP.Add(this.lc);
      ccP.Add(this.tab);
      ccP.Add(this.auth);
      ccP.Add(this.arp_srcoll);
      ccP.Add(this.login);
    }

    private void Action(string link)
    {
      this.SetReq(0, 0, 0, 0, link);
      this.GetHdoc();
      this.GetEnd();
      this.refBuf = link;
    }

    private void SetReq(int xb, int xe, int yb, int ye, string link)
    {
      ServicePointManager.Expect100Continue = true;
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
      HttpWebRequest req = (HttpWebRequest) WebRequest.Create(link);
      this.SetReqParam(req);
      HttpWebResponse response = (HttpWebResponse) req.GetResponse();
      using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
      {
        this.ses = response.Cookies["sess3"];
        this.tmp = streamReader.ReadToEnd();
      }
    }

    private void SetReqParam(HttpWebRequest req)
    {
      req.Method = "GET";
      req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
      req.Referer = "https://bgmafia.com/";
      req.Accept = " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
      req.ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
      req.CookieContainer = new CookieContainer();
      CookieCollection cookieCollection = new CookieCollection();
      req.Referer = this.refBuf;
      this.GatherCookies(cookieCollection);
      req.CookieContainer.Add(cookieCollection);
    }

    private void GetHdoc()
    {
      using (WebBrowser webBrowser = new WebBrowser())
      {
        webBrowser.ScriptErrorsSuppressed = true;
        webBrowser.DocumentText = this.tmp;
        this.hdoc = webBrowser.Document.OpenNew(true);
        this.hdoc.Write(tmp);
        webBrowser.Dispose();
        Form1.SetProcessWorkingSetSize(Form1.GetCurrentProcess(), -1, -1);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
      }
    }

    private void GetEnd()
    {
      this.script = this.hdoc.GetElementsByTagName("script");
      for (int index = 0; index < this.script.Count; ++index)
      {
        string innerHtml = this.script[index].InnerHtml;
        if (innerHtml != null)
        {
          int num = innerHtml.IndexOf("var req_id");
          this.end_s = "z=" + innerHtml.Substring(num + 14, 3);
          index = this.script.Count;
        }
      }
    }

    public Form1() => this.InitializeComponent();

    private void button2_Click(object sender, EventArgs e) => this.itemType = this.textBox5.Text;

    private void button1_Click(object sender, EventArgs e)
    {
      this.ses.Value = this.textBox1.Text;
      this.lc.Value = this.textBox2.Text;
      this.mashine.Value = this.textBox3.Text;
      this.auth.Value = this.textBox4.Text;
      this.Action("https://bgmafia.com/inventory");
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.Action("https://bgmafia.com/inventory");
      string str1 = "";
      string str2 = "NotAllowed";
      using (StreamReader streamReader = new StreamReader(WebRequest.Create("https://cloud351.free.bg/udi2.txt").GetResponse().GetResponseStream()))
        str2 = streamReader.ReadToEnd();
      HtmlElementCollection elementsByTagName = this.hdoc.GetElementsByTagName("script");
      for (int index = 0; index < elementsByTagName.Count; ++index)
      {
        HtmlElement htmlElement = elementsByTagName[index];
        if (htmlElement.OuterHtml.Contains("UID = 3"))
        {
          str1 = htmlElement.InnerHtml;
          break;
        }
      }
      if (str1.Contains(str2))
      {
        this.itemType = this.textBox5.Text;
        Form1.ClientController clientController = new Form1.ClientController();
        Form1.ClientController.InitCookies(this.ses.Value, this.lc.Value, this.mashine.Value, this.auth.Value);
        clientController.DoWorkAsync(this.itemType, this.end_s);
      }
      else
      {
        int num = (int) MessageBox.Show("Account Not Allowed");
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.groupBox1 = new GroupBox();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.textBox5 = new TextBox();
      this.label5 = new Label();
      this.button2 = new Button();
      this.button3 = new Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.button1.Location = new Point(207, 20);
      this.button1.Name = "button1";
      this.button1.Size = new Size(277, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Update Cookies";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.textBox4);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.textBox3);
      this.groupBox1.Controls.Add((Control) this.textBox2);
      this.groupBox1.Controls.Add((Control) this.textBox1);
      this.groupBox1.Location = new Point(207, 49);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(277, 156);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Cookies";
      this.textBox1.Location = new Point(156, 35);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 22);
      this.textBox1.TabIndex = 0;
      this.textBox2.Location = new Point(156, 63);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(100, 22);
      this.textBox2.TabIndex = 1;
      this.textBox2.Text = "1649012247";
      this.textBox3.Location = new Point(156, 91);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(100, 22);
      this.textBox3.TabIndex = 2;
      this.textBox3.Text = "3606758506";
      this.textBox4.Location = new Point(156, 119);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(100, 22);
      this.textBox4.TabIndex = 2;
      this.textBox4.Text = "mH%2Bll7iTmWOgobB5X7NanqPJpOfFypyp5X94k5lkoKGwgGmbmXyflqOm05ZZgNuXb2XSbZZomHxRtLU%3D";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(101, 38);
      this.label1.Name = "label1";
      this.label1.Size = new Size(49, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "sess3:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(128, 66);
      this.label2.Name = "label2";
      this.label2.Size = new Size(22, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "lc:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(66, 94);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 17);
      this.label3.TabIndex = 5;
      this.label3.Text = "machine_id:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(110, 122);
      this.label4.Name = "label4";
      this.label4.Size = new Size(40, 17);
      this.label4.TabIndex = 6;
      this.label4.Text = "auth:";
      this.textBox5.Location = new Point(101, 78);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(100, 22);
      this.textBox5.TabIndex = 2;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(23, 81);
      this.label5.Name = "label5";
      this.label5.Size = new Size(73, 17);
      this.label5.TabIndex = 3;
      this.label5.Text = "Disarm ID:";
      this.button2.Location = new Point(21, 49);
      this.button2.Name = "button2";
      this.button2.Size = new Size(180, 23);
      this.button2.TabIndex = 4;
      this.button2.Text = "Update Disarm ID";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.Location = new Point(21, 20);
      this.button3.Name = "button3";
      this.button3.Size = new Size(180, 23);
      this.button3.TabIndex = 5;
      this.button3.Text = "Double";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(506, 217);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (Form1);
      this.Text = nameof (Form1);
      this.TopMost = true;
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class ClientController
    {
      private static readonly HttpClient myClient;
      private static CookieContainer myCC = new CookieContainer();

      public static void InitCookies(string s1, string s2, string s3, string s4)
      {
        Form1 form1 = new Form1();
        form1.ses.Value = s1;
        form1.lc.Value = s2;
        form1.mashine.Value = s3;
        form1.auth.Value = s4;
        Cookie cookie = new Cookie("clickcoords", "0", "/", ".bgmafia.com");
        Form1.ClientController.myCC.Add(cookie);
        Form1.ClientController.myCC.Add(form1.max_level);
        Form1.ClientController.myCC.Add(form1.min_level);
        Form1.ClientController.myCC.Add(form1.max_respect);
        Form1.ClientController.myCC.Add(form1.mashine);
        Form1.ClientController.myCC.Add(form1.registered);
        Form1.ClientController.myCC.Add(form1.ses);
        Form1.ClientController.myCC.Add(form1.terms_accepted);
        Form1.ClientController.myCC.Add(form1.world_id);
        Form1.ClientController.myCC.Add(form1.online);
        Form1.ClientController.myCC.Add(form1.lc);
        Form1.ClientController.myCC.Add(form1.tab);
        Form1.ClientController.myCC.Add(form1.auth);
        Form1.ClientController.myCC.Add(form1.arp_srcoll);
        Form1.ClientController.myCC.Add(form1.login);
      }

      static ClientController() => Form1.ClientController.myClient = new HttpClient((HttpMessageHandler) new HttpClientHandler()
      {
        CookieContainer = Form1.ClientController.myCC
      });

      public async Task<string> GetAsync(Uri baseAddressP)
      {
        HttpResponseMessage resp = await Form1.ClientController.myClient.GetAsync(baseAddressP);
        resp.EnsureSuccessStatusCode();
        string end;
        using (Task<Stream> responseStream = resp.Content.ReadAsStreamAsync())
        {
          using (StreamReader sr = new StreamReader(responseStream.Result))
          {
            string parse = sr.ReadToEnd();
            end = sr.ReadToEnd();
          }
        }
        return end;
      }

      public async void DoWorkAsync(string item_id, string end_sP)
      {
        Uri baseAddr = new Uri("https://bgmafia.com/inventory/disarm/" + item_id + "?" + end_sP);
        Uri baseAddr2 = new Uri("https://bgmafia.com/inventory/disarm/" + item_id + "?" + end_sP);
        Uri[] urls = new Uri[2]{ baseAddr, baseAddr2 };
        IEnumerable<Task<string>> tasks = ((IEnumerable<Uri>) urls).Select<Uri, Task<string>>((Func<Uri, Task<string>>) (i => this.GetAsync(i)));
        string[] strArray = await Task.WhenAll<string>(tasks);
      }
    }
  }
}
