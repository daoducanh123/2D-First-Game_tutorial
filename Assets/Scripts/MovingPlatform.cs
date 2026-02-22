using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    [SerializeField] private Transform posA, posB;
    private Vector3 target;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movingSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == posA.position)
            {
                target = posB.position;
            }
            else target = posA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
