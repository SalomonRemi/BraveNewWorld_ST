using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class ElectricPowerButton : MonoBehaviour {

    public List<GameObject> objectList;

    private bool isActivated;
	
    public void EnableObjects()
    {
        if(!isActivated)
        {
            AudioManager.instance.PlaySound("lockerButton");

            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].SetActive(true);
            }

            isActivated = true;
        }
    }
}
