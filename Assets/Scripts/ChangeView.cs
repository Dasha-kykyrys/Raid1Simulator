using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    [SerializeField] Transform m_camera;
    [SerializeField] Transform cameraTarget1, cameraTarget2;
    float transitionDuration = 1f;
    float slideOffset = 2f;
    public static ChangeView instance;
    private void Awake()
    {
        instance = this;
    }
    public void MoveCameraToBar()
    {
        StartCoroutine(SmoothTransition(cameraTarget1));
    }

    public void MoveCameraToMaker()
    {
        StartCoroutine(SmoothTransition(cameraTarget2));
    }

    private IEnumerator SmoothTransition(Transform target)
    {
        Vector3 startPos = m_camera.position;
        Quaternion startRot = m_camera.rotation;

        Vector3 slideStartPos = startPos + (target.position - startPos).normalized * slideOffset;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / transitionDuration;

            float smoothT = Mathf.SmoothStep(0f, 1f, t);
            Vector3 intermediatePos = Vector3.Lerp(startPos, slideStartPos, smoothT);
            m_camera.position = Vector3.Lerp(intermediatePos, target.position, smoothT);

            m_camera.rotation = Quaternion.Slerp(startRot, target.rotation, smoothT);

            yield return null;
        }

        m_camera.position = target.position;
        m_camera.rotation = target.rotation;
    }
}
