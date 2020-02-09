using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        if (8 <= transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}