using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ITriggerEnterBall actionTriggerEnteredBall = other.GetComponent<ITriggerEnterBall>();
        actionTriggerEnteredBall?.ActionTriggerEnteredBall(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
