using hero2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hero2.Logic
{
    public static class ContentItemLogic
    {
        public static bool isCorrectData(this ContentItem c)
        {
            bool isCorrect = false;
            switch(c.ContentType)
            {
                case Enums.ContentType.Text:
                    if(c.Text.Equals(String.Empty))
                        isCorrect=false;
                    break;
                case Enums.ContentType.Image:
                    if(c.ImageURL.Equals(String.Empty))
                        isCorrect=false;
                    break;
                case Enums.ContentType.Button:
                    if(c.URL.Equals(String.Empty))
                        isCorrect=false;
                    break;
                case Enums.ContentType.URLImage:
                    if(c.URL.Equals(String.Empty) || c.ImageURL.Equals(String.Empty))
                        isCorrect=false;
                    break;
            }
            return isCorrect;
        }
        public static string displayItem(this ContentItem c)
        {
            string result = String.Empty;

            switch(c.ContentType)
            {
                case Enums.ContentType.Text:
                    result = String.Format("<div class=\"gametext\">{0}</html>",
                        c.Text);
                    break;
                case Enums.ContentType.Image:
                    result = String.Format("<img class=\"gameimage\" src=\"{0}\"></html>",
                        c.ImageURL);
                    break;
                case Enums.ContentType.Button:
                    result = String.Format("<button class=\"gamebutton\" src=\"{0}\">{1}</button>",
                        c.URL, c.Text);
                    break;
            }
            return result;
        }
    }
}