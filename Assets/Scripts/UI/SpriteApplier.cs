using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpriteApplier : MonoBehaviour
{
    [SerializeField] private ArtStyle artStyleSO;

    [SerializeField] Image image;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    public void Start()
    {
        ApplySprite(sprites);
    }

    public void ApplySprite(Sprite[] newSprite)
    {
        if (artStyleSO.isNoirSelected)
            image.sprite = newSprite[0];
        else if (artStyleSO.isSpaceSelected)
            image.sprite = newSprite[1];
        else if (artStyleSO.isSynthwaveSelected)
            image.sprite = newSprite[2];
    }
}