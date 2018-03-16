using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float speed = 5.0f;
	private Vector3 direction;
	public Vector3 Direction {set{direction = value; }}

	private SpriteRenderer sprite;

	private void Awake()
	{
		sprite = GetComponentInChildren<SpriteRenderer> ();
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
	}
}
