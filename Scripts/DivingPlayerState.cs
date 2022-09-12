using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    Player player;
    Rigidbody rb;

    public void Enter(Player player)
    {
        Debug.Log("Dive");
        rb = player.GetComponent<Rigidbody>();
        rb.AddForce(0, -10000 * Time.deltaTime, 0, ForceMode.VelocityChange);
        player.currentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rb.transform.position, Vector3.down, 0.55f))
        {
            IPlayerState nextState;
            if (Input.GetKey(KeyCode.S))
            {
                nextState = new DuckingPlayerState();
            }
            else
            {
                nextState = new StandingPlayerState();
            }

            nextState.Enter(player);
        }
    }
}
