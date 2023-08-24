using DG.Tweening;
using JetBrains.Annotations;
using NTC.Global.Pool;
using UnityEngine;

public class ResourceAnimator : MonoBehaviour
{
    [SerializeField] private Vector3 _scale;

    [Header("Jumping")]
    [SerializeField] private float _lenght;
    [SerializeField] private float _duration;
    [SerializeField] private float _jumpPower;

    [Header("Stay animation")]
    [SerializeField] private float _stayDuration;
    [SerializeField] private Ease _ease;

    [Header("Move animation")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotationAngle;
    [SerializeField] private float _moveDuration;

    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main.transform;

        transform.DOScale(_scale, _stayDuration).SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
    }

    public void Jump(Vector3 position)
    {
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        var endPosition = position + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _lenght;

        transform.DOJump(endPosition, _jumpPower, 1, _duration);
    }

    public void PickUp()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_camera.position + _offset, _moveDuration))
            .Insert(0f, transform.DOScale(_scale, _moveDuration))
            .Insert(0f, transform.DORotate(_rotationAngle, _moveDuration))
            .AppendCallback(Disable);
    }

    public void Disable()
    {
        NightPool.Despawn(this);
    }
}
