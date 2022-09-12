using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerState currentState;

    private void Awake()
    {
        currentState = new StandingPlayerState();
    }

    void Update()
    {
        currentState.Execute(this);
    }
}
