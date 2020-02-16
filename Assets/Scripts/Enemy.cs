using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private GameObject laserPrefab = default;
    
    private Player _player;
    private Animator _anim;
    private AudioSource _audioSource;
    private float _fireRate = 3.0f;
    private float _canFire = -1f;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = .1f;
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }

        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is null");
        }
    }


    private void Update()
    {
        CalculateMovement();
        if (_canFire < Time.time)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate + _canFire;
            GameObject enemyLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            foreach (var laser in lasers)
            {
                laser.AssignEnemyLaser();
            }
        }
    }

    void CalculateMovement()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        if (!(transform.position.y < -5f)) return;
        var randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            _anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            _audioSource.Play();

            Destroy(this.gameObject, 2.8f);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());

            Destroy(this.gameObject, 2.8f);
        }
    }
}