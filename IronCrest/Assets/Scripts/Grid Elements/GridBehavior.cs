using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class GridBehavior : MonoBehaviour
{
    public bool findDistance = false;
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3(0, 0, 0);
    public bool previewActive;

    public bool previewChangeState;
    

    public GameObject[,] gridArray;

    public List<GameObject> path = new List<GameObject>();

    private void Awake()
    {

        gridArray = new GameObject[columns, rows];


    }

    // Start is called before the first frame update
    void Start()
    {

        GameManager.OnGameStateChanged += OnStateChange;
        EventManager.SendFirstEnemyPos += FindTargetPath;
        // EventManager.SendGridLocation += GridLocationReceived;
    }


    public void ReciveDisplayLocation(GridStats targetTile)
    {

        //EventManager.ReciveDisplayMovePath(CreateTilePath(targetTile, GameManager.Instance.activeUnit));

        path = CreateTilePath(targetTile, GameManager.Instance.activeUnit);

        EventManager.ReciveTileDisplayLine(path);
    }

    public void SendGridPath(GridStats targetTile)
    {

        EventManager.ReceiveMovePath(CreateTilePath(targetTile, GameManager.Instance.activeUnit));
    }

    //Targeted gridstat attempts to reach player location
    public void FindTargetPath(GridStats targetTile)
    {
        //StartCoroutine(EnemyPathfindSteps(targetTile));   
        StartCoroutine(EnemyMovementPath(targetTile));
    }

    //Path towards player is sent to EnemyPhase
    private void SendTargetPath(List<GameObject> newPath)
    {
        //EventManager.ReciveTileDisplayLine(newPath);
        path = newPath;

        //EventManager.ReciveTileDisplayLine(newPath);

        EventManager.ReciveTargetPath(newPath);

    }







    private IEnumerator EnemyMovementPath(GridStats targetTile)
    {
        int detectRange = GameManager.Instance.activeUnit.targetDetectRange;

        int moveRange = GameManager.Instance.activeUnit.moveRange;

        int weaponRange = GameManager.Instance.activeUnit.weaponRange;

        yield return null;

        List<GameObject> initPath = EnemyCreateTilePath(targetTile, GameManager.Instance.activeUnit, detectRange);

        yield return null;

        for (int i = 0; i < initPath.Count; i++)
        {
            initPath[i].GetComponent<GridStats>().arrowActive = false;
            initPath[initPath.Count - 1 - i].GetComponent<GridStats>().position = 0;
        }

        yield return null;

        List<GameObject> newPath = new List<GameObject>();

        yield return null;

        if (initPath.Count > moveRange)
        {

            print("Outside move range");
            for (int i = 0; i <= moveRange; i++)
            {
                print(i);
                newPath.Add(initPath[initPath.Count - 1 - i]);
                initPath[initPath.Count - 1 - i].GetComponent<GridStats>().arrowActive = true;

                initPath[initPath.Count - 1 - i].GetComponent<GridStats>().position = moveRange - i;

                yield return null;
            }

        }
        else
        {
            print("Inside move range");
            for (int i = 0; i < initPath.Count; i++)
            {
                print(i);
                newPath.Add(initPath[initPath.Count - 1 - i]);
                initPath[initPath.Count - 1 - i].GetComponent<GridStats>().arrowActive = true;

                initPath[initPath.Count - 1 - i].GetComponent<GridStats>().position = initPath.Count - 1 - i;

                yield return null;
            }
        }

        yield return null;

        newPath.Reverse();

        yield return null;

        SendTargetPath(newPath);

    }


    public List<GridStats> EnemyFindTargetsInRange(GridStats startingTile, int range, bool attacking)
    {
        List<GridStats> AllUnitsInRange = new();

        print("Search started at " +startingTile);

        HoverInitialSetup(startingTile);

        if (startingTile.unit != null)
        {
            HoverInitialSetup(startingTile);




            Unit targetUnit = startingTile.unit.GetComponent<Unit>();

            print(startingTile.unit.GetComponent<Unit>());


            for (int step = 1; step < rows * columns; step++)
            {
                foreach (GameObject obj in gridArray)
                {

                    if (obj && obj.GetComponent<GridStats>().visited == step - 1)
                    {
                        TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                        if (obj.GetComponent<GridStats>().visited <= range)
                        {
                           
                            if (obj.GetComponent<GridStats>().unit != null)
                                if (obj.GetComponent<GridStats>().unit.unitType == UnitType.PlayerUnit)

                                    if (attacking)
                                    {
                                        print("Found a " + obj.GetComponent<GridStats>().unit + " to attack");
                                        AllUnitsInRange.Add(obj.GetComponent<GridStats>());
                                    }
                                    else
                                    {
                                        print(obj.GetComponent<GridStats>().unit);
                                        AllUnitsInRange.Add(EnemyFindTargetInWeaponRange(obj.GetComponent<GridStats>(), range, targetUnit.weaponRange, obj.GetComponent<GridStats>().visited)); //obj.GetComponent<GridStats>());
                                    }




                        }



                    }

                }


            }

            //print(AllUnitsInRange);


            return AllUnitsInRange;

        }
        else
        {
            print("nothing here");
            return null;
        }
    }

    public GridStats EnemyFindTargetInWeaponRange(GridStats target, int range, int weaponRange, int visitTarget)
    {
        List<GridStats> AllUnitsInRange = new();


        GridStats finalTarget = null;

        // for (int step = 1; step < rows * columns; step++)
        {
            foreach (GameObject obj in gridArray)
            {

                if (obj)
                {
                    // TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                    if (obj.GetComponent<GridStats>().visited == visitTarget - weaponRange)
                    {
                        print(visitTarget - weaponRange);
                        if (obj.GetComponent<GridStats>().unit == null)
                        {
                            if (finalTarget != null)
                            {

                                if (Vector3.Distance(target.gameObject.transform.position, finalTarget.gameObject.transform.position) > Vector3.Distance(target.gameObject.transform.position, obj.transform.position))
                                //if (((target.x + target.y)- (finalTarget.x + finalTarget.y)) >= ((target.x + target.y) - (obj.GetComponent<GridStats>().x + obj.GetComponent<GridStats>().y) ))
                                {


                                    print(((obj.GetComponent<GridStats>().x - obj.GetComponent<GridStats>().y) + (target.x - target.y)));
                                    finalTarget = obj.GetComponent<GridStats>();
                                }
                            }
                            else
                            {

                                print("Basic target = " + ((obj.GetComponent<GridStats>().x + obj.GetComponent<GridStats>().y) + (target.x + target.y)));
                                finalTarget = obj.GetComponent<GridStats>();
                            }
                        }

                        //AllUnitsInRange.Add(obj.GetComponent<GridStats>());

                    }



                }

            }


        }



        return finalTarget;


    }



    public List<GameObject> EnemyCreateTilePath(GridStats targetTile, Unit newActiveUnit, int range) //Gamestate will determine what range to display
    {
        //newActiveUnit.gameObject.transform.position = newActiveUnit.occupiedTile.transform.position; //targetTile.transform.position;

        EnemyRangeSetup(newActiveUnit.occupiedTile);

        return SetPath(targetTile.x, targetTile.y, range);
    }


    //Creates path of GridStat waypoints from newActiveUnit's occupied tile to targetTile
    public List<GameObject> CreateTilePath(GridStats targetTile, Unit newActiveUnit) //Gamestate will determine what range to display
    {
        //newActiveUnit.gameObject.transform.position = newActiveUnit.occupiedTile.transform.position; //targetTile.transform.position;
        
        //DisplayRange(newActiveUnit.occupiedTile, newActiveUnit.moveRange);

        return SetPath(targetTile.x, targetTile.y, newActiveUnit.moveRange);
    }

    public void DisplayTileRange(GridStats targetTile, int type)
    {
        
            if (!previewActive)
            {
          
      
                previewActive = true;
                switch (type)
                {
                    case 0:
                        StartCoroutine(DisplayRange(targetTile, targetTile.unit.moveRange));
                        break;
                    case 1:
                        DisplayAttackRange(targetTile);
                        break;
                }

            }
        

      
    }

    public void DisplayEnemyTileRange(GridStats targetTile, int type)
    {
        switch (type)
        {
            case 0:
                DisplayRange(targetTile, targetTile.unit.moveRange);
                break;
            case 1:
               // DisplayRange(targetTile, targetTile.unit.moveRange);
                DisplayAttackRange(targetTile);
                break;
        }


    }















    private void OnStateChange(GameState newState)
    {
       
            //ClearGrid();
       
    }

    public void CreateGrid()
    {
        gridArray = new GameObject[columns, rows];
        if (gridPrefab)
        {
            GenerateGrid();
        }
        else
        {
            print("Missing Grid Prefab!");
        }
    }


    void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStats>().x = i;
                obj.GetComponent<GridStats>().y = j;
                obj.GetComponent<GridStats>().owner = this;

                gridArray[i, j] = obj;
            }
        }
    }

    //Clears range when mouse leaves occupied tile
    public void ClearGrid(List<GridStats> inputClearArray)  //IEnumerator
    {
        //yield return new WaitUntil(() => !previewChangeState);

        //StopCoroutine(DisplayRange(null, 0));

      //  yield return null;
        print("Clearing grid");
        if (inputClearArray.Count > 0)
        {
            for (int step = 1; step < rows * columns; step++)
            {
                foreach (GridStats obj in inputClearArray)
                {
                    if(obj)
                    {
                        obj.GetComponent<GridStats>().canMove = false;
                        obj.GetComponent<GridStats>().canAttack = false;
                        obj.GetComponent<GridStats>().arrowActive = false;
                    }
                }
               
            }
        }
       // yield return null;
    }

   






    void EnemyRangeSetup(GridStats hoverTarget)
    {
        if (hoverTarget.unit.GetComponent<Unit>())
        {
            HoverInitialSetup(hoverTarget);

            Unit targetUnit = hoverTarget.unit.GetComponent<Unit>();

            for (int step = 1; step < rows * columns; step++)
            {
                foreach (GameObject obj in gridArray)
                {

                    if (obj && obj.GetComponent<GridStats>().visited == step - 1)
                    {
                        TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                        if (step <= (targetUnit.moveRange + targetUnit.weaponRange) + 1)
                        {
                            obj.GetComponent<GridStats>().inAttackRange = true;
                            obj.GetComponent<GridStats>().canMove = false;
                            obj.GetComponent<GridStats>().canAttack = true;

                        }
                        else
                        {
                            obj.GetComponent<GridStats>().inAttackRange = true;
                            obj.GetComponent<GridStats>().canMove = false;
                            obj.GetComponent<GridStats>().canAttack = false;
                        }


                    }

                }

            }
        }

    }



    void DisplayAttackRange(GridStats hoverTarget)
    {
        if (hoverTarget.unit.GetComponent<Unit>())
        {
            HoverInitialSetup(hoverTarget);

            Unit targetUnit = hoverTarget.unit.GetComponent<Unit>();

            for (int step = 1; step < rows * columns; step++)
            {
                foreach (GameObject obj in gridArray)
                {

                    if (obj && obj.GetComponent<GridStats>().visited == step - 1)
                    {
                        TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                        if (step <= targetUnit.weaponRange + 1)
                        {
                            obj.GetComponent<GridStats>().inAttackRange = true;
                            obj.GetComponent<GridStats>().canMove = false;
                            obj.GetComponent<GridStats>().canAttack = true;

                        }
                        else
                        {
                            obj.GetComponent<GridStats>().inAttackRange = false;
                            obj.GetComponent<GridStats>().canMove = false;
                            obj.GetComponent<GridStats>().canAttack = false;
                        }


                    }

                }

            }
        }
        
    }



    //Displays range when an occupied tile is hovered over 
    private IEnumerator DisplayRange(GridStats hoverTarget, int maxMove)
    {
        List<GridStats> nearbyTiles = new List<GridStats>();

        if (hoverTarget.unit.GetComponent<Unit>())
        {
            if (hoverTarget.unit.unitType == UnitType.PlayerUnit)
            {
                HoverInitialSetup(hoverTarget);

                Unit targetUnit = hoverTarget.unit.GetComponent<Unit>();

                for (int step = 1; step < rows * columns; step++)
                {
                    foreach (GameObject obj in gridArray)
                    {

                        if (obj && obj.GetComponent<GridStats>().visited == step - 1)
                        {
                            TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                            if (step <= targetUnit.moveRange + 1)
                            {

                                obj.GetComponent<GridStats>().canMove = true;
                                obj.GetComponent<GridStats>().canAttack = false;
                                nearbyTiles.Add(obj.GetComponent<GridStats>());

                            }
                            else if (step <= (targetUnit.moveRange + targetUnit.weaponRange) + 1)
                            {
                                obj.GetComponent<GridStats>().canAttack = true;
                                obj.GetComponent<GridStats>().canMove = false;
                                nearbyTiles.Add(obj.GetComponent<GridStats>());
                            }
                            else
                            {
                                obj.GetComponent<GridStats>().canMove = false;
                                obj.GetComponent<GridStats>().canAttack = false;
                            }

                            
                        }
                        

                    }
                    

                }

                hoverTarget.nearbyClearTiles = nearbyTiles;
                previewChangeState = false;
    
                yield return null;

                
            }
            else if (hoverTarget.unit.unitType == UnitType.EnemyUnit)
            {
                
            
                    HoverInitialSetup(hoverTarget);

                    Unit targetUnit = hoverTarget.unit.GetComponent<Unit>();

                    for (int step = 1; step < rows * columns; step++)
                    {
                        foreach (GameObject obj in gridArray)
                        {

                            if (obj && obj.GetComponent<GridStats>().visited == step - 1)
                            {
                                TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);

                                if (step <= (targetUnit.moveRange + targetUnit.weaponRange) + 1)
                                {

                                    obj.GetComponent<GridStats>().canMove = false;
                                    obj.GetComponent<GridStats>().canAttack = true;
                                    nearbyTiles.Add(obj.GetComponent<GridStats>());

                            }
                                else
                                {
                                    obj.GetComponent<GridStats>().canMove = false;
                                    obj.GetComponent<GridStats>().canAttack = false;
                                }


                            }
                        


                    }

                    hoverTarget.nearbyClearTiles = nearbyTiles;
                    previewChangeState = false;

                    //yield return null;
                }
                }
            
        }

        yield return null;

        /*hoverTarget.nearbyClearTiles = nearbyTiles;
        previewChangeState = false;
        print("Grid Can Change");*/
        yield return null;
    }

    

    

    //Generates list of tiles to form path
    List<GameObject> SetPath(int x, int y, int maxMove)
    {
        List<GameObject> newPath = new List<GameObject>();
        int step;
 
        List<GameObject> tempList = new List<GameObject>();

        if (path.Count > 0)
        {
            for (int i = 0; i < path.Count; i++)
            {
                path[i].GetComponent<GridStats>().arrowActive = false;

            }
        }

        newPath.Clear();

        if (gridArray[x, y] && gridArray[x, y].GetComponent<GridStats>().visited >= 0)
        {


            newPath.Add(gridArray[x, y]);


            step = gridArray[x, y].GetComponent<GridStats>().visited - 1;
            if (step < maxMove)
            {
                newPath[0].GetComponent<GridStats>().arrowActive = true;
                newPath[0].GetComponent<GridStats>().position = 0;
                newPath[0].GetComponent<GridStats>().owner = this;

            }

        }
        else
        {
            print("Can't reach location");
            return null;
        }
        if (step < maxMove)
        {

            int p = 1;
            for (int i = step; step > -1; step--)
            {

                if (TestDirection(x, y, step, 1))
                {
                    tempList.Add(gridArray[x, y + 1]);
                    //gridArray[x,y].GetComponent<GridStats>().direction = 1;
                }
                if (TestDirection(x, y, step, 2))
                {
                    tempList.Add(gridArray[x + 1, y]);
                    //gridArray[x, y].GetComponent<GridStats>().direction = 3;
                }
                if (TestDirection(x, y, step, 3))
                {
                    tempList.Add(gridArray[x, y - 1]);
                    //gridArray[x, y].GetComponent<GridStats>().direction = 2;
                }
                if (TestDirection(x, y, step, 4))
                {
                    tempList.Add(gridArray[x - 1, y]);
                    //gridArray[x, y].GetComponent<GridStats>().direction = 4;
                }

                GameObject tempObj = FindClosest(gridArray[x, y].transform, tempList);
                tempObj.GetComponent<GridStats>().position = p;
                newPath.Add(tempObj);
                x = tempObj.GetComponent<GridStats>().x;
                y = tempObj.GetComponent<GridStats>().y;


                tempObj.GetComponent<GridStats>().owner = this;
                tempObj.GetComponent<GridStats>().arrowActive = true;


                p++;


                tempList.Clear();

            }
            //return newPath;
            
        }

        return newPath;

    }

    

    void HoverInitialSetup(GridStats hoverTarget)
    {
        foreach (GameObject obj in gridArray)
        {
            if (obj != null)
            {
                obj.GetComponent<GridStats>().visited = -1;
            }
        }
        hoverTarget.visited = 0;
    }

    bool TestDirection(int x, int y, int step, int direction)
    {
        //Direction 1 is up, 2 is right, 3 is down, 4 is left
        switch (direction)
        {
            case 1:
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStats>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStats>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 3:
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStats>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 4:
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<GridStats>().visited == step)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        return false;
    }

    void TestFourDirections(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1))
        {
            SetVisited(x, y + 1, step);
        }
        if (TestDirection(x, y, -1, 2))
        {
            SetVisited(x + 1, y, step);
        }
        if (TestDirection(x, y, -1, 3))
        {
            SetVisited(x, y - 1, step);
        }
        if (TestDirection(x, y, -1, 4))
        {
            SetVisited(x - 1, y, step);
        }
    }

    void SetVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
        {
            gridArray[x, y].GetComponent<GridStats>().visited = step;
        }
    }

    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = scale * rows * columns;
        int indexNum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNum = i;
            }
        }
        return list[indexNum];
    }
}
