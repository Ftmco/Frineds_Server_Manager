using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// Create New Site View Model
/// </summary>
public record NewSiteViewModel
{
    /// <summary>
    /// site Name
    /// </summary>
    public string SiteName { get; set; }

    /// <summary>
    /// Physical Path 
    /// </summary>
    public string PhysicalPath { get; set; }

    /// <summary>
    /// Site Ip Address 
    /// If Is Null Ip = LocalHost
    /// Like 127.0.0.1
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// Port To Connect 
    /// Defult Port On Http : 80 and Https : 443
    /// </summary>
    public string Port { get; set; }

    /// <summary>
    /// Binding Type
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// Binding Information
    /// </summary>
    public string HostName { get; set; }
}

/// <summary>
/// Type Of Protocol
/// </summary>
public enum Type
{
    /// <summary>
    /// Http 
    /// </summary>
    http = 1,

    /// <summary>
    /// Https
    /// </summary>
    https = 2,

    /// <summary>
    /// Net.Pipe
    /// </summary>
    net_pipe = 3,

    /// <summary>
    /// Msmq.Formatnan
    /// </summary>
    msmq_formatnan = 4,

    /// <summary>
    /// Net.Msmq
    /// </summary>
    net_msmq = 5,

    /// <summary>
    /// Net.Tcp
    /// </summary>
    net_tcp = 6
}