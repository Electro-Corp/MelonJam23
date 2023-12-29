using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
   	public float attackSpeed;

	public float damage;

    public Pistol()
    {
        this.damage = 23f;
        this.attackSpeed= 1.5f;
    }

    public TrailRenderer trailRenderer;

	public float MultiplierDamage { get; set; }

    public override void OnAim()
    {
        throw new System.NotImplementedException();
    }

    public override void StopUse()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector3 attackDirection)
    {
        throw new System.NotImplementedException();
    }
}
