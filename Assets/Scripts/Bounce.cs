// Bounce
using UnityEngine;

public class Bounce : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		MonoBehaviour.print("yeet");
		_ = (bool) other.gameObject.GetComponent<Rigidbody>();
        if ((bool) other.gameObject.GetComponent<Rigidbody>()) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * 100f);
        }
	}
}
