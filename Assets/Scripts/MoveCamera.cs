using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public Transform player;

	private Vector3 offset;

	private Camera cam;

	public static MoveCamera Instance { get; private set; }

	private void Start()
	{
		Instance = this;
		cam = transform.GetComponentInParent<Camera>();
		cam.fieldOfView = GameState.Instance.fov;
		offset = transform.position - player.transform.position;
	}

	private void Update()
	{
		transform.position = player.transform.position;
	}

	public void UpdateFov()
	{
		cam.fieldOfView = GameState.Instance.fov;
	}
}
