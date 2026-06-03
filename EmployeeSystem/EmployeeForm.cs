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

            LoadData();
        }

        private void CreateTable()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("資料表建立失敗：" + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvEmployees.Rows.Clear();

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM Employees";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvEmployees.Rows.Add(
                            reader["EmpId"].ToString(),
                            reader["EmpName"].ToString(),
                            reader["Dept"].ToString(),
                            reader["JobTitle"].ToString(),
                            reader["Phone"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料載入失敗：" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string empId = txtEmpId.Text.Trim();
            string empName = txtEmpName.Text.Trim();
            string dept = txtDept.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (empId == "" || empName == "" || dept == "" || jobTitle == "" || phone == "")
            {
                MessageBox.Show("請輸入完整資料!");
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                    INSERT INTO Employees (EmpId, EmpName, Dept, JobTitle, Phone)
                    VALUES (@EmpId, @EmpName, @Dept, @JobTitle, @Phone)";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.Parameters.AddWithValue("@EmpName", empName);
                    cmd.Parameters.AddWithValue("@Dept", dept);
                    cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearFields();
                MessageBox.Show("新增成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message);
            }
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
                txtEmpId.ReadOnly = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("請先點選要修改的資料!");
                return;
            }

            string empId = txtEmpId.Text.Trim();
            string empName = txtEmpName.Text.Trim();
            string dept = txtDept.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (empId == "" || empName == "" || dept == "" || jobTitle == "" || phone == "")
            {
                MessageBox.Show("請輸入完整資料!");
                return;
            }

            try
            {
                //txtEmpId.ReadOnly = true;

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                    UPDATE Employees
                    SET EmpName = @EmpName,
                        Dept = @Dept,
                        JobTitle = @JobTitle,
                        Phone = @Phone
                    WHERE EmpId = @EmpId";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpName", empName);
                        cmd.Parameters.AddWithValue("@Dept", dept);
                        cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@EmpId", empId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
                MessageBox.Show("修改成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失敗：" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("請先點選要刪除的資料!");
                return;
            }

            string empId = dgvEmployees.CurrentRow.Cells[0].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                "確定要刪除這筆資料嗎?",
                "確認刪除",
                MessageBoxButtons.YesNo
            );
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM Employees WHERE EmpId = @EmpId";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpId", empId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
                MessageBox.Show("刪除成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除失敗：" + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtNameSearch.Text.Trim();

            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells[1].Value.ToString();
                row.Visible = name.Contains(keyword);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.IsNewRow) continue;
                row.Visible = true;
            }
            txtNameSearch.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // 抽成獨立方法，避免重複寫清空邏輯
        private void ClearFields()
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtDept.Clear();
            txtJobTitle.Clear();
            txtPhone.Clear();
            txtEmpId.ReadOnly = false;
            txtEmpId.Focus();
        }

        private void lblEmpId_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}