using Menu;
using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmortalState : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private CheckColision checkColision;
    [SerializeField] private GameManager.GameManager gameManager;
    [SerializeField] private GameObject pauseManager;

    [SerializeField] private float maxTime;
    [SerializeField] private float currentTime;

    private bool isInmortal;

    private void Start()
    {
        gameManager.nextLevel += ChangeInmortalState;
    }
    void Update()
    {
        
        if(isInmortal) 
        {
            pauseManager.SetActive(false);
            currentTime += Time.deltaTime;

            if(currentTime > maxTime) 
            {

                ChangeInmortalState();
            }
        }
    }

    private void ChangeInmortalState()
    {
        isInmortal = !isInmortal;

        collider.enabled = !isInmortal;
        checkColision.enabled = !isInmortal;

        currentTime = 0;

        pauseManager.SetActive(true);
    }
}
