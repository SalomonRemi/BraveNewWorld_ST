using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    public string startRadioName;
    public string cutRadioName;

    public GameObject node;

    public Animator radioAnim;

    private MeshRenderer nodeMr;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        nodeMr = node.GetComponent<MeshRenderer>();
    }


    public void TurnOnRadio() //CALL ON ELECTRIC PANNEL GOOD
    {
        CutRadio();
        radioAnim.SetBool("turnOn", true);
    }


    public void StartRadio() //CALL ON BUTTON PRESS ON
    {
        nodeMr.material.color = Color.green;
        isActivated = true;
    }

    public void CutRadio() //CALL ON BUTTON PRESS OFF
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
    }
}
