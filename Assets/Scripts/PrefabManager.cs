// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PrefabManager
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
	public GameObject bulletDestroy;

	public GameObject muzzleFlash;

	public GameObject explosion;

	public GameObject bulletHitAudio;

	public GameObject enemyHitAudio;

	public GameObject gunShotAudio;

	public GameObject objectImpactAudio;

	public GameObject destructionAudio;

	public static PrefabManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}
}
