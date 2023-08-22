using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    [Header("View properties")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _counter;

    private void Start()
    {
        Initialize();  
    }

    [ContextMenu("Initialize")]
    private void Initialize()
    {
        _icon.sprite = _config.Sprite;
    }

    public void OnResourceCountChanged(int value)
    {
        _counter.text = value.ToString();
    }
}
