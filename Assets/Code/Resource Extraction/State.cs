using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

public class State : MonoBehaviour
{
    private float _duration = 1f;

    public void GrowUp()
    {
        var scale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(scale, _duration);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Destroy()
    {
        NightPool.Despawn(this);
    }
}