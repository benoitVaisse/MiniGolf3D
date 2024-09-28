using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    [SerializeField]
    private List<AudioClip> _audios = new();
    [SerializeField]
    private AudioSource _gameSound;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        _gameSound = transform.Find("GameSound").GetComponent<AudioSource>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("SoundManager").ToArray();
        if (gos.Length > 1) { Destroy(gameObject); }
    }

    public void PlayGameSound(int index)
    {
        _gameSound.PlayOneShot(_audios[index]);
    }


}

public class GameSountConst
{
    public const int PAUSE = 0;
}
