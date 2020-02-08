using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Time.deltaTime * horizontalInput * _speed * Vector3.right);
        // transform.Translate(Time.deltaTime * verticalInput * _speed * Vector3.up);
        // Optimal
        var direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate( _speed * Time.deltaTime * direction);
    }
}