using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            EndingManager.instance.endDialogTrigger = true;
        }
    }
}
