using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mru : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    [SerializeField] private float timer;

    private Vector3 currentDirection = Vector3.right;

    void Update()
    {
        timer += Time.deltaTime;
        float desplazamiento = velocidad * Time.deltaTime;

        transform.Translate(currentDirection * desplazamiento);
    }
        public void Move(Vector3 direction)
    {
        currentDirection = direction.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inicial")
        {
            Debug.LogError("Te demoraste en llegar al siguiente punto (MRU): " + timer + " segundos");
            Debug.LogError("La velocidad Lineal es: " + velocidad + " segundos");

        }
    }
}