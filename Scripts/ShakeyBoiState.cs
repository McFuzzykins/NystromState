using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeyBoiState : IPlayerState
{
    Player player;
    Rigidbody rb;

    public void Enter(Player player)
    {
        Debug.Log("He Shake");
        rb = player.GetComponent<Rigidbody>();
        rb.transform.localScale += new Vector3(3, 2, 5) * Time.time; //(4, 3, 6)
        rb.transform.position += new Vector3(2, 0, 4);
        rb.transform.localScale -= new Vector3(2, 1, 3) * Time.time; //(2, 2, 2)
        rb.transform.position -= new Vector3(2, 0, 4);
        rb.transform.localScale -= new Vector3(0, 1, 1) * Time.time; //(1, 0, 1)
        player.currentState = this;
    }

    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.Q))
        {
            StandingPlayerState standState = new StandingPlayerState();
            standState.Enter(player);
        }
    }
}
