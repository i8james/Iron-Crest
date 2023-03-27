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

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //unit = null;
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
        EventManager.SendClearGrid += ClearGrid;
    }

        private void ClearGrid()
        {
            owner.ClearGrid();
        }

      
        private void ShowLine(List<GameObject> points)
        {
       



            if (arrowActive)
            {

                GridStats previous = findP(points);
                GridStats next = findN(points);
                //bend.transform.rotation = bendRotation;
                //owner.path.Count - 
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

        if (position > 0)
        {
            if (points[position - 1].GetComponent<GridStats>() != null)
            {
                next = points[position - 1].GetComponent<GridStats>();
                return next;
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
        if (newState == GameState.PlayerSelect)
        {
            canMove = false;
            canAttack = false;
            ClearTile();
        }
        else if (newState == GameState.PlayerAction)
        {
            ClearTile();
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
    
    //Returns every unit within range
    public List<GridStats> SetTarget()
    {
        return owner.EnemyFindTargetsInRange(this);
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
            if(unit == null)
            {   
                
                
                owner.ReciveDisplayLocation(this);

                //Show path
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
                    EventManager.ReceiveNewActiveUnitRequest(this);
                }
            }
        } else if (gameState == GameState.PlayerMove)
        {
            if (unit == null)
            {
                Unit activeUnit = GameManager.Instance.activeUnit;
                GameManager.Instance.NewGameState(GameState.PlayerMoveSelect, activeUnit);
                owner.SendGridPath(this);

                //Begin movement on path
            }
        }

        if (gameState == GameState.PlayerAction)
        {
            if(inAttackRange)
            {
                print(this);
                GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
            }
        }


    }




    private void OnMouseExit()
    {
        selected.SetActive(false);
        //removeEventLinks();
        //selected.SetActive(false);
        //clear grid
        if (rangeActive)
        {
            owner.ClearGrid();
            rangeActive = false;
        }
    }
}
