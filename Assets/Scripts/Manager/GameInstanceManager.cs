using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceManager : MonoBehaviour
{
    private GameObject _soundSystem;
    [SerializeField]
    private GameObject _soundSystemRessource;
    // Start is called before the first frame update
    void Start()
    {
        _soundSystem = GameObject.Find("_SoundManager");
        if (_soundSystem == null)
        {
            Instantiate(_soundSystemRessource);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
