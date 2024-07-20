using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnterCave : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        LoadSceneManager.LoadScene("01.Stage01");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color color = text.color;
        color.a = 0.7f;
        text.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color color = text.color;
        color.a = 1f;
        text.color = color;
    }
}
