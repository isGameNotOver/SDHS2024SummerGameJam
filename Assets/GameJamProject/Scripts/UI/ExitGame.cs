using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
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
