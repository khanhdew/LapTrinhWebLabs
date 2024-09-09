using Lab.Models;
using Lab.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab.Controllers;

public class StudentController : Controller
{
    static List<Student> _listStudents = new List<Student>
    {
        new Student() {Id = 1, Name="Hải Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true,
            Address="A1-2018",Email="nam@g.com"},
        new Student() {Id = 2, Name="Minh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular=true,
            Address="A1-2019",Email="tu@g.com"},
        new Student() {Id = 3, Name="Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male, IsRegular=false,
            Address="A1-2020",Email="nam@g.com"},
        new Student() {Id = 4, Name="Xuân Mai", Branch = Branch.EE, Gender = Gender.Male, IsRegular=false,
            Address="A1-2021",Email="mai@g.com"},
    };
    readonly IBufferFileUploadService _bufferFileUploadService;
    public StudentController(IBufferFileUploadService bufferFileUploadService)
    {
        _bufferFileUploadService = bufferFileUploadService;
    }

    
    public IActionResult Index()
    {
        return View(_listStudents);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        ViewBag.AllBranches = new List<SelectListItem>()
        {
            new SelectListItem {Text="IT", Value ="1"},
            new SelectListItem {Text="BE", Value ="2"},
            new SelectListItem {Text="CE", Value ="3"},
            new SelectListItem {Text="EE", Value ="4"}
        };
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            if (student.Photo != null)
            {
                var photoPath = await _bufferFileUploadService.UploadFile(student.Photo);
                student.PhotoPath = photoPath;
            }
            
            student.Id = _listStudents.Last().Id + 1;
            _listStudents.Add(student);
            return View("Index", _listStudents);
        }
        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        ViewBag.AllBranches = new List<SelectListItem>()
        {
            new SelectListItem {Text="IT", Value ="1"},
            new SelectListItem {Text="BE", Value ="2"},
            new SelectListItem {Text="CE", Value ="3"},
            new SelectListItem {Text="EE", Value ="4"}
        };
        return View(student);
    }
}