using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSkipLight : MonoBehaviour {

    public GameObject player;
    public ElectricPowerButton button;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.L)) Skip();
	}

    private void Skip()
    {
        player.transform.position = transform.position;
        button.EnableObjects();
    }
}