using System;
using System.Web.UI;

namespace TMDemo
{
    public partial class _Default : Page
    {
        protected override void OnInit(EventArgs e)
        {
            Trace.Warn("OnInit");
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Trace.Warn("OnLoad");
            base.OnLoad(e);
        }

    }
}