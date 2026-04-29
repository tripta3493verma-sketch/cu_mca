. Open the Solution File in your Visual Studio

. Install the necessary nuget packages
1. Microsoft.AspNetCore.Identity.EntityFrameworkCore
2. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
3. Microsoft.EntityFrameworkCore.Design
4. Microsoft.EntityFrameworkCore.SqlServer
5. Microsoft.EntityFrameworkCore.Tools
6. Microsoft.VisualStudio.Web.CodeGeneration.Design

. Before running do the following to make database working
1. Goto Tools=>NuGet Package Manager=>Package Manager Console
2. Then type "Add-Migration init"
3. Then "Update-Database"

   services.AddDbContext<EventContext>(options => options.UseSqlServer("Server=.;Database=EventReading;Integrated Security=True;"));
           