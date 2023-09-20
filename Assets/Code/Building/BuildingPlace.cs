using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private BuildingConfig _config;
    [SerializeField] private RequirementPanel _view;
    [SerializeField] private UnityEvent _builded;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _view.Init(_config.Requirement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if(_config.Requirement.TryGrant(player))
            {
                StartCoroutine(player.SpawnResources(_config.Requirement.Config, 
                    _config.Requirement.Count, 
                    player.transform, 
                    transform));

                Build();
            }
        }
    }

    public void Build()
    {
        _collider.enabled = false;
        _view.Hide();

        var building = NightPool.Spawn(_config.Prefab, transform);

        building.transform.localScale = Vector3.zero;
        building.transform.DOScale(Vector3.one, 1f);

        _builded?.Invoke();
    }
}
