using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStats : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;

    //public GameObject previous;


    //public GameObject unit;

    public Unit unit;

    public GameObject selected;

    public bool arrowActive;

    public GridBehavior owner;

    public int direction; //1 is up, 2 is down, 3 is right, 4 is left

    public bool canMove;

    public bool canAttack;

    public GameObject green;

    public GameObject red;

    public GameObject point;
    public GameObject line;
    public GameObject line2;


    public GameObject bend;
    public GameObject bend2;
    public GameObject bend3;
    public GameObject bend4;

    public GameObject arrow;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;


    private bool rangeActive;

    public bool inAttackRange;

    List<GridStats> playerTilesInArea;

  

    public int position;

    private Quaternion bendRotation;

    private GameState gameState;

    public List<GridStats> nearbyClearTiles;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //unit = null;
        nearbyClearTiles = null;
        rangeActive = false;
        gameState = GameState.PlayerSelect;

        if (owner != null)
        {
            owner.gridArray[x, y] = gameObject;
        }

        selected.SetActive(false);
        arrow.SetActive(false);
        red.SetActive(false);

        bend.SetActive(false);
        bend2.SetActive(false);
        bend3.SetActive(false);
        bend4.SetActive(false);

        arrow.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);


        line.SetActive(false);
        line2.SetActive(false);
        arrowActive = false;
        bendRotation = bend.transform.rotation;

        
        GameManager.OnGameStateChanged += UpdateGameState;
        //EventManager.SendClearGrid += ClearGrid;
        //EventManager.SendTileDisplayLine += ShowLine;
        //EventManager.SendTargetPath += ShowLine;
    }

     
      
        private void ShowLine(List<GameObject> points)
        {
       



            if (arrowActive)
            {

                GridStats previous = findP(points);
                GridStats next = findN(points);
              
                arrow.SetActive(false);
                arrow2.SetActive(false);
                arrow3.SetActive(false);
                arrow4.SetActive(false);

                line.SetActive(false);
                line2.SetActive(false);

                bend.SetActive(false);
                bend2.SetActive(false);
                bend3.SetActive(false);
                bend4.SetActive(false);




                if (previous != null)
                {

                    Vector2 p_dir = (new Vector2(x, y) - new Vector2(previous.x, previous.y)).normalized;


                    if (next != null)
                    {
                        Vector2 n_dir = (new Vector2(x, y) - new Vector2(next.x, next.y)).normalized;

                        if (p_dir.x == 1 && n_dir.y == 1)
                        {

                            bend4.SetActive(true);
                        }
                        else if (p_dir.x == 1 && n_dir.y == -1)
                        {

                            bend3.SetActive(true);
                        }
                        else if (p_dir.x == -1 && n_dir.y == 1)
                        {

                            bend.SetActive(true);
                        }
                        else if (p_dir.x == -1 && n_dir.y == -1)
                        {

                            bend2.SetActive(true);
                        }


                        else if (p_dir.y == 1 && n_dir.x == 1)
                        {

                            bend4.SetActive(true);
                        }
                        else if (p_dir.y == 1 && n_dir.x == -1)
                        {
                        //lower left top
                            bend.SetActive(true);
                        }
                        else if (p_dir.y == -1 && n_dir.x == 1)
                        {
                            //lower left bottom
                            bend3.SetActive(true);
                        }
                        else if (p_dir.y == -1 && n_dir.x == -1)
                        {

                            bend2.SetActive(true);
                        }
                        else
                        {
                            if (n_dir.y == 0)
                            {
                                line2.SetActive(true);
                            }
                            else
                            {
                                line.SetActive(true);
                            }


                        }
                    }
                    else
                    {
                        if (position == 0)
                        {

                            if (p_dir.x == 1)
                            {
                                arrow2.SetActive(true);
                            }
                            else if (p_dir.x == -1)
                            {
                                arrow4.SetActive(true);
                            }
                            else if (p_dir.y == 1)
                            {
                                arrow.SetActive(true);
                            }
                            else if (p_dir.y == -1)
                            {
                                arrow3.SetActive(true);
                            }
                        }
                    }

                }
            

            }
            else
            {

                arrow.SetActive(false);
                line.SetActive(false);
                line2.SetActive(false);

                bend.SetActive(false);
                bend2.SetActive(false);
                bend3.SetActive(false);
                bend4.SetActive(false);

                arrow.SetActive(false);
                arrow2.SetActive(false);
                arrow3.SetActive(false);
                arrow4.SetActive(false);

            }
        }



    


  


    GridStats findP(List<GameObject> points)
    {
        GridStats previous;
        if (position + 1 < points.Count)
        {
            if (points[position + 1].GetComponent<GridStats>() != null)
            {
                previous = points[position + 1].GetComponent<GridStats>();
                return previous;
            } else
            {
                return null;
            }
        } else
        {
            return null;
        }
    }

    GridStats findN(List<GameObject> points)
    {
        GridStats next;

        if (position > 0 && points != null && position < points.Count)
        {
            if (points[position - 1] != null)
            {
                if (points[position - 1].GetComponent<GridStats>() != null)
                {
                    next = points[position - 1].GetComponent<GridStats>();
                    return next;
                } else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        } 
        else
        {
            return null;
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        //if (owner.GetComponent<GridBehavior>().path != null)
        if (owner)
        {
            if (owner.path.Count > 0)
            {
                ShowLine(owner.path);
            }
        }
        
        if (canMove)
        {

            green.SetActive(true);


        }
        else
        {

            green.SetActive(false);

        }

        if (canAttack)
        {

            red.SetActive(true);


        }
        else
        {

            red.SetActive(false);

        }




    }

    private void UpdateGameState(GameState newState)
    {
        if (newState == GameState.PlayerSelect || newState == GameState.EnemySelect)
        {
            if (rangeActive)
            {
               

                      //  StartCoroutine(owner.ClearGrid(nearbyClearTiles));
                owner.ClearGrid(nearbyClearTiles);

                //owner.ClearGrid();
                rangeActive = false;
                canMove = false;
            }
            canMove = false;
            canAttack = false;
            if (arrowActive)
            {
                ClearTile();
            }
        }
        else if (newState == GameState.PlayerAction)
        {
            if (arrowActive)
            {
                ClearTile();
            }
            if (GameManager.Instance.activeUnit == unit)
            {
                owner.DisplayTileRange(this, 1);
            }
        } 


        gameState = newState;
        
    }

    private void ClearTile()
    {
        if (owner != null)
        {
            arrowActive = false;

            print("Clearing tile");
            owner.path.Clear();

            arrow.SetActive(false);
            line.SetActive(false);
            line2.SetActive(false);

            bend.SetActive(false);
            bend2.SetActive(false);
            bend3.SetActive(false);
            bend4.SetActive(false);

            arrow.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
            arrow4.SetActive(false);
        }
    }
    
    //Returns every unit within movement targeting range
    public List<GridStats> SetTarget()
    {
        return owner.EnemyFindTargetsInRange(this, unit.targetDetectRange, false);
    }


    //Returns every unit withing weapon range
    public List<GridStats> SetAttackTarget()
    {
        print("Setting attack target within " + unit.rWeaponRange);
        return owner.EnemyFindTargetsInRange(this, unit.rWeaponRange, true);
    }
    

    //UnitEnemy calls GridBehavior to creat a path to this location
    public void EnemyTargetThisLocation()
    {
        owner.FindTargetPath(this);
    }



    private void OnMouseOver()
    {
        //createEventLinks();
        //Gamestate player selection

        
        selected.SetActive(true);

        if (gameState == GameState.PlayerSelect)
        {
            if (unit != null)
            {
                EventManager.ReceivePopUpStatus(0, unit);
                if (!unit.acted)
                {

                    //print("Display range");

                  
                        owner.DisplayTileRange(this, 0);
                    
                    //Show move range
                    rangeActive = true;
                }
            }
        } 
        else

        //Gamestate Player Movement
        if(gameState == GameState.PlayerMove)
        {
            if (unit == null)
            {


                owner.ReciveDisplayLocation(this);

                //Show path
            }
            else if (unit == GameManager.Instance.activeUnit)
            {
                for(int i = 0; i < owner.path.Count; i++)
                {
                    owner.path[i].GetComponent<GridStats>().arrowActive = false;
                }
            }
        }

        



    }

    private void OnMouseDown()
    {
        
        //Gamestate player select
        if (gameState == GameState.PlayerSelect)
        {
            if (unit != null)
            {
                if (!unit.acted)
                {
                    if (unit.unitType == UnitType.PlayerUnit)
                    {
                        EventManager.ReceiveNewActiveUnitRequest(this);
                    }

                }
            }
        } else if (gameState == GameState.PlayerMove)
        {
            if (unit == null)
            {
                if (canMove)
                {
                    
                    Unit activeUnit = GameManager.Instance.activeUnit;
                    GameManager.Instance.NewGameState(GameState.PlayerMoveSelect, activeUnit);
                    owner.SendGridPath(this);
                    EventManager.ReceivePopUpStatus(1, null);
                }
                //Begin movement on path
            }
            else if (unit == GameManager.Instance.activeUnit)
            {
                unit.acted = true;
                GameManager.Instance.NewGameState(GameState.PlayerMenu, GameManager.Instance.activeUnit);
            }
        }

        if (gameState == GameState.PlayerAction)
        {
            if(inAttackRange)
            {
                {
                    if (unit != null)
                    {
                        if (unit.unitType == UnitType.EnemyUnit)
                        {
                            print("Attacking this space!");
                            //if(unit.ReturnType() == 2) 
                            //{
                            print(this.unit.gameObject.name);
                            unit.CallCombat();
                            //EventManager.RecieveCombatStartRequest(GameManager.Instance.activeUnit, this.unit);
                            //}
                            //EventManager.RecieveEndPlayerTurn();
                        }
                        else
                        {
                            EventManager.RecieveEndPlayerTurn();
                        }
                    } else
                    {
                        GameManager.Instance.NewGameState(GameState.PlayerMenu, GameManager.Instance.activeUnit);
                        //EventManager.RecieveEndPlayerTurn();
                    }
                }
            }
        }


    }




    private void OnMouseExit()
    {
        owner.previewActive = false;
        selected.SetActive(false);
        //removeEventLinks();
        //selected.SetActive(false);
        //clear grid
      
        if (rangeActive)
        {
            if (gameState == GameState.PlayerSelect)
            {
                if (nearbyClearTiles != null)
                {

                    // StartCoroutine(owner.ClearGrid(nearbyClearTiles));
                    owner.ClearGrid(nearbyClearTiles);
                }
            }
            //owner.ClearGrid();
            rangeActive = false;
            EventManager.ReceivePopUpStatus(1, null);
        }
    }
}
