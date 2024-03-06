using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    [SerializeField] private MenuInputManger menuInputManger;
    [SerializeField] private GameObject credits;
    [SerializeField] private float speed;

    private Transform target;
    private void OnEnable()
    {
        menuInputManger.back += CloseCredits;
        target = transform;
    }

    private void OnDisable()
    {
        menuInputManger.back -= CloseCredits;
    }

    public void Credits()
    {
        credits.SetActive(true);
        target.rotation = new Quaternion(90, 0, 0, 1);
    }

    private void Update()
    {
        float newDistance = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, newDistance);
    }

    private void CloseCredits()
    {
        credits.SetActive(false);
        target.rotation = new Quaternion(0, 0, 0, 1);
    }
}
