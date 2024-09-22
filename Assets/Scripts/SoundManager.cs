using System.Collections;
using System.Collections.Generic;
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
        _instance = this;
        _gameSound = transform.Find("GameSound").GetComponent<AudioSource>();
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
