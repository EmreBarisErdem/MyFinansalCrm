using FinansalCrm.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FinansalCrm
{
	public partial class FrmBanks : Form
	{
		public FrmBanks()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		private void FrmBanks_Load(object sender, EventArgs e)
		{

			#region Banka Bakiyeleri...
			var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();

			var vakıfBankBalance = db.Banks.Where(x=>x.BankTitle == "VakıfBank").Select(y =>y.BankBalance).FirstOrDefault();

			var isBankBalance = db.Banks.Where(x=>x.BankTitle == "İş Bankası").Select(y =>y.BankBalance).FirstOrDefault();

			lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " \u20BA";
			lblVakıfBankBalance.Text = vakıfBankBalance.ToString() + " \u20BA";
			lblIsBankBalance.Text = isBankBalance.ToString() + " \u20BA";
			#endregion

			#region Banka Hareketleri...
			/* Uzun Uzun yazadabiliriz...
			//var bankProcess1 = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).FirstOrDefault();

			//lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;
			
			//var bankProcess2 = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(2).Skip(1).FirstOrDefault();

			//lblBankProcess2.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

			//var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();

			//lblBankProcess3.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

			//var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();

			//lblBankProcess4.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

			//var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();

			//lblBankProcess5.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;
			*/

			var bankProcesses = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).ToList();
			var labels = new[] { lblBankProcess1, lblBankProcess2, lblBankProcess3, lblBankProcess4, lblBankProcess5 };

			int index = 0;

			foreach (var bankProcess in bankProcesses)
			{
				labels[index].Text = $"{bankProcess.Description} {bankProcess.Amount} {bankProcess.ProcessDate}";
				index++;
			}


			#endregion
		}

		private void btnBillForm_Click(object sender, EventArgs e)
		{
			FrmBilling frm = new FrmBilling();

			frm.Show();
			this.Hide();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			FrmDashboard frm = new FrmDashboard();

			frm.ShowDialog();

			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Show();
		}
	}
}
