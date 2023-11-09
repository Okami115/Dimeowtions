using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraMenu : MonoBehaviour
{

    [SerializeField] private float speed;
    public Transform[] camaraPos;
    private int indexPos = 0;
    private Transform currentPos;

    public event Action moveCameraLeft;
    public event Action moveCameraRight;

    public void OnLeft()
    {
        indexPos--;
        if (indexPos < 0)        
            indexPos = 0;   
        
        moveCameraLeft?.Invoke();

        currentPos = camaraPos[indexPos];
    }

    public void OnRight()
    {
        indexPos++;
        if (indexPos > camaraPos.Length - 1)       
            indexPos = camaraPos.Length - 1;
        
        moveCameraRight?.Invoke();

        currentPos = camaraPos[indexPos];
    }

    // Start is called before the first frame update
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

    public int GetIndex()
    {
        return indexPos;
    }

}
