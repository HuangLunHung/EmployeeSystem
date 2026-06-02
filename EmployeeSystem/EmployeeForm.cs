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
            //ClearDatabase();
            CreateTable();
            dgvEmployees.Columns.Clear();

            dgvEmployees.Columns.Add("colEmpId", "員工編號");
            dgvEmployees.Columns.Add("colEmpName", "姓名");
            dgvEmployees.Columns.Add("colDept", "部門");
            dgvEmployees.Columns.Add("colTitle", "職稱");
            dgvEmployees.Columns.Add("colPhone", "電話");

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // ⭐新增
            LoadData();
        }
        /*private void ClearDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Employees";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }*/
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

        // ⭐新增
        //private 修飾符確保 LoadData 方法只能在 EmployeeForm 類別內部被呼叫
        private void LoadData()
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
            // ⭐新增
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                INSERT INTO Employees (EmpId, EmpName, Dept, JobTitle, Phone)
                VALUES (@EmpId, @EmpName, @Dept, @JobTitle, @Phone)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                cmd.Parameters.AddWithValue("@EmpId", EmpId);
                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Parameters.AddWithValue("@Dept", Dept);
                cmd.Parameters.AddWithValue("@JobTitle", JobTitle);
                cmd.Parameters.AddWithValue("@Phone", Phone);

                cmd.ExecuteNonQuery();
            }

            // ⭐新增
            LoadData();

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
            // 1. 檢查是否有選取資料列
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("請先點選要刪除的資料!");
                return;
            }

            // 2. 取得選取列的員工編號（EmpId 是主鍵）
            string empId = dgvEmployees.CurrentRow.Cells[0].Value.ToString();

            // 3. 建立 SQLite 連線並執行刪除
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

            // 4. 刪除後重新載入資料
            LoadData();
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
