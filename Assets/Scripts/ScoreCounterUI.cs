using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private float duration;
    [SerializeField] private Transform ScoreTextContainer;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = ScoreTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdatePoint(int point)
    {
        Debug.Log("Updating UI Point to: " + point); // Verify this is reached
        toUpdate.SetText($"{point}");
     //   ScoreTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
       // StartCoroutine(ResetPointContainer(point));
    }

    private IEnumerator ResetPointContainer(int point)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{point}");
        Vector3 localPosition = ScoreTextContainer.localPosition;
        ScoreTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);

    }
}
