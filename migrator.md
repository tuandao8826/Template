# How to Run Migrations Using Package Manager Console

This guide walks you through running migrations using the Package Manager Console in Visual Studio.

---

## 🛠 Step 1: Open the Package Manager Console

In Visual Studio, go to:

```md
Tools → NuGet Package Manager → Package Manager Console
```

---

## 📁 Step 2: Select the Default Project

In the **Package Manager Console**, use the **Default project** dropdown to select the project where you want the migration files to be saved.

```md
Ex: Migrators/Migrators.PostgreSql 
```

---

## 🧱 Step 3: Create a Migration

**Note**: Make sure to configure the database path in Src/Configurations/databases.json.
To create a new migration file based on changes in your models, run the following command:

```powershell
Add-Migration -Context ApplicationDbContext
```

---

## 🧱 Step 4: Update the Database

To apply the migration and create/update the database schema, run:

```powershell
Update-Database -Context ApplicationDbContext
```
