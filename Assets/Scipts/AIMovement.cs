using UnityEngine;

public class AIMovement : PaddleMovement
{
    void Start()
    {
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
		if (this.ball.transform.position.y > transform.position.y + 0.5f)
        {
            this.playerMovement = new Vector2(0, 1);
        }
        else if (this.ball.transform.position.y < transform.position.y - 0.5f)
        {
            this.playerMovement = new Vector2(0, -1);
        }
        else {
            this.playerMovement = new Vector2(0, 0);
        }
	}
}
