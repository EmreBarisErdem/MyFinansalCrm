using FinansalCrm.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;


namespace FinansalCrm
{
	public partial class FrmBilling : Form
	{
		public FrmBilling()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		private void FrmBilling_Load(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnBillList_Click(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnCreateBill_Click(object sender, EventArgs e)
		{
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;

			Bills bills = new Bills();

			bills.BillTitle = title;
			bills.BillAmount = amount;
			bills.BillPeriod = period;

			db.Bills.Add(bills);
			db.SaveChanges();

			MessageBox.Show("Ödeme Başarılı bir şekilde sisteme eklendi","Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;

		}

		private void btnRemoveBill_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtBillId.Text);

			var removeValue = db.Bills.Find(id);
			db.Bills.Remove(removeValue);
			db.SaveChanges();

			MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi","Ödeme & Faturalar" , MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnUpdateBill_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtBillId.Text);
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;

			var value = db.Bills.Find(id);

			value.BillTitle = title;
			value.BillAmount = amount;
			value.BillPeriod = period;
			

			db.Bills.AddOrUpdate(value);
			db.SaveChanges();

			MessageBox.Show("Ödeme Başarılı bir şekilde sisteme eklendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values2 = db.Bills.ToList();
			dataGridView1.DataSource = values2;
		}

		private void btnBanksForms_Click(object sender, EventArgs e)
		{
			FrmBanks frm = new FrmBanks();
			frm.Show();
			this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			FrmDashboard frm = new FrmDashboard();

			frm.Show();
			this.Hide();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
