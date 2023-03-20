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
    //Players name and in game currency trackers
    public string playerName;
    public int gold;
    //Creates all of the data for the units in the game
    public List<Units> Units = new List<Units>();
}
[System.Serializable]
public class Units
{
    public string unitName;
    public GameObject unitsModel;
    //Unit stats from the Unit script
    public int currentHealth;
    public int maximumHealth;
    public GameObject equippedWeapon;
    public int attackPower;
    public int attackRange;
    public int defense;
    public int ac;
    public int crit;
    public int move;
    //Need to add different parts to the total
}