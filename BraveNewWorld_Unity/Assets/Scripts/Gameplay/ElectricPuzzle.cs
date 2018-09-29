﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DigitalRuby.SoundManagerNamespace;

public class ElectricPuzzle : MonoBehaviour {

    public static ElectricPuzzle instance = null;

    [Header("Puzzles Settigns")]
    public List<PuzzleSlider> sliderList;
    public TextMeshPro text;
    public GameObject validateButton;

    public Material greenMat;
    public Material redMat;
    public Material originalMat;

    [Header("Megaphone")]
    public int megaphoneCode;
    public GameObject megaphoneNumberDisplay;
    public Megaphone megaphone;
    public GameObject megaCable;

    [Header("Radio")]
    public int radioCode;
    public GameObject radioNumberDisplay;
    public Radio radio;
    public GameObject radioCable;

    [Header("Digicode")]
    public int digicodeCode;
    public GameObject digicodeNumberDisplay;
    public DigicodePuzzle digicode;
    public GameObject digiCable;

    [Header("Alarm")]
    public int alarmCode;
    public GameObject alarmNumberDisplay;
    public Alarm alarm;
    public GameObject alarmCable;

    [Header("Cables Settigns")]
    public Material cableOnMat;


    private List<int> sliderOn;

    private int multiplicationResult;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

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


        if(multiplicationResult == 1)
        {
            text.text = "0";
        }
        else text.text = multiplicationResult.ToString();
    }

    public void Validate()
    {
        if(multiplicationResult == megaphoneCode)
        {
            Debug.Log("megaphone");
            StartCoroutine(Flash(greenMat));
            megaphoneNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
            megaphone.TurnOnMegaphone();
            megaCable.GetComponent<MeshRenderer>().material = cableOnMat;
        }
        else if (multiplicationResult == radioCode)
        {
            Debug.Log("radio");
            StartCoroutine(Flash(greenMat));
            radioNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            radio.TurnOnRadio();
            AudioManager.instance.PlaySound("digiOkSound");
            radioCable.GetComponent<MeshRenderer>().material = cableOnMat;
        }
        else if (multiplicationResult == alarmCode)
        {
            Debug.Log("alarm");
            StartCoroutine(Flash(greenMat));
            alarmNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
            alarm.TurnOnAlarm();
            alarmCable.GetComponent<MeshRenderer>().material = cableOnMat;
        }
        else if (multiplicationResult == digicodeCode)
        {
            Debug.Log("digicode");
            StartCoroutine(Flash(greenMat));
            digicodeNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
            digicode.TurnOnDigi();
            megaCable.GetComponent<MeshRenderer>().material = cableOnMat;
        }
        else
        {
            Debug.Log("false");
            StartCoroutine(Flash(redMat));
            AudioManager.instance.PlaySound("digiError");
        }
    }

    IEnumerator Flash (Material flashColor)
    {
        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = flashColor;
        }
        //validateButton.GetComponent<MeshRenderer>().material = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = originalMat;
        }
        //validateButton.GetComponent<MeshRenderer>().material = originalMat;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = flashColor;
        }
        //validateButton.GetComponent<MeshRenderer>().material = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = originalMat;
        }
        //validateButton.GetComponent<MeshRenderer>().material = originalMat;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = flashColor;
        }
        //validateButton.GetComponent<MeshRenderer>().material = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = originalMat;
        }
        //validateButton.GetComponent<MeshRenderer>().material = originalMat;
        yield return new WaitForSeconds(0.2f);


        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material = slider.currentMatColor;
        }
        //validateButton.GetComponent<MeshRenderer>().material = validateButton.GetComponent<PuzzleSlider>().currentMatColor;

        yield return null;
    }
}