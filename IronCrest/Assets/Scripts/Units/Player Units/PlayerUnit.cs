using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public new void BeginMovement(List<GameObject> tilePath)
    {
        movement.BeginMove(tilePath);
    }

    public new int ReturnType()
    {
        //0 is base, 1 is player, 2 is enemy
        return 1;
    }

}
