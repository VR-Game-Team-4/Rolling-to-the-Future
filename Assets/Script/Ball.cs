using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
  [Header("Respawn Settings")]
  public Transform respawnPoint;
  public float respawnHeightOffset;
  public float fallYThreshold = -10f;

  [Header("Goal Settings")]
  [Tooltip("���I����A�i�H��J�h�Ӳ��I")]
  public Collider[] goalColliders;

  public Color goalColor = Color.green;
  public float colorChangeDuration = 1.5f;
  public int flashCount = 3;
  public float flashInterval = 0.2f;

  private Renderer ballRenderer;
  private Color originalColor;
  private Coroutine goalCoroutine;

  void Start()
  {
    ballRenderer = GetComponent<Renderer>();
    if (ballRenderer != null)
      originalColor = ballRenderer.material.color;
    else
      Debug.LogWarning("Ball has no Renderer!");
  }

  void Update()
  {
    if (transform.position.y < fallYThreshold)
      Respawn();
  }

  void Respawn()
  {
    if (respawnPoint != null)
    {
      transform.position = respawnPoint.position + Vector3.up * respawnHeightOffset;
      Rigidbody rb = GetComponent<Rigidbody>();
      if (rb != null)
      {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
      }

      if (ballRenderer != null)
        ballRenderer.material.color = originalColor;

      if (goalCoroutine != null)
        StopCoroutine(goalCoroutine);
    }
    else
    {
      Debug.LogWarning("Respawn point not assigned!");
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (goalColliders != null)
    {
      foreach (Collider goal in goalColliders)
      {
        if (other == goal)
        {
          if (goalCoroutine != null)
            StopCoroutine(goalCoroutine);

          goalCoroutine = StartCoroutine(GoalEffect());
          break;
        }
      }
    }
  }

  IEnumerator GoalEffect()
  {
    Color startColor = ballRenderer.material.color;

    float t = 0f;
    while (t < colorChangeDuration)
    {
      t += Time.deltaTime;
      ballRenderer.material.color = Color.Lerp(startColor, goalColor, t / colorChangeDuration);
      yield return null;
    }
    ballRenderer.material.color = goalColor;

    for (int i = 0; i < flashCount; i++)
    {
      ballRenderer.material.color = Color.white;
      yield return new WaitForSeconds(flashInterval);
      ballRenderer.material.color = goalColor;
      yield return new WaitForSeconds(flashInterval);
    }
  }
}
