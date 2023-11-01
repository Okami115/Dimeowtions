using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraMenu : MonoBehaviour
{

    [SerializeField] private Transform[] camaraPos;
    private int indexPos;
    private Transform currentPos;

    public void OnLeft()
    {
        indexPos--;
        if (indexPos < 0)
            indexPos = 0;


        currentPos = camaraPos[indexPos];
    }

    public void OnRight()
    {
        indexPos++;
        if (indexPos > camaraPos.Length - 1)
            indexPos = camaraPos.Length - 1;

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
        float newDistance = 1000 * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, currentPos.position, newDistance);
    }

}
