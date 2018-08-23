using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmRotator : MonoBehaviour {

    public float rotationSpeed;

    private Vector3 rot;

    private void Start()
    {
        rot = new Vector3(0, rotationSpeed, 0);
    }

    void Update ()
    {
        transform.Rotate(rot);
	}
}
