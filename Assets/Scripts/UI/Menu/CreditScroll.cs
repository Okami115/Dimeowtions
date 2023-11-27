using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector3 initialPos;

    public event Action endCredits;

    private Vector3 newPos;

    private void OnEnable()
    {
        rectTransform.position = initialPos;
    }

    private void OnDisable()
    {
        rectTransform.position = initialPos;
    }

    void Update()
    {

        float aux;

        aux = rectTransform.position.y + speed * Time.deltaTime;

        newPos = new Vector3(Screen.width / 2, aux, 0);

        rectTransform.position = newPos;
    }
}
