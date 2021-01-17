using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Tasks
/// </summary>
public record Tasks
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public Guid TaskId { get; set; }

    /// <summary>
    /// Task Programe Name
    /// </summary>
    [Required]
    public string ImageName { get; set; }

    /// <summary>
    /// Programe Id
    /// </summary>
    [Required]
    public int Pid { get; set; }

    /// <summary>
    /// Session Name
    /// </summary>
    [Required]
    public string SessionName { get; set; }

    /// <summary>
    /// Session Id
    /// </summary>
    [Required]
    public string SessionId { get; set; }

    /// <summary>
    /// Memory Usage
    /// </summary>
    [Required]
    public string MemUsage { get; set; }

    /// <summary>
    /// Set Date 
    /// </summary>
    [Required]
    public DateTime RequestDate { get; set; }
}
