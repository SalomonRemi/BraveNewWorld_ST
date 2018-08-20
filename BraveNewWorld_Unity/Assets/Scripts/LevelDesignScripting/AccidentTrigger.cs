using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class AccidentTrigger : MonoBehaviour {

    public Animator accidentAnim;
    public string soundName;

    private bool accidentHappened;

    private void OnTriggerEnter(Collider other)
    {
        if(!accidentHappened)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ScreenshakeManager.instance.DoAccidentShake();

                accidentAnim.SetBool("doAccident", true);

                AudioManager.instance.PlaySound(soundName);
            }

            accidentHappened = true;
        }
    }
}
