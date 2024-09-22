using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private float Offset = 12;
    [SerializeField]
    private int Recul = 3;
    private float RotationX;
    private float RotationY;
    private Quaternion Rotation;
    private Touch Touch;

    private Vector3 ddd;
    void Start()
    {
        Ball = GameObject.Find("Ball").gameObject;
        RotationX = transform.eulerAngles.x;
        RotationY = transform.eulerAngles.y;
        ddd = Ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        RotationY += Input.GetAxis("Mouse X");
#endif

#if UNITY_ANDROID || UNITY_IPHONE
         if(Input.touches.Length == 1)
         {
            RotationY += Input.GetTouch(0).deltaPosition.x *0.1f;
         }
#endif

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Rotation = Quaternion.Euler(RotationX, RotationY, 0);
            transform.rotation = Rotation;
            //Vector3 position = /*Rotation **/ Ball.transform.position - ddd;
            Vector3 position = Rotation * new Vector3(0, Ball.transform.position.y + Recul, -Offset) + Ball.transform.position;
            transform.position = position;
        }
    }
}
