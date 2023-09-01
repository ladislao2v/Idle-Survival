using UnityEngine;

public class RequirementPanel : MonoBehaviour
{
    private RequirementViewFactory _factory;

    private void Awake()
    {
        _factory = GetComponent<RequirementViewFactory>();
    }

    public void Init(Requirement requirement)
    {
        _factory.Spawn(requirement, transform);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}