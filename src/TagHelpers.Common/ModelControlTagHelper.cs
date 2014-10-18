using System;
using System.Text;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.AspNet.Razor.TagHelpers;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Mvc.TagHelpers;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace TagHelpers.Common
{
    [TagName("model-control")]
    [ContentBehavior(ContentBehavior.Prepend)]
    public class ModelControlTagHelper : TagHelper
    {
        [Activate]
        protected internal ITagHelperActivator Activator { get; set; }

        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        [Activate]
        protected internal IHtmlGenerator Generator { get; set; }

        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            For.Metadata

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("form-group");
            
            var label = new LabelTagHelper()
            {
                For = For
            };
            Activator.Activate(label, ViewContext);

            var input = new InputTagHelper()
            {
                For = For
            };
            Activator.Activate(input, ViewContext);

            var labelOutput = new TagHelperOutput("label", new Dictionary<string, string>(output.Attributes), string.Empty);
            var inputOutput = new TagHelperOutput("input", new Dictionary<string, string>(output.Attributes), string.Empty);

            label.Process(context, labelOutput);
            input.Process(context, inputOutput);

            var sb = new StringBuilder();
            sb.Append(labelOutput.GenerateStartTag());
            sb.Append(labelOutput.GenerateContent());
            sb.Append(labelOutput.GenerateEndTag());

            sb.Append(inputOutput.GenerateStartTag());
            sb.Append(inputOutput.GenerateContent());
            sb.Append(inputOutput.GenerateEndTag());

            tagBuilder.InnerHtml = sb.ToString();

            output.Merge(tagBuilder);
        }
    }
}
