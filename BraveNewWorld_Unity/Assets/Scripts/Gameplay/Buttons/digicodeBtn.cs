﻿using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digicodeBtn : MonoBehaviour {

    public bool clicked;
    public float btnValue;
    public bool validate;
    public bool reset;
    public digiCode parent;

    private void Start()
    {
        parent = gameObject.GetComponentInParent<digiCode>();
    }


    public void enableButton()
    {
        if (validate) //  && parent.enabledAmmount == 4 && !MissionManager.instance.keyPadCorrect
        {
            if(parent.keycode == 0)
            {
                AudioManager.instance.PlaySound("buttonFalse");
            }
            else parent.validateInput();
        }
        else if(reset)
        {
            if(parent.keycode == 0)
            {
                AudioManager.instance.PlaySound("buttonFalse");
            }
            else
            {
                parent.keycode = 0;
                parent.enabledAmmount = 0;
                AudioManager.instance.PlaySound("clickBtn");
            }
        }
        else if (parent.enabledAmmount < 4 && !clicked)
        {
            if (parent.enabledAmmount == -1)
            {
				parent.enabledAmmount = 0;
                parent.keycode += btnValue;
            }
            else
            {
                parent.keycode = (parent.keycode * 10) + btnValue;
            }
            AudioManager.instance.PlaySound("clickBtn");
            parent.enabledAmmount++;
           // clicked = true;
        }
    }
}