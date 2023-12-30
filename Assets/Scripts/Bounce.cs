// Bounce
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 550f;
	private void OnCollisionEnter(Collision other)
	{
		MonoBehaviour.print("yeet");
		_ = (bool) other.gameObject.GetComponent<Rigidbody>();
        if ((bool) other.gameObject.GetComponent<Rigidbody>()) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,bounceForce,0f), ForceMode.Impulse);
        }
	}
}
