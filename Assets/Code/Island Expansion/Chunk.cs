using NTC.Global.Pool;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Properties")] 
    [SerializeField] private ChunkConfig _config;
    [SerializeField] private bool _isFirst;

    [Header("Adjacent chunks")]
    [SerializeField] private Chunk[] _adjacentChunks;

    [Header("Buy platform")]
    [SerializeField] private ChunkView _chunkPanel;

    private bool _isActive;
    private GameObject _filling;

    public bool IsActive => _isActive;

    private void Start()
    {
        _chunkPanel.Init(_config.Price);

        Spawn();
        HidePanel();
        ShowAvailableChunks();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive)
            return;

        if (other.TryGetComponent(out Player player))
        {
            if(player.TrySpendMoney(_config.Price))
                Build(this);
        }
    }

    private void Spawn()
    {
        _filling = NightPool.Spawn(_config.Filling, transform);
        _filling.SetActive(_isFirst);

        _isActive = _isFirst;
    }

    private void Build(Chunk chunk)
    {
        chunk.Show();

        chunk.ShowAvailableChunks();
    }

    private void ShowAvailableChunks()
    {
        if(!_isActive)
            return;

        foreach (var chunk in _adjacentChunks)
        {
            if (!chunk.IsActive)
            {
                chunk.ShowPlatform();
            }
        }
    }

    private void Show()
    {
        _isActive = true;

        HidePanel();

        _filling.SetActive(true);
    }

    private void HidePanel()
    {
        _chunkPanel.Hide();
    }

    private void ShowPlatform()
    {
        _chunkPanel.Show();
    }
}
