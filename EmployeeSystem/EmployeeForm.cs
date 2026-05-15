using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SQLite;

namespace EmployeeSystem
{
    public partial class EmployeeForm : Form
    {
        string connectionString = "Data Source=employees.db"; 
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            CreateTable();
            dgvEmployees.Columns.Clear();

            dgvEmployees.Columns.Add("colEmpId", "員工編號");
            dgvEmployees.Columns.Add("colEmpName", "姓名");
            dgvEmployees.Columns.Add("colDept", "部門");
            dgvEmployees.Columns.Add("colTitle", "職稱");
            dgvEmployees.Columns.Add("colPhone", "電話");

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void CreateTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Employees (
                    EmpId TEXT PRIMARY KEY,
                    EmpName TEXT,
                    Dept TEXT,
                    JobTitle TEXT,
                    Phone TEXT
                )";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
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

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

                txtEmpId.Text = row.Cells[0].Value.ToString();
                txtEmpName.Text = row.Cells[1].Value.ToString();
                txtDept.Text = row.Cells[2].Value.ToString();
                txtJobTitle.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("請先點選要修改的資料!");
                return;
            }
            DataGridViewRow row = dgvEmployees.CurrentRow;
            row.Cells[0].Value = txtEmpId.Text;
            row.Cells[1].Value = txtEmpName.Text;
            row.Cells[2].Value = txtDept.Text;
            row.Cells[3].Value = txtJobTitle.Text;
            row.Cells[4].Value = txtPhone.Text;
            MessageBox.Show("修改成功");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("請先點選要修改的資料!");
                return;
            }
            dgvEmployees.Rows.Remove(dgvEmployees.CurrentRow);
            MessageBox.Show("刪除成功!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtNameSearch.Text;

            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                string name = row.Cells[1].Value.ToString();
                if (name.Contains(keyword))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.IsNewRow) ;
                if (row.Visible == false)
                {
                    row.Visible = true;
                }
            }
            txtNameSearch.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtDept.Clear();
            txtJobTitle.Clear();
            txtPhone.Clear();
            txtEmpId.Focus();
        }
    }
}
