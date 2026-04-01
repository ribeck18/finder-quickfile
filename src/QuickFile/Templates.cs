static class Templates
{
    private static Dictionary<string, string> _mdTemplates = new Dictionary<string, string>{
        {"helloWorld", "# Hello World"},
        {"readme", @"
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
"},
        {"blank", ""}
    };

    private static Dictionary<string, string> _txtTemplates = new Dictionary<string, string>{
        {"helloWorld", "Hello World"},
        {"requirments", @"# Requirements
# Format: package-name==version
# Use '==' to pin exact versions (recommended for production)
# Use '>=' to allow newer versions
# Example:
# requests==2.31.0
# numpy>=1.24.0

# Core Dependencies


# Development Dependencies


# Testing Dependencies

"},
        {"blank", ""}
    };

    private static Dictionary<string, string> _pyTemplates = new Dictionary<string, string>{
        {"helloWorld", @"hello_world = 'Hello World!'
print(hello_world)
            "},
        {"blank", ""}
    };

    private static Dictionary<string, string> _csTemplates = new Dictionary<string, string>{
        {"helloWorld", @"
using System;

namespace ProjectName
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}
"},
        {"blank", ""}
    };

    //Lists of the keys in each dictionary respectivly
    private static List<string> _mdKeyList = _mdTemplates.Keys.ToList();
    private static List<string> _txtKeyList = _txtTemplates.Keys.ToList();
    private static List<string> _pyKeyList = _pyTemplates.Keys.ToList();
    private static List<string> _csKeyList = _csTemplates.Keys.ToList();

    //Get the list of keys for the template dict.
    public static List<string> GetKeyList(string extension)
    {
        if (extension == "md")
        {
            return _mdKeyList;
        }
        else if (extension == "txt")
        {
            return _txtKeyList;
        }
        else if (extension == "py")
        {
            return _pyKeyList;
        }
        else
        {
            return _csKeyList;
        }
    }

    //Get the template dictionary depending on the extension argument.
    private static Dictionary<string, string> GetTemplateDict(string extension)
    {
        if (extension == "md")
        {
            return _mdTemplates;
        }
        else if (extension == "txt")
        {
            return _txtTemplates;
        }
        else if (extension == "py")
        {
            return _pyTemplates;
        }
        else
        {
            return _csTemplates;
        }
    }

    //Get the correct template string to give to the file request.
    public static string GetChosenTemplate(string extension, string key)
    {
        Dictionary<string, string> templateDict = GetTemplateDict(extension);

        string template = templateDict[key];

        return template;
    }


}
