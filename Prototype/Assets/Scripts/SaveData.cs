using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //Saving progress
    [SerializeField] private PlayersUnitData _PlayersUnitData = new PlayersUnitData();

    public void SaveIntoJson()
    {
        string unit = JsonUtility.ToJson(_PlayersUnitData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayersUnitData.json", unit);
    }
}
[System.Serializable]
public class PlayersUnitData
{
    //Creates all of the data for the units in the game
    public List<Units> Units = new List<Units>();
}
[System.Serializable]
public class Units
{
    public string name;

    //Unit stats from the Unit script
    public int health;
    public int attack;
    public int defense;
    public int ac;
    public int crit;
    public int move;
    //Need to add different parts to the total
}