using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private Transform player;
    private Vector3 directionOfMoving = Vector3.zero;
    private Shooting shooting;

    public void SetDirectionOfMoving(Vector3 destination)
    {
        directionOfMoving = destination;
    }

    private void Start() 
    {
        shooting = GetComponent<Shooting>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update() 
    {
        transform.LookAt(player);
        Move();
        Shoot();
    }

    private void Move()
    {
        transform.Translate(directionOfMoving * speed * Time.deltaTime, Space.World);
    }

    private void Shoot()
    {
        shooting.Shoot();
    }
}
