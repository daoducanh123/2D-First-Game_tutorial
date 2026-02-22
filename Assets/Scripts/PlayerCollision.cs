using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Transform enemyCheck1;
    [SerializeField] private Transform enemyCheck2;

    [SerializeField] private LayerMask enemyLayer;
    private GameManager gameManager; private AudioManager audioManager;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindAnyObjectByType<AudioManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Collide with Coin, Key, Trap
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            gameManager.AddPoint(1);      
            audioManager.PlayCoinSound();
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            gameManager.GameIsOver();
        }

        else if (other.gameObject.CompareTag("Key")){
            gameManager.GameIsWin();
        }

    }
    
    // Enemy
    private void OnCollisionEnter2D (Collision2D other)
    {
         if (other.gameObject.CompareTag("Enemy"))
        {
            if (Physics2D.OverlapCircle(enemyCheck1.position, 0.1f, enemyLayer) || Physics2D.OverlapCircle(enemyCheck2.position, 0.15f, enemyLayer))
            {   
                rb.AddForce(Vector2.up * 9.0f, ForceMode2D.Impulse);
                Destroy(other.gameObject);
                gameManager.AddPoint(1);
                audioManager.PlayJumpSound();
            }
            else 
            gameManager.GameIsOver();
        }
    }


}
