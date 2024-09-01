using System.ComponentModel.DataAnnotations;

namespace Lab.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [StringLength(100, MinimumLength = 6)]
    public string? Password { get; set; }
    [Required]
    public Branch? Branch { get; set; }
    [Required]
    public Gender? Gender { get; set; }
    public bool IsRegular { get; set; }
    [DataType(DataType.MultilineText)]
    [Required]
    public string? Address { get; set; }
    [Range(typeof(DateTime), "1/1/1980", "1/1/2010")]
    public DateTime? DateOfBirth { get; set; }
    public IFormFile? Photo { get; set; }
    
    public string? PhotoPath { get; set; }
}