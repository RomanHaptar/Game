using InputReader;
using System.Collections.Generic;
using System.Linq;

namespace Player {
    public class PlayerBrain
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;

        public PlayerBrain(PlayerEntity player, List<IEntityInputSource> inputSources) 
        {
            _playerEntity = player;
            _inputSources = inputSources;
        }

        public void OnFixedUpdate()
        {
            _playerEntity.Move(GetHorizontalDirection(),IsJump());

            foreach (var inputSource in _inputSources)
                inputSource.ResetActions();
           
        }

        private float GetHorizontalDirection()
        {
            foreach(var inputSource in _inputSources)
            {
                if (inputSource.HorizontalMove == 0)
                    continue;

                return inputSource.HorizontalMove;
            }

            return 0;
        }

        private bool IsJump() => _inputSources.Any(source => source.Jump);
    }
}
