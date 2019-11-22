using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Infrastructure.TagHelperNs
{
    public class ButtonTagHelper : TagHelper
    {
        public string BsButtonColor { get; set; }
        public override void Process(TagHelperContext context,TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}
