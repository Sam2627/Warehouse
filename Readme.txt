Test@123

Nuget:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

- Add Scaffolding

Add-Migration Init -Context ApplicationDbContext
Update-Database -Context ApplicationDbContext
Remove-Migration -Context ApplicationDbContext

Add-Migration Init -Context WarehouseDbContext
Update-Database -Context WarehouseDbContext
Remove-Migration -Context WarehouseDbContext



