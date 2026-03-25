using System.IO;


class Controller
{
    private string _path = "files/";
    private UserInterface _window;

    public Controller()
    {
        _window = new UserInterface();
    }

    public void RunUI()
    {
        //When the save button is clicked it also runs SaveAction.
        _window.OnSaveClicked += SaveAction;
    }
    public UserInterface GetWindow()
    {
        return _window;
    }

    private void SaveAction(Dictionary<string, string> userEntryDict)
    {
        _window.Close();
        SaveFile(userEntryDict);
    }
    private FileRequest RequestFile(Dictionary<string, string> userEntryDict)
    {
        //I need to use the info from the UI to build the fileRequest.
        FileRequest fileRequest = new FileRequest(userEntryDict["name"], userEntryDict["extension"], int.Parse(userEntryDict["template"]), _path);
        return fileRequest;
    }

    private FileType BuildFile(Dictionary<string, string> userEntryDict)
    {
        BuildFile buildFile = new BuildFile(RequestFile(userEntryDict));
        FileType file = buildFile.CreateFile();

        return file;
    }

    private void SaveFile(Dictionary<string, string> userEntryDict)
    {
        FileType file = BuildFile(userEntryDict);
        string fileContent = file.GetTemplate();
        string path = $"{_path}/{file.GetFileName()}";
        //this is for debugging
        Console.WriteLine(path);

        File.WriteAllText(path, fileContent);
    }

}
