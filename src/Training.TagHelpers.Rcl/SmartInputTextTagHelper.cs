using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Training.TagHelpers.Rcl;

/// <summary>
/// Tag Helper implementation the Smart Input Text.
/// </summary>
//[HtmlTargetElement("This Can override the tag helper name !")]
//  -> By default the framework converts the name to khebab case in our case "smart-input-text
public class SmartInputTextTagHelper : TagHelper // Any Tag Helper must implement the "TagHelper" class.
{
    // Again Pascal case is convert to kebab case if not specified.

    //[HtmlAttributeName("value")]
    public string? Value { get; set; }

    public string? Id { get; set; }

    public string? Placeholder { get; set; }

    public override void Init(TagHelperContext context)
    {
        // Here we can add some behavior upon the initialization of the component.
        // Validation and exception throwing on particular cases should be here.
        base.Init(context);
    }

    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // ProcessAsync calls base.Process.
        // See https://github.com/dotnet/aspnetcore/blob/c85baf8db0c72ae8e68643029d514b2e737c9fae/src/Razor/Razor/src/TagHelpers/TagHelper.cs#L51.
        return base.ProcessAsync(context, output);
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // base.Process does nothing.
        base.Process(context, output);

        // By default the tag name will be "smart-input-text" we need to change it !
        output.TagName = "input";

        // We want this element to be rendered as closed (ie <input /> instead of <input></input>.
        output.TagMode = TagMode.SelfClosing; // See the enumeration to understand other possible values.

        // It should be a type="text" therefore we need to specify that.
        output.Attributes.Add("type", "text");

        // We can set the Id is defined
        if (!string.IsNullOrEmpty(Id))
        {
            output.Attributes.Add("Id", Id);
        }

        // Same for the placeholder.
        if (!string.IsNullOrEmpty(Placeholder))
        {
            output.Attributes.Add("placeholder", Placeholder);
        }

        // Finally the input text needs to have the 'c-input' class.
        // We can use this extension method.
        output.AddClass("c-input", HtmlEncoder.Default);

        // Our component is done.

    }
}
