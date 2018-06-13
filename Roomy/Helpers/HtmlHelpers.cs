﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Roomy.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString GetImage(this IHtmlHelper helper, File file)
        {
            var image = new TagBuilder("img");
            var src = "";
            if (file.ContentType.Contains("image"))
            {
                var base64 = Convert.ToBase64String(file.Content);
                src = $"data:{file.ContentType};base64,{base64}";
            }
            else
            {
                src = @"data:image/jpeg;base64,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";
            }

            image.Attributes.Add("src", src);
            image.Attributes.Add("alt", file.Name);

            using (var writer = new System.IO.StringWriter())
            {
                image.WriteTo(writer, HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }
        }
    }
}
