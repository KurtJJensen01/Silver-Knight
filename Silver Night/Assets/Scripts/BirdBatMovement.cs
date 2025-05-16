using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BirdBatMovement : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public Transform center;
    public Transform startingPoint;

    private Enemy IsDead;
    private LayerMask GroundLayer;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        GroundLayer = LayerMask.GetMask("Ground");
        IsDead = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead.isDead==false)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, center.transform.position);

            //Debug.DrawLine(center.transform.position, player.transform.position, Color.red);
            RaycastHit2D hit = Physics2D.Linecast(center.transform.position, player.transform.position, GroundLayer);
            //Debug.Log(hit.collider);

            if (distanceFromPlayer < lineOfSite && hit.collider == null)
            {
                    Flip();
                    this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (transform.position.x > startingPoint.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                this.transform.position = Vector2.MoveTowards(this.transform.position, startingPoint.position, speed * Time.deltaTime);
            }
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(center.transform.position, lineOfSite);
    //}

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
