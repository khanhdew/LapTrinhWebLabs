using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.ViewComponents;

public class MajorViewComponent:ViewComponent

{
    private SchoolContext db;
    private List<Major> majors;
    public MajorViewComponent(SchoolContext db)
    {
        this.db = db;
        majors = db.Majors.ToList();
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("RenderMajor",majors);
    }
}