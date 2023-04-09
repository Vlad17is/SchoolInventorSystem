using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School
{
    public int id;
    public string name;
       // Public parameterless constructor
    public School() { }

    public School(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
