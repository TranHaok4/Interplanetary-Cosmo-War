using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BurstShoot",menuName ="ScriptableObject/BurstShoot")]
public class BurstShootingSO : TypeShootSO
{
    [SerializeField] int number_burstBullet = 2;

    public int Number_BurstBullet { get => number_burstBullet; }
}
