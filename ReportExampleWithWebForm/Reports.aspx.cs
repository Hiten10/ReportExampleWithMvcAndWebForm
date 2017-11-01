using Microsoft.Reporting.WebForms;
using System;
using System.Web.UI.WebControls;

namespace ReportExampleWithWebForm
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnReportDisplay_Click(object sender, EventArgs e)
        {

            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;
            ReportViewer1.Width = Unit.Percentage(99);
            ReportViewer1.Height = Unit.Pixel(1000);
            ReportViewer1.AsyncRendering = true;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
            ReportViewer1.ServerReport.ReportPath = "/DemoSSRSProject/Report1";
            ReportViewer1.ShowParameterPrompts = false;
            ReportViewer1.ServerReport.Refresh();
            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter();
            param[0].Name = "SellStartDate1";
            param[0].Values.Add("01/01/2017");
            param[1] = new ReportParameter();
            param[1].Name = "ProductName";
            param[1].Values.Add(null);
            ReportViewer1.ServerReport.SetParameters(param);
            ReportViewer1.ServerReport.Refresh();
        }
    }
}