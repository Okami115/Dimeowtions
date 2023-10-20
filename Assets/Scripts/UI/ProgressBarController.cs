using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Image completedProgressBar;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Transform handle;

    private void Update()
    {
        completedProgressBar.fillAmount = CalculateProgress();

        Vector3 newPosition = handle.localPosition;
        newPosition.x = Mathf.Lerp(completedProgressBar.rectTransform.rect.xMin, completedProgressBar.rectTransform.rect.xMax, completedProgressBar.fillAmount);
        handle.localPosition = newPosition;
    }

    private float CalculateProgress()
    {
        return Mathf.Clamp01((playerStats.score * 0.01f) / (playerStats.maxScore * 0.01f)) ;
    }
}