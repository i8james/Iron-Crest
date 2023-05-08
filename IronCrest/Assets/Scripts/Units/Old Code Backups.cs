using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCodeBackups : MonoBehaviour
{
    /*private IEnumerator EnemyPathfindSteps(GridStats targetTile)
    {
        int detectRange = GameManager.Instance.activeUnit.targetDetectRange;

        int moveRange = GameManager.Instance.activeUnit.moveRange;

        int weaponRange = GameManager.Instance.activeUnit.weaponRange;

        //Path to player
        List<GameObject> initPath = EnemyCreateTilePath(targetTile, GameManager.Instance.activeUnit, detectRange);

        yield return null;

        GridStats newTargetTile;

        if (initPath.Count > moveRange)
        {
            //Make a new path to last player unit path spot within range
            newTargetTile = initPath[(initPath.Count - 1) - moveRange].GetComponent<GridStats>();
        } else
        {
            //Make a new path that doesn't reach player's location due to weapon range
            newTargetTile = initPath[(initPath.Count - 1) - weaponRange].GetComponent<GridStats>();
        }

        yield return null;

        List<GameObject> newPath = EnemyCreateTilePath(newTargetTile, GameManager.Instance.activeUnit, GameManager.Instance.activeUnit.targetDetectRange);

        yield return null;

        SendTargetPath(newPath);

        yield return null;
    }*/
}
