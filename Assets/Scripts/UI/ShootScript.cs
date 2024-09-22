using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private float _power = 2000;
    private bool _canShoot = true;
    private bool _barShotActivated = false;
    [SerializeField]
    private float _valueProgressBar = 0.01f;

    [SerializeField]
    private RectTransform _rectTransformBar;


    void Start()
    {
        _ball = GameObject.Find("Ball");
#if UNITY_EDITOR || UNITY_STANDALONE
        transform.Find("ButtonShot").gameObject.SetActive(false);
#endif
        SetForceBarToOrigin();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0)) { Handle(); }
#endif
        if (_ball.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
        {
            _canShoot = true;
            _ball.GetComponent<BallManager>().SetRespawnPosition();
        }
    }

    public void Handle()
    {
        if (_canShoot)
        {
            if (_barShotActivated)
            {
                Shoot();
            }
            else
            {
                PowerBarShoot();
            }
        }
    }

    private void PowerBarShoot()
    {
        _barShotActivated = true;
        StartCoroutine(ProgressBarShoot());
    }

    private IEnumerator ProgressBarShoot()
    {
        int mustGrowUp = 1;
        while (_barShotActivated)
        {
            if (_rectTransformBar.localScale.x > (1 - _valueProgressBar))
                mustGrowUp = -1;
            if (_rectTransformBar.localScale.x < _valueProgressBar)
                mustGrowUp = 1;

            yield return new WaitForSeconds(_valueProgressBar);
            _rectTransformBar.localScale = new Vector3(_rectTransformBar.localScale.x + (_valueProgressBar * mustGrowUp), _rectTransformBar.localScale.y, _rectTransformBar.localScale.z);
        }
    }

    private void Shoot()
    {
        _canShoot = false;
        _barShotActivated = false;
        StopAllCoroutines();
        float shootPowerFinal = _rectTransformBar.localScale.x * _power;
        _ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootPowerFinal);
        SetForceBarToOrigin();
    }

    private void SetForceBarToOrigin()
    {
        _rectTransformBar.localScale = new Vector3(0f, _rectTransformBar.localScale.y, _rectTransformBar.localScale.z);
    }
}
