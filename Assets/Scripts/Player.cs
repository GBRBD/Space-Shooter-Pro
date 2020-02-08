using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        MovePlayer();
        SetTopAndBottomBoundaries();
        WarpPlayer();
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void SetTopAndBottomBoundaries()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
    }

    private void WarpPlayer()
    {
        if (11.3f <= transform.position.x)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}