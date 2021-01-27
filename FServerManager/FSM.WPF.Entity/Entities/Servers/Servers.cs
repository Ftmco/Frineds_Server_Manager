

using System;
using System.ComponentModel.DataAnnotations;

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
    [Key]
    public Guid ServerId { get; set; }

    /// <summary>
    /// Server Name or Server Ip Address
    /// </summary>
    [Required]
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
    [Required]
    public DateTime InsertDate { get; set; }
}
