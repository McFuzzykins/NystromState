using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerState
{
    Player player;
    Rigidbody rb;

    public void Enter(Player player)
    {
        Debug.Log("Ducking");
        rb = player.GetComponent<Rigidbody>();
        rb.transform.localScale *= 0.5f;
        player.currentState = this;
    }

    public void Execute(Player player)
    {
        //From duck to stand
        if (!Input.GetKey(KeyCode.S))
        {
            rb.transform.localScale *= 2.0f;
            StandingPlayerState standState = new StandingPlayerState();
            standState.Enter(player);
        }

        //from duck to bigJump
        if (Input.GetKey(KeyCode.Space))
        {
            rb.transform.localScale *= 2.5f;
            BigJumpState bigJump = new BigJumpState();
            bigJump.Enter(player);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rb.transform.localScale *= 2.0f;
            ShakeyBoiState shakeState = new ShakeyBoiState();
            shakeState.Enter(player);  
        }
    }
}
