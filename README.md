# Cloner

## Why I build this project?
I use often the method contained in this library when I need to clone object. I thought it was time to create a NuGet out of this.

## What the project does?
It simply serializes the object into JSON and then deserialize it into a new object.

## How to use the project
Just call the Clone method on the object you want to clone. You can use the option builder to manage the setting of the serializer. 

The package uses the beautiful Newtonsoft.Json serializer.

### Example
```c#
var clone = myObject.Clone();
```
