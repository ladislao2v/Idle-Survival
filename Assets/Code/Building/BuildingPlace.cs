using NTC.Global.Pool;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private BuildingConfig _config;
    [SerializeField] private RequirementsView _view;
    [SerializeField] private GameObject _arrow;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _view.Init(_config.Requirements);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Debug.Log("Yes");

            int satisfiedCount = 0;

            foreach (var requirement in _config.Requirements)
            {
                if(requirement.TryGrant(player))
                {
                    satisfiedCount++;
                }    
            }

            if(satisfiedCount == _config.Requirements.Length)
            {
                Build();
            }

            Debug.Log(satisfiedCount);
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
