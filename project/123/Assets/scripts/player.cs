using UnityEngine;
using System.Collections;

public class player : Unit 
{
	[SerializeField]
	private int lives = 5;
	[SerializeField]
	private float speed = 3.0f;
	[SerializeField]
	private float jumpForce = 15.0f;

	private bool isGrounded = false;

	private Bullet bullet;

	new private Rigidbody2D rigidbody;
	private Animator animator;
	private SpriteRenderer sprite;
	private KeyCode F;
	private GameObject Player;
	private Transform teleport;

	private CharState State
	{
		get{return (CharState) animator.GetInteger ("State"); }
		set{animator.SetInteger ("State", (int)value); }
	}

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer> ();

		bullet = Resources.Load<Bullet> ("Bullet");
	}

	private void FixedUpdate ()
	{
		CheckGround ();
	}

	private void Update()
	{
		if (isGrounded) State = CharState.Idle;

		if (Input.GetButtonDown ("Fire1"))
			Shoot();
		if (Input.GetButton ("Horizontal"))
			Move();
		if (isGrounded && Input.GetButtonDown ("Jump"))
			Jump();
	}

	private void Move()
	{
		if (isGrounded) State = CharState.Move;

		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
		sprite.flipX = direction.x < 0.0f;
	}
	private void Jump()
	{
		rigidbody.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
	}

	private void CheckGround()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.3F);
		isGrounded = colliders.Length > 1;
		if (!isGrounded)
			State = CharState.Jump;
	}

	private void Shoot()
	{
		Vector3 position = transform.position;  position.y += 0.8f;
		Instantiate(bullet, position, bullet.transform.rotation);
	}
	private void Blink()
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Player.transform.position = teleport.position;
		}
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "GameController") 
		{
			Vector3 direction = transform.up * Input.GetAxis ("Vertical");
		}
	}
}


public enum CharState
{
	Idle,
	Move,
	Jump
}