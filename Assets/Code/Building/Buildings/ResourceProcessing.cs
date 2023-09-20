using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ResourceProcessing : Building
{
    [SerializeField] private ResourceConfig _resourceConfig;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _time;
    [SerializeField] private ProcessingView _view;
    [SerializeField] private UnityEvent<int, int> _updated;

    private int _count;
    private Coroutine _generation;
    private WaitForSeconds _generationDelay;
    private WaitForSeconds _viewDelay = new WaitForSeconds(0.25f);

    private void Awake()
    {
        _generationDelay = new WaitForSeconds(_time);
        _view.Init(_resourceConfig);
    }

    private void Start()
    {
        _generation = StartCoroutine(GenerateWood());
        _updated?.Invoke(_count, _maxCount);
    }

    protected override void Interact(Player player)
    {
        StopCoroutine(_generation);

        player.TryPutResource(_resourceConfig.ResourceType, _count);

        StartCoroutine(player.SpawnResources(_resourceConfig, 
            _count, 
            transform,
            player.transform));

        StartCoroutine(SmoothReduction(_count, 0));
    }

    private IEnumerator SmoothReduction(int from, int to)
    {
        for(int i = from; i >= to; i--)
        {
            _updated?.Invoke(i, _maxCount);

            yield return _viewDelay;
        }

        _generation = StartCoroutine(GenerateWood());
    }

    private IEnumerator GenerateWood()
    {
        _count = 0;

        while (true)
        {
            yield return _generationDelay;

            if (_count == _maxCount)
            {
                yield return _generationDelay;
            }
            else
            {
                _updated?.Invoke(_count++, _maxCount);
            }
        }
    }
}
