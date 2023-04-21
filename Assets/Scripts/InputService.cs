using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputService : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject restartPanel;
    public event Action<Vector3> OnShoot;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Physics.Raycast(Camera.main!.ScreenPointToRay(eventData.position), out RaycastHit hitInfo))
            OnShoot?.Invoke(hitInfo.point);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void ShowRestartPanel()
    {
        restartPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}