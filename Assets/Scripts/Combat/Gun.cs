using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileShootPosition;

    public Vector3 GetPositionOfShooting()
    {
        return projectileShootPosition.position;
    }
}
