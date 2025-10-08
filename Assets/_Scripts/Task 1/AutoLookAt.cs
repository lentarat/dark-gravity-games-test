using UnityEngine;

namespace DarkGravityGames.Task1
{
    public class AutoLookAt : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        [SerializeField] private bool _lockYAxis;
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            FocusOnTarget();
        }

        private void FocusOnTarget()
        {
            Vector3 lookDirectionVector = _targetTransform.position - transform.position;
            if (_lockYAxis)
            {
                lookDirectionVector.y = 0f;
            }

            Quaternion lookDirectionQuaternion = Quaternion.LookRotation(lookDirectionVector);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                lookDirectionQuaternion,
                _rotationSpeed * Time.deltaTime
                );
        }
    }
}
