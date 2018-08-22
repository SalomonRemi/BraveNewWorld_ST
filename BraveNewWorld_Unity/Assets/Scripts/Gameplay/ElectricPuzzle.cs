using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DigitalRuby.SoundManagerNamespace;

public class ElectricPuzzle : MonoBehaviour {

    public static ElectricPuzzle instance = null;

    public List<PuzzleSlider> sliderList;
    public TextMeshPro text;
    public GameObject validateButton;

    [Header("Megaphone")]
    public int megaphoneCode;
    public GameObject megaphoneNumberDisplay;
    public Megaphone megaphone;

    [Header("Radio")]
    public int radioCode;
    public GameObject radioNumberDisplay;
    public Radio radio;

    [Header("Digicode")]
    public int digicodeCode;
    public GameObject digicodeNumberDisplay;
    public DigicodePuzzle digicode;

    [Header("Alarm")]
    public int alarmCode;
    public GameObject alarmNumberDisplay;
    

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
            StartCoroutine(Flash(Color.green));
            megaphoneNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
            megaphone.TurnOnMegaphone();
        }
        else if (multiplicationResult == radioCode)
        {
            Debug.Log("radio");
            StartCoroutine(Flash(Color.green));
            radioNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            radio.TurnOnRadio();
            AudioManager.instance.PlaySound("digiOkSound");
        }
        else if (multiplicationResult == alarmCode)
        {
            Debug.Log("alarm");
            StartCoroutine(Flash(Color.green));
            alarmNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
        }
        else if (multiplicationResult == digicodeCode)
        {
            Debug.Log("digicode");
            StartCoroutine(Flash(Color.green));
            digicodeNumberDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
            AudioManager.instance.PlaySound("digiOkSound");
            digicode.TurnOnDigi();
        }
        else
        {
            Debug.Log("false");
            StartCoroutine(Flash(Color.red));
            AudioManager.instance.PlaySound("digiError");
        }
    }

    IEnumerator Flash (Color flashColor)
    {
        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = flashColor;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = Color.grey;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = flashColor;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = Color.grey;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = flashColor;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = flashColor;
        yield return new WaitForSeconds(0.2f);

        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = Color.grey;
        yield return new WaitForSeconds(0.2f);


        foreach (PuzzleSlider slider in sliderList)
        {
            slider.gameObject.GetComponent<MeshRenderer>().material.color = slider.currentMatColor;
        }
        validateButton.GetComponent<MeshRenderer>().material.color = validateButton.GetComponent<PuzzleSlider>().currentMatColor;

        yield return null;
    }
}