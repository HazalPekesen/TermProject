﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TermProject.TagHelpers
{
    public class UserPictureThumbnailTagHelper : TagHelper
    {
        public string? PictureUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            if (String.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userpictures/default_pict.jpg");

            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
            }
        }
    }
}
