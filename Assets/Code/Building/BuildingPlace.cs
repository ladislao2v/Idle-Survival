using NTC.Global.Pool;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private BuildingConfig _config;
    [SerializeField] private RequirementPanel _view;
    [SerializeField] private GameObject _arrow;

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
                Build();
            }
        }
    }

    public void Build()
    {
        _collider.enabled = false;
        _view.Hide();
        _arrow.SetActive(false);

        var building = NightPool.Spawn(_config.Prefab, transform);
    }
}
