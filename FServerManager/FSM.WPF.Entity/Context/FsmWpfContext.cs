using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Db Context
/// </summary>
public class FsmWpfContext : DbContext
{
    /// <summary>
    /// Server Table
    /// </summary>
    public DbSet<Server> Servers { get; set; }
}
