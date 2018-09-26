using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryEndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }

    IEnumerator LoadTempEndScene()
    {
        yield return new WaitForSeconds(15f);
    }
}
