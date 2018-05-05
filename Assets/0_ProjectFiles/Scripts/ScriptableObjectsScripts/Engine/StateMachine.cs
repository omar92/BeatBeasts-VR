﻿using UnityEngine;

[CreateAssetMenu(fileName = "StateMachine", menuName = "Engine/StateMachine", order = 2)]
public class StateMachine : ScriptableObject
{
    
    public GameState previousState;
    public GameState currentState;

    public void ChangeStateForced(GameState newState)
    {
        Debug.LogWarning("state changed:" + newState);
        if (currentState != null)
        {
            currentState.OnExit();
        }
      
        previousState = currentState;
        currentState = newState;
        currentState.OnEnter();
    }

    /// <summary>
    /// Chnage state only if all listener is done and ready to change state
    /// Also it set the current listener to Done if failed to change now
    /// returns True if success
    /// returns false if failed
    /// </summary>
    /// <param name="newState"></param>
    /// <returns></returns>
    public bool ChangeStateSmooth(GameState newState)
    {
        if(currentState!=null)
        {
            if (currentState.IsAllListenersDone())
            {
                ChangeStateForced(newState);
                return true;//success
            }
            else
            {
                Debug.LogWarning("IsAllListenersDone: false");
                return false;//fail
            }
        }
        else
        {
            ChangeStateForced(newState); //no current state so change anyway
            return true;
        }

    }
}