using TMPro;
using UnityEngine;

public class StorageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _capacityText;

    public void OnCapacityChanged(int current, int max)
    {
        _capacityText.text = $"{current:000}/{max:000}";
    }
}
