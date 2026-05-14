namespace EmployeeSystem
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblEmpId = new Label();
            lblEmpName = new Label();
            lblDept = new Label();
            lblJobTitle = new Label();
            lblPhone = new Label();
            lblNameSearch = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            btnRefresh = new Button();
            panel1 = new Panel();
            txtPhone = new TextBox();
            txtJobTitle = new TextBox();
            txtDept = new TextBox();
            txtEmpName = new TextBox();
            txtEmpId = new TextBox();
            txtNameSearch = new TextBox();
            panel2 = new Panel();
            grpTool = new GroupBox();
            dgvEmployees = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            grpTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(321, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(333, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "員工管理系統 (Employee Management Syst)em";
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Location = new Point(3, 4);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(69, 19);
            lblEmpId.TabIndex = 1;
            lblEmpId.Text = "員工號碼";
            // 
            // lblEmpName
            // 
            lblEmpName.AutoSize = true;
            lblEmpName.Location = new Point(3, 32);
            lblEmpName.Name = "lblEmpName";
            lblEmpName.Size = new Size(39, 19);
            lblEmpName.TabIndex = 2;
            lblEmpName.Text = "姓名";
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(3, 60);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(39, 19);
            lblDept.TabIndex = 3;
            lblDept.Text = "部門";
            // 
            // lblJobTitle
            // 
            lblJobTitle.AutoSize = true;
            lblJobTitle.Location = new Point(3, 88);
            lblJobTitle.Name = "lblJobTitle";
            lblJobTitle.Size = new Size(39, 19);
            lblJobTitle.TabIndex = 4;
            lblJobTitle.Text = "職稱";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(3, 116);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(39, 19);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "電話";
            // 
            // lblNameSearch
            // 
            lblNameSearch.AutoSize = true;
            lblNameSearch.Location = new Point(3, 14);
            lblNameSearch.Name = "lblNameSearch";
            lblNameSearch.Size = new Size(69, 19);
            lblNameSearch.TabIndex = 6;
            lblNameSearch.Text = "查詢姓名";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 23);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(6, 53);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 81);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(6, 109);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 10;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(244, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "查詢";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(338, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "重整";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(txtJobTitle);
            panel1.Controls.Add(txtDept);
            panel1.Controls.Add(txtEmpName);
            panel1.Controls.Add(txtEmpId);
            panel1.Controls.Add(lblJobTitle);
            panel1.Controls.Add(lblEmpId);
            panel1.Controls.Add(lblEmpName);
            panel1.Controls.Add(lblDept);
            panel1.Controls.Add(lblPhone);
            panel1.Location = new Point(0, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 146);
            panel1.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(109, 113);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 10;
            // 
            // txtJobTitle
            // 
            txtJobTitle.Location = new Point(109, 85);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(125, 27);
            txtJobTitle.TabIndex = 9;
            // 
            // txtDept
            // 
            txtDept.Location = new Point(109, 57);
            txtDept.Name = "txtDept";
            txtDept.Size = new Size(125, 27);
            txtDept.TabIndex = 8;
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(109, 29);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(125, 27);
            txtEmpName.TabIndex = 7;
            // 
            // txtEmpId
            // 
            txtEmpId.Location = new Point(109, 1);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(125, 27);
            txtEmpId.TabIndex = 6;
            // 
            // txtNameSearch
            // 
            txtNameSearch.Location = new Point(77, 11);
            txtNameSearch.Name = "txtNameSearch";
            txtNameSearch.Size = new Size(157, 27);
            txtNameSearch.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtNameSearch);
            panel2.Controls.Add(lblNameSearch);
            panel2.Controls.Add(btnRefresh);
            panel2.Location = new Point(0, 204);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 47);
            panel2.TabIndex = 14;
            // 
            // grpTool
            // 
            grpTool.Controls.Add(btnDelete);
            grpTool.Controls.Add(btnAdd);
            grpTool.Controls.Add(btnUpdate);
            grpTool.Controls.Add(btnClear);
            grpTool.ForeColor = SystemColors.ControlText;
            grpTool.Location = new Point(340, 53);
            grpTool.Name = "grpTool";
            grpTool.Size = new Size(105, 145);
            grpTool.TabIndex = 15;
            grpTool.TabStop = false;
            grpTool.Text = "Tool";
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(0, 248);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(981, 405);
            dgvEmployees.TabIndex = 16;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(dgvEmployees);
            Controls.Add(grpTool);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            grpTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblEmpId;
        private Label lblEmpName;
        private Label lblDept;
        private Label lblJobTitle;
        private Label lblPhone;
        private Label lblNameSearch;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private Button btnRefresh;
        private Panel panel1;
        private TextBox txtPhone;
        private TextBox txtJobTitle;
        private TextBox txtDept;
        private TextBox txtEmpName;
        private TextBox txtEmpId;
        private TextBox txtNameSearch;
        private Panel panel2;
        private GroupBox grpTool;
        private DataGridView dgvEmployees;
    }
}