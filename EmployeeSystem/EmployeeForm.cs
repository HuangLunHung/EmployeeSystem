using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSystem
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            dgvEmployees.Columns.Clear();

            dgvEmployees.Columns.Add("colEmpId", "員工編號");
            dgvEmployees.Columns.Add("colEmpName", "姓名");
            dgvEmployees.Columns.Add("colDept", "部門");
            dgvEmployees.Columns.Add("colTitle", "職稱");
            dgvEmployees.Columns.Add("colPhone", "電話");

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string EmpId = txtEmpId.Text;
            string EmpName = txtEmpName.Text;
            string Dept = txtDept.Text;
            string JobTitle = txtJobTitle.Text;
            string Phone = txtPhone.Text;

            if (EmpId == "" || EmpName == "" || Dept == "" || JobTitle == "" || Phone == "")
            {
                MessageBox.Show("請輸入完整資料!");
                return;
            }
            dgvEmployees.Rows.Add(EmpId, EmpName, Dept, JobTitle, Phone);

            txtEmpId.Clear();
            txtEmpName.Clear();
            txtDept.Clear();
            txtJobTitle.Clear();
            txtPhone.Clear();
            txtEmpId.Focus();
        }
    }
}
