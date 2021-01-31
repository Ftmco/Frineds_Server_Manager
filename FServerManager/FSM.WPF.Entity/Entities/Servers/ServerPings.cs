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
    /// Server Title
    /// </summary>
    [Required]
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
}