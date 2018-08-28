using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockerNum : MonoBehaviour {

    public int goodNumber;
    public int goodNumber2;

    [HideInInspector] public bool isGoodNumber;
    [HideInInspector] public bool isGoodNumber2;

    private int actualNumber = 1;
    private TextMeshPro displayText;


    private void Start()
    {
        displayText = gameObject.GetComponentInChildren<TextMeshPro>();
    }


    private void Update()
    {
        displayText.text = actualNumber.ToString();

        if (goodNumber == actualNumber) isGoodNumber = true;
        else isGoodNumber = false;

        if (goodNumber2 == actualNumber) isGoodNumber2 = true;
        else isGoodNumber2 = false;
    }


    public void IncreaseNumber()
    {
        if (actualNumber == 9)
        {
            actualNumber = 1;
        }
        else actualNumber++;
    }

    public void DecreaseNumber()
    {
        if (actualNumber == 1)
        {
            actualNumber = 9;
        }
        else actualNumber--;
    }
}