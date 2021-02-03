using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Server Pings 
/// </summary>
public record ServerPings
{
    public ServerPings()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    /// <summary>
    /// Server Name Or Ip Address
    /// </summary>
    [NotNull]
    public string ServerName { get; set; }

    /// <summary>
    /// Server Title
    /// </summary>
    [NotNull]
    public string Title { get; set; }

    /// <summary>
    /// Ping Length
    /// </summary>
    public int Ping { get; set; }

    /// <summary>
    /// Request Count
    /// </summary>
    public int RequestCount { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Descriptions
    /// </summary>
    [MaxLength(800)]
    public string Description { get; set; }

    /// <summary>
    /// Ping Avrage
    /// </summary>
    public float Avrage { get; set; }

    /// <summary>
    /// Pings Sum
    /// </summary>
    public int PingSum { get; set; }

    /// <summary>
    /// Server Ip Address
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// Server Exception Count
    /// </summary>
    public int ExceptionCount { get; set; }
}