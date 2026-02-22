using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; private AudioManager audioManager;
    private Rigidbody2D rb;
    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsWin() || gameManager.IsOver()) return;
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }

    // Movement
    [SerializeField] private float moveSpeed = 5.0f;
    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");   //  A -1, Ko bam 0, D 1
        rb.linearVelocity = new Vector2 (moveInput * moveSpeed, rb.linearVelocity.y); // Bạn ra lệnh cho Rigidbody2D: “Mỗi frame, hãy chạy với vận tốc X này theo vecto vận tốc”
        if (moveInput > 0) transform.localScale = new Vector3(1,1,1);
        else if (moveInput < 0) transform.localScale = new Vector3 (-1,1,1);
    }

    // Jump
    [SerializeField] private float jumpForce = 5.0f; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f ,groundLayer); //true // false
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpForce);
            // Below: is better and smoother version 
            // rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            isGrounded =  false;
            audioManager.PlayJumpSound();
        }
    }

    // animator
    private Animator animator;
    private bool isJumping, isRunning;
    private void UpdateAnimation()
    {
    isJumping = !isGrounded;
    isRunning =  Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);        
    }

}
