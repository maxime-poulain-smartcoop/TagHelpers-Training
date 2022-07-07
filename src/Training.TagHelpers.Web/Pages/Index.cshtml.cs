using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Training.TagHelpers.Web.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public RegisterMemberRequest? RegisterMemberRequest { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    // Convention requires to have the method with the following nomenclature
    // [On] plus [HTTP Verb]
    public ActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage();
    }
}

public class RegisterMemberRequest
{
    [MinLength(5)]
    [Required]
    public string? FirstName { get; set; }

    [MinLength(5)]
    [Required]
    public string? LastName { get; set; }

    [Range(0, 100)]
    public int Age { get; set; }
}