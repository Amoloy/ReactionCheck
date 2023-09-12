using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public List<Sprite> sprites;

    private Image image;

    public delegate void Action();
    public static event Action CountdownEnd;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(starting());
    }

    IEnumerator starting()
    {
        gameObject.SetActive(true);

        for (int i = sprites.Count - 1; i >= 0; i--)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(1.0f);
        }

        gameObject.SetActive(false);

        CountdownEnd?.Invoke();

        yield break;
    }
}
