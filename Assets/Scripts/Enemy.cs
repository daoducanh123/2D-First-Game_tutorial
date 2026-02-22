using NUnit.Framework;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        leftBound = startPos.x - distance; 
        rightBound = startPos.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePatrol();
    }

    // Enemy Patrol
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float distance = 5.0f;
    private Vector2 startPos;  // store original position of enemy using vector
    private float leftBound, rightBound;
    private bool movingRight = false;
    private Vector3 scaler;
    
    private void HandlePatrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }
    private void Flip()
    {
        scaler = transform.localScale;
        if (movingRight) scaler = new Vector3(1,1,1);
        else scaler = new Vector3 (-1,1,1);
        transform.localScale = scaler;
    }
}
