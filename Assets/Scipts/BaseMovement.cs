using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected float movementSpeed = 7.5f;
	protected Rigidbody2D rb;

	public abstract void Move();
}