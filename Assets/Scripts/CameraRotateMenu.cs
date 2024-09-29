using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateMenu : MonoBehaviour
{
    private GameObject _arroundRotation;
    // Start is called before the first frame update
    void Start()
    {
        _arroundRotation = GameObject.Find("Level").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_arroundRotation.transform.position, Vector3.up, 10f * Time.deltaTime);
    }
}
