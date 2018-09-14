using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    public string displayName;

    public Animator doorAnim;

    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void OpenDoor()
    {
        doorAnim.SetBool("Open", true);
        AudioManager.instance.PlaySound("doorOpen");
        AudioManager.instance.PlaySound("buttonFalse");

        col.enabled = false;
    }
}