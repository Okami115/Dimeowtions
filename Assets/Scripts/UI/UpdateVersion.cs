using TMPro;
using UnityEngine;

public class UpdateVersion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; 
    void Start() 
    {
        text.text = "V" + Application.version; 
    }
}
