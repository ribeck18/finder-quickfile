class FileRequest
{
    //Attributes
    private string _name;
    private string _extension;
    private int _templateChoice;
    private string _path;

    public FileRequest(string name, string extension, int templateChoice, string path)
    {
        _name = name;
        _extension = extension;
        _templateChoice = templateChoice;
        _path = path;
    }

    //methods
    private string GetTemplateOptions()
    {
        string type = _extension;
        Dictionary<string, string> templateDict = new Dictionary<string, string>();
        if (type == "md")
        {
        }
    }

    public string GetTemplate()
    {
        string selectedTemplate = _templateOptions[_extension][_templateChoice];
        return selectedTemplate;
    }

    public string GetPath()
    {
        return _path;
    }

    public Dictionary<string, string> GetFileDict()
    {
        Dictionary<string, string> fileDict = new Dictionary<string, string>();
        fileDict.Add("name", _name);
        fileDict.Add("extension", _extension);
        fileDict.Add("template", GetTemplate());
        fileDict.Add("path", _path);

        return fileDict;
    }
}
