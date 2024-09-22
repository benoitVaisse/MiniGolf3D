using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation = new Vector3(0,10,0);
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
