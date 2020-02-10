using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject tripleShot;
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private int lives = 3;
    [SerializeField] private bool isTripleShotActive = false;

    private float _canFire = -1f;
    private SpawnManager _spawnManager;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is null");
        }
    }

    private void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && _canFire < Time.time)
        {
            Shoot();
        }
    }

    private void CalculateMovement()
    {
        var transform1 = transform;
        MovePlayer(transform1);
        SetTopAndBottomBoundaries(transform1);
        WarpPlayer(transform1);
    }

    private void MovePlayer(Transform transform1)
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontalInput, verticalInput, 0);
        transform1.Translate(speed * Time.deltaTime * direction);
    }

    private void SetTopAndBottomBoundaries(Transform transform1)
    {
        transform1.position = new Vector3(transform.position.x, Mathf.Clamp(transform1.position.y, -3.8f, 0), 0);
    }

    private void WarpPlayer(Transform transform1)
    {
        if (11.3f <= transform.position.x)
        {
            transform1.position = new Vector3(-11.3f, transform1.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform1.position = new Vector3(11.3f, transform1.position.y, 0);
        }
    }

    private void Shoot()
    {
        _canFire = Time.time + fireRate;

        if (isTripleShotActive)
        {
            Instantiate(tripleShot, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laser, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        this.lives--;
        if (lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot()
    {
        this.isTripleShotActive = true;
        StartCoroutine(TripleShotPowerRoutine());
    }

    IEnumerator TripleShotPowerRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
}