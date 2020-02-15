using System.Xml.Serialization;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    // 0 triple shot, 1 speed, 2 shield
    [SerializeField] private int powerupId = default;
    [SerializeField] private AudioClip clip = default;
    
    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(this.gameObject);
            var player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupId)
                {
                    case 0:
                        player.ActivateTripleShot();
                        break;
                    case 1:
                        player.ActivateSpeedBoost();
                        break;
                    case 2:
                        player.ActivateShield();
                        break;
                    default:
                        Debug.Log("Default value");
                        break;
                }
            }
        }
    }
}