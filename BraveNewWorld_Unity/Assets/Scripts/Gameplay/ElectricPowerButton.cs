using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class ElectricPowerButton : MonoBehaviour {

    public List<GameObject> objectList;
    public Animator buttonHolderAnim;

    [HideInInspector] public bool isActivated;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void EnableObjects()
    {
        if(!isActivated)
        {
            AudioManager.instance.PlaySound("powerButton");
            buttonHolderAnim.SetBool("SetOn", true);

            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].SetActive(true);
            }

            isActivated = true;
        }

        col.enabled = false;
    }
}