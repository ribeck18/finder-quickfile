class MarkdownType : FileType
{
    public MarkdownType(string name, string extension, string template) : base(name, extension, template)
    {

    }

    public override string FormatFileName()
    {
        string nameString = $"{_name}.{_extension}";
        string fileName = nameString.ToUpper();

        _fileName = fileName;
        return fileName;
    }
}
