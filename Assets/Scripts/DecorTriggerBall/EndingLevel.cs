using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLevel : MonoBehaviour, ITriggerEnterBall
{
    [SerializeField]
    private GameObject particule;
    public void ActionTriggerEnteredBall(GameObject ball)
    {
        StartCoroutine(FinishLevel());
    }

    private IEnumerator FinishLevel()
    {
        particule.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        LevelManager.Instance.ShowPanelEndingLevel();
    }
}
