using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipSwitch : MonoBehaviour {

    private Animator anim;
    public bool switchOn = false;

    private MeshCollider col;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        col = GetComponent<MeshCollider>();
    }

    public void flip()
    {
        if (switchOn)
        {
            switchOn = false;
        }
        else
        {
            switchOn = true;
            col.enabled = false;
        }

        anim.SetBool("doSwitch", true);

        AudioManager.instance.PlaySound("leverMove");
    }
}