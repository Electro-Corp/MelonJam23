// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// RangedWeapon
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
	public GameObject projectile;

	public float pushBackForce;

	public float force;

	public float accuracy;

	public int bullets;

	public float boostRecoil;

	private Transform guntip;

	private Rigidbody rb;

	private Collider[] projectileColliders;

	private new void Start()
	{
		Start();
		rb = GetComponent<Rigidbody>();
		guntip = transform.GetChild(0);
	}

	public override void Use(Vector3 attackDirection)
	{
		if (readyToUse && pickedUp)
		{
			SpawnProjectile(attackDirection);
			Recoil();
			readyToUse = false;
			Invoke("GetReady", attackSpeed);
		}
	}

	public override void OnAim()
	{
	}

	public override void StopUse()
	{
	}

	private void SpawnProjectile(Vector3 attackDirection)
	{
		Vector3 vector = guntip.position - guntip.transform.right / 4f;
		Vector3 normalized = (attackDirection - vector).normalized;
		List<Collider> list = new List<Collider>();
		if (player)
		{
			PlayerMovement.Instance.GetRb().AddForce(transform.right * boostRecoil, ForceMode.Impulse);
		}
		for (int i = 0; i < bullets; i++)
		{
			// Instantiate(PrefabManager.Instance.muzzle, vector, Quaternion.identity);
			GameObject gameObject = Instantiate(projectile, vector, transform.rotation);
			Rigidbody componentInChildren = gameObject.GetComponentInChildren<Rigidbody>();
			projectileColliders = gameObject.GetComponentsInChildren<Collider>();
			RemoveCollisionWithPlayer();
			componentInChildren.transform.rotation = transform.rotation;
			Vector3 vector2 = normalized + (guntip.transform.up * Random.Range(0f - accuracy, accuracy) + guntip.transform.forward * Random.Range(0f - accuracy, accuracy));
			componentInChildren.AddForce(componentInChildren.mass * force * vector2);
			Bullet bullet = (Bullet)gameObject.GetComponent(typeof(Bullet));
			if (bullet != null)
			{
				Color col = Color.red;
				if (player)
				{
					col = Color.blue;
					Gun.Instance.Shoot();
					if (bullet.explosive)
					{
						// Instantiate(PrefabManager.Instance.thumpAudio, transform.position, Quaternion.identity);
					}
					else
					{
						// AudioManager.Instance.PlayPitched("GunBass", 0.3f);
						// AudioManager.Instance.PlayPitched("GunHigh", 0.3f);
						// AudioManager.Instance.PlayPitched("GunLow", 0.3f);
					}
					componentInChildren.AddForce(componentInChildren.mass * force * vector2);
				}
				else
				{
					// Instantiate(PrefabManager.Instance.gunShotAudio, transform.position, Quaternion.identity);
				}
				bullet.SetBullet(damage, pushBackForce, col);
				bullet.player = player;
			}
			foreach (Collider item in list)
			{
				Physics.IgnoreCollision(item, projectileColliders[0]);
			}
			list.Add(projectileColliders[0]);
		}
	}

	private void GetReady()
	{
		readyToUse = true;
	}

	private void Recoil()
	{
	}

	private void RemoveCollisionWithPlayer()
	{
		Collider[] array = ((!player) ? transform.root.GetComponentsInChildren<Collider>() : new Collider[1] { PlayerMovement.Instance.GetPlayerCollider() });
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < projectileColliders.Length; j++)
			{
				Physics.IgnoreCollision(array[i], projectileColliders[j], ignore: true);
			}
		}
	}
}
