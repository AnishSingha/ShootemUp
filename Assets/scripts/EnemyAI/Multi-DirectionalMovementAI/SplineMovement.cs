using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer splineContainer; // Reference to the SplineContainer that holds the path.
    public float speed = 2.0f; // The speed at which the object moves along the path.
    public bool loop = true; // Whether to loop the path.

    private float t = 0.0f; // The parameter t that determines the position along the path.

    private void Update()
    {
        // Check if the SplineContainer is assigned and has at least one spline.
        if (splineContainer != null && splineContainer.Splines.Count > 0)
        {
            // Increment the parameter t based on the speed.
            t += speed * Time.deltaTime;

            // If t exceeds 1, reset it for looping.
            if (t > 1.0f)
            {
                if (loop)
                {
                    t = 0.0f;
                }
                else
                {
                    // If not looping, stop the movement.
                    t = 1.0f;
                }
            }

            // Evaluate the position and tangent on the spline.
            if (splineContainer.Evaluate(t, out var position, out var tangent, out _))
            {
                // Set the object's position to the evaluated position.
                transform.position = position;

                // **Optionally, rotate the object to align with the tangent.
                //transform.rotation = Quaternion.LookRotation(tangent, Vector3.up);
            }
        }
    }
}
