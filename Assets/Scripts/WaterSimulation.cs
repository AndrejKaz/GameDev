using UnityEngine;

namespace LowPolyWater
{
    public class LowPolyWater : MonoBehaviour
    {
        /*[===Wave properties===]*/
        private float waveHeight = 0.3f;
        private float waveFrequency = 0.3f;
        private float waveLength = 1f;
        private Vector3 waveOriginPosition = new Vector3(0f,0f,0f);

        /*[===Water mesh and GameObject===]*/
        [SerializeField] MeshFilter meshFilter;
        GameObject water;
        Mesh mesh;
        Vector3[] vertices;

        private void Start()
        {
            water = GameObject.FindWithTag("Water");

            if(water != null)
            {
                meshFilter = GetComponent<MeshFilter>();
                CreateMeshLowPoly(meshFilter);
            }
        }

        void Update()
        {
            GenerateWaves();
        }
        
        MeshFilter CreateMeshLowPoly(MeshFilter mf)
        {
            mesh = mf.mesh;

            //Get the original vertices of the gameobject's mesh
            Vector3[] originalVertices = mesh.vertices;

            //Get the list of triangle indices of the gameobject's mesh
            int[] triangles = mesh.triangles;

            //Create a vector array for new vertices 
            Vector3[] vertices = new Vector3[triangles.Length];
            
            //Assign vertices to create triangles out of the mesh
            for (int i = 0; i < triangles.Length; i++)
            {
                vertices[i] = originalVertices[triangles[i]];
                triangles[i] = i;
            }

            //Update the gameobject's mesh with new vertices
            mesh.vertices = vertices;
            mesh.SetTriangles(triangles, 0);
            
            // Assign the new mesh to the MeshFilter
            mf.mesh = mesh;
            this.vertices = mesh.vertices;

            return mf;
        }

        void GenerateWaves()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];

                //Initially set the wave height to 0
                v.y = 0.0f;

                //Get the distance between wave origin position and the current vertex
                float distance = Vector3.Distance(v, waveOriginPosition);
                distance = (distance % waveLength) / waveLength;

                //Oscilate the wave height via sine to create a wave effect
                v.y = waveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequency + (Mathf.PI * 2.0f * distance));
                
                //Update the vertex
                vertices[i] = v;
            }

            //Update the mesh properties
            mesh.vertices = vertices;
        }
    }
}