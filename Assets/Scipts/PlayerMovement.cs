using UnityEngine;

public class PlayerMovement : PaddleMovement
{
	void Start()
    {
        this.movementSpeed = 15;
        this.rb = GetComponent<Rigidbody2D>();
		this.ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        this.Move();
    }

    private void FixedUpdate()
	{
		this.rb.velocity = this.playerMovement * this.movementSpeed;
	}

	public override void Move()
	{
		this.playerMovement = new Vector2(0, Input.GetAxisRaw("Vertical"));
	}
}
