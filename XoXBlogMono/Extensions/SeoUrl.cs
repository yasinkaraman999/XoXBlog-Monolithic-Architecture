
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace System;


public static class SeoUrl
{
    public static string GetSeoUrl(string text)
    {
          if (text != "")
            {
                text = text.ToLower();
            }
            text = text.Replace(" ", "-");
            text = text.Replace(".", "-");

            text = text.Replace("ı", "i");
            text = text.Replace("ü", "u");
            text = text.Replace("ö", "o");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");

            text = text.Replace("İ", "I");
            text = text.Replace("Ü", "U");
            text = text.Replace("Ö", "O");
            text = text.Replace("Ş", "S");
            text = text.Replace("Ğ", "g");

            text = String.Join("", text.Normalize(NormalizationForm.FormD) // türkçe karakterleri ingilizceye çevir.
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));


            text = HttpUtility.UrlEncode(text);
            return System.Text.RegularExpressions.Regex.Replace(text, @"\%[0-9A-Fa-f]{2}", "");
    }
}

 