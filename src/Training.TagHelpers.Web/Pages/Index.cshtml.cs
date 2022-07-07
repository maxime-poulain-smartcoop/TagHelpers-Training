using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Training.TagHelpers.Web.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string? FirstName { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    // Convention requires to have the method with the following nomenclature
    // [On] plus [HTTP Verb]
    public void OnPost()
    {

    }
}
