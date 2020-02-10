using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private bool _isParentNotNull;

    private void Start()
    {
        _isParentNotNull = transform.parent != null;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        if (8f <= transform.position.y)
        {
            if (_isParentNotNull)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}