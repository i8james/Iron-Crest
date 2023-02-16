using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    public bool findDistance = false;
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3(0,0,0);

    public GameObject[,] gridArray;

    //Starting position:
    public int startX = 0;
    public int startY = 0;

    //Destination:
    public int endX = 2;
    public int endY = 2;

    public int maxMove = 5;

    public List<GameObject> path = new List<GameObject>();

    public GameObject unit;

    public bool clicked;

    public int unitStartX = 0;
    public int unitStartY = 0;

    private void Awake()
    {
        //GameObject child = GetComponentInChildren<GameObject>();
        gridArray = new GameObject[columns, rows];
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartTurn()
    {
        
        if (unit.GetComponent<UnitMovement>() != null)
        {
            maxMove = unit.GetComponent<UnitMovement>().moveRange;

            unitStartX = unit.GetComponent<UnitMovement>().x;

            unitStartY = unit.GetComponent<UnitMovement>().y;
        }
        else
        {
            maxMove = unit.GetComponent<EnemyMovement>().moveRange;

            unitStartX = unit.GetComponent<EnemyMovement>().x;

            unitStartY = unit.GetComponent<EnemyMovement>().y;
        }

        startX = unitStartX;

        startY = unitStartY;

        unit.transform.position = gridArray[unitStartX, unitStartY].transform.position;
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

    // Update is called once per frame
    void Update()
    {
        if (unit.GetComponent<UnitMovement>() != null)
        {
            clicked = unit.GetComponent<UnitMovement>().click;
        } else
        {
            clicked = unit.GetComponent<EnemyMovement>().click;
        }

        if (findDistance && !clicked)
        {

            findDistance = false;

            SetDistance();

            SetPath();

            if (unit.GetComponent<UnitMovement>() != null)
            {
                unit.GetComponent<UnitMovement>().movement = true;
                unit.GetComponent<UnitMovement>().Waypoints = path;
            }
            else
            {
                unit.GetComponent<EnemyMovement>().movement = true;
                unit.GetComponent<EnemyMovement>().Waypoints = path;
            }
            //startX = endX;
            //startY = endY;
        }
        
        if (clicked)
        {
            startX = endX;
            startY = endY;
        }
    }

    void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z+scale*j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStats>().x = i;
                obj.GetComponent<GridStats>().y = j;
                obj.GetComponent<GridStats>().owner = this;

                gridArray[i, j] = obj;
            }
        }
    }

    void SetDistance()
    {
        InitialSetup();
        int x = startX;
        int y = startY;
        int[] testArray = new int[rows * columns];

        for(int step = 1; step < rows*columns; step++)
        {
            foreach(GameObject obj in gridArray)
            {
                
                if(obj && obj.GetComponent<GridStats>().visited == step - 1)
                {   
                    TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y, step);
                    if (step <= maxMove + 1)
                    {
                        
                            obj.GetComponent<GridStats>().canMove = true;
                        
                    } else
                    {
                        obj.GetComponent<GridStats>().canMove = false;
                    }
                }
            }
        }
    }

    void SetPath()
    {
        int step;
        int x = endX;
        int y = endY;
        List<GameObject> tempList = new List<GameObject>();
        if(path.Count > 0)
        {
            for(int i = 0; i < path.Count; i++)
            {
                path[i].GetComponent<GridStats>().arrowActive = false;
                //path[i].GetComponent<GridStats>().previous = null;
                //path[i].GetComponent<GridStats>().canMove = false;
            }
        }
        path.Clear();
        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<GridStats>().visited > 0)
        {
            path.Add(gridArray[x, y]);
            
                step = gridArray[x, y].GetComponent<GridStats>().visited - 1;
            if (step < maxMove)
            {
                path[0].GetComponent<GridStats>().arrowActive = true;
                path[0].GetComponent<GridStats>().position = 0;
                path[0].GetComponent<GridStats>().owner = this;

            }
                
        } else
        {
            print("Can't reach location");
            return;
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
                
                GameObject tempObj = FindClosest(gridArray[endX, endY].transform, tempList);
                tempObj.GetComponent<GridStats>().position = p;
                path.Add(tempObj);
                x = tempObj.GetComponent<GridStats>().x;
                y = tempObj.GetComponent<GridStats>().y;
                

                tempObj.GetComponent<GridStats>().owner = this;
                tempObj.GetComponent<GridStats>().arrowActive = true;


                p++;


                tempList.Clear();
                
            }
        }
        


    }

    void InitialSetup()
    {
        foreach(GameObject obj in gridArray)
        {
            if (obj != null)
            {
                obj.GetComponent<GridStats>().visited = -1;
            }
        }
        gridArray[startX, startY].GetComponent<GridStats>().visited = 0;
    }

    bool TestDirection(int x, int y, int step, int direction)
    {
        //Direction 1 is up, 2 is right, 3 is down, 4 is left
        switch(direction)
        {
            case 1:
                if(y+1<rows && gridArray[x,y+1] && gridArray[x,y+1].GetComponent<GridStats>().visited == step)
                {
                    return true;
                } else
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
        if(TestDirection(x,y,-1,1))
        {
            SetVisited(x, y + 1, step);
        }
        if(TestDirection(x, y, -1, 2))
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

    void SetVisited (int x, int y, int step)
    {
        if (gridArray[x,y])
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
            if(Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNum = i;
            }
        }
        return list[indexNum];
    }
}
