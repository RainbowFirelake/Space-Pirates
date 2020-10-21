using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        LookAtMousePosition();
        Move();
        Shoot();
    }

    private void LookAtMousePosition()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMousePosition(), out hit);
        if (hasHit)
        {
            transform.LookAt(hit.point);
        }
    }

    private void Move()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMousePosition(), out hit);
        if (hasHit && Input.GetMouseButton(0))
        {
           transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            shooting.Shoot();
        }
    }

    private Ray GetMousePosition()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
