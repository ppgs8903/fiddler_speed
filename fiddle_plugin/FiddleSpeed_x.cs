using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Fiddler;
using fiddle_plugin;

[assembly: Fiddler.RequiredVersion("4.4.9.2")]

public class FiddleSpeed_x : IAutoTamper    // Ensure class is public, or Fiddler won't see it!
{
    public String down_Load;
    public String up_Load;
    public fiddleSpeed_form ff;

    public FiddleSpeed_x()
    {
        /* NOTE: It's possible that Fiddler UI isn't fully loaded yet, so don't add any UI in the constructor.
           But it's also possible that AutoTamper* methods are called before OnLoad (below), so be
           sure any needed data structures are initialized to safe values here in this constructor */
        ff = new fiddleSpeed_form(this);
        down_Load = "0";
        up_Load = "0";
    }

    public void OnLoad() {
        /* Load your UI here */
        TabPage fiddleSpeedTab = new TabPage("FiddleSpeedx");
        ImageList imageList1 = new ImageList();
        Stream myStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("fiddle_plugin.Resources.laptop.png");
        FiddlerApplication.UI.imglSessionIcons.Images.Add(Image.FromStream(myStream));
        fiddleSpeedTab.ImageIndex = Enum.GetNames(typeof(SessionIcons)).Length;
        ff.TopLevel = false;
        fiddleSpeedTab.Controls.Add(ff);
        ff.Show();
        FiddlerApplication.UI.tabsViews.TabPages.Add(fiddleSpeedTab);
    }
    public void OnBeforeUnload() { }

    public void AutoTamperRequestBefore(Session oSession) {
        oSession["request-trickle-delay"] = down_Load;
        oSession["response-trickle-delay"] = up_Load;
    }
    public void AutoTamperRequestAfter(Session oSession) { }
    public void AutoTamperResponseBefore(Session oSession) { }
    public void AutoTamperResponseAfter(Session oSession) { }
    public void OnBeforeReturningError(Session oSession) { }

    public void alert_debug()
    {
        String form_path = System.AppDomain.CurrentDomain.BaseDirectory;
        MessageBox.Show(form_path);
    }
}