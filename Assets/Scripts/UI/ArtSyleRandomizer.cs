using UnityEngine;
using UnityEngine.UI;

public class ArtSyleRandomizer : MonoBehaviour
{
    [SerializeField] private ArtStyle artStyleSO;

    private void Awake()
    {
        artStyleSO.isNoirSelected = false;
        artStyleSO.isSpaceSelected = false;
        artStyleSO.isSynthwaveSelected = false;

        artStyleSO.stylesAmmount = 3;

        int randomIndex = Random.Range(0, artStyleSO.stylesAmmount);

        switch (randomIndex)
        { 
        case 0:
                artStyleSO.isNoirSelected = true;
            break;
        case 1:
                artStyleSO.isSpaceSelected = true;
            break;               
        case 2:
                artStyleSO.isSynthwaveSelected = true;
            break;
        }
    }

    private void OnDisable()
    {
        artStyleSO.isNoirSelected = false;
        artStyleSO.isSpaceSelected = false;
        artStyleSO.isSynthwaveSelected = false;
    }
}
