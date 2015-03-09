# soccer-league-table
Reference implementation of AngularJS + ASP.NET Web API, and ASP.NET MVC

Enable-Migrations -ProjectName Repository -StartUpProjectName Repository -ConnectionString "Server=.\sqlexpress;Database=SoccerLeague;Integrated Security=true" -ConnectionProviderName System.Data.SqlClient

Add-Migration -Name Initial -ProjectName Repository -StartUpProjectName Repository -ConnectionString "Server=.\sqlexpress;Database=SoccerLeague;Integrated Security=true" -ConnectionProviderName System.Data.SqlClient

Update-Database -ProjectName Repository -StartUpProjectName Repository -ConnectionString "Server=.\sqlexpress;Database=SoccerLeague;Integrated Security=true" -ConnectionProviderName System.Data.SqlClient -Verbose
