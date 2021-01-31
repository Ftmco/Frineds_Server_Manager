using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

/// <summary>
/// Db Context
/// </summary>
public class FsmWpfContext : DbContext
{
    private const string ConnectionString = "Server=185.83.208.175; Database=FSM_DB;User Id=motilogin; Password=Motahar@347";

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
