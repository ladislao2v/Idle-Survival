using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Extracter : MonoBehaviour
{
    [SerializeField] private float _coolDownTime;
    [SerializeField] private float _duration;
    [SerializeField] private UnityEvent<bool> _slashed;

    private WaitForSeconds _coolDown;
    private WaitForSeconds _slashDuration;
    private Coroutine _lastSlash;

    private void Start()
    {
        _coolDown = new WaitForSeconds(_coolDownTime);
        _slashDuration = new WaitForSeconds(_coolDownTime);
    }

    private IEnumerator Slashing(Source source)
    {
        _slashed?.Invoke(true);

        while (true)
        {
            yield return _slashDuration;

            if (!source.TryChangeState())
                break;

            yield return _coolDown;
        }

        _slashed?.Invoke(false);
    }

    public void Extract(Source source)
    {
        _lastSlash = StartCoroutine(Slashing(source));
    }

    public void StopExtract()
    {
        _slashed?.Invoke(false);

        StopCoroutine(_lastSlash);
    }
}
