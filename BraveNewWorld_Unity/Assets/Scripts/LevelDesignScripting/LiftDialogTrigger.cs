using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDialogTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EndingManager.instance.liftDialogTrigger = true;
        }
    }
}
