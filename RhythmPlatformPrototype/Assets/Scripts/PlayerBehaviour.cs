using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public KeyCode jump;
    public KeyCode slide;

    public CapsuleCollider2D normalHB;
    public CircleCollider2D slideHB;

    public bool jumped = false;
    public bool grounded;
    public Rigidbody2D rb2d;
    public float moveSpeed;
    public float jumpForce = 14;
    public Vector2 groundNormal;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump) && grounded)
        {
            grounded = false;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            print("Up");

            jumped = true;
        }
    }

    void FixedUpdate()
    {
        if(grounded == true)
        {
            Movement();
        }
    }

    void Movement()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y) * Time.deltaTime * 50;

        if (Input.GetKey(slide))
        {
            normalHB.size = new Vector2(1, 0.5f);
            GetComponent<SpriteRenderer>().size = new Vector2(1, 0.5f);
        }
        else
        {
            normalHB.size = new Vector2(1, 1);
            GetComponent<SpriteRenderer>().size = new Vector2(1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
        collision.GetContacts(contacts);
        GroundCheck(contacts, collision.otherCollider);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(grounded == false)
        {
            ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contacts);
            GroundCheck(contacts, collision.otherCollider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.contactCount == 0)
        {
            grounded = false;
        }
        else
        {
            ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contacts);
            GroundCheck(contacts, collision.otherCollider);
        }
    }

    public Vector2 curveCenterBottom;

    void GroundCheck(ContactPoint2D[] contacts_, Collider2D coll)
    {
        grounded = false;

        if (coll == normalHB)
        {
            curveCenterBottom = coll.bounds.center - Vector3.up * (coll.bounds.extents.y - coll.bounds.extents.x);
        }
        else
        {
            curveCenterBottom = coll.bounds.center;
        }

        foreach (ContactPoint2D c in contacts_)
        {
            Vector2 dir = c.point - curveCenterBottom;

            if (dir.y < 0f)
            {
                grounded = true;
                jumped = false;
            }
        }
    }
}
