# PhotoAlbum_LeanTechnicalShowCase_Hayes

author: Zachary Hayes

Lean Technical Showcase, PhotoAlbum

## Getting Started

This is a **.Net** project I wrote using **Visual Studio 2017 Enterprise**. To run the program, open in Visual Studio and run the **EntryPoint.cs** class which contains the main method. Console will appear prompting user for an Album ID number. Enter a number, or enter "ALL" to write all photos to the console, or enter "EXIT" to end the program. The program will loop until user exits.

The VS solution should contain a project of unit tests which can be ran using CTRL+R then A.

## Classes

**EntryPoint.cs** contains the main method, which handles the user input.

**JsonPhotoDeserializer.cs** parses JSON into Photo objects using the JSON URL provided for this project and the album ID provided by the user. The deserializeJson method returns a list of Photo objects.

**Photo.cs** is a blueprint for the deserialized JSON photo objects.

**PhotoOrganizer.cs** handles a list of Photo objects. The printCollectionToConsole method is used to write a photo album to the console in the format suggested in the instructions for this project.


