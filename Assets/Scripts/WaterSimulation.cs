using UnityEngine;

namespace LowPolyWater
{
    [RequireComponent(typeof(MeshFilter))]
    public class LowPolyWater : MonoBehaviour
    {
        /* ================= Wave Settings ================= */
        [Header("Wave Settings")]
        [SerializeField] private float waveHeight = 0.3f;
        [SerializeField] private float waveFrequency = 0.3f;
        [SerializeField] private float waveLength = 1f;
        [SerializeField] private Vector3 waveOriginPosition = Vector3.zero;

        /* ================= Mesh Data ================= */
        private Mesh mesh;
        private Vector3[] vertices;
        private Vector3[] baseVertices;

        void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            mesh = meshFilter.mesh; // runtime instance (IMPORTANT)

            CreateLowPolyMesh();

            vertices = mesh.vertices;
            baseVertices = mesh.vertices.Clone() as Vector3[];
        }

        void Update()
        {
            GenerateWaves();
        }

        /* ================= Low Poly Mesh ================= */
        void CreateLowPolyMesh()
        {
            Vector3[] originalVertices = mesh.vertices;
            int[] originalTriangles = mesh.triangles;

            Vector3[] newVertices = new Vector3[originalTriangles.Length];
            int[] newTriangles = new int[originalTriangles.Length];

            for (int i = 0; i < originalTriangles.Length; i++)
            {
                newVertices[i] = originalVertices[originalTriangles[i]];
                newTriangles[i] = i;
            }

            mesh.Clear();
            mesh.vertices = newVertices;
            mesh.triangles = newTriangles;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }

        /* ================= Wave Generation ================= */
        void GenerateWaves()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = baseVertices[i];

                Vector3 worldPos = transform.TransformPoint(v);
                float distance = Vector3.Distance(worldPos, waveOriginPosition);
                distance = (distance % waveLength) / waveLength;

                v.y += waveHeight * Mathf.Sin(
                    Time.time * Mathf.PI * 2f * waveFrequency +
                    Mathf.PI * 2f * distance
                );

                vertices[i] = v;
            }

            mesh.vertices = vertices;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }
    }
}
