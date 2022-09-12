using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    Player player;
    Rigidbody rb;
    float airTime;

    public void Enter(Player player)
    {
        Debug.Log("He Doin a Jump");
        rb = player.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 10, 0);
        airTime = Time.time;
        player.currentState = this;
    }

    public void Execute(Player player)
    {
        Debug.Log("He Jump");
        if (Physics.Raycast(rb.transform.position, Vector3.down, 0.55f) && Time.time - airTime > 0.5f)
        {
            StandingPlayerState standState = new StandingPlayerState();
            standState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DivingPlayerState diveState = new DivingPlayerState();
            diveState.Enter(player);
        }
    }
}
