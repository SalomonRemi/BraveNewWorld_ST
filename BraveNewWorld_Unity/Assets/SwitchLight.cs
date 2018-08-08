using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    private bool isObj1Activated;
    private bool isObj2Activated;
    private bool isObj3Activated;
    private bool isObj4Activated;

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.U))
        {
            if(isObj1Activated)
            {
                isObj1Activated = false;
                obj1.SetActive(false);
            }
            else
            {
                isObj1Activated = true;
                obj1.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isObj2Activated)
            {
                isObj2Activated = false;
                obj2.SetActive(false);
            }
            else
            {
                isObj2Activated = true;
                obj2.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isObj3Activated)
            {
                isObj3Activated = false;
                obj3.SetActive(false);
            }
            else
            {
                isObj3Activated = true;
                obj3.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isObj4Activated)
            {
                isObj4Activated = false;
                obj4.SetActive(false);
            }
            else
            {
                isObj4Activated = true;
                obj4.SetActive(true);
            }
        }
    }
}
