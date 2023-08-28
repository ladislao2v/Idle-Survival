using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private ToolType _type;

    public ToolType Type => _type;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}