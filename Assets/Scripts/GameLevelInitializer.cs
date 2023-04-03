using InputReader;
using Player;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInitializer:MonoBehaviour
{
    [SerializeField] private PlayerEntity _player;
    [SerializeField] private GameUIInputView _gameUIInputView;

    private ExternalInputReader _inputReader;
    private PlayerBrain _playerBrain;

    private bool _onPause = false;

    private void Awake()
    {
        _inputReader= new ExternalInputReader();
        _playerBrain = new PlayerBrain(_player, new List<IEntityInputSource>
        {
            _gameUIInputView,
            _inputReader
        });
    }

    private void Update()
    {
        if (_onPause) return;
        _inputReader.OnUpdate();
    }

    private void FixedUpdate()
    {
        if (_onPause) return;
        _playerBrain.OnFixedUpdate();
    }
}

