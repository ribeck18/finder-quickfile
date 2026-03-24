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

    public string GetFileName()
    {
        string fileName = $"{_name}.{_extension}";
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
        result = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2");
        result = Regex.Replace(result, @"([A-Z]+)([A-Z][a-z])", "$1_$2");
        result.ToLower();

        return result;
    }

    protected static string ToPascalCase(string input)
    {
        string result = Regex.Replace(input, @"\s", "_");
        result = Regex.Replace(
            result,
            @"()?:^[\s_-])(\w)",
            match => match.Groups[1].Value.ToUpper()
        );

        return result;
    }
}
