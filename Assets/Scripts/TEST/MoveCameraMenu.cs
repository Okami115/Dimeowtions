using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraMenu : MonoBehaviour
{
    [SerializeField] private MenuInputManger menuInputManger;
    [SerializeField] private float speed;
    public Transform[] camaraPos;
    private int indexPos = 0;
    private Transform currentPos;

    private void OnEnable()
    {
        menuInputManger.moveCameraLeft += MoveCameraLeft;
        menuInputManger.moveCameraRight += MoveCameraRight;
    }

    private void OnDisable()
    {
        menuInputManger.moveCameraLeft -= MoveCameraLeft;
        menuInputManger.moveCameraRight -= MoveCameraRight;
    }

    public void MoveCameraLeft()
    {       
        if (indexPos > 0)
        {
            indexPos--;
            currentPos = camaraPos[indexPos];
        }      
    }

    public void MoveCameraRight()
    {        
        if (indexPos < camaraPos.Length - 1)
        {
            indexPos++;
            currentPos = camaraPos[indexPos];
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        currentPos = camaraPos[0];
        transform.position = currentPos.position;
    }

    private void Update()
    {
        float newDistance = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, currentPos.position, newDistance);
    }
}
