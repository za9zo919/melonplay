using UnityEngine;

namespace Mod
{
    public class ppower : MonoBehaviour
    {
      private PhysicalBehaviour PhysicalBehaviour;
      public float BaseForce = 3000f;
      public float ChargeInfluence = 10f;
      public float SpreadAngle = 30f;
      public float EmitterSize = 1f;
      public int RayCount = 6;
      public float Range = 10f;

      private static RaycastHit2D[] buffer = new RaycastHit2D[8];

      private void Awake()
      {
        PhysicalBehaviour = GetComponent<PhysicalBehaviour>();
      }

    public void Use()
    {
        Vector2 vector = transform.position;
        Vector2 vector2 = -transform.up;
        float num = this.BaseForce + this.PhysicalBehaviour.Charge * this.ChargeInfluence;
        CameraShakeBehaviour.main.Shake(num * 0.01f, vector, 1f);
        this.PhysicalBehaviour.rigidbody.AddForceAtPosition(vector2 * 0, vector, ForceMode2D.Impulse);
        float num2 = this.SpreadAngle / 2f;
        float num3 = this.EmitterSize / 2f;
        float num4 = (float)this.RayCount - 1f;
        for (int i = 0; i < this.RayCount; i++)
        {
            float num5 = (float)i / num4;
            float z = num5 * this.SpreadAngle - num2;
            float d = num5 * this.EmitterSize - num3;
            Vector3 vector3 = Quaternion.Euler(0f, 0f, z) * vector2;
            int num6 = Physics2D.RaycastNonAlloc(vector + Vector2.Perpendicular(vector2) * d, vector3, ppower.buffer, this.Range);
            for (int j = 0; j < num6; j++)
            {
                RaycastHit2D raycastHit2D = ppower.buffer[j];
                PhysicalBehaviour physicalBehaviour;
                if (raycastHit2D.transform && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(raycastHit2D.transform, out physicalBehaviour))
                {

                    Vector3 v = num * vector3 * physicalBehaviour.rigidbody.mass;
                    physicalBehaviour.rigidbody.AddForceAtPosition(v, raycastHit2D.point);
                }
            }
        }
    }
  }
}
