# 員工管理系統 Employee Management System

一個使用 C# WinForms 開發的桌面應用程式，提供員工資料的新增、查詢、修改、刪除功能，並串接 SQLite 資料庫進行資料持久化。

---

## 使用技術

- C# / .NET Framework
- WinForms
- SQLite
- ADO.NET

---

## 功能說明

- **新增**：輸入員工編號、姓名、部門、職稱、電話，新增至資料庫
- **修改**：點選資料列後修改欄位內容，員工編號作為主鍵不可變更
- **刪除**：點選資料列後刪除，刪除前跳出確認視窗防止誤刪
- **搜尋**：依姓名關鍵字即時篩選資料列
- **重置**：清除搜尋條件，顯示全部資料

---

## 畫面截圖

### 主畫面
![主畫面](image/main.png)

### 新增員工
![新增員工](image/add.png)

### 修改員工資料
![修改](image/update.png)

### 搜尋功能
![搜尋](image/search.png)

### 刪除確認
![刪除確認](image/delete.png)

---

## 專案結構

```
EmployeeSystem/
├── EmployeeForm.cs       # 主要邏輯
├── EmployeeForm.Designer.cs
├── Program.cs
└── employees.db          # SQLite 資料庫（執行後自動產生）
```

---

## 執行方式

1. 使用 Visual Studio 開啟專案
2. 確認已安裝 `System.Data.SQLite` NuGet 套件
3. 按下執行，資料庫會自動建立

---

## 開發者

- GitHub：[HuangLunHung](https://github.com/HuangLunHung)
