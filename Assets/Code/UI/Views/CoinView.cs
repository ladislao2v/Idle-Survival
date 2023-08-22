using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;

    public void OnMoneyCountChanged(int value)
    {
        _counter.text = value.ToString();
    }
}
