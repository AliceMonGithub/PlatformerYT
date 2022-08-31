using UnityEngine;

namespace Codebase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        [Range(0, 1f), SerializeField] private float _smooth;

        [Header("Components")]
        [SerializeField] private Transform _transform;

        private void LateUpdate()
        {
            _transform.position = Vector3.Lerp(_transform.position, _target.position + _offset, _smooth);
        }

        private void OnValidate()
        {
            _smooth = Mathf.Clamp01(_smooth);

            if(_target != null)
            {
                _transform.position = _target.position + _offset;
            }
        }
    }
}