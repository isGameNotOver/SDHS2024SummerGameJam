using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Filled Image�� ����Ͽ� ���� �ε��ϴ� Ŭ����.
public class LoadSceneManager : MonoBehaviour
{
    // ������ �ε��� ���� �̸��� �����ϴ� ���� ����.
    public static string nextScene;

    // �����Ϳ��� Filled Image UI ��Ҹ� �����ϱ� ���� ����ȭ�� �ʵ�.
    [SerializeField] Image progressBar;

    // ���̵� ȿ���� ���� CanvasGroup�� �����ϱ� ���� ����ȭ�� �ʵ�.
    [SerializeField] CanvasGroup fadeCanvasGroup;

    // ���̵� ��/�ƿ� ���� �ð��� �����ϱ� ���� ����ȭ�� �ʵ�.
    [SerializeField] float fadeDuration = 1.0f;

    private void Awake()
    {
        // �񵿱� �� �ε带 �����ϴ� �ڷ�ƾ�� ������.
        StartCoroutine(LoadScene());
    }

    // ���� ���� �����ϰ� �ε� ������ ��ȯ�ϴ� ���� �޼���.
    public static void LoadScene(string sceneName)
    {
        // ������ �ε��� ���� �̸��� ������.
        nextScene = sceneName;
        // Filled Image�� ǥ���ϱ� ���� �ε� ���� �ε���.
        SceneManager.LoadScene("99.LoadingScene");
    }

    // ���� ���� �񵿱������� �ε��ϴ� �ڷ�ƾ.
    IEnumerator LoadScene()
    {
        // ���̵� �ƿ� ȿ���� ������.
        yield return StartCoroutine(FadeOut());

        // ���� �ε�Ǳ� �����ߴ��� Ȯ���ϱ� ���� �� �������� ��ٸ�.
        yield return null;

        // ���� ���� �񵿱������� �ε��ϰ� �ڵ� Ȱ��ȭ�� ������.
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        // Filled Image �ִϸ��̼��� �����ϱ� ���� Ÿ�̸�.
        float timer = 0.0f;

        // ���� �ε�� ������ ������ �ݺ���.
        while (!op.isDone)
        {
            // ���� �������� ��ٸ�.
            yield return null;
            // ������ ������ ���� ����� �ð���ŭ Ÿ�̸Ӹ� ������Ŵ.
            timer += Time.deltaTime;

            // ���� 90% �ε� ���൵�� �������� ���� ���.
            if (op.progress < 0.9f)
            {
                // �ε� ���൵�� ���� Filled Image ä��� ���� �ε巴�� �ִϸ��̼�ȭ��.
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                // ä��� ���� �ε� ���൵�� �����ϸ� Ÿ�̸Ӹ� ������.
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else // ���� ���� �ε� �Ϸ�� ��� (90% �̻�).
            {
                // Filled Image ä��� ���� �ִ�� �ε巴�� �ִϸ��̼�ȭ��.
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                // Filled Image�� ���� ���� ���̵� �� ȿ���� �����ϰ� �� Ȱ��ȭ�� ����� �� ������ ������.
                if (progressBar.fillAmount == 1.0f)
                {
                    yield return null;
                    yield return StartCoroutine(FadeIn());
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    // ���̵� �� ȿ���� ���� �ڷ�ƾ.
    IEnumerator FadeIn()
    {
        // ���̵� ���� ������ �� ĵ���� �׷��� ���� ���� 1�� ������.
        fadeCanvasGroup.alpha = 1f;
        float timer = 0f;

        // ������ ���̵� �� ���� �ð� ���� ���� ���� 0���� ���ҽ�Ŵ.
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = 1f - (timer / fadeDuration);
            yield return null;
        }

        // ���̵� ���� �Ϸ�Ǹ� ���� ���� 0���� ������.
        fadeCanvasGroup.alpha = 0f;
    }

    // ���̵� �ƿ� ȿ���� ���� �ڷ�ƾ.
    IEnumerator FadeOut()
    {
        // ���̵� �ƿ��� ������ �� ĵ���� �׷��� ���� ���� 0���� ������.
        fadeCanvasGroup.alpha = 0f;
        float timer = 0f;

        // ������ ���̵� �ƿ� ���� �ð� ���� ���� ���� 1�� ������Ŵ.
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        // ���̵� �ƿ��� �Ϸ�Ǹ� ���� ���� 1�� ������.
        fadeCanvasGroup.alpha = 1f;
    }
}