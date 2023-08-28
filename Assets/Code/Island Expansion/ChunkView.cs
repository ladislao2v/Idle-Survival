using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class ChunkView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;

    [Header("Animation property")]
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _duration;

    public void Init(int price)
    {
        _priceText.text = price.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}