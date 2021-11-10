using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] Vector2 movement;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float speed = 10.0f;
	[SerializeField] bool isFacingRight = true;


	const int idle = 0;
	const int speedUp = 1;
	const int backAway = -1;


	// Start is called before the first frame update
	void Start()
	{
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();

	}

	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

	}

	//called potentially multiple times per frame, best for physics for smooth behavior
	void FixedUpdate()
	{

		//rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

		rigid.MovePosition(rigid.position + movement * speed * Time.fixedDeltaTime);




		if (movement.x < 0 && isFacingRight || movement.x > 0 && !isFacingRight)

			Flip();


	}

	void Flip()
	{

		//transform.Rotate(0, 180, 0);

		isFacingRight = !isFacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

}