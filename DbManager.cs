using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite4Unity3d;

public class DbManager : MonoBehaviour
{
    private SQLiteConnection _connection;

    private void Awake()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, "Inventory.db");
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        CreateTables();
    }

    private void CreateTables()
    {
        _connection.CreateTable<School>();
        _connection.CreateTable<Room>();
        _connection.CreateTable<Equipment>();
    }

    public List<School> LoadSchools()
    {
        return _connection.Table<School>().ToList();
    }

    public void SaveSchool(School school)
    {
        _connection.Insert(school);
    }

    public void UpdateSchool(School school)
    {
        _connection.Update(school);
    }

    public void DeleteSchool(School school)
    {
        _connection.Delete(school);
    }

    public List<Room> LoadRooms()
    {
        return _connection.Table<Room>().ToList();
    }

    public void SaveRoom(Room room)
    {
        _connection.Insert(room);
    }

    public void UpdateRoom(Room room)
    {
        _connection.Update(room);
    }

    public void DeleteRoom(Room room)
    {
        _connection.Delete(room);
    }

    public List<Equipment> LoadEquipment()
    {
        return _connection.Table<Equipment>().ToList();
    }

    public void SaveEquipment(Equipment equipment)
    {
        _connection.Insert(equipment);
    }

    public void UpdateEquipment(Equipment equipment)
    {
        _connection.Update(equipment);
    }

    public void DeleteEquipment(Equipment equipment)
    {
        _connection.Delete(equipment);
    }
}
