using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockerNum : MonoBehaviour {

    public int goodNumber;
    public int goodNumber2;

    public int redFoodNumber;
    public int greenFoodNumber;
    public int somaNumber;

    [HideInInspector] public bool isGoodNumber;
    [HideInInspector] public bool isGoodNumber2;
    [HideInInspector] public bool isRedFoodNumber;
    [HideInInspector] public bool isGreenFoodNumber;
    [HideInInspector] public bool isSomaNumber;

    private int actualNumber = 1;
    private TextMeshPro displayText;


    private void Start()
    {
        actualNumber = Random.Range(1, 6);
        displayText = gameObject.GetComponentInChildren<TextMeshPro>();
    }


    private void Update()
    {
        displayText.text = actualNumber.ToString();

        if (actualNumber == goodNumber) isGoodNumber = true;
        else isGoodNumber = false;

        if (actualNumber == goodNumber2) isGoodNumber2 = true;
        else isGoodNumber2 = false;

        if (actualNumber == redFoodNumber) isRedFoodNumber = true;
        else isRedFoodNumber = false;
        if (actualNumber == greenFoodNumber) isGreenFoodNumber = true;
        else isGreenFoodNumber = false;
        if (actualNumber == somaNumber) isSomaNumber = true;
        else isSomaNumber = false;
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