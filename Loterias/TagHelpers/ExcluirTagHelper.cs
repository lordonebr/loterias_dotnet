using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loterias.TagHelpers
{
    public class ExcluirTagHelper : TagHelper
    {
        public string Url { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);
            output.TagName = "a";
            output.Attributes.SetAttribute("onclick", "return confirm('Deseja realmente excluir o registro?');");
            output.Attributes.SetAttribute("href", Url);
            output.Content.SetContent("Excluir");
        }
    }
}
