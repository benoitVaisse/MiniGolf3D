using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Vector3 _respawnPosition { get; set; }

    void Start()
    {
        _respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = _respawnPosition;
    }

    public void SetRespawnPosition()
    {
        _respawnPosition = transform.position;
    }
    public void SetRespawnPosition(Vector3 position)
    {
        _respawnPosition = position;
    }
}
