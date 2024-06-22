using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mruv : MonoBehaviour
{
    [SerializeField] private float velocidadInicial = -5f;
    [SerializeField] private float acceleration = 2f;
    private float cambioVelocidad;
    private float displacement;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float timer;

    void Start()
    {
        currentSpeed = velocidadInicial; 
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        cambioVelocidad = acceleration * Time.deltaTime;

        currentSpeed = currentSpeed + cambioVelocidad;

        displacement = currentSpeed * Time.deltaTime;

        transform.Translate(Vector3.right * displacement);
        Debug.Log("La velocidad de persecucion es: " + currentSpeed + "");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Persecucion")
        {
            Debug.Log("La velocidad de persecucion es: " + displacement + "");
        }
    }
}
