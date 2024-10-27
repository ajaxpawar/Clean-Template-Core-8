# Migration Initialization Instructions

To initialize a migration in your project, follow these steps:

## Step 1: Set Startup Project

1. Open **Visual Studio**.
2. In the **Solution Explorer**, right-click on the `Infrastructure` project.
3. Select **Set as Startup Project**.

## Step 2: Open Package Manager Console

1. Go to **Tools** in the top menu.
2. Select **NuGet Package Manager**.
3. Click on **Package Manager Console**.

## Step 3: Run Migration Command

In the **Package Manager Console** within the `Infrastructure` project, execute the following command:

```powershell
Add-Migration <MigrationName>

update-databases