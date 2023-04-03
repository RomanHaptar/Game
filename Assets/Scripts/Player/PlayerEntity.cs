using Animation;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        public Rigidbody2D rb;
        public BoxCollider2D coll;

        private float _horizontalMove = 0f;

        [SerializeField] private float _jumpForce = 14f;
        [SerializeField] private float _moveSpeed = 7f;

        [SerializeField] private LayerMask _jumpableGround;

        public PlayerAnimation anim;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            anim.UpdateAnimationState(_horizontalMove);
        }

        public void Move(float move, bool jump)
        {
            _horizontalMove = move * _moveSpeed;
            rb.velocity = new Vector2(_horizontalMove, rb.velocity.y);

            if (jump && IsGrounded())
            {
                rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
        }
    }
}