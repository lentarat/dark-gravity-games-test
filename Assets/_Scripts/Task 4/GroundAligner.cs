using UnityEngine;

namespace DarkGravityGames.Task4
{
    public class GroundAligner : MonoBehaviour
    {
        public void AlignObject()
        {
            (Vector3 hitPoint, Vector3 hitNormal) = GetGroundHit();
            Allign(hitPoint, hitNormal);
        }

        private (Vector3 hitPoint, Vector3 hitNormal) GetGroundHit()
        {
            Ray rayBeneath = new Ray(transform.position, Vector3.down);
            Physics.Raycast(rayBeneath, out RaycastHit hitInfoBeneath);
            Vector3 hitPoint = hitInfoBeneath.point;
            Vector3 hitNormal = hitInfoBeneath.normal;

            return (hitPoint, hitNormal);
        }

        private void Allign(Vector3 position, Vector3 upDirection)
        {
            transform.position = position;
            transform.up = upDirection;
        }
    }
}
