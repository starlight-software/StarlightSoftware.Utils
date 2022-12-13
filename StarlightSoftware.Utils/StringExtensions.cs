using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarlightSoftware.Utils;
public static class StringExtensions
{
    private static readonly Regex _htmlTag = new("<[^>]*>", RegexOptions.Compiled | RegexOptions.Multiline);
    private static readonly Regex _multiline = new("^\\s*$\\n", RegexOptions.Compiled | RegexOptions.Multiline);

    /// <summary>
    /// Produces URL-friendly version of a value, "like-this-one".
    /// </summary>
    [PublicAPI]
    public static string Slugify(this string value, int maxLength = 80)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }
        
        int len = value.Length;
        bool lastCharWasDash = false;
        StringBuilder sb = new(len);

        for (int i = 0; i < len; i++)
        {
            if (i == maxLength)
            {
                break;
            }

            char c = value[i];

            switch (c)
            {
                case >= 'a' and <= 'z':
                case >= '0' and <= '9':
                    sb.Append(c);
                    lastCharWasDash = false;
                    break;
                case >= 'A' and <= 'Z':
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    lastCharWasDash = false;
                    break;
                case ' ':
                case ',':
                case '.':
                case '/':
                case '\\':
                case '-':
                case '_':
                case '=':
                {
                    if (!lastCharWasDash && sb.Length > 0)
                    {
                        sb.Append('-');
                        lastCharWasDash = true;
                    }

                    break;
                }
                default:
                {
                    if (c >= 128)
                    {
                        int length = sb.Length;
                        sb.Append(RemapInternationalCharToAscii(c));
                        if (length != sb.Length)
                        {
                            lastCharWasDash = false;
                        }
                    }

                    break;
                }
            }
        }

        return sb.ToString().TrimEnd('-');
    }

    /// <summary>
    /// Strips html tags from a string, preserving the inner text
    /// </summary>
    /// <param name="html">HTML to sanitise</param>
    /// <returns>Returns the string value without html tags</returns>
    [PublicAPI]
    public static string RemoveHtml(this string html)
    {
        if (string.IsNullOrWhiteSpace(html)) return string.Empty;

        string output;

        // Repeat as needed to avoid nested tags
        do
        {
            //get rid of HTML tags
            output = _htmlTag.Replace(html, string.Empty);

            //get rid of multiple blank lines
            output = _multiline.Replace(output, string.Empty);
        } while (_htmlTag.IsMatch(output));

        return output;
    }

    /// <summary>
    /// Gets the initials for a given value. This is the first letter of each space-delimited word
    /// </summary>
    /// <param name="value">The text to initialise</param>
    /// <returns>The initials</returns>
    [PublicAPI]
    public static string GetInitials(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;

        return string.Concat(value
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
            .Select(x => x[0]));
    }

    private static string RemapInternationalCharToAscii(char c)
    {
        return c switch
        {
            'à' => "a",
            'å' => "a",
            'á' => "a",
            'â' => "a",
            'ä' => "a",
            'ã' => "a",
            'ą' => "a",
            'è' => "e",
            'é' => "e",
            'ê' => "e",
            'ë' => "e",
            'ę' => "e",
            'ì' => "i",
            'í' => "i",
            'î' => "i",
            'ï' => "i",
            'ı' => "i",
            'ò' => "o",
            'ó' => "o",
            'ô' => "o",
            'õ' => "o",
            'ö' => "o",
            'ø' => "o",
            'ő' => "o",
            'ð' => "o",
            'ù' => "u",
            'ú' => "u",
            'û' => "u",
            'ü' => "u",
            'ŭ' => "u",
            'ů' => "u",
            'ç' => "c",
            'ć' => "c",
            'č' => "c",
            'ĉ' => "c",
            'ż' => "z",
            'ź' => "z",
            'ž' => "z",
            'ś' => "s",
            'ş' => "s",
            'š' => "s",
            'ŝ' => "s",
            'ñ' => "n",
            'ń' => "n",
            'ý' => "y",
            'ÿ' => "y",
            'ğ' => "g",
            'ĝ' => "g",
            'ř' => "r",
            'ł' => "l",
            'đ' => "d",
            'ß' => "ss",
            'Þ' => "th",
            'ĥ' => "h",
            'ĵ' => "j",
            _ => ""
        };
    }
}