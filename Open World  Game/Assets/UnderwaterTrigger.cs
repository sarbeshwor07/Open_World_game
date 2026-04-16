using UnityEngine;
using UnityEngine.Rendering;

public class UnderwaterTrigger : MonoBehaviour
{
    [Header("References")]
    public GameObject underwaterVolume;

    [Header("Settings")]
    public string playerTag = "Player";
    public float transitionSpeed = 2f;

    private Volume _volume;
    private float _targetWeight = 0f;

    void Start()
    {
        if (underwaterVolume != null)
        {
            underwaterVolume.SetActive(true);
            _volume = underwaterVolume.GetComponent<Volume>();
            _volume.weight = 0f;
        }
    }

    void Update()
    {
        if (_volume != null)
            _volume.weight = Mathf.Lerp(_volume.weight, _targetWeight, Time.deltaTime * transitionSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
            _targetWeight = 1f;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
            _targetWeight = 0f;
    }
}