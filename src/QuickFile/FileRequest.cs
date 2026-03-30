class FileRequest
{
    //Attributes
    private string _name;
    private string _extension;
    private Dictionary<string, Dictionary<int, string>> _templateOptions;
    private int _templateChoice;
    private string _path;

    public FileRequest(string name, string extension, int templateChoice, string path)
    {
        _name = name;
        _extension = extension;
        _templateChoice = templateChoice;
        _path = path;
        _templateOptions = new Dictionary<string, Dictionary<int, string>>
        {
            {
                "md",
                new Dictionary<int, string> {{1, "# MARKDOWN HEADER"}, {2, @"
# Project Title

## Overview
A brief description of what this project does and who it's for.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Installation
Follow these steps to get the project running locally:

1. Clone the repository
2. Install dependencies
3. Configure environment variables
4. Run the application

## Usage
Explain how to use the project here. You can include code examples like this:
```python
def hello_world():
    print(""Hello, World!"")
```

Or inline code like `print(""Hello"")` within a sentence.

## Features
- **Bold text** for emphasis
- *Italic text* for lighter emphasis
- ~~Strikethrough~~ for removed content
- [Hyperlinks](https://example.com)

## Tables

| Column A | Column B | Column C |
|----------|----------|----------|
| Row 1    | Data     | Data     |
| Row 2    | Data     | Data     |

## Blockquotes
> This is a blockquote. Useful for callouts, warnings, or quoted text.

## Images
![Alt text](https://example.com/image.png)

## Contributing
Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
"}}
            },
            {
            "txt",
                new Dictionary<int, string> { { 1, "Text File" } }
            },
            {
            "py",
                new Dictionary<int, string> { { 1, "print('Hello World')" } }
            },
            {
            "cs",
                new Dictionary<int, string> { { 1, "Console.WriteLine('Hello World')" } }
            }
    };
    }

    //methods
    public string GetTemplate()
    {
        string selectedTemplate = _templateOptions[_extension][_templateChoice];
        return selectedTemplate;
    }

    public string GetPath()
    {
        return _path;
    }

    public Dictionary<string, string> GetFileDict()
    {
        Dictionary<string, string> fileDict = new Dictionary<string, string>();
        fileDict.Add("name", _name);
        fileDict.Add("extension", _extension);
        fileDict.Add("template", GetTemplate());
        fileDict.Add("path", _path);

        return fileDict;
    }
}
