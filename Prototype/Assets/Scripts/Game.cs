using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Game
{
    public static Game current;
    public Character unitA;
    public Character unitB;
    public Character unitC;

    public Game ()
    {
        unitA = newCharacter();
        unitB = newCharacter();
        unitC = newCharacter();
    }
}
