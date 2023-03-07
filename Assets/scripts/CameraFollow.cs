using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            _playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void LateUpdate()
    {
        if (_playerObj)
        {
            transform.position = new Vector3(_playerObj.transform.position.x, _playerObj.transform.position.y, transform.position.z);
        }
    }
}
