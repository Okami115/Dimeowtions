using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpriteApplier : MonoBehaviour
{
    [SerializeField] private ArtStyle artStyleSO;

    [SerializeField] Image image;
    [SerializeField] private Sprite[] baseSprites;
    [SerializeField] private Sprite[] selectedButtonSprites;

    public void Start()
    {
        ApplySpriteFromArray(baseSprites);
    }

    public void ApplySpriteFromArray(Sprite[] newSprite)
    {
        if (artStyleSO.isNoirSelected)
            image.sprite = newSprite[0];
        else if (artStyleSO.isSpaceSelected)
            image.sprite = newSprite[1];
        else if (artStyleSO.isSynthwaveSelected)
            image.sprite = newSprite[2];
    }

    public void ApplyDeselected()
    {
        ApplySpriteFromArray(baseSprites);
    }

    public void ApplySelected()
    {
        ApplySpriteFromArray(selectedButtonSprites);
    }

    //public void ApplySprite(Sprite newSprite)
    //{
    //    image.sprite = newSprite;
    //}
}