using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class DigicodePuzzle : MonoBehaviour {

    private Animator anim;

    private bool isActivated;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TurnOnDigi() //CALL ON ELECTRIC PANNEL GOOD
    {
        isActivated = false;
        anim.SetBool("turnOn", true);
    }
}
