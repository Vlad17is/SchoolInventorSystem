using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Reference to the database manager
    private DbManager  dbManager;
    
    // List of schools
    private List<School> schools;
    
    // List of rooms
    private List<Room> rooms;
    
    // List of equipment
    private List<Equipment> equipment;
    
    // Initialize the database manager and load data from the database
    private void Start()
    {
        dbManager = GetComponent<DbManager>();
        schools = dbManager.LoadSchools();
        rooms = dbManager.LoadRooms();
        equipment = dbManager.LoadEquipment();
    }
    
    // Add a new school
    public void AddSchool(string name)
    {
        int id = schools.Count + 1;
        School school = new School(id, name);
        schools.Add(school);
        dbManager.SaveSchool(school);
    }
    
    // Edit an existing school
    public void EditSchool(School school)
    {
        dbManager.UpdateSchool(school);
    }
    
    // Delete an existing school
    public void DeleteSchool(School school)
    {
        schools.Remove(school);
        dbManager.DeleteSchool(school);
    }
    
    // Get a list of all schools
    public List<School> GetSchools()
    {
        return schools;
    }
    
    // Add a new room
    public void AddRoom(string name)
    {
        int id = rooms.Count + 1;
        Room room = new Room(id, name);
        rooms.Add(room);
        dbManager.SaveRoom(room);
    }
    
    // Edit an existing room
    public void EditRoom(Room room)
    {
        dbManager.UpdateRoom(room);
    }
    
    // Delete an existing room
    public void DeleteRoom(Room room)
    {
        rooms.Remove(room);
        dbManager.DeleteRoom(room);
    }
    
    // Get a list of all rooms
    public List<Room> GetRooms()
    {
        return rooms;
    }
    
    // Add a new piece of equipment
    public void AddEquipment(string name, int schoolId, string owner, System.DateTime dateReceived, string fromWhom, int roomId, int quantity)
    {
        int id = equipment.Count + 1;
        Equipment newEquipment = new Equipment(id, name, schoolId, owner,dateReceived, fromWhom, roomId, quantity);
        equipment.Add(newEquipment);
        dbManager.SaveEquipment(newEquipment);
    }
    // Edit an existing piece of equipment
    public void EditEquipment(Equipment equipment)
    {
        dbManager.UpdateEquipment(equipment);
    }

    // Delete an existing piece of equipment
    public void DeleteEquipment(Equipment equipment)
    {
        this.equipment.Remove(equipment);
        dbManager.DeleteEquipment(equipment);
    }

    // Get a list of all equipment
    public List<Equipment> GetEquipment()
    {
        return equipment;
    }

    // Get a list of all equipment for a particular school
    public List<Equipment> GetEquipmentForSchool(int schoolId)
    {
        List<Equipment> equipmentForSchool = new List<Equipment>();
        foreach (Equipment e in equipment)
        {
            if (e.schoolId == schoolId)
            {
                equipmentForSchool.Add(e);
            }
        }
        return equipmentForSchool;
    }

    // Get a list of all equipment for a particular room
    public List<Equipment> GetEquipmentForRoom(int roomId)
    {
        List<Equipment> equipmentForRoom = new List<Equipment>();
        foreach (Equipment e in equipment)
        {
            if (e.roomId == roomId)
            {
                equipmentForRoom.Add(e);
            }
        }
        return equipmentForRoom;
    }

    // Generate random data for schools, rooms, and equipment
    public void GenerateRandomData()
    {
        // Create a random number generator
        System.Random random = new System.Random();

        // Generate 10 schools with random names
        for (int i = 1; i <= 10; i++)
        {
            string schoolName = "School " + i;
            schools.Add(new School(i, schoolName));
            dbManager.SaveSchool(new School(i, schoolName));
        }

        // Generate 50 rooms with random names and school IDs
        for (int i = 1; i <= 50; i++)
        {
            string roomName = "Room " + i;
            int schoolId = random.Next(1, 11);
            rooms.Add(new Room(i, roomName));
            dbManager.SaveRoom(new Room(i, roomName));
        }

        // Generate 1000 pieces of equipment with random names, school IDs, owners, dates received, from whom, room IDs, and quantities
        for (int i = 1; i <= 1000; i++)
        {
            string equipmentName = "Equipment " + i;
            int schoolId = random.Next(1, 11);
            string owner = "Owner " + i;
            System.DateTime dateReceived = System.DateTime.Now.AddDays(-random.Next(1, 365));
            string fromWhom = "From Whom " + i;
            int roomId = random.Next(1, 51);
            int quantity = random.Next(1, 11);
            equipment.Add(new Equipment(i, equipmentName, schoolId, owner, dateReceived, fromWhom, roomId, quantity));
            dbManager.SaveEquipment(new Equipment(i, equipmentName, schoolId, owner, dateReceived, fromWhom, roomId, quantity));
        }
    }
}
