using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 20.0f;
    [SerializeField] private GameObject explosionPrefab = default;

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * transform.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.1f);
            Destroy(other.gameObject);
        }
    }
}