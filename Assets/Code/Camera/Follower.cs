using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private Transform _target;

    public void Init(Player player)
    {
        _target = player.transform;
    }

    private void FixedUpdate()
    {
        var position = new Vector3(_target.position.x, _target.position.y + _height, _target.position.z - _rearDistance);

        transform.position = Vector3.Lerp(transform.position, position, _returnSpeed * Time.deltaTime);
    }
}
