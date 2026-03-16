# Needs

- UI to add a select a file type and name a file
    - dropdown to select the file extension
    - Textbox to enter a file name
- Shortcut that can be entered while browsing finder to initiate the UI
    - something like cmd shift q
- Add file to whatever folder was open when the shortcut was entered
    - Pass the file path to the project.

# Classes

## Program

The basic program that runs the app. Kind of like main.py

## Controller

Simple logic/connection point. ex.(run UI → init FileRequest → BuildFile)

make sure that this is just a manager, it doesn’t do any building or requesting.

actions:

- Opens the UI
- Places an order (FileRequest)
- Delivers order (BuildFile)

## FileType

Contains the file format and any optional templates for the file.

Potentially allow for a body so that a user could add things they want in the file.

Contains: 

- extension information
- templates
- naming conventions/name formatting
- UI Name (what the user will see)

### MarkDownType

derived class of FileType

### TxtType

derived class of FileType

### PythonType

derived class of FileType

### CSharpType

derived class of FileType

## UserInterface

Visual way to add files, has a dropdown to select file types, and has a text box to name files. 

Potentially a dropbox for any templates to use.

This is a place where a user can essentially place an order, kind of like calling the pizza place to place an order.

needs:

- Dropdown file type selection
    - Get a readable name from FileType
- Text Box for name
- Template selection

## BuildFile

Gets info from the FileRequest Object and actually adds the file to the Finder

- performs disk operations

## FileRequest

Gets the user input and selects a file type based on the input, and puts together everything for the file. This is like the written Pizza order, so that BuildFile knows what Pizza to bake.

Contains: 

- File path
- FileType
- File name
- File contents

# MacOS Shortcut

## Run application

- Perhaps use a macOS shortcut or autmation to run the app.

## Add file to Finder

- Have the shortcut or autmator get the current finder path, and give it to the app.

# UI

## Framework

Use Avalonia to create the UI.