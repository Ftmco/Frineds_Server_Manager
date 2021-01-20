using System;

public record Users
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ActiveCode { get; set; }
    public DateTime ActiveDate { get; set; }
    public bool IsActive { get; set; }
}
