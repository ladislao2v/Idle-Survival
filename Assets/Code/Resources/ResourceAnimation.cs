using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

public class ResourceAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _scale;

    [Header("Jumping")]
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

    private void OnEnable()
    {
        _camera = Camera.main.transform;


        StartJumpAnimation();
        StartStayAnimation();          
    }

    private void StartJumpAnimation()
    {
        var x = Random.Range(-4.5f, 4.5f);
        var z = Random.Range(-4.5f, 4.5f);
        var direction = new Vector3(x, 0f, z);

        transform.DOJump(transform.position + direction, _jumpPower, 1, _duration);
    }

    private void StartStayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(_scale, _stayDuration).SetEase(_ease))
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void StartMoveAnimation()
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
