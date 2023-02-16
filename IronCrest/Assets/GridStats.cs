using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStats : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;

    //public GameObject previous;

    
    public GameObject selected;

    public bool arrowActive;

    public GridBehavior owner;

    public int direction; //1 is up, 2 is down, 3 is right, 4 is left

    public bool canMove;

    public GameObject green;

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


    public List<GameObject> points;

    public int position;

    private Quaternion bendRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (owner != null)
        {
            owner.gridArray[x, y] = gameObject;
        }

        selected.SetActive(false);
        arrow.SetActive(false);

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
    }

    GridStats findP()
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

    GridStats findN()
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
        if (owner != null)
        {
            if (owner.path != null)
            {
                points = owner.GetComponent<GridBehavior>().path;
                


                if (arrowActive)
                {

                    GridStats previous = findP();
                    GridStats next = findN();
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
                            else if (p_dir.x == - 1 && n_dir.y == 1)
                            {
                                
                                bend.SetActive(true);
                            }
                            else if (p_dir.x == - 1 && n_dir.y == -1)
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
                                } else
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
                    else
                    {
                        //arrow.SetActive(true);
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
        }

        if (canMove)
        {

            green.SetActive(true);


        }
        else
        {

            green.SetActive(false);

        }
        

        



    }


    

    private void OnMouseOver()
    {
        if (!owner.clicked)
        {
            selected.SetActive(true);
            owner.endX = x;
            owner.endY = y;
            owner.findDistance = true;
        }
    }

    private void OnMouseExit()
    {
        selected.SetActive(false);
    }
}
