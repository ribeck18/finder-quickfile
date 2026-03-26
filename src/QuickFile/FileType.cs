using System.Globalization;
using System.Text.RegularExpressions;

abstract class FileType
{
    //Attributes
    protected string _name;
    protected string _extension;

    // private string _content;
    private string _template;

    //Constructor
    public FileType(string name, string extension, string template)
    {
        _name = name;
        _extension = extension;
        _template = template;
    }

    //methods
    public string GetName()
    {
        return _name;
    }

    public string GetExtension()
    {
        return _extension;
    }

    // public string GetFileName()
    // {
    //     string fileName = $"{_name}.{_extension}";
    //     return fileName;
    // }
    public virtual string GetFileName()
    {
        string fileName = FormatFileName();

        return fileName;
    }

    public abstract string FormatFileName();

    public string GetTemplate()
    {
        return _template;
    }

    protected static string ToSnakeCase(string input)
    {
        string result = Regex.Replace(input, @"\s", "_");
        result = Regex.Replace(result, @"([a-z0-9])([A-Z])", "$1_$2");
        result = Regex.Replace(result, @"([A-Z]+)([A-Z][a-z])", "$1_$2");
        result = result.ToLower();

        return result;
    }

    protected static string ToPascalCase(string input)
    {
        string result = Regex.Replace(input, @"[\s_-]+", " ");
        string[] parts = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //For each part in parts
        for (int i = 0; i < parts.Length; i++)
        {
            //Make the part lowercase
            string part = parts[i].ToLower();
            //uppercase the first character.
            parts[i] = char.ToUpper(part[0]) + part.Substring(1);
        }
        //return combined parts.
        return string.Concat(parts);
    }
}
