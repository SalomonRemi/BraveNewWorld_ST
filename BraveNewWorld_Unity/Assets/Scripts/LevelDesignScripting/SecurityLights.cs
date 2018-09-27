using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLights : MonoBehaviour {

    public ElectricPowerButton ep;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ep.EnableObjects();
        }
    }
}