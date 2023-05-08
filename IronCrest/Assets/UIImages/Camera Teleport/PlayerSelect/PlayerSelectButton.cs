using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectButton : MonoBehaviour
{
    public Unit owner;
    public Image self;

    public void SetOwnerActive()
    {
        if (GameManager.Instance.State == GameState.PlayerSelect)
        {
            if (owner != null)
            {
                if (!owner.acted)
                {
                    owner.occupiedTile.owner.DisplayTileRange(owner.occupiedTile, 0);
                    GameManager.Instance.NewGameState(GameState.PlayerMove, owner);
                    
                }
            }
        }
    }
}
