using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Extracter : MonoBehaviour
{
    [SerializeField] private ToolType _mainType;
    [SerializeField] private Tool[] _tools;
    [SerializeField] private float _coolDownTime;
    [SerializeField] private float _duration;
    [SerializeField] private UnityEvent<bool> _slashed;

    private Tool _currentTool;
    private WaitForSeconds _coolDown;
    private WaitForSeconds _slashDuration;
    private Coroutine _lastSlash;

    private void Start()
    {
        foreach(Tool tool in _tools)
        {
            if(tool.Type == _mainType)
                _currentTool = tool;

            tool.Hide();
        }

        _currentTool.Show();

        _coolDown = new WaitForSeconds(_coolDownTime);
        _slashDuration = new WaitForSeconds(_coolDownTime);
    }

    private void ChangeTool(ToolType type)
    {
        _currentTool.Hide();

        foreach (Tool tool in _tools)
        {
            if (tool.Type == type)
                _currentTool = tool;
        }

        _currentTool.Show();
    }

    private IEnumerator Slashing(Source source)
    {
        _slashed?.Invoke(true);

        while (true)
        {
            yield return _slashDuration;

            if (!source.TryChangeState())
                break;

            yield return _coolDown;
        }

        _slashed?.Invoke(false);
    }

    public void Extract(Source source)
    {
        ChangeTool(source.Type);

        _lastSlash = StartCoroutine(Slashing(source));
    }

    public void StopExtract()
    {
        _slashed?.Invoke(false);

        if(_lastSlash != null )
            StopCoroutine(_lastSlash);
    }
}
