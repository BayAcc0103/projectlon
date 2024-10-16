using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwing : MonoBehaviour
{
    public Transform KnifeTransform;   // Reference to the cube (Knife)
    public float swingSpeed = 5f;      // Speed of the swing
    public float swingAngle = 45f;     // Max angle for the swing
    private Vector3 initialRotation;   // Store initial rotation
    private bool isSwinging = false;

    private void Start()
    {
        // Store the cube's initial rotation
        initialRotation = KnifeTransform.localEulerAngles;
    }

    public void StartSwing()
    {
        if (!isSwinging)
        {
            StartCoroutine(SwingKnife());
        }
    }

    private IEnumerator SwingKnife()
    {
        isSwinging = true;
        float elapsedTime = 0f;

        // Rotate to the swing position
        while (elapsedTime < 1f)
        {
            float angle = Mathf.Lerp(0f, swingAngle, elapsedTime);
            KnifeTransform.localEulerAngles = new Vector3(initialRotation.x, initialRotation.y+ angle, initialRotation.z );
            elapsedTime += Time.deltaTime * swingSpeed;
            yield return null;
        }

        elapsedTime = 0f;

        // Rotate back to the initial position
        while (elapsedTime < 1f)
        {
            float angle = Mathf.Lerp(swingAngle, 0f, elapsedTime);
            KnifeTransform.localEulerAngles = new Vector3(initialRotation.x, initialRotation.y+ angle, initialRotation.z );
            elapsedTime += Time.deltaTime * swingSpeed;
            yield return null;
        }

        // Reset rotation and stop swinging
        KnifeTransform.localEulerAngles = initialRotation;
        isSwinging = false;
    }
}
