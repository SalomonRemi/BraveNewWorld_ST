using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDigicodeCode : MonoBehaviour {

    public digiCode digicode;

    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    void Update ()
    {
        text.text = digicode.keycode.ToString();
	}
}
