# QuikFile
A simple application to quickly add simple files, such as .txt or .md, when browsing folders in MacOS Finder.


# Class Diagram
```mermaid
classDiagram
  class Program {
    +Main(args: string[])
    +BuildAvaloniaApp() AppBuilder
  }

  class App {
    +Initialize()
    +OnFrameworkInitializationCompleted()
  }

  class Controller {
    -_path: string
    -_window: UserInterface
    +Controller(args: string[])
    +RunUI()
    +GetWindow() UserInterface
    -SaveAction(userEntryDict: Dictionary~string,string~)
    -RequestFile(userEntryDict: Dictionary~string,string~) FileRequest
    -BuildFile(userEntryDict: Dictionary~string,string~) FileType
    -SaveFile(userEntryDict: Dictionary~string,string~)
  }

  class UserInterface {
    -_fileNameEntry: TextBox
    -_typeSelection: ComboBox
    -_templateSelection: ComboBox
    -_saveButton: Button
    -_fileRequestDict: Dictionary~string,string~
    +UserInterface()
    -BuildFileNameEntry() TextBox
    -BuildTypeSelection() ComboBox
    -BuildTemplateSelection() ComboBox
    -BuildSaveButton() Button
    -OnSaveClick(sender: object?, e: RoutedEventArgs)
    -AssembleDict(name: string, extension: string, template: string)
    +OnSaveClicked: Action~Dictionary~string,string~~
    +GetFileRequestDict() Dictionary~string,string~
  }

  class FileRequest {
    -_name: string
    -_extension: string
    -_templateOptions: Dictionary~string,Dictionary~int,string~~
    -_templateChoice: int
    -_path: string
    +FileRequest(name: string, extension: string, templateChoice: int, path: string)
    +GetTemplate() string
    +GetPath() string
    +GetFileDict() Dictionary~string,string~
  }

  class BuildFile {
    -_filerequest: FileRequest
    +BuildFile(fileRequest: FileRequest)
    +CreateFile() FileType
  }

  class FileType {
    #_name: string
    #_extension: string
    -_template: string
    +FileType(name: string, extension: string, template: string)
    +GetName() string
    +GetExtension() string
    +GetFileName() string
    +FormatFileName()* string
    +GetTemplate() string
    #ToSnakeCase(input: string)$ string
    #ToPascalCase(input: string)$ string
  }

  class TxtType {
    +TxtType(name: string, extension: string, template: string)
    +FormatFileName() string
  }

  class MarkdownType {
    +MarkdownType(name: string, extension: string, template: string)
    +FormatFileName() string
  }

  class PythonType {
    +PythonType(name: string, extension: string, template: string)
    +FormatFileName() string
  }

  class CSharpType {
    +CSharpType(name: string, extension: string, template: string)
    +FormatFileName() string
  }

  class Tui {
    -_name: string
    -_extension: string
    -_templateChoice: int
    -SetName(name: string)
    -SetExtension(extension: string)
    -SetTemplateChoice(templateChoice: int)
    +GetName() string
    +GetExtension() string
    +GetTemplateChoice() int
    +RunTui()
  }

  Program ..> App : configures
  App ..> Controller : creates
  Controller *-- UserInterface : owns
  Controller ..> FileRequest : creates
  Controller ..> BuildFile : uses
  BuildFile --> FileRequest : reads
  BuildFile ..> FileType : creates
  FileType <|-- TxtType
  FileType <|-- MarkdownType
  FileType <|-- PythonType
  FileType <|-- CSharpType
```
