using DG.Tweening;
using UnityEngine;

public class SourceAnimator : MonoBehaviour
{
    [Header("Shake properties")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _strength = 1;
    [SerializeField] private int _vibrato = 10;
    [SerializeField] private float _randomness = 90;
    [SerializeField] private bool _fadeOut = true;
    [SerializeField] private ShakeRandomnessMode _mode = ShakeRandomnessMode.Full;

    public void Shake()
    {
        transform.DOShakeScale(_duration, _strength, _vibrato, _randomness, _fadeOut, _mode);
    }
}
