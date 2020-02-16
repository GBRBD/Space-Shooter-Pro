using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private bool _isParentNotNull;
    private bool _isEnemyLaser = false;

    private void Start()
    {
        _isParentNotNull = transform.parent != null;
    }

    private void Update()
    {
        if (!_isEnemyLaser) MoveUp();
        else MoveDown();
    }

    void MoveUp()
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

    void MoveDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -8f)
        {
            if (_isParentNotNull)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isEnemyLaser)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
        }
    }
}