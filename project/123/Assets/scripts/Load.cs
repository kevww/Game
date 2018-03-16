using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour 
{
	public int NuberScene;
	public string playerTag;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("!");
		if (other.tag == playerTag)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				SceneManager.LoadScene(NuberScene);
			}
		}
	}
}
	