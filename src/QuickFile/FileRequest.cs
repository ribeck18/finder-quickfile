class FileRequest
{
    //Attributes
    private string _name;
    private string _extension;
    private Dictionary<string, Dictionary<int, string>> _templateOptions;
    private int _templateChoice;
    private string _path;

    public FileRequest(string name, string extension)
    {
        _name = name;
        _extension = extension;
        _templateOptions = new Dictionary<string, Dictionary<int, string>>{
            { "MarkDown", new Dictionary<int, string>{ { 1, "# MARKDOWN HEADER"} } }
        };
    }

    //methods
    public int SetTemplate(string extension, int templateChoice)
    {
        dictChoice =
    }

    public string SetPath(string path)
    {
        _path = path;
        return path;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetExtension()
    {
        return _extension;
    }

    public int GetTemplate()
    {
        // need to return a selection from the template options using templateChoice as the key.
    }
    public string GetPath()
    {
        return _path;
    }
}
