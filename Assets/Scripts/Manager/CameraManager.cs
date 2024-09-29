using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private float _offset = 12;
    [SerializeField]
    private int _recul = 3;
    private float _rotationX;
    private float _rotationY;
    private Quaternion _rotation;
    void Start()
    {
        _ball = GameObject.Find("Ball").gameObject;
        _rotationX = transform.eulerAngles.x;
        _rotationY = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        _rotationY += Input.GetAxis("Mouse X");
#endif

#if UNITY_ANDROID || UNITY_IPHONE
         if(Input.touches.Length == 1)
         {
            _rotationY += Input.GetTouch(0).deltaPosition.x *0.1f;
         }
#endif

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            _rotation = Quaternion.Euler(_rotationX, _rotationY * 4, 0);
            transform.rotation = _rotation;
            //Vector3 position = /*Rotation **/ Ball.transform.position - ddd;
            Vector3 position = _rotation * new Vector3(0, _ball.transform.position.y + _recul, -_offset) + _ball.transform.position;
            transform.position = position;
        }

        if(transform.position.y < 0.0f)
            transform.position =  new Vector3(transform.position.x, 0.0f, transform.position.z);
    }
}
