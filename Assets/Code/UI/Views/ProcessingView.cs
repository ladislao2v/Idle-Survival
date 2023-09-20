
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingView : MonoBehaviour
{
    [SerializeField] private Image _logo;
    [SerializeField] private TextMeshProUGUI _text;

    public void Init(ResourceConfig config)
    {
        _logo.sprite = config.Sprite;
    }

    public void OnUpdated(int count, int maxCount)
    {
        _text.text = $"{count:00}/{maxCount:00}";
    }
}
