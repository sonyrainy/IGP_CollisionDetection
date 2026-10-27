// SatCollisionObject.cs
// 역할: 오브젝트의 PolygonCollider2D에서 꼭짓점을 월드 좌표로 추출하여, 충돌 연산에 필요한 정보를 CollisionManager에 제공한다.

using UnityEngine;

namespace CollisionDetection {
    public class SatCollisionObject : MonoBehaviour {
        private PolygonCollider2D polygonCollider;
        private Vector2[] localVertices;
        private Vector2[] worldVertices;

        private void Start() {
            polygonCollider = GetComponent<PolygonCollider2D>();
            if (polygonCollider == null) return;

            localVertices = polygonCollider.points;
            worldVertices = new Vector2[localVertices.Length];
        }

        public Vector2[] GetVertices() {
            if (polygonCollider == null) return null;

            for (int i = 0; i < localVertices.Length; i++) {
                worldVertices[i] = transform.TransformPoint(localVertices[i]);
            }

            return worldVertices;
        }
    }
}
