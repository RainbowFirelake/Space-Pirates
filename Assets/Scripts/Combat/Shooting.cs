using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Range(1, 3)]
    public int countOfActiveGuns = 0;
    public delegate void Shots(int number);
    public static event Shots shots;

    [SerializeField] private List<Gun> guns;
    [SerializeField] private float shootSpeed = 5f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int numberOfShoots = 3;
    [SerializeField] private float timeOfGettingShoot = 5f;
    [SerializeField] private bool isPlayer = false;

    private float timeAfterLastShoot = Mathf.Infinity;
    private float timeAfterLastGettingShoot = 0f;
    
    private void Start() 
    {
        foreach(var gun in guns)
        {
            gun.gameObject.SetActive(false);
        }
        InitializeGuns();
        if (isPlayer)
        {
            shots(numberOfShoots);
        }
    }

    private void Update() 
    {
        UpdateShoots();
        timeAfterLastShoot += Time.deltaTime;
        timeAfterLastGettingShoot += Time.deltaTime;
    }

    public void Shoot()
    {
        if (guns != null)
        {
            if (timeAfterLastShoot > shootSpeed)
            {
                foreach (var gun in guns)
                {
                    if (gun != null && numberOfShoots > 0 && gun.gameObject.activeInHierarchy)
                    {
                        var copy = Instantiate(projectile, gun.GetPositionOfShooting(), gun.transform.rotation);
                        copy.GetComponent<Projectile>().SetParent(isPlayer);
                        numberOfShoots--;
                        if (isPlayer)
                        {
                            shots(numberOfShoots);
                        }
                    }
                }
                timeAfterLastShoot = 0;
            }
        }
    }

    public void GetNewGun()
    {
        if (countOfActiveGuns >= guns.Count)
        {
            countOfActiveGuns = guns.Count;
            return;
        }
        else
        {
            countOfActiveGuns++;
            InitializeGuns();
        }
    }

    private void InitializeGuns()
    {
        for (int i = 0; i < countOfActiveGuns; i++)
        {
            if (guns[i] != null)
            {
                guns[i].gameObject.SetActive(true);
            }
        }
    }

    private void UpdateShoots()
    {
        if (timeAfterLastGettingShoot > timeOfGettingShoot)
        {
            numberOfShoots++;
            timeAfterLastGettingShoot = 0f;
            if (isPlayer)
            {
                shots(numberOfShoots);
            }
        }
    }
}
