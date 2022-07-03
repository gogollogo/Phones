﻿using System.ComponentModel.DataAnnotations;

namespace Phones.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PasswordHash { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}
