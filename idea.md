# File Templates Idea

## FileType

- store the templates in the individual classes. This is a dict<string, string>
- - template name, template string
- Should also have a list of all the keys, and a getter for that list.

### Completed

## UserInterface

- after user selects the extension the combo box needs to update.
- Get the template list based on selected type.
- Build the combobox by iterating over the list.

## BuildFile

- will need to refactor this so that the file template is picked from the derived FileType class and not from FileRequest

## FileRequest

- Will need to remove the template options and store each of them in their respective classes.
