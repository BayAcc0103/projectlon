using System.Collections;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public Transform swordTransform;   // Reference to the sword
    public float swingSpeed = 5f;      // Speed of the swing
    public float swingAngle = 45f;     // Max angle for the swing
    private Vector3 initialRotation;   // Store initial rotation
    private bool isSwinging = false;
   
    private void Start()
    {
        // Store the sword's initial rotation
        initialRotation = swordTransform.localEulerAngles;
    }

    // Call this method to start the sword swing
    public void StartSwing()
    {
        if (!isSwinging)
        {
            StartCoroutine(SwingSword());
        }
    }

    private IEnumerator SwingSword()
    {
        isSwinging = true;
        float elapsedTime = 0f;

        // Rotate to the swing position
        while (elapsedTime < 1f)
        {
            float angle = Mathf.Lerp(0f, swingAngle, elapsedTime);
            swordTransform.localEulerAngles = new Vector3(initialRotation.x , initialRotation.y + angle, initialRotation.z);
            elapsedTime += Time.deltaTime * swingSpeed;
            yield return null;
        }

        elapsedTime = 0f;

        // Rotate back to the initial position
        while (elapsedTime < 1f)
        {
            float angle = Mathf.Lerp(swingAngle, 0f, elapsedTime);
            swordTransform.localEulerAngles = new Vector3(initialRotation.x , initialRotation.y + angle, initialRotation.z);
            elapsedTime += Time.deltaTime * swingSpeed;
            yield return null;
        }

        // Reset rotation and stop swinging
        swordTransform.localEulerAngles = initialRotation;
        isSwinging = false;
    }
}
