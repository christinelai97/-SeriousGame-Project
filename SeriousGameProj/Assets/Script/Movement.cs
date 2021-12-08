using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] Vector2 movement;
	[SerializeField] float move;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float speed = 10.0f;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] Animator anim;
	private AudioSource footstep;
	private bool interacting;
	
	const int IDLE = 0;
	const int WALK = 1;
	// const int backAway = -1;


	// Start is called before the first frame update
	void Start()
	{


		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();

		if (anim == null)
		{
			anim = GetComponent<Animator>();
		}

		anim.SetInteger("motion", IDLE);
		footstep = GetComponent<AudioSource>();

	}

	void Update()
	{
		if (!interacting)
		{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		move = movement.x;
	    }
		if (interacting)
		{
		anim.SetInteger("motion",IDLE);
		movement.x = 0;
		movement.y = 0;
		move = 0;
		}
	}

	//called potentially multiple times per frame, best for physics for smooth behavior
	void FixedUpdate()
	{

		//rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

		rigid.MovePosition(rigid.position + movement * speed * Time.fixedDeltaTime);

		if (move > .01 || move < -0.1)
		{
			anim.SetInteger("motion", WALK);
		}
		else
		{
			anim.SetInteger("motion", IDLE);
		}

		if (movement.x < 0 && isFacingRight || movement.x > 0 && !isFacingRight)

			Flip();


	}

	 public void ToggleInteraction()
    {
        interacting = !interacting;
    }

	void Flip()
	{

		//transform.Rotate(0, 180, 0);

		isFacingRight = !isFacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void Footsteap()
    {
		footstep.Play();
    }

}