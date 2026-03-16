using System.Dynamic;

class FileRequest
{
    private string _filePath;
    private string _fileExtension;
    private string _fileName;
    private string _fileContents;

    public FileRequest(string path, string extension, string name, string contents)
    {
        _filePath = path;
        _fileExtension = extension;
        _fileName = name;
        _fileContents = contents;
    }

    public Dictionary<string, string> GetFile() { }
}
