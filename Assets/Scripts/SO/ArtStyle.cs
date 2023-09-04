using UnityEngine;

[CreateAssetMenu(fileName = "New Art Style", menuName = "Custom/Art Style")]
public class ArtStyle : ScriptableObject
{
    public bool isNoirSelected;
    public bool isSpaceSelected;
    public bool isSynthwaveSelected;

    public int stylesAmmount;
}
