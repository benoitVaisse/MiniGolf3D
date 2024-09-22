using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    [SerializeField]
    private Material[] _skyboxMaterials = new Material[5];
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, _skyboxMaterials.Length);
        RenderSettings.skybox = _skyboxMaterials[random];
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 1f * Time.time);
    }
}
