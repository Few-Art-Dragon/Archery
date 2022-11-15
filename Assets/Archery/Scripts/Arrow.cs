using UnityEngine;

public class Arrow : MonoBehaviour
{
    private bool _isFlying;
    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;

    public bool IsFlying
    {
        get { return _isFlying; }
    }

    public void SetDefaultTransform(Transform transformRope) 
    {
        transform.parent = transformRope;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        SwitchKinematicOnRigidbody(true);
        SwitchTrailRenderer(false);
    }

    public void Shot(float velocity) 
    {
        SetStateIsFlying(true);
        transform.parent = null;
        SwitchKinematicOnRigidbody(false);
        _rigidbody.AddForce(transform.forward * (velocity * Random.Range(1.3f, 1.7f)), ForceMode.Impulse);
        ClearTrailRenderer();
        SwitchTrailRenderer(true);
    }

    private void SwitchKinematicOnRigidbody(bool state)
    {
        _rigidbody.isKinematic = state;
    }

    private void ClearTrailRenderer()
    {
        _trailRenderer.Clear();
    }

    private void SwitchTrailRenderer(bool state)
    {
        _trailRenderer.enabled = state;
    }

    private void SetStateIsFlying(bool state)
    {
        _isFlying = state;
    }

    private void Awake()
    {
        _isFlying = false;
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _rigidbody.centerOfMass = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetStateIsFlying(false);
        _rigidbody.isKinematic = true;
    }
}
