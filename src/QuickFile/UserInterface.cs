using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Platform;
using Avalonia.Layout;

class UserInterface : Window
{
    //Notes: make all of the elemenets a field in the class. Then Each one should have a build method (like a setter). Then in the Constructor each build should be called.
    //The purpose of this is so that when save button is pressed it can pull the data from each text box etc.
    private TextBox _fileNameEntry = new TextBox();
    private ComboBox _typeSelection = new ComboBox();
    private ComboBox _templateSelection = new ComboBox();
    private Button _saveButton = new Button();
    private Dictionary<string, string> _fileRequestDict = new Dictionary<string, string>();


    public UserInterface()
    {
        //Window Settings
        Title = "Quick File";
        Width = 400;
        Height = 300;
        TransparencyLevelHint = new[] { WindowTransparencyLevel.AcrylicBlur };
        ExtendClientAreaToDecorationsHint = true;
        ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.NoChrome;
        SystemDecorations = SystemDecorations.BorderOnly;

        Content = BuildWindow();
    }

    private Control BuildWindow()
    {
        Grid root = new Grid();
        //Defines the rows of the grid -- 2 rows, one for title bar, one for content.
        root.RowDefinitions = RowDefinitions.Parse("40,*");

        Control titleBar = BuildTitleBar();
        Grid.SetRow(titleBar, 0);

        Control content = BuildWindowContent();
        Grid.SetRow(content, 1);

        root.Children.Add(titleBar);
        root.Children.Add(content);

        return root;
    }
    private Control BuildWindowContent()
    {
        //Define/build the text elements
        TextBlock fileName = new TextBlock { Text = "File Name:" };
        TextBlock extension = new TextBlock { Text = "File Type:" };
        TextBlock template = new TextBlock { Text = "Template:" };

        //organize all of the elemenets
        StackPanel stackpanel = new StackPanel();
        stackpanel.Spacing = 10;
        stackpanel.Margin = new Avalonia.Thickness(20);

        stackpanel.Children.Add(fileName);
        stackpanel.Children.Add(BuildFileNameEntry());
        stackpanel.Children.Add(extension);
        stackpanel.Children.Add(BuildTypeSelection());
        stackpanel.Children.Add(template);
        stackpanel.Children.Add(BuildTemplateSelection());
        stackpanel.Children.Add(BuildSaveButton());

        return stackpanel;

    }

    private TextBox BuildFileNameEntry()
    {
        _fileNameEntry.Watermark = "Enter file name...";
        _fileNameEntry.MaxLength = 50;

        return _fileNameEntry;
    }

    private ComboBox BuildTypeSelection()
    {
        _typeSelection.Items.Add("md");
        _typeSelection.Items.Add("txt");
        _typeSelection.Items.Add("py");
        _typeSelection.Items.Add("cs");
        _typeSelection.SelectedIndex = 0;

        //Wires to the template selection combobox so that it populates depending on the currently selected item.
        _typeSelection.SelectionChanged += OnTypeSelectionChanged;

        return _typeSelection;
    }

    //Event handler for the type selection change.
    private void OnTypeSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        string selectedType = _typeSelection.SelectedItem?.ToString() ?? "";
        List<string> templateKeys = Templates.GetKeyList(selectedType);

        //clear and repopulate the template combobox.
        _templateSelection.Items.Clear();
        foreach (string templateKey in templateKeys)
        {
            _templateSelection.Items.Add(templateKey);
        }

        //Reset the currently selected template to the first one in the list
        _templateSelection.SelectedIndex = 0;
    }

    //Builds the template selection combo box. However this it populated only using the OnTypeSelectionChanged Event handler.
    private ComboBox BuildTemplateSelection()
    {
        OnTypeSelectionChanged(null, null!);
        _templateSelection.SelectedItem = 0;

        return _templateSelection;
    }

    // Builds the save button. OnSaveClicked is ran when button pressed.
    private Button BuildSaveButton()
    {
        _saveButton.Content = "Save";
        _saveButton.Click += OnSaveClick;

        return _saveButton;
    }

    //Save button click event. Gets all of the data from the UI and calls AssembleDict function.
    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        string name = _fileNameEntry.Text ?? "";
        string extension = _typeSelection.SelectedItem?.ToString() ?? "";
        string template = _templateSelection.SelectedItem?.ToString() ?? "helloWorld";
        //for debug
        Logger.Log($"template key used: {template}");

        AssembleDict(name, extension, template);
    }

    //Build a dictionary with all the user entered data so that A FileRequest can be made.
    private void AssembleDict(string name, string extension, string template)
    {
        _fileRequestDict.Add("name", name);
        _fileRequestDict.Add("extension", extension);
        _fileRequestDict.Add("template", template);

        OnSaveClicked?.Invoke(_fileRequestDict);
    }

    public event Action<Dictionary<string, string>>? OnSaveClicked;

    public Dictionary<string, string> GetFileRequestDict()
    {
        return _fileRequestDict;
    }

    //These are for the layout of the page and macOS Styling.

    //This is the top bar that has the close btn and the min/max btn
    private Control BuildTitleBar()
    {
        Panel titleBar = new Panel
        {
            Background = new SolidColorBrush(Color.Parse("#ECECEC"))
        };

        StackPanel trafficLights = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 9,
            Margin = new Avalonia.Thickness(12, 0, 0, 0),
            VerticalAlignment = VerticalAlignment.Center
        };

        trafficLights.Children.Add(MakeTrafficLights("#FF5F57", () => Close()));
        // trafficLights.Children.Add(MakeTrafficLights("FFBD2E", () => WindowState.Minimized));
        // trafficLights.Children.Add(MakeTrafficLights("28C840", () => WindowState.FullScreen));

        titleBar.Children.Add(trafficLights);

        return titleBar;
    }
    private Control MakeTrafficLights(string color, Action onClick)
    {
        Button btn = new Button
        {
            Width = 12,
            Height = 12,
            CornerRadius = new Avalonia.CornerRadius(6),
            Background = new SolidColorBrush(Color.Parse(color)),
            BorderThickness = new Avalonia.Thickness(0),
            Padding = new Avalonia.Thickness(0)
        };

        btn.Click += (_, _) => onClick();
        return btn;
    }
}
