using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMaker : MonoBehaviour
{
    public float pieceHeight = 4f;
    public float pieceLength = 2f;
    public GameObject[] firstFloorWallPieces;
    public GameObject[] otherWallPieces;
    public GameObject[] shopWallPieces;
    public GameObject[] roofPieces;
    public GameObject shopWall;
    public GameObject shopWall2;
    public GameObject stairs;
    public GameObject stair2;
    public GameObject door;

    public int minWallAmt = 2;
    public int maxWallAmt = 5;
    public int minHeightAmt = 2;
    public int maxHeightAmt = 5;
    public GameObject cornerPiece;
   
    public GameObject roofPrefab;

    int frontSize;
    int sideSize;
    int floorAmount;


    int CalculateSize(int min, int max)
    {
        int number = Random.Range(min, max + 1);
        while ((1.0 * number) % 2 == 0)
        {
            number = Random.Range(min, max + 1);
        }
        return number;
    }

    int CalculateHeight(int min, int max)
    {
        int number = Random.Range(min, max + 1);
        
        return number;
    }



    public void CreateBuilding()
    {
        
        frontSize = minWallAmt; //CalculateSize(minWallAmt, maxWallAmt);
        sideSize = maxWallAmt; //CalculateSize(minWallAmt, maxWallAmt);
        floorAmount = minHeightAmt; //CalculateHeight(minHeightAmt, maxHeightAmt);
        


        GameObject newBuilding = new GameObject();
        //newBuilding.transform.position = Vector3.zero;
        newBuilding.transform.position = transform.position;
        newBuilding.name = "New Building";
        //newBuilding.transform.localScale /= 1.75f;

        //newBuilding.AddComponent<Despawn>();

        int random = Random.Range(0, 4);

        bool shops = true;
        int trueSides = sideSize;
        float trueSize = pieceLength;

        for (int i = 0; i < floorAmount; i++)
        {
            pieceLength = trueSize;
            sideSize = trueSides;
            /*if (i == 0)
            {
                if (shops)
                {
                    //sideSize /= 2;

                    //add the shop floors here

                    //pieceLength = 4;

                    //CreateFloor(newBuilding, shopWallPieces, (int)(i * pieceHeight));

                    //CreateFloor(newBuilding, firstFloorWallPieces, (int)(i * pieceHeight), true);
                    CreateFloorsFloor(newBuilding, otherWallPieces, (int)(i * pieceHeight), true, roofPrefab, false, i);
                }
                else
                {
                    //CreateFloor(newBuilding, firstFloorWallPieces, (int)(i * pieceHeight));
                }




            }
            else
            if (i == floorAmount)
            {
                CreateFloorsFloor(newBuilding, roofPieces, (int)(i * pieceHeight), false, roofPieces[0], true, i);
            } else*/

                {
                    //CreateFloor(newBuilding, otherWallPieces, (int)(i * pieceHeight));

                    CreateFloorsFloor(newBuilding, otherWallPieces, (int)(i * pieceHeight), false, roofPrefab, false, i);

                /*Vector3 scales = new Vector3(frontSize * pieceLength, roofPrefab.transform.localScale.y, sideSize * pieceLength);
                Vector3 poss = new Vector3(frontSize * pieceLength / 2, i * pieceHeight, sideSize * pieceLength / 2);
                GameObject rooff = Instantiate(roofPrefab, poss, Quaternion.identity, newBuilding.transform);
                rooff.transform.localScale = scales;*/

                /*Vector3 stairPos = newBuilding.transform.position + new Vector3(pieceLength - 2f + 1.5f, i * pieceHeight, 1f);
                GameObject stairs = Instantiate(stair, stairPos, Quaternion.identity, newBuilding.transform);
                stairs.transform.Rotate(0, 180, 0);
                stairs.transform.Translate(0, 0, 2);
                if (i % 2 == 0)
                {
                    stairs.transform.Rotate(0, 180, 0);
                    stairs.transform.Translate(0, 0, 6);
                }*/
            }   
        }

        //newBuilding.transform.Rotate(Vector3.up * ( 90 * random));
        
        /*/roof
        Vector3 scale = new Vector3(frontSize * pieceLength, roofPrefab.transform.localScale.y, sideSize * pieceLength);
        Vector3 pos = new Vector3(frontSize * pieceLength / 2, floorAmount * pieceHeight, sideSize * pieceLength / 2);
        GameObject roof = Instantiate(roofPrefab, pos, Quaternion.identity, newBuilding.transform);
        roof.transform.localScale = scale;
        
        //Street
        scale = new Vector3(frontSize * (pieceLength * 2), roofPrefab.transform.localScale.y, sideSize * (pieceLength * 2));
        pos = new Vector3(frontSize * pieceLength / 2, 0 - 0.1f, sideSize * pieceLength / 2);
        roof = Instantiate(roofPrefab, pos, Quaternion.identity, newBuilding.transform);
        roof.transform.localScale = scale;*/
    }


    public void CreateFloorsFloor(GameObject newBuilding, GameObject[] wallPieces, int floorHeight, bool groundFloor, GameObject floor, bool roof, int floorNum)
    {
        int shopBack = CalculateSize(2, minWallAmt - 3);

        //corner piece = 2

        //shop openings = 4

        for (int x = 0; x <= sideSize; x++)
        {

            for (int i = 0; i <= frontSize; i++)
            {
                if (x == 0)
                {
                    if (i == 0)
                    {

                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight + 0.1f, 0);
                        GameObject newWallPiece = Instantiate(wallPieces[1], pos, Quaternion.Euler(0, 90, 0), newBuilding.transform);
                    }




                    else if (i == frontSize)
                    {



                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight + 0.1f, 0);
                        GameObject newWallPiece = Instantiate(wallPieces[1], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                    }


                    else
                    {

                        if (groundFloor)
                        {

                            Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, 0);
                            GameObject newWallPiece = Instantiate(wallPieces[3], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                            i++;

                        }
                        else
                        {
                            Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, 0);
                            GameObject newWallPiece = Instantiate(wallPieces[2], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                        }
                    }
                }
                else if (x == sideSize)
                {
                    //
                    if (i == 0)
                    {
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight + 0.1f, x * pieceLength);
                        GameObject newWallPiece = Instantiate(wallPieces[1], pos, Quaternion.Euler(0, 180, 0), newBuilding.transform);
                    }
                    else if (i == frontSize)
                    {
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight + 0.1f, x * pieceLength);
                        GameObject newWallPiece = Instantiate(wallPieces[1], pos, Quaternion.Euler(0, -90, 0), newBuilding.transform);

                    } /*else 
                    if (x == shopBack && groundFloor)
                    {
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                        GameObject newWallPiece = Instantiate(wallPieces[0], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                    } */



                    else
                    {
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                        GameObject newWallPiece = Instantiate(wallPieces[2], pos, Quaternion.Euler(0, 180, 0), newBuilding.transform);
                    }


                }
                
                /*(else if (x <= sideSize - 4 && i > frontSize - 2 && !roof)    
                {
                    if(x == sideSize - 4 && i == frontSize - 2) {
                       
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                        GameObject newWallPiece = Instantiate(door, pos, Quaternion.Euler(0, 90, 0), newBuilding.transform);
                    } else
                    {

                    }

                }*/


                /*else
                if (x == shopBack && groundFloor /*&& i == 0)
                {
                    
                    //Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                    //GameObject newWallPiece = Instantiate(wallPieces[0], pos, Quaternion.Euler(0, 90
                        //, 0), newBuilding.transform);
                } 
                else
                if (x == shopBack && groundFloor && i == frontSize)
                {
                    Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                    GameObject newWallPiece = Instantiate(wallPieces[0], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                } */
                else
                if (i == 0)
                {
                    Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                    GameObject newWallPiece = Instantiate(wallPieces[2], pos, Quaternion.Euler(0, 90, 0), newBuilding.transform);
                }
                else if (i == frontSize)
                {
                    Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                    GameObject newWallPiece = Instantiate(wallPieces[2], pos, Quaternion.Euler(0, -90, 0), newBuilding.transform);
                }
                else
                {

                    /*if (x == shopBack && groundFloor)
                    {
                        int rand = Random.Range(0, 2);
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight, x * pieceLength);
                        GameObject newWallPiece = Instantiate(firstFloorWallPieces[rand], pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                    }*/
                    
                        Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * (pieceLength)), floorHeight + 0.1f, x * pieceLength);
                        GameObject newWallPiece = Instantiate(floor, pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                    
                    
                }

                


            }
        }
    }

    /*
     if ((i == 1 || i ==2) && (x < 4 && x > 0))
                {

                    


                }
                else
                {
                    Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength - 2f + (i * (pieceLength / 2)), floorHeight, x);




                    GameObject newWallPiece = Instantiate(wallPieces, pos, Quaternion.identity, newBuilding.transform);

                }

                //front
                
     */

    public void CreateFloor(GameObject newBuilding, GameObject[] wallPieces, int floorHeight)
    {
        
            
        
        



        
            //First front and back wall
            for (int i = 0; i < frontSize; i++)
            {

                //front
                Vector3 pos = newBuilding.transform.position + new Vector3(pieceLength / 2 + (i * pieceLength), floorHeight, 0);
                int randomIndex = Random.Range(0, wallPieces.Length);


                GameObject newWallPiece = Instantiate(wallPieces[randomIndex], pos, Quaternion.identity, newBuilding.transform);



                pos += new Vector3(0, 0, sideSize * pieceLength);
                randomIndex = Random.Range(0, wallPieces.Length);

                newWallPiece = Instantiate(wallPieces[randomIndex], pos, Quaternion.Euler(0, 180, 0), newBuilding.transform);
            }
            
            //sides
            for (int i = 0; i < sideSize; i++)
            {
                //left side
                Vector3 pos = newBuilding.transform.position + new Vector3(0, floorHeight, pieceLength / 2 + (i * pieceLength));
                int randomIndex = Random.Range(0, wallPieces.Length);

                GameObject newWallPiece = Instantiate(wallPieces[randomIndex], pos, Quaternion.Euler(0, 90, 0), newBuilding.transform);

                //right side
                pos = newBuilding.transform.position + new Vector3(frontSize * pieceLength, floorHeight, pieceLength / 2 + (i * pieceLength));
                randomIndex = Random.Range(0, wallPieces.Length);
                newWallPiece = Instantiate(wallPieces[randomIndex], pos, Quaternion.Euler(0, -90, 0), newBuilding.transform);

            }

            //corners
            for (int i = 0; i < 4; i++)
            {
                //left side
                Vector3 pos = newBuilding.transform.position + new Vector3(0, floorHeight, 0);
                GameObject newWallPiece = Instantiate(cornerPiece, pos, Quaternion.Euler(0, 180, 0), newBuilding.transform);
                //right end
                pos += new Vector3(frontSize * pieceLength, 0, 0);
                newWallPiece = Instantiate(cornerPiece, pos, Quaternion.Euler(0, 90, 0), newBuilding.transform);
                //rightBack end
                pos += new Vector3(0, 0, sideSize * pieceLength);
                newWallPiece = Instantiate(cornerPiece, pos, Quaternion.Euler(0, 0, 0), newBuilding.transform);
                //leftBack end
                pos -= new Vector3(frontSize * pieceLength, 0, 0);
                newWallPiece = Instantiate(cornerPiece, pos, Quaternion.Euler(0, -90, 0), newBuilding.transform);


            }

        



    }




    // Start is called before the first frame update
    void Start()
    {
        CreateBuilding();   
    }

    //private void Awake()
    //{
        //CreateBuilding();
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
