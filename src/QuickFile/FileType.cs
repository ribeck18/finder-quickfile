class FileType
{
    //Attributes
    private string _name;
    private string _extension;
    private string _content;
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
}
