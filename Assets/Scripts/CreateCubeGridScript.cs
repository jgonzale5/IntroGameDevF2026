using UnityEngine;
//Add this so we can use lists
using System.Collections.Generic; 

public class CreateCubeGridScript : MonoBehaviour
{
    //The dimensions of this grid. Expects integers.
    public Vector2 gridSize;
    //The distance between an element of the grid and the next one.
    public float distanceBetweenElements = 0.1f;
    //The object that we'll spawn
    public Transform gridObject;
    //The list of cubes in the grid, added as they're created
    public List<Transform> cubesInGrid = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            Transform temp;

            //A loop is made of three elements:
            //    V The initial condition
            //                 V The condition we check at the end of each iteration, to determine if we repeat
            //                                V What's done to the variable between iterations
            for (int x = 0; x < Mathf.RoundToInt(gridSize.x); x++)
            {
                //Spawn a new object at this location with no rotation
                temp = Instantiate(gridObject, transform.position, Quaternion.identity);

                //Parent the newly created cube to this object
                temp.SetParent(this.transform);

                //Add the "temp" element to the list of cubes in grid
                cubesInGrid.Add(temp);

                //Equivalent terms
                //temp.position += Vector3.right * x * distanceBetweenElements;
                //temp.position = temp.position + new Vector3(x * distanceBetweenElements, 0, 0);
                temp.position = new Vector3(
                    temp.position.x + x * distanceBetweenElements,
                    temp.position.y,
                    temp.position.z);

                //We repeat the offset in Z
                temp.position += Vector3.forward * y * distanceBetweenElements;
            }

            
        }
    }

    public void DeleteGrid()
    {
        //var is a type that will become whatever makes sense in that context
        // In this case, since cubesInGrid contains Transforms, it makes t a Transform
        foreach(var t in cubesInGrid)
        {
            //For each element in the list, destroy it
            Destroy(t.gameObject);
        }

        //Clear the list so we don't leave missing references in it
        cubesInGrid.Clear();
    }
}
