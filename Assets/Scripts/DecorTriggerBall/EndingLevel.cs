using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLevel : MonoBehaviour, ITriggerEnterBall
{
    public void ActionTriggerEnteredBall(GameObject ball)
    {
        LevelManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
