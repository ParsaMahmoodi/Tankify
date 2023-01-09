using UnityEngine;

namespace Features.Core.Scripts
{
    public class AgentRotation : MonoBehaviour
    {
        private float _previousAngle = 0;
        private float _newAngle = 0;

        public void Rotate(Vector2 target)
        {
            _newAngle = CalculateRotationAngle(target);
            if (_previousAngle != _newAngle)
            {
                _previousAngle = _newAngle;
                DoRotate(_newAngle);
            }
        }
        
        private void DoRotate(float angle)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
        
        private float CalculateRotationAngle(Vector2 target)
        {
            Vector2 moveDirection = (target - (Vector2)transform.position).normalized;
            
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            return angle;
        }

    }
}
