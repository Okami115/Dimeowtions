using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        ToggleCanvas(true);
    }

    public void ToggleCanvas(bool active)
    {
        canvas.SetActive(active);
    }
}
