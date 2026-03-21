class TxtType : FileType
{

    public TxtType(string name, string extension, string template) : base(name, extension, template) { }


    public override string FormatFileName()
    {
        string nameString = $"{_name}.{_extension}";
        string fileName = ToSnakeCase(nameString);

        _fileName = fileName;
        return fileName;
    }
}
