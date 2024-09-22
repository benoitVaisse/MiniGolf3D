using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLevel : MonoBehaviour, ITriggerEnterBall
{
    public void ActionTriggerEnteredBall(GameObject ball)
    {
        ball.GetComponent<BallManager>().Respawn();
    }
}
