using UnityEngine;
using System.Collections;

public class MeshSmoother : MonoBehaviour {
	
	public bool DoSmooth = false;
	public float Strength = 0.5f;
	public int Iterations = 1;
	
	void Start () {
		if(DoSmooth) {
			MeshFilter mesh = GetComponent<MeshFilter>();
			
			for(int i=0; i<Iterations; i++) {
				Smooth(mesh.mesh, Strength);
			}
			
			mesh.mesh.RecalculateBounds();
			mesh.mesh.RecalculateNormals();
		}
	}
	
	public static void Smooth(Mesh mesh, float strength) {
		Vector3[] verts = mesh.vertices;
		Vector3[] newVerts = new Vector3[verts.Length];
		
		int[] tris = mesh.triangles;
		
		for(int v=0; v<verts.Length; v++) {
			Vector3 sum = new Vector3();
			int num = 0;
			
			for(int t=0; t<tris.Length; t+=3) {
				if(tris[t+0] == v || verts[tris[t+0]].Equals(verts[v]))
					sum += verts[tris[t+1]] + verts[tris[t+2]];
				else if(tris[t+1] == v || verts[tris[t+1]].Equals(verts[v]))
					sum += verts[tris[t+0]] + verts[tris[t+2]];
				else if(tris[t+2] == v || verts[tris[t+2]].Equals(verts[v]))
					sum += verts[tris[t+0]] + verts[tris[t+1]];
				else
					continue;
				
				sum -= 2*verts[v];
				num += 2;
			}
			
			newVerts[v] = verts[v] + sum/num*strength;
		}
		
		mesh.vertices = newVerts;
	}
}
