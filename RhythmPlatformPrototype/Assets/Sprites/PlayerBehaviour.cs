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
    public float jumpForce;
    public Vector2 groundNormal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump))
        {
            print("Up");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumped = true;
            grounded = false;
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
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (Input.GetKey(slide))
        {
            normalHB.enabled = false;
            slideHB.enabled = true;
        }
        else
        {
            normalHB.enabled = true;
            slideHB.enabled = false;
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
                groundNormal = c.normal;

                grounded = true;
                jumped = false;
            }
        }
    }
}
