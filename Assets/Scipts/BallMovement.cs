using UnityEngine;

public class BallMovement : BaseMovement
{
    private float speedIncrease = 0.25f;
    private int hitCounter;
    private int xDirection = 0;
    private int yDirection = 0;
    private GameManager gameManager;

	void Start()
    {
        this.movementSpeed = 10;
        this.rb = GetComponent<Rigidbody2D>();
        this.gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Invoke("StartBall", 2f);
    }

    public override void Move()
	{
		this.rb.velocity = Vector2.ClampMagnitude(this.rb.velocity, this.movementSpeed + (this.speedIncrease * hitCounter));
	}

    private void FixedUpdate()
	{
		this.Move();
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag.ToLower())
        {
            case "ai":
            case "player":
                this.OnPaddleCollision();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name.ToLower())
        {
            case "ai goal":
                this.gameManager.aiScored();
                this.ResetBall();
                break;
            case "player goal":
                this.gameManager.playerScored();
                this.ResetBall();
                break;
        }
    }

    private void StartBall()
    {
        int whoStartsFirst = Random.Range(0, 2);
        int randomYDirection = Random.Range(0, 2);
        this.xDirection = whoStartsFirst < 1 ? -1 : 1;
        this.yDirection = randomYDirection < 1 ? -1 : 1;
        this.rb.velocity = new Vector2(this.xDirection, this.yDirection) * (this.movementSpeed + this.speedIncrease * this.hitCounter);
    }

    private void ResetBall()
    {
        this.rb.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(0, 0);
        this.hitCounter = 0;

        Invoke("StartBall", 2f);
    }

    private void OnPaddleCollision()
    {
        this.hitCounter++;
        this.xDirection = -1 * this.xDirection;
        this.yDirection = -1 * this.yDirection;
        this.rb.velocity = new Vector2(this.xDirection, this.yDirection) * (this.movementSpeed + this.speedIncrease * this.hitCounter);
    }
}
