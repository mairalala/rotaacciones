using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    [SerializeField] Transform _stage;
    [SerializeField] float _rotationSpeed;
    [SerializeField] GameObject _playerObj;
    [SerializeField] Vector3[] _rotations;
    int _currentRotation;
    bool _rotationActive;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            _playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeRotation(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeRotation(false);
        }

        if (_rotationActive)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotations[_currentRotation]), _rotationSpeed * Time.deltaTime); ;

            if (transform.rotation == Quaternion.Euler(_rotations[_currentRotation]))
            {
                _rotationActive = false;
            }
        }

    }

    void ChangeRotation(bool _right)
    {
        _stage.SetParent(null);
        transform.position = _playerObj.transform.position;
        _stage.SetParent(transform);

        if (_right)
        {
            if (_currentRotation - 1 < 0)
            {
                _currentRotation = _rotations.Length - 1;
            }

            else
            {
                _currentRotation--;
            }
        }

        else
        {
            if (_currentRotation + 1 > _rotations.Length - 1)
            {
                _currentRotation = 0;
            }

            else
            {
                _currentRotation++;
            }
        }

        _rotationActive = true;
    }
}
