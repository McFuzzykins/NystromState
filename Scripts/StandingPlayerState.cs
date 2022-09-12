using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Standing");
        player.currentState = this;
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingPlayerState jumpState = new JumpingPlayerState();
            jumpState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DuckingPlayerState duckState = new DuckingPlayerState();
            duckState.Enter(player);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ShakeyBoiState shakeState = new ShakeyBoiState();
            shakeState.Enter(player);
        }
    }
}
