using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;//ToList<>
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Question[] question;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    private SpriteRenderer renderer;
    public Animator feedAnim;
    int nilai = 0;
    public GameObject vbButtonMulai;
    private timerScript timer;
    private int quizLimiter;

    public AudioSource soundTarget;
    public AudioClip clipTarget1;
    public AudioClip clipTarget2;

    [SerializeField]
    private TextMesh factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private GameObject gambar;

    void stopAudio()
    {
        soundTarget.Stop();
    }

    void playAudio1()
    {
        soundTarget.clip = clipTarget1;
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }

    void playAudio2()
    {
        soundTarget.clip = clipTarget2;
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }

    void Awake()
    {
        renderer = gambar.AddComponent<SpriteRenderer>();
        unansweredQuestions = question.ToList<Question>();
        feedAnim.GetComponent<Animator>();
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        factText.text = "Mulai mengerjakan kuis?";
        quizLimiter = unansweredQuestions.Count - 11;
    }

    public void removeQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
    }

    public void GetRandomQuestion()
    {
        if (unansweredQuestions.Count == quizLimiter)
        {
            //unansweredQuestions = question.ToList<Question>();
            timer = FindObjectOfType<timerScript>();
            timer.stopCount();
            factText.text = "Kuis selesai";
            renderer.sprite = null;
        }
        else
        {
            if (PlayerPrefs.GetString("kuisProgress") == "1")
            {
                PlayerPrefs.SetString("gameScore", nilai.ToString());
                int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
                currentQuestion = unansweredQuestions[randomQuestionIndex];

                factText.text = currentQuestion.fact;
                renderer.sprite = currentQuestion.sprite;
                timer = FindObjectOfType<timerScript>();
                timer.startCount();
            }
        }
        //vbButtonMulai.SetActive(false);
        
    }

    IEnumerator TransitionToNextQuestion()
    {
        removeQuestion();
        yield return new WaitForSeconds(timeBetweenQuestions);
        GetRandomQuestion();
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            //debug "correct"
            /*
            if (unansweredQuestions.Count != 0)
            {
                nilai++;
                feedAnim.Play("right");
            }
             */
            if (unansweredQuestions.Count != quizLimiter)
            {
                nilai+=10;
                feedAnim.Play("right");
                if (PlayerPrefs.GetString("sound") == "enabled")
                {
                    playAudio1();
                }
            }
        }
        else
        {
            //debug "wrong"
            /*
            if (unansweredQuestions.Count != 0)
            {
                feedAnim.Play("wrong");
            }
             */
            if (unansweredQuestions.Count != quizLimiter)
            {
                feedAnim.Play("wrong");
                if (PlayerPrefs.GetString("sound") == "enabled")
                {
                    playAudio2();
                }
            }
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            //debug "correct"
            /*
            if (unansweredQuestions.Count != 0)
            {
                nilai++;
                feedAnim.Play("right");
            }
             */
            if (unansweredQuestions.Count != quizLimiter)
            {
                nilai+=10;
                feedAnim.Play("right");
                if (PlayerPrefs.GetString("sound") == "enabled")
                {
                    playAudio1();
                }
            }
        }
        else
        {
            /*
            if (unansweredQuestions.Count != 0)
            {
                feedAnim.Play("wrong");
            }
             */
            if (unansweredQuestions.Count != quizLimiter)
            {
                feedAnim.Play("wrong");
                if (PlayerPrefs.GetString("sound") == "enabled")
                {
                    playAudio2();
                }
            }
            //debug "wrong"
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
