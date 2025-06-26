/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            /*float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle; 
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;      // Reference to the player's transform
    public float moveSpeed = 3f;  // Movement speed of the enemy
    public float detectionRange = 10f;  // How far the enemy can see
    public float raycastDistance = 1f;  // How far the enemy checks for walls

    private Vector2 moveDirection;

    void Update(Collision2D collision)
    {
        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Check if there's a wall in the way using Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance);
        
        if (hit.collider != null && collision.gameObject.tag == "Wall")
        {
            // Wall detected, change direction to avoid it
            Vector2 avoidDirection = new Vector2(-direction.y, direction.x); // Perpendicular direction to the wall
            moveDirection = avoidDirection.normalized;
        }
        else
        {
            // No wall detected, move towards the player
            moveDirection = direction;
        }

        // Move the enemy towards the player or in the avoidance direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;           // Reference to the player’s transform
    public float followSpeed = 3f;     // Speed of the enemy’s movement
    private NavMeshAgent navMeshAgent; // NavMeshAgent to move the enemy

    void Start()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = followSpeed;

        // Ensure the NavMeshAgent starts on a valid NavMesh (optional)
        if (!navMeshAgent.isOnNavMesh)
        {
            Debug.LogWarning("NavMeshAgent is not on a valid NavMesh!");
        }
        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete) {
    Debug.Log("Path found and completed");
} else {
    Debug.Log("No valid path found");
}

    }

    void Update()
    {
        // Set the destination of the NavMeshAgent to the player’s position
        if (player != null && navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    
}


