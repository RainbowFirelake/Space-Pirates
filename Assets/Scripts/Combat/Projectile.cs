using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    
    [SerializeField] private float damage = 10f;
    
    private bool isPlayerShot;

    private void Update() 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        Destroy(gameObject, 10f);
    }

    public void SetParent(bool shot)
    {
        isPlayerShot = shot;
    }

    private void OnTriggerEnter(Collider other) 
    {   
        var target = other.GetComponent<Health>();
        if (target)
        {
            target.TakeDamage(damage, isPlayerShot);
            Destroy(gameObject);
        }
    }
}
