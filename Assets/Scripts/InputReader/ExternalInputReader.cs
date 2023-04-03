using Player;
using UnityEngine;

namespace InputReader
{
    public class ExternalInputReader : IEntityInputSource
    {
        public float HorizontalMove => Input.GetAxisRaw("Horizontal");

        public bool Jump { get; private set; }

        // Update is called once per frame
        public void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump = true;
            }
        }

        public void ResetActions()
        {
            Jump = false;
        }
    }
}
