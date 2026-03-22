class UserInterface
{
    //Attributes
    // var _ui;
    string _name;
    string _extension;
    int _templateChoice;

    //Constructor


    //Methods
    public void RunUI()
    {
        //run the UserInterface

    }
    public void SetTemplate(int templateChoice)
    {
        _templateChoice = templateChoice;
    }
    public void SetExtension(string extension)
    {
        _extension = extension;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public Dictionary<string, string> GetInputDict()
    {
        Dictionary<string, string> outputDict = new Dictionary<string, string>();

        outputDict.Add("name", _name);
        outputDict.Add("extesnsion", _extension);
        outputDict.Add("templateChoice", _templateChoice.ToString());

        return outputDict;
    }
}
