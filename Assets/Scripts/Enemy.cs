using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        if (!(transform.position.y < -5f)) return;
        var randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}