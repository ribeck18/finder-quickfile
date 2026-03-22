class BuildFile
{
    private FileRequest _filerequest;

    public BuildFile(FileRequest request)
    {
        _filerequest = request;
    }

    public FileType CreateFile()
    {
        Dictionary<string, string> fileDict = _filerequest.GetFileDict();
        string extension = fileDict["extension"];
        //add several if statements here to check what file extension is in the dic. then build a file using the correct file type.
        FileType file;
        if (extension == "txt")
        {
            file = new TxtType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else if (extension == "md")
        {
            file = new MarkdownType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else if (extension == "py")
        {
            file = new PythonType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else
        {
            file = new CSharpType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
    }
}
