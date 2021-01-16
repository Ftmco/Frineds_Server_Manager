using Microsoft.EntityFrameworkCore;

/// <summary>
/// Db Context
/// </summary>
public class FSMServerContext : DbContext 
{
    public FSMServerContext(DbContextOptions<FSMServerContext> options):base(options)
    {
    }

}

