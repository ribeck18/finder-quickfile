using System.IO;

class Controller
{
    private string _path;
    private UserInterface _window;

    public Controller(string[] args)
    {
        //if the argument is not passed through or is blank when user runs the program it will add the file @ /files
        if (args.Length > 0)
        {
            _path = args[0].Trim().TrimEnd('/');
        }
        else
        {
            _path = "files";
        }

        _window = new UserInterface();
    }

    public void RunUI()
    {
        //When the save button is clicked it also runs SaveAction.
        _window.OnSaveClicked += SaveAction;
        //UI runs until the save action is taken. Then it closes the ui
    }

    public UserInterface GetWindow()
    {
        return _window;
    }

    private void SaveAction(Dictionary<string, string> userEntryDict)
    {
        //closes the UI saves the file.
        _window.Close();
        SaveFile(userEntryDict);
    }

    private FileRequest RequestFile(Dictionary<string, string> userEntryDict)
    {
        //Assembles a file request using user input
        FileRequest fileRequest = new FileRequest(
            userEntryDict["name"],
            userEntryDict["extension"],
            userEntryDict["template"],
            _path
        );
        return fileRequest;
    }

    private FileType BuildFile(Dictionary<string, string> userEntryDict)
    {
        //Uses the file request to build the FileType derived class.
        BuildFile buildFile = new BuildFile(RequestFile(userEntryDict));
        FileType file = buildFile.CreateFile();

        return file;
    }

    private void SaveFile(Dictionary<string, string> userEntryDict)
    {
        // Writes the file to the path argument.
        FileType file = BuildFile(userEntryDict);
        string fileContent = file.GetTemplate();
        string path = $"{_path}/{file.GetFileName()}";

        File.WriteAllText(path, fileContent);
    }
}
