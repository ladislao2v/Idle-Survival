using UnityEngine;

[RequireComponent(typeof(WoodResourceFactory))]
public sealed class WoodSource : Source
{
    private WoodResourceFactory _factory;

    private void Awake()
    {
        _factory = GetComponent<WoodResourceFactory>();
    }

    protected override void DropResource(Vector3 position)
    {
        _factory.Spawn(position);
    }
}