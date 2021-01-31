using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

/// <summary>
/// Db Context
/// </summary>
public class FsmWpfContext : DbContext
{


    private static string ConnectionString = "Data Source=FSM_DB.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(ConnectionString);


    /// <summary>
    /// Server Table
    /// </summary>
    public DbSet<Server> Servers { get; set; }

    /// <summary>
    /// Pinging Servers Table
    /// </summary>
    public DbSet<ServerPings> ServerPings { get; set; }
}
