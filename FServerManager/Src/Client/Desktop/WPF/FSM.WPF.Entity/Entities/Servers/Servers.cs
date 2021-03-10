

using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
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
    public Guid Id { get; set; }

    /// <summary>
    /// Server Name (Title)
    /// </summary>
    [NotNull]
    public string ServerName { get; set; }

    /// <summary>
    /// Server Ip Address 
    /// </summary>
    [NotNull]
    public string ServerIpAddress { get; set; }

    /// <summary>
    /// Server Conect Token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Insert Date Time
    /// </summary>
    [NotNull]
    public DateTime InsertDate { get; set; }

}
