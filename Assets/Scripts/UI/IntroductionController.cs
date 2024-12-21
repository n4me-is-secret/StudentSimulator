using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntroductionController : MonoBehaviour
{
    
    public UIDocument UI;

    [SerializeField] private float typingSpeed = 0.1f;

    private int textOrder = 0;
    private string fullText;
    private Coroutine typingCoroutine;   
    private bool bTypingCoroutine = false; 
    private bool bStartIntroduction = false;

    Color BlackoutColor = new Color(0, 0, 0, 1);
    IEnumerator Start()
    {

        Color visualTextColor = new Color(255, 255, 255, 0);

        var root = UI.rootVisualElement;

        var mainButton = root.Q<Button>("MainButton");
        mainButton.clicked += MainButton_clicked;

        var myText = root.Q<Label>("MyText");

        fullText = myText.text;
        myText.text = "";

        var Blackout = root.Q<VisualElement>("Blackout"); 
        Blackout.style.backgroundColor = BlackoutColor;

        var VisualText = root.Q<VisualElement>("VisualElement");
        VisualText.style.backgroundColor = visualTextColor; 

        while (BlackoutColor.a > 0f) 
        {
            
            if (BlackoutColor.a > 0.7f)
            {
                Blackout.style.backgroundColor = BlackoutColor;
                BlackoutColor.a -= 0.15f * Time.deltaTime;
                yield return null;
            }

            else
            {
                Blackout.style.backgroundColor = BlackoutColor;
                BlackoutColor.a -= 0.7f * Time.deltaTime;

                visualTextColor.a += 0.5f * Time.deltaTime; 
                VisualText.style.backgroundColor = visualTextColor;

                yield return null;
            }

        }

        VisualText.style.backgroundColor = new Color(255, 255, 255, 0.48f);
        
        bStartIntroduction = true;
        typingCoroutine = StartCoroutine(TypeText());

    }

    IEnumerator TypeText()
    {

        bTypingCoroutine = true;

        UI.rootVisualElement.Q<Label>("MyText").text = "";

        foreach (char c in fullText)
        {
            UI.rootVisualElement.Q<Label>("MyText").text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        bTypingCoroutine = false;

    }

    public void SkipTyping()
    {
        if (typingCoroutine != null && bTypingCoroutine) 
        {
            StopCoroutine(typingCoroutine);
            UI.rootVisualElement.Q<Label>("MyText").text = fullText;

            bTypingCoroutine = false;
        }
    }

    IEnumerator BlackOutScreen(string sceneName)
    {

        var root = UI.rootVisualElement;

        var Blackout = root.Q<VisualElement>("Blackout"); 

        while (BlackoutColor.a < 1.1f) 
        {
            
            if (BlackoutColor.a <= 0.7f)
            {
                Blackout.style.backgroundColor = BlackoutColor;
                BlackoutColor.a += 0.9f * Time.deltaTime;
                yield return null;
            }

            else
            {
                Blackout.style.backgroundColor = BlackoutColor;
                BlackoutColor.a += 0.15f * Time.deltaTime;

                yield return null;
            }

        }

        SceneManager.LoadScene(sceneName);

    }

    private void MainButton_clicked()
    {
        
        if (bTypingCoroutine) SkipTyping();
        else if (bTypingCoroutine == false && bStartIntroduction) 
        {

            textOrder += 1; 

            switch (textOrder)
            {
                case 1: 
                    fullText = "*Эх... Ну вот... Снова я погряз в своих мыслях. Ну ладно, так о чем это я. А точно.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 2:
                    fullText = "*С этого момента начинается моя самостоятельная жизнь. Именно в этом здании я буду жить следующие 4 года своей студенческой жизни. Наверное это и есть вход в общагу.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 3:
                    fullText = "*Хм... Темно... Чистый и морской воздух с ветреной улицы резко сменился, ударив мне в нос, удушающим запахом дешёвого табака, плавно переходящим в затухлый подъездный смрад сталинской пятиэтажки...*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 4:
                    fullText = "*Мне вроде бы на второй этаж.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 5:
                    fullText = "*Мдаааа..... Вот это очередь. Сколько мне её ждать?*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 6:
                    fullText = "*Ладно.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 7:
                    fullText = "*Почитаю пока что на доске есть.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 8:
                    fullText = "*Стирка, График генералок, Дежурство по территории, ...*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 9:
                    fullText = "*50 минут спустя...*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 10:
                    fullText = "*6.....*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 11:
                    fullText = "*6 раз я перечитал эту хренову доску. Сколько я уже тут стою. Может мне сходить перекусить...)*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 12:
                    fullText = "Неизвестный: Эй, парень. Парень. Сюда подойди. Ну чё ты на заселение?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 13:
                    fullText = "Ну....ну....д-д-да.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 14:
                    fullText = "Неизвестный: Че говоришь?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 15:
                    fullText = "Ну да-да, на заселение....";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 16:
                    fullText = "Неизвестный: Че че, еще раз, не слышу.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 17:
                    fullText = "На заселение!!";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 18:
                    fullText = "Неизвестный: А, ну вот держи. Короч, это бланк заявления на заселения. Заполни вот тут свои данные: ФИО, место прописки, паспортные данные. Понял?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 19:
                    fullText = "П-п-понял...";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 20:
                    fullText = "Неизвестный: Че говоришь?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 21:
                    fullText = "Понял!";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 22:
                    fullText = "*Он че, прикалывается надо мной? На самом деле я конечно же как и любой человек которому объясняют правильность и порядок заполнения, нихера не запомнил, как собственно и имя этого великана.)*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 23:
                    fullText = "А-а-а, это, ну, извини, можешь мне своё имя повторить.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 24:
                    fullText = "Неизвестный: Мое? Меня Артём зовут.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 25: // Происходит ввод имени персонажа! -------------------------------------------------------
                    fullText = "А меня....";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 26:
                    fullText = "Артем: Приятно познакомиться.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 27:
                    fullText = "*Ладно, приступим к заполнению договора.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 28:
                    fullText = "*10 минут спустя...*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 29:
                    fullText = "*Эх...вроде бы всё заполнил.*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 30:
                    fullText = "А... это, Артём.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 31:
                    fullText = "Артем: Что?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 32:
                    fullText = "Вот. Заполнил.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 33:
                    fullText = "Артем: Ну-с, давай проверим....ага...угу... Ну вроде всё правильно. Теперь можешь к Фёдоровне?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 34:
                    fullText = "К кому?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 35:
                    fullText = "Артем: Спецалист по воспитательной работе... Ну там... в кабинете... тебе туда хехе";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 36:
                    fullText = "*Что за тучная женщина? Мои глаза заслезились от мерзкого запаха селедки, перегара и сигарет...*";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 37:
                    fullText = "З-здравствуйте, я запомнил договор, что дальше?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 38:
                    fullText = "Федоровна: Здравствуйте, давайте сюда. Так... Тут все правильно... тут тоже... Ладно слушай правила. Невовремя оплаченная общага — выселение, алкоголь и курение в общаге — выселение, электроприборы в комнате — выселение. Так же ты обязан выполнять дежурство по этажу и по территории.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 39:
                    fullText = "Погодите, какое ещё дежурство?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 40:
                    fullText = "Федоровна: Всмысле какое дежурство? Ты читал что подписывал. Ты обязан дежурить по этажу с 17:00 до 17:00 следующего дня и нести ответственность за инвентарь на этаже.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 41:
                    fullText = "Л-л-ладно понял, а что за дежурство по территории?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 42:
                    fullText = "Федоровна: Я что каждому должна это объяснять? Мне на это time and power не хватит explain for everyone.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 43:
                    fullText = "UwU, гхм, то есть, что?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 44:
                    fullText = "*Федоровна: Протяжный вздох с отвращением и английским акцентом* Артём, АРТЁМ, подойди сюда.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 45:
                    fullText = "Артем: Что такое Елена Фёдоровна?";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 46:
                    fullText = "Федоровна: Проведи вот этого мальчика в его комнату и объясни ему правила общежития.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 47:
                    fullText = "Артем: Хорошо. Пойдём.";
                    typingCoroutine = StartCoroutine(TypeText());
                    break;
                case 48:
                    StartCoroutine(BlackOutScreen("Game"));
                    break;
            }

        }

        Debug.Log(textOrder);

    }

}

