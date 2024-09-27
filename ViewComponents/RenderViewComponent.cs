using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.ViewComponents;

public class RenderViewComponent : ViewComponent
{
    private List<MenuItem> _menuItems = new()
    {
        new MenuItem { Id = 1, Name = "Branches", Link = "Branches/List" },
        new MenuItem { Id = 2, Name = "Students", Link = "" },
        new MenuItem { Id = 3, Name = "Subjects", Link = "Subjects/List" },
        new MenuItem { Id = 4, Name = "Courses", Link = "Courses/List" }
    };
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("RenderLeftMenu",_menuItems);
    }
    
}