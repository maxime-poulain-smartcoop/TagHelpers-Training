using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Training.TagHelpers.Rcl;

/// <summary>
/// Tag Helper implementation of the Smart form.
/// A Smart Form is looks like this:
/// <form>
///     <div class="o-form-group-layout o-form-group-layout--standard">
///         *** INNER HTML OF GOES HERE ***
///     </div>
/// </form>
/// </summary>
[HtmlTargetElement("smart-form")]
public class SmartForm : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // Here the difficulty is to add more HTML than just render <smart-form> into a <form> with a bunch of attributes.

        // Set the <form> tag name and make sure that it will be rendered with an opening and closing tags.
        output.TagName = "form";
        output.TagMode = TagMode.StartTagAndEndTag;

        // We need to have <div class="o-form-group-layout o-form-group-layout--standard"> as the first child of the <form>
        // TagBuilder are object that can construct HTML.
        var div = new TagBuilder("div");
        div.InnerHtml.SetHtmlContent(await output.GetChildContentAsync());

        // NOTE TagBuilder.AddCssClass supports multiple classes while TagHelperOutput.AddCss DOES NOT.
        div.AddCssClass("o-form-group-layout o-form-group-layout--standard");

        // The content of the <form> becomes the div. However we must "restore" the actual inner HTML of the <smart-form>;
        output.Content.SetHtmlContent(div);
    }
}
