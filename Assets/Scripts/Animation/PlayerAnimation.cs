using UnityEngine;

namespace Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Animator anim;

        private bool _faceRight = true;

        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void UpdateAnimationState(float horizontalMove)
        {
            AnimationType state;

            if (horizontalMove > 0f)
            {
                state = AnimationType.running;
                Flip(horizontalMove);
            }
            else if (horizontalMove < 0f)
            {
                state = AnimationType.running;
                Flip(horizontalMove);
            }
            else
            {
                state = AnimationType.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = AnimationType.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = AnimationType.falling;
            }

            anim.SetInteger("state", (int)state);
        }

        private void Flip(float direction)
        {
            if ((_faceRight && direction < 0) || (!_faceRight && direction > 0))
            {
                transform.Rotate(0, 180, 0);
                _faceRight = !_faceRight;
            }
        }
    }
}