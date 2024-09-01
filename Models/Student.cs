using System.ComponentModel.DataAnnotations;

namespace Lab.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string? Name { get; set; }
    [Required(ErrorMessage ="Email bắt buộc phải được nhập")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail.com", ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(@"""^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$""
", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số")]
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
    [Range(0, 10)]
    public float? GPA { get; set; }
}