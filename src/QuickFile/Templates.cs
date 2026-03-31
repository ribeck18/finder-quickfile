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
"}
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

"}
    };

    private static Dictionary<string, string> _pyTemplates = new Dictionary<string, string>{
        {"helloWorld", @"hello_world = 'Hello World!'
print(hello_world)
            "}
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
"}
    };

    //make the key lists here.
    private static string[] _mdKeyList = ["helloWorld", "readme"];
    private static string[] _txtKeyList = ["helloWorld"];
    private static string[] _pyKeyList = ["helloWorld"];
    private static string[] _csKeyList = ["helloWorld"];

    private static string[] GetKeyList(string extension)
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

    public static string GetChosenTemplate(string extension, string key)
    {
        // Returns the template as a string. 
        Dictionary<string, string> templateDict = GetTemplateDict(extension);

        string template = templateDict[key];

        return template;
    }


}
