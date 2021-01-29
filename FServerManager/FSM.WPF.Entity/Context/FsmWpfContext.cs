using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Db Context
/// </summary>
public class FsmWpfContext : DbContext
{
    private const string ConnectionString = "Data Source=.;Initial Catalog=FSM_DB;Integrated Security=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(ConnectionString);


    /// <summary>
    /// Server Table
    /// </summary>
    public DbSet<Server> Servers { get; set; }

    /// <summary>
    /// Pinging Servers Table
    /// </summary>
    public DbSet<ServerPings> ServerPings { get; set; }
}
