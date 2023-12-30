// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// StartPlayer
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
	private void Awake()
	{
		for (int num = transform.childCount - 1; num >= 0; num--)
		{
			MonoBehaviour.print("removing child: " + num);
			transform.GetChild(num).parent = null;
		}
		Destroy(gameObject);
	}
}
