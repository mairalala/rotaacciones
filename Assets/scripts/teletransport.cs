using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletransport : MonoBehaviour
{
    public Transform target;
    public GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = target.transform.position;
    }
}
