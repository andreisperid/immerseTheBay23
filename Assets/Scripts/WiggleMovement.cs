using UnityEngine;

public class GentleFloating : MonoBehaviour
{
    public float verticalSpeed = 0.5f; // Speed of up and down movement
    public float verticalAmplitude = 0.5f; // Amplitude of up and down movement
    public float rotationSpeed = 30f; // Speed of rotation

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        startPos = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Random offset for natural variation
    }

    void Update()
    {
        FloatAndRotate();
    }

    void FloatAndRotate()
    {
        // Up and Down movement
        float newY = startPos.y + verticalAmplitude * Mathf.Sin(verticalSpeed * Time.time + randomOffset);
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Gentle rotation
        float newZRotation = Mathf.Sin(verticalSpeed * Time.time + randomOffset) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, newZRotation);
    }
}
