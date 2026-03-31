class MarkdownType : FileType
{
    Dictionary<string, string> _templateDict = new Dictionary<string, string>{
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

    string[] _keyList = ["helloWorld", "readme"];

    public MarkdownType(string name, string extension, string template) : base(name, extension, template)
    {

    }

    public override string FormatFileName()
    {
        string nameString = $"{_name.ToUpper()}.{_extension}";

        return nameString;
    }

    public override string[] GetKeyList()
    {
        return _keyList;
    }
}
