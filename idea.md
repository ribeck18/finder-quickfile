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
- Note this actually can just be changed in the file request and the build file can stay the same.

## FileRequest

- Will need to remove the template options and store each of them in their respective classes.

## Question

- I would like the GetKeyList to be static as really the key list belongs to the class. However I don't think i can have a static method in an abstract class. What is the appropriate way to handle this??
- - I could make it static in each derived class but in think that defeats the purpose of an abstract method as it wouldn't be forced to implement it.
- - I could just keep the current setup and just instantiate the class in the constructor in User Interface.

### Question 2

- If i have a memebr variable that has the same name and type but just contains slightly different data. Can I create a universal getter, or do I need to do an abstract method and then type it out in each derived class.?
