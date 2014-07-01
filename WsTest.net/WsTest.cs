using System;
using System.Windows.Forms;
using WsTestMain;
using CommonWsItf;
using SecHeader;
namespace WsTest.Units
{
    public class WsTest
    {
        // Form1
        [STAThread]
        public static void Main(string[] args)
        {
            // Application.Initialize;
            WsTestMain.Units.WsTestMain.Form1 = new TForm1();
            // Application.Run;
            Application.Run(WsTestMain.Units.WsTestMain.Form1);
        }

    } // end WsTest

}

