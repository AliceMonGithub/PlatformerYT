using Codebase.Services.InputLogic;
using UnityEngine;
using Zenject;

namespace Codebase.HeroLogic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _speed;
        [SerializeField] private float _smooth;

        [Space]

        [SerializeField] private float _jumpForce;

        [Space]

        [SerializeField] private LayerMask _groundLayer;

        [SerializeField] private Transform _boxPoint;
        [SerializeField] private Color _boxColor = Color.white;

        [SerializeField] private Vector2 _boxSize;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;

        private InputSystem _inputSystem;

        private Vector2 _currentVelosity;
        private Vector2 _smoothVelosity;

        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private bool OnGround => Physics2D.OverlapBox(_boxPoint.position, _boxSize, 0, _groundLayer);

        private void Update()
        {
            TryJump();

            Move();
        }

        private void OnDrawGizmos()
        {
            if (_boxPoint == null) return;

            Gizmos.color = _boxColor;

            Gizmos.DrawWireCube(_boxPoint.position, _boxSize);
        }

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
            _smooth = Mathf.Clamp(_smooth, 0, float.MaxValue);

            _jumpForce = Mathf.Clamp(_jumpForce, 0, float.MaxValue);

            _boxSize = new Vector2(Mathf.Clamp(_boxSize.x, 0, float.MaxValue), Mathf.Clamp(_boxSize.y, 0, float.MaxValue));
        }

        private void Move()
        {
            Vector2 velosity = new Vector2(_inputSystem.Axis.x * _speed * Time.deltaTime, _rigidbody.velocity.y);

            _smoothVelosity = Vector2.SmoothDamp(_smoothVelosity, velosity, ref _currentVelosity, _smooth);

            _rigidbody.velocity = new Vector2(_smoothVelosity.x, _rigidbody.velocity.y);
        }

        private void TryJump()
        {
            if (_inputSystem.JumpButtonDown && OnGround)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}