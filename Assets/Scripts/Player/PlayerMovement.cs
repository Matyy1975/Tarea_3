using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    public void StartSpeedBoost(float boostAmount, float duration)
    {
        currentSpeed += boostAmount;
        StartCoroutine(ResetSpeedBoost(boostAmount, duration));
    }

    private System.Collections.IEnumerator ResetSpeedBoost(float boostAmount, float duration)
    {
        yield return new WaitForSeconds(duration);
        currentSpeed -= boostAmount;
    }
}
