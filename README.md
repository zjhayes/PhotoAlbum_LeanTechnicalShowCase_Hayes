# PhotoAlbum_LeanTechnicalShowCase_Hayes

author: Zachary Hayes
version: 2

Lean Technical Showcase, PhotoAlbum

## Getting Started

This is a **.Net** project I wrote using **Visual Studio 2017 Enterprise**. The program can now be run from the VS console or command line. 

**To run from console**, open in Visual Studio and run the **Program.cs** class which contains the main method. Console will appear prompting user for an Album ID number. Enter a number, or enter "ALL" to write all photos to the console, or enter "EXIT" to end the program. The program will loop until user exits.

**To run from command line**, you can execute **PhotoAlbum.exe** located in "PhotoAlbum > bin > Debug" along with an integer argument to designate the album to be displayed *(ex. > PhotoAlbum 5)*. The program will run once.

The VS solution should contain a project of unit tests which can be ran using CTRL+R then A.

## Classes

**Program.cs** contains the main method, determines whether to run console or command line program.

**EntryPoint.cs** determines how the user input should be handled and runs the main program.

**JsonPhotoDeserializer.cs** parses JSON into Photo objects using the JSON URL provided for this project and the album ID provided by the user. The deserializeJson method returns a list of Photo objects.

**Photo.cs** is a blueprint for the deserialized JSON photo objects.

**PhotoOrganizer.cs** handles a list of Photo objects. The printCollectionToConsole method is used to write a photo album to the console in the format suggested in the instructions for this project.

**UserInput.cs** is an instance of the IUserInput interface, and sets the input method so it reads off the console.

## Interfaces

**IJsonDeserializer** used mainly for dependency injection to ensure EntryPoint interacts with the deserializer.

**IUserInput** set the method by which the program receives input.
