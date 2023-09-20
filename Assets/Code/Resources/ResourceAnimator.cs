using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ResourceAnimator : MonoBehaviour
{
    [SerializeField] private Vector3 _scale;
    [SerializeField] private AudioClip _sound;

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
    private AudioSource _audioSource;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _audioSource = GetComponent<AudioSource>();

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
        _audioSource.PlayOneShot(_sound);

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

    public void JumpTo(Vector3 endPosition)
    {
        _audioSource.PlayOneShot(_sound);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOJump(endPosition, _jumpPower, 1, _duration))
            .AppendCallback(Disable);
    }
}
