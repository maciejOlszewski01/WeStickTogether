using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GUIFaceCamera : MonoBehaviour
{

    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;


    // Start is called before the first frame update
    private void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);


    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {

        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
