using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObjects : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject light;

    [SerializeField] private float scaleBase;
    [SerializeField] private float scaleSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button.interactable)
        {
            light.SetActive(true);
            transform.localScale = new Vector3(scaleSelected, scaleSelected, scaleSelected);
        }
        else
        {
            light.SetActive(false);
            transform.localScale = new Vector3(scaleBase, scaleBase, scaleBase);
        }
    }
}
