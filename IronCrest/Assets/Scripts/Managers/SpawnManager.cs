using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  

    public List<GameObject> playersToSpawn;

    public List<GameObject> enemiesToSpawn;


    public List<GridStats> playerSpawnTiles;

    public List<GridStats> enemySpawnTiles;



    public GameObject playerUnitHolder;

    public GameObject enemyUnitHolder;

    public List<PlayerSelectButton> playerSelectButtons;


    private void Start() 
    {
        if(GameManager.Instance.State == GameState.PlayerSpawn) 
        {
          StartCoroutine(SpawnHeroes());
        }
    }

    private IEnumerator SpawnHeroes()
    {
        List<Unit> playerUnits = new List<Unit>();
        for(int i = 0; i < playersToSpawn.Count; i++)
        {
            
            GameObject newUnit = Instantiate(playersToSpawn[i], playerSpawnTiles[i].gameObject.transform);
            newUnit.transform.localPosition = Vector3.zero;
            newUnit.transform.parent = playerUnitHolder.transform;
            newUnit.GetComponent<Unit>().occupiedTile = playerSpawnTiles[i];
            playerSpawnTiles[i].unit = newUnit.GetComponent<Unit>();
            playerUnits.Add(newUnit.GetComponent<Unit>());
            playerSelectButtons[i].owner = newUnit.GetComponent<Unit>();
            //Send the tile to playerPhase so it can add it to list
        }

        yield return null;

        EventManager.RecivePlayerUnitList(playerUnits);

        yield return null;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() {
        List<Unit> enemyUnits = new List<Unit>();
        for(int i = 0; i < enemiesToSpawn.Count; i++)
        {
            
            GameObject newUnit = Instantiate(enemiesToSpawn[i], enemySpawnTiles[i].gameObject.transform);
            newUnit.transform.localPosition = Vector3.zero;
            newUnit.transform.parent = enemyUnitHolder.transform;
            newUnit.GetComponent<Unit>().occupiedTile = enemySpawnTiles[i];
            enemySpawnTiles[i].unit = newUnit.GetComponent<Unit>();
            enemyUnits.Add(newUnit.GetComponent<Unit>());
            //Send the tile to playerPhase so it can add it to list
        }

        yield return null;

        EventManager.ReciveEnemyUnitList(enemyUnits);

        yield return null;

        GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
    }

    
}
