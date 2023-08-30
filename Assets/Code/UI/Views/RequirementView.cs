using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequirementView : MonoBehaviour
{
    [SerializeField] private Image _ressourceLogo;
    [SerializeField] private TextMeshProUGUI _ressourceCount;

    public void Init(Requirement requirement)
    {
        _ressourceLogo.sprite = requirement.Sprite;
        _ressourceCount.text = requirement.Count.ToString();
    }
}