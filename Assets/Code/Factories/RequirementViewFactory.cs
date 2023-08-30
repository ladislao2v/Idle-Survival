using NTC.Global.Pool;
using UnityEngine;

public class RequirementViewFactory : MonoBehaviour
{
    [SerializeField] private RequirementView _prefab;
    [SerializeField] private Quaternion _prefabRotation;
    

    public void Spawn(Requirement requirement, Transform parent)
    {
        var view = NightPool.Spawn(_prefab, parent);
        
        view.transform.rotation = _prefabRotation;

        view.Init(requirement);
    }
}