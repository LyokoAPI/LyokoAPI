
# Lyoko API
LyokoAPI is a simple tool written in C# to connect applications that have a Code Lyoko theme.

## Features
Currently the API is in it's child's shoes, so this feature list will be expanded.
### Events
 An event is a message that is sent to the whole application.
 As a developer, you can subscribe to events in order to run code when they occur.
 A subscribing method, or a class containing those methods are sometimes called Listeners.
 
All the events in the API can be called with :

    SpecificEvent.Call( //parameters here);
An event can be subscribed to with: 

    SpecificEvent.Subscribe( //delegate);
    
*A delegate is a predescribed method or code block with a specific return value and specific parameters*
You can find the needed delegates in the sections below
A delegate can also be a lamda, like so:

    TowerEvent.Subscribe( tower => Console.WriteLine(tower.Number);
  But it can also be a method that fits the delegate like this : 
  


If you want to remove the listener, you can do

    var listener = SpecificListener.Subscribe( //delegate );
    SpecificListener.UnsubScribe(listener);

#### TowerActivationEvent
Called when a tower is activated. 
Parameters: ITower
#### TowerDeactivationEvent
Called when a tower deactivates
Parameters: None
#### TowerHijackEvent
Called when one tower gets a new Activator (for example, Hopper taking over a tower)
Parameters: ITower, APIActivator old, APIActivator new
#### XanaAwakenEvent
Called when Xana starts an attack
Parameters: ITower (the tower that started the attack)
#### XanaDefeatEvent
Called when Xana is defeated
Parameters: None

### Classes And Interfaces
The API has a few interfaces and classes defined for your convenience. 
If you dont want to use these, you won't often have to. 
However, the events do require objects that implement the relevant interfaces.
You have a few choices:

 - Implementing the interfaces in your own classes
	  for example, your SpecialTower can implement ITower with:  `SpecialTower : ITower`
	  And everything will work as long as your SpecialTower has the required properties.
	  We recommend this if your structure isnt very different from ITower 
	  
 - Extending the existing classes
	 You can for example extend APITower and add/change functionality
	 as you please. We dont really recommend this.
	 
 - Creating the object on the fly
	For example, when you need to call a TowerActivation event, you can create an APITower based on your class. Most constructors allow for purely strings to be used. 
	Example: `TowerActivationEvent.Call("lyoko",this.SectorName,5)` will create a new tower with a sectorname equal to SectorName, and the virtualworld "Lyoko'".
	This is the safest option because there's no link back to your application. Although that might 		   be what you want

#### IVirtualWorld
Properties:
	string Name, bool isLyoko, List\<ISector> Sectors
#### ISector
Properties:
	string Name, List\<ITower> Towers, IVirtualWorld World
#### ITower
Properties:
	int Number, bool Activated, ISector Sector, APIActivator Activator

#### APIVirtualWorld : IVirtualWorld
	
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTMyMDg3NjE2LC0xNjkxODQxMzM0XX0=
-->