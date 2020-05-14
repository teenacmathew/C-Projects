# C-Sharp-Project-Automotive-Kiosk

GUI
Use a WPF control to allow a user select between one of three items: tires, windshield wipers,and car batteries.

Every item type has:
 - An item number – Hard code in a different item number for each type.
 - A cost – Windshield Wipers cost $15. Batteries cost $100. Tires cost $200.
 - A weight – Windshield Wipers weigh 1 kg. Batteries weigh 10 kgs. Tires weigh 30 kgs. 

 Use WPF controls allow the entering of the following information for all types of items: 
 - Item Name (string, you do not have to validate what string is given)

 Use WPF controls to allow the entering of the following information for only a specific itemtype:
 - Tires: Tire Model Name (string, don't have to validate what string), Wheel diameter (int)
 - Batteries: Voltage (int)
 - Windshield wipers: Length (int) 

 Classes
 Create a class called Item which contains all information common to all item types.

 Create a class for each of Tire, Windshield Wipers and Battery. Each of these classes shouldinherit from the Item class.Create an Interface called IShipItem which contains:
 - A method header ShipItem which returns an int.
 - A property Ship of type bool.

 This interface should be implemented by the Windshield Wiper and Battery classes. Forwindshield wipers, ShipItem returns $10, for Batteries, ShipItem returns $30. Tires cannot beshipped.

 Logic

 When the Submit option is selected, all the information entered by the user should be used tocreate an object of the appropriate type.All items submitted should be saved to an appropriate collection of your choice.When an item is purchased, its cost including shipping is added to the total which is displayedon the application. The shipping costs should be returned from the appropriate methods.

 IO
 When a user selects the Save control, the collection of items currently ordered should be savedto the hard drive in any format. The user must use the save control to save, do not auto saveafter   each   item   purchased. Save the file in the local directory (i.e. the folder that theapplication executable is running from, usually project\bin\Debug).

 When a user selects the Load control, the collection of items currently ordered should beoverwritten with whatever is in the save file. The total displayed on the GUI should be updatedto reflect the total that was loaded from the file.

 When the application is opened, you do not have to auto-load any previously saved files.LINQProvide the option to perform the following searches through

  LINQ:
  - Display the name of the item that has been purchased the most, along with the numberof items purchased. The search should query the current collection in runtime memory,not any saved file. If there is a tie for the most purchased item, display all the itemnames that are tied.
