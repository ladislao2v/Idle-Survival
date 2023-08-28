using UnityEngine;

[CreateAssetMenu(fileName = "new ChunkConfig", menuName = "Gameplay/ChunkConfig")]
public class ChunkConfig : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private GameObject _filling;

    public int Price => _price;
    public GameObject Filling => _filling;
}
