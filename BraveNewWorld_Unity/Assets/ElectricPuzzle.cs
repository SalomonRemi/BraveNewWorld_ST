using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElectricPuzzle : MonoBehaviour {


    public List<PuzzleSlider> sliderList;

    public int megaphoneCode;
    public int radioCode;
    public int alarmCode;
    public int digicodeCode;

    public TextMeshPro text;

    private List<int> sliderOn;

    private int multiplicationResult;


    private void Start()
    {
        multiplicationResult = 1;
        sliderOn = new List<int>();
    }

    void Update ()
    {
        multiplicationResult = 1;
        
        for (int i = 0; i < sliderList.Count; i++)
        {
            multiplicationResult = multiplicationResult * sliderList[i].realSliderValue;
        }

        text.text = multiplicationResult.ToString();


        if(multiplicationResult == megaphoneCode)
        {
            //IL SE PASSE UN TRUC
        }
        else if (multiplicationResult == radioCode)
        {
            //IL SE PASSE UN TRUC
        }
        else if (multiplicationResult == alarmCode)
        {
            //IL SE PASSE UN TRUC
        }
        else if (multiplicationResult == digicodeCode)
        {
            //IL SE PASSE UN TRUC
        }
    }
}