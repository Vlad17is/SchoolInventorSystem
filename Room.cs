using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int id;
    public string name;

     // Public parameterless constructor
    public Room() { }
    public Room(int id, string name)
    {
        this.id = id;
        this.name = name;

    }
}
