using ServiceStack.DataAnnotations;
using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Servers Entity
/// Pings
/// </summary>
public record Server
{
    public Server()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public Guid ServerId { get; set; }

    /// <summary>
    /// Server Name or Server Ip Address
    /// </summary>
    [NotNull]
    public string ServerName { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Descriptiion { get; set; }

    /// <summary>
    /// Title For Server Pings
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Insert Date Time
    /// </summary>
    [NotNull]
    public DateTime InsertDate { get; set; }
}
