using System.IO;


class Controller
{
    private string _path;
    private Tui _tui;

    public Controller(string path, Tui tui)
    {
        _path = path;
        _tui = tui;
    }

    private void RunUI()
    {
        // _UI.RunUI();
        _tui.RunTui();

        //I need to make this so that it only returns when the ui is complete so that the next thing can begin.
    }
    private FileRequest RequestFile()
    {
        FileRequest fileRequest = new FileRequest(_tui.GetName(), _tui.GetExtension(), _tui.GetTemplateChoice(), _path);
        return fileRequest;
    }

    private FileType BuildFile()
    {
        BuildFile buildFile = new BuildFile(RequestFile());
        FileType file = buildFile.CreateFile();

        return file;
    }

    private void SaveFile()
    {
        FileType file = BuildFile();
        string fileContent = file.GetTemplate();
        string path = $"{_path}/{file.GetFileName()}";

        File.WriteAllText(path, fileContent);
    }

    public void RunController()
    {

        //Note: IDK if this will actually be a problem but I may need to find a way to make sure SaveFile Doesn't run until the UI is done.
        // bool isRunning;
        RunUI();
        SaveFile();
        //
        // if (isRunning == false)
        // {
        //     SaveFile();
        // }
    }
}
