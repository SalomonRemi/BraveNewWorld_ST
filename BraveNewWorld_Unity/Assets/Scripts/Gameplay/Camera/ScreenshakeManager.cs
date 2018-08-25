using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeManager : MonoBehaviour {

    public static ScreenshakeManager instance = null;

    public CameraShake.Properties elevatorLongShake;
    public CameraShake.Properties elevatorEndShake;
    public CameraShake.Properties accidentShake;
    public CameraShake.Properties alarmShake;

    private bool isInElevator = true;

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
        StartCoroutine(TimingCoroutine());
    }

    public void DoAccidentShake()
    {
        FindObjectOfType<CameraShake>().StartShake(accidentShake);
    }

    public void DoAlarmShake()
    {
        FindObjectOfType<CameraShake>().StartShake(alarmShake);
    }

    IEnumerator TimingCoroutine()
    {
		//FindObjectOfType<CameraShake>().StartShake (elevatorLongShake);

		yield return new WaitForSeconds(MissionManager.instance.timeInElevator + MissionManager.instance.fadeTime);

		FindObjectOfType<CameraShake>().StartShake(elevatorEndShake);
    }
}