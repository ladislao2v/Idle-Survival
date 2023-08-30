using System;
using UnityEngine;

public class RequirementsView : MonoBehaviour
{
    private RequirementViewFactory _factory;

    private void Awake()
    {
        _factory = GetComponent<RequirementViewFactory>();
    }

    public void Init(Requirement[] requirements)
    {
        foreach(var requirement in requirements)
        {
            _factory.Spawn(requirement, transform);
        }
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}