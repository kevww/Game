using UnityEngine;

public class Cam : MonoBehaviour 
{

	public GameObject Character;

	void Update () 
	{
		transform.position = new Vector3 (Character.transform.position.x, Character.transform.position.y + 2.3f, -10f);
	}
}
