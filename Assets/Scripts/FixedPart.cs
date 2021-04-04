using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPart : MonoBehaviour
{
    public Material _highlightMaterial;
    public int PartArrayNumber;

    public enum State
    {
        Disabled,
        Highlighted,
        Visible
    }

    MeshRenderer _meshRenderer;
    Material[] _materials;
    
    public State state
    {
        get
        {
            return _currentState;
        }
        set
        {
            if (_currentState != value)
            {
                switch(value)
                {
                    case State.Disabled:
                        gameObject.GetComponent<Collider>().enabled = false;
                        _meshRenderer.enabled = false;
                        gameObject.transform.Find("SnapDropZone").gameObject.SetActive(false);
                        break;
                    case State.Highlighted:
                        Material[] materials = _meshRenderer.materials;
                        for (int i = 0; i < _meshRenderer.materials.Length; ++i)
                        {
                            materials[i] = _highlightMaterial;
                        }
                        _meshRenderer.materials = materials;
                        _meshRenderer.enabled = true;
                        gameObject.transform.Find("SnapDropZone").gameObject.SetActive(true);

                        break;
                    case State.Visible:
                        //gameObject.GetComponent<Collider>().enabled = true;
                        _meshRenderer.materials = _materials;
                        _meshRenderer.enabled = true;
                        Destroy(gameObject.transform.Find("SnapDropZone").gameObject);

                        break;
                }
            }
            _currentState = value;
        }
    }
    State _currentState = State.Visible;

	void Awake ()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = _meshRenderer.materials;

        state = State.Disabled;
	}



}
