using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorProvider : MonoBehaviour
{
    private Animator _animator;

    private const string IsSlash = nameof(IsSlash);
    private const string IsRun = nameof(IsRun);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnSlashed(bool isSlash)
    {
        _animator.SetBool(IsSlash, isSlash);
    }

    public void OnMoved(bool isRun)
    {
        _animator.SetBool(IsRun, isRun);
    }
}
