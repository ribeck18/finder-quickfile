# QuickFile — Program Flow

```mermaid
flowchart TD
    A([macOS Finder\nKeyboard Shortcut]) -->|passes folder path as arg| B

    subgraph Startup
        B["Program.Main(args)"]
        B --> C["BuildAvaloniaApp()\n.StartWithClassicDesktopLifetime()"]
        C --> D["App.Initialize()\nApply FluentTheme"]
        D --> E["App.OnFrameworkInitializationCompleted()"]
        E --> F["new Controller(args)\n— extracts _path from args"]
        F --> G["new UserInterface()\n— builds StackPanel with controls"]
        G --> H["controller.RunUI()\n— wires OnSaveClicked → SaveAction"]
        H --> I["desktop.MainWindow = controller.GetWindow()"]
        I --> J([Window displayed to user])
    end

    subgraph UserInteraction["User Interaction"]
        J --> K["User enters filename\nin TextBox"]
        K --> L["User selects file type\nComboBox: md, txt, py, cs"]
        L --> M["User selects template\nComboBox: 1, 2, ..."]
        M --> N["User clicks Save"]
    end

    subgraph UIEvent["UserInterface — OnSaveClick()"]
        N --> O["Read: name, extension, template\nfrom controls"]
        O --> P["AssembleDict()\nBuild _fileRequestDict\n{name, extension, template}"]
        P --> Q["Invoke OnSaveClicked event\n→ passes dict to Controller"]
    end

    subgraph ControllerSave["Controller — SaveAction() / SaveFile()"]
        Q --> R["_window.Close()"]
        Q --> S["SaveFile(userEntryDict)"]
        S --> T["RequestFile(dict)\n→ new FileRequest(name, ext, templateChoice, path)"]
        T --> U["new BuildFile(fileRequest)\n.CreateFile()"]
    end

    subgraph Factory["BuildFile — CreateFile() Factory"]
        U --> V{extension?}
        V -->|md|  W["new MarkdownType()\nFormatFileName: UPPERCASE\nTemplates: helloWorld, readme"]
        V -->|txt| X["new TxtType()\nFormatFileName: snake_case\nTemplates: helloWorld"]
        V -->|py|  Y["new PythonType()\nFormatFileName: snake_case\nTemplates: helloWorld"]
        V -->|cs\nor default| Z["new CSharpType()\nFormatFileName: PascalCase\nTemplates: helloWorld"]
    end

    subgraph Output["Controller — Write to Disk"]
        W & X & Y & Z --> AA["file.GetTemplate()\n→ template content string"]
        AA --> AB["file.GetFileName()\n→ FileType.FormatFileName()\n→ formatted filename"]
        AB --> AC["Build full path:\n_path + '/' + fileName"]
        AC --> AD["File.WriteAllText(path, content)"]
        AD --> AE([File created in\nFinder directory])
    end
```

## Class Responsibilities

| Class | Role |
|---|---|
| `Program` | Entry point; bootstraps Avalonia |
| `App` | Framework init; creates Controller and sets main window |
| `Controller` | Orchestrator; wires UI events, drives save workflow |
| `UserInterface` | Avalonia `Window`; renders controls, emits `OnSaveClicked` event |
| `FileRequest` | Data container for user inputs (name, extension, template index, path) |
| `BuildFile` | Factory; maps extension string → concrete `FileType` subclass |
| `FileType` | Abstract base; defines `FormatFileName()`, `GetTemplate()`, `GetFileName()` |
| `TxtType` | Concrete type; snake_case naming, plain-text templates |
| `MarkdownType` | Concrete type; UPPERCASE naming, helloWorld + readme templates |
| `PythonType` | Concrete type; snake_case naming, Python boilerplate template |
| `CSharpType` | Concrete type; PascalCase naming, C# boilerplate template |
| `Logger` | Utility; appends timestamped messages to `~/quickfile.log` |
