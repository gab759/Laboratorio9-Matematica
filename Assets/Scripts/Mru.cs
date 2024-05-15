using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mru : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    [SerializeField] private float timer;

    void Update()
    {
        timer = timer + Time.deltaTime;
        float desplazamiento = velocidad * Time.deltaTime;
        
        transform.Translate(Vector3.right * desplazamiento);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Tiempo de colisión MRU: " + timer + " segundos");
        }
    }
}