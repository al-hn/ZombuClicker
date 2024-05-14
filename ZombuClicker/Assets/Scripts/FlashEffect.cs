using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
// using Unity.VisualScripting;
using UnityEngine;
// using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] public Material mat;
    [SerializeField] public float duration = 0.1f;
    public UnityEngine.UI.Image img;
    public Material originalMat;
    public Coroutine flashRoutine;

    void Start()
    {
        img = GetComponent<UnityEngine.UI.Image>();
        originalMat = img.material;
    }

    public IEnumerator FlashRoutine()
    {
        img.material = mat;
        yield return new WaitForSeconds(duration);
        img.material = originalMat;
        flashRoutine = null;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

}
