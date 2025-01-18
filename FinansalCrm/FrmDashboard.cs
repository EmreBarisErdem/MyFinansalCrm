using FinansalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansalCrm
{
	public partial class FrmDashboard : Form
	{
		public FrmDashboard()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		int count = 0;
		private void FrmDashboard_Load(object sender, EventArgs e)
		{
			var totalBalance = db.Banks.Sum(x=>x.BankBalance);

			lblTotalBalance.Text = totalBalance.ToString() + " \u20BA";

			var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();

			lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " \u20BA";


			//Chart1 Kodları

			var bankData = db.Banks.Select(x => new
			{
				x.BankTitle,
				x.BankBalance

			}).ToList();

			chart1.Series.Clear();
			var series = chart1.Series.Add("Series1");

			foreach (var item in bankData)
			{
				series.Points.AddXY(item.BankTitle, item.BankBalance);
			}

			//Chart2 Kodları

			var billData = db.Bills.Select(x => new
			{
				x.BillTitle,
				x.BillAmount
			}).ToList();
			
			chart2.Series.Clear();

			var series2 = chart2.Series.Add("Faturalar");

			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			
			foreach(var item in billData)
			{
				series2.Points.AddXY(item.BillTitle, item.BillAmount);
			}



		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			count++;
			if (count % 4 == 1)
			{
				var electricBill = db.Bills.Where(x=>x.BillTitle == "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();

				lblBillTitle.Text = electricBill.ToString() + " \u20BA";
			}
			if (count % 4 == 2)
			{
				var gasBill = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();

				lblBillTitle.Text = gasBill.ToString() + " \u20BA";
			}
			if (count % 4 == 3)
			{
				var waterBill = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();

				lblBillTitle.Text = waterBill.ToString() + " \u20BA";
			}
			if (count % 4 == 0)
			{
				var internetBill = db.Bills.Where(x => x.BillTitle == "Internet Faturası").Select(y => y.BillAmount).FirstOrDefault();

				lblBillTitle.Text = internetBill.ToString() + " \u20BA";
			}
		}
	}
}
