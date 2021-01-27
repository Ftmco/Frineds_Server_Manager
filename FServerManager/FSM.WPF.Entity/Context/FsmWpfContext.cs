using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Db Context
/// </summary>
public class FsmWpfContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FSM_DB;Integerated Security=True");
    }

    /// <summary>
    /// Server Table
    /// </summary>
    public DbSet<Server> Servers { get; set; }
}
