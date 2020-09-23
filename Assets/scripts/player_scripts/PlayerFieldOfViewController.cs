using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldOfViewController : MonoBehaviour
{
	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	Vector3 origin = Vector3.zero;
	float startingAngle;
	

	[SerializeField]
	int lightAngle = 90;

	[SerializeField]
	float viewDistance = 5f;

	[SerializeField]
	float adjustAngle = 0f;

	private Mesh mesh;


	// Start is called before the first frame update
	void Start()
    {
		mesh = new Mesh();
		origin = transform.position;
		GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		int rayCount = lightAngle / 2;
		int[] triangles = new int[rayCount * 3];

		float angle = startingAngle;
		float angleIncrease = lightAngle / rayCount;

		Vector3[] vertices = new Vector3[rayCount + 1 + 1];
		Vector2[] uv = new Vector2[vertices.Length];

		vertices[0] = origin;

		for (int index = 0, vertexIndex = 1, triangleIndex = 0; index <= rayCount; index++)
		{
			Vector3 vertex;

			RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))), viewDistance, layerMask);

			if (raycastHit2D.collider != null)
			{
				vertex = raycastHit2D.point;
			}

			else
			{
				vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * viewDistance;
			}

			vertices[vertexIndex] = vertex;

			if (index > 0)
			{
				triangles[triangleIndex] = 0;
				triangles[triangleIndex + 1] = vertexIndex - 1;
				triangles[triangleIndex + 2] = vertexIndex;

				triangleIndex += 3;
			}

			vertexIndex++;

			angle -= angleIncrease;
		}

		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;

	}

	public void SetOrigin(Vector3 newOrigin)
	{
		origin = newOrigin;

		mesh.RecalculateBounds();
	}

	public void SetAimDirection(Vector3 aimDirection)
	{
		float angle;

		aimDirection = aimDirection.normalized;

		angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

		if(angle < 0)
		{
			angle += 360;
		}

		startingAngle = angle + lightAngle / 2f + adjustAngle;

		mesh.RecalculateBounds();
	}

	public void SetMaterial(Material lightingMaterial)
	{
		GetComponent<MeshRenderer>().material = lightingMaterial;
	}
}
