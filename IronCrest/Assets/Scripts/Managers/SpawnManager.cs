using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> unitsToSpawn;
    public List<GridStats> spawnTiles;
    public GameObject unitHolder;

    private void SpawnHeroes()
    {
        for(int i = 0; i < unitsToSpawn.Count; i++)
        {
            
            GameObject newUnit = Instantiate(unitsToSpawn[i], spawnTiles[i].gameObject.transform);
            newUnit.transform.localPosition = Vector3.zero;
            newUnit.transform.parent = unitHolder.transform;
            newUnit.GetComponent<Unit>().occupiedTile = spawnTiles[i];
            spawnTiles[i].unit = newUnit.GetComponent<Unit>();
            //Send the tile to playerPhase so it can add it to list
        }
    }

    
}
