using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class textEffect : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        float shakeAmount = 0.5f; // Adjust for more or less shaking
        transform.localPosition = originalPosition + new Vector3(
            Random.Range(-shakeAmount, shakeAmount),
            Random.Range(-shakeAmount, shakeAmount),
            0
        );
    }
}
