using System;
using System.ComponentModel.DataAnnotations;

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
    [Key]
    public Guid PingId { get; set; }

    /// <summary>
    /// Server Name Or Ip Address
    /// </summary>
    [Required]
    public string ServerName { get; set; }

    /// <summary>
    /// Ping Length
    /// </summary>
    [Required]
    public int Ping { get; set; }

    /// <summary>
    /// Request Count
    /// </summary>
    [Required]
    public int RequestCount { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [Required]
    public string Status { get; set; }
}