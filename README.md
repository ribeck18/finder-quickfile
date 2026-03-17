# QuikFile
A simple application to quickly add simple files, such as .txt or .md, when browsing folders in MacOS Finder.


# Class Diagram
```mermaid
classDiagram
  class File {
    -_extension: str
    -_name: str
    -_content: str
    +FileType(extension, name, content)
    +GetTemplate()
    +GetFileName()
    +GetExtension()
    +SetTemplate()
  }

  class MarkdownType {
    -_templates: List~str~
    +GetTemplate()
    +SetTemplate()
  }

  class TxtType {
    -_templates: List~str~
    +GetTemplate()
    +SetTemplate()
  }

  class PythonType {
    -_templates: List~str~
    +GetTemplate()
    +SetTemplate()
  }

  class DotnetType {
    -_templates: List~str~
    +GetTemplate()
    +SetTemplate()
  }

  File <|-- MarkdownType
  File <|-- TxtType
  File <|-- PythonType
  File <|-- DotnetType

  class UserInterface {
    -_ui
    -_name: str
    -_extension: str
    -_template: int
    +GetTemplateOptions()
    +SetTemplate()
    +SetExtension()
    +SetName()
    +GetInputDict()
    +RunUI()
  }

  class FileRequest {
    -_name: str
    -_extension: str
    -_templates: dict~str, dict~int, str~~
    -_templateChoice: int
    -_path: str
    +SetTemplate()
    +SetPath()
    +GetName()
    +GetExtension()
    +GetTemplate()
    +GetPath()
    +GetTemplateOptions()
  }

  class BuildFile {
    -_fileRequest: FileRequest
    -_fileType: File
    +SetFileType()
    +BuildFile()
  }

  class Controller {
    +RunUI()
    +OrderFile()
    +BuildFile()
    +DeliverFile()
  }

  Controller --> UserInterface
  UserInterface --> Controller
  UserInterface --> FileRequest
  Controller --> FileRequest
  FileRequest --> Controller
  Controller --> BuildFile
  BuildFile --> Controller
```