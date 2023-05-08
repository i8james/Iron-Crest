using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PartSelectGameManager : MonoBehaviour
{
    public static PartSelectGameManager PSInstance;

    public PartSelectGameState State;

    public static event Action<PartSelectGameState> OnPSGameStateChanged;

    public Unit activeDisplayUnit;

    private void Awake()
    {
        PSInstance = this;
        
    }

    public void NewPSGameState(PartSelectGameState newState)
    {
        State = newState;
        OnPSGameStateChanged(newState);
    }

    

}

public enum PartSelectGameState
{
    BaseMenu,
    PartSelectOpen
}