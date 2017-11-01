using Microsoft.Reporting.WebForms;
using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ReportExampleWithMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Report()
        {
            ReportViewer rptViewer = new ReportViewer();

            // ProcessingMode will be Either Remote or Local  
            rptViewer.ProcessingMode = ProcessingMode.Remote;
            rptViewer.SizeToReportContent = true;
            rptViewer.ZoomMode = ZoomMode.PageWidth;
            rptViewer.Width = Unit.Percentage(99);
            rptViewer.Height = Unit.Pixel(1000);
            rptViewer.AsyncRendering = true;
            rptViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer/");
            rptViewer.ServerReport.ReportPath = "/DemoSSRSProject/Report1";
            rptViewer.ShowParameterPrompts = false;
            rptViewer.ServerReport.Refresh();
            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter();
            param[0].Name = "SellStartDate1";
            param[0].Values.Add("01/01/2017");
            param[1] = new ReportParameter();
            param[1].Name = "ProductName";
            param[1].Values.Add(null);
            rptViewer.ServerReport.SetParameters(param);
            rptViewer.ServerReport.Refresh();
            ViewBag.ReportViewer = rptViewer;
            return View();
        }
    }
}