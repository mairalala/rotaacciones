using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageRotation : MonoBehaviour
{
    //[SerializeField] public GameObject[] pies;
    [SerializeField] Transform _stage;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Vector3[] _rotations;
    [SerializeField] public bool TocaSuelo = false;
    //[SerializeField] public GameObject Player;
    //[SerializeField] Vector3 _increaseRotation = new Vector3(0, 0, 0.1f);
    public int _currentRotation;
    bool _rotationActive;
    public int posicionActualPie = 0;
    //bool _canIncreaseRotation = true;

    ManagerPlaye _player;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagerPlaye>();
        }

        //for (int i = 0; i < pies.Length; i++)
        //{
        //    if (i == 0)
        //    {
        //        pies[i].SetActive(true);
        //    }
        //    else
        //    {
        //        pies[i].SetActive(false);
        //    }
        //}

    }

    private void Update()
    {
        if (_player != null)
        {

            Debug.Log("LoHaceCorrutina");
            // Player.GetComponent<ManagerPlaye>().Rotaranimaciones();
        }
        if (Input.GetKeyDown(KeyCode.D) && _player.TocandoSuelo/*&& TocaSuelo*/)
        {
            SinSuelo();
            ChangeRotation(true);
            //HabilitaPie(true);
        }

        if (Input.GetKeyDown(KeyCode.A) && _player.TocandoSuelo)
        {
            SinSuelo();
            ChangeRotation(false);
            //HabilitaPie(false);
        }

        if (_rotationActive)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotations[_currentRotation]), _rotationSpeed * Time.deltaTime);

            if (transform.rotation == Quaternion.Euler(_rotations[_currentRotation]))
            {
                _rotationActive = false;
            }
        }

        // Si se mantiene presionada la tecla "E"
        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        if (_canIncreaseRotation)
        //        {
        //            // Aumenta gradualmente la rotación en Z
        //            transform.rotation *= Quaternion.Euler(0, 0, 0.3f);


        //            // Verifica si se ha alcanzado la rotación límite
        //            if (transform.rotation.eulerAngles.z >= _rotations[_currentRotation].z + 45)
        //            {
        //                _canIncreaseRotation = false;
        //            }
        //        }
        //    }
        //    // Si se deja de presionar la tecla "E"
        //    else
        //    {
        //        _canIncreaseRotation = true;
        //        // Devuelve gradualmente la rotación en Z a su valor anterior
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotations[_currentRotation]), _rotationSpeed * Time.deltaTime);
        //    }
        //}

        void ChangeRotation(bool _right)
        {
            _stage.SetParent(null);
            transform.position = _player.transform.position;
            _stage.SetParent(transform);

            if (_right)
            {
                if (_currentRotation + 1 > _rotations.Length - 1)
                {
                    _currentRotation = 0;
                }

                else
                {
                    _currentRotation++;
                    _player.GetComponent<ManagerPlaye>().AumentarPosicion();
                    _player.GetComponent<ManagerPlaye>().Rotaranimaciones();

                }
            }

            else
            {
                if (_currentRotation - 1 < 0)
                {
                    _currentRotation = _rotations.Length - 1;
                }

                else
                {
                    _currentRotation--;
                    _player.GetComponent<ManagerPlaye>().DisminuirPosicion();
                    _player.GetComponent<ManagerPlaye>().Rotaranimaciones();

                }
            }

            _rotationActive = true;

            _player.ActivarPies(_currentRotation);
        }
    }
    public void HabilitaPie(bool _r)
    {
        if (_r)
        {
            posicionActualPie++;
            if (posicionActualPie >= 4)
            {
                posicionActualPie = 0;
            }
        }
        else
        {


            posicionActualPie--;
            if (posicionActualPie < 0)
            {
                posicionActualPie = 3;

            }

        }

        //for (int i = 0; i < pies.Length; i++)
        //{
        //    if (i == posicionActualPie)
        //    {
        //        pies[i].SetActive(true);
        //    }
        //    else
        //    {
        //        pies[i].SetActive(false);
        //    }
        //}
    }



    public void EstaEnSuelo()
    {
        TocaSuelo = true;

        // Aquí implementa la lógica para determinar si el jugador está en el suelo
        // y devuelve true si lo está, de lo contrario devuelve false.

    }

    public void SinSuelo()
    {
        TocaSuelo = false;

        // Aquí implementa la lógica para determinar si el jugador está en el suelo
        // y devuelve true si lo está, de lo contrario devuelve false.

    }
}

