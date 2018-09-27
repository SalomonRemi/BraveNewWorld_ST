using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Toilet : MonoBehaviour {

    public Animator anim;

    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void DoFlush()
    {
        anim.SetBool("isActive", true);
        AudioManager.instance.PlaySound("toiletFlush");
        col.enabled = false;
    }
}