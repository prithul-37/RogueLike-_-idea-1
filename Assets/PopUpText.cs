using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public static PopUpText Create(string text, Vector3 pos,Color c)
    {
        GameObject popupTextTransform = Instantiate(GameAssets.i.PopUpText, pos, Quaternion.identity);
        PopUpText popUpText = popupTextTransform.GetComponent<PopUpText>();
        popUpText._textMeshPro.color = c;
        popUpText.Setup(text);
        return popUpText;
    }

    private TextMeshPro _textMeshPro;
    private Color _color;
    float timer = 1f;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _color = _textMeshPro.color;
    }

    public void Setup(string text)
    {
        _textMeshPro.text = text;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(0 < timer ) 
        transform.position += new Vector3(0,.0005f,0);

        if (timer <= 0)
        {
            float alphaChange = .05f;
            _color.a -= alphaChange;
            _textMeshPro.color = _color;

            if (_color.a < 0f)
            {
                Destroy(gameObject);
            }
        }
    }

}
