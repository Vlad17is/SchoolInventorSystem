using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public int id;
    public string name;
    public int schoolId;
    public string owner;
    public System.DateTime dateReceived;
    public string fromWhom;
    public int roomId;
    public int quantity;
      // Public parameterless constructor
    public Equipment() { }
    public Equipment(int id, string name, int schoolId, string owner, System.DateTime dateReceived, string fromWhom, int roomId, int quantity)
    {
        this.id = id;
        this.name = name;
        this.schoolId = schoolId;
        this.owner = owner;
        this.dateReceived = dateReceived;
        this.fromWhom = fromWhom;
        this.roomId = roomId;
        this.quantity = quantity;
    }
}
