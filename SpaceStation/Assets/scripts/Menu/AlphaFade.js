var fade : float = 1;
var theTexture : Texture2D;

function OnLevelWasLoaded(level : int)
{
    StopCoroutine("FadeCoroutine");
    StartCoroutine("FadeCoroutine");
}

function FadeCoroutine()
{
    while(true)
    {
        fade = 0;
        var time : float = 0;
        while (time < 5)
        {
            yield;
            fade += Time.deltaTime / 5;
            time += Time.deltaTime;
        }
        fade = 1;
        time = 20;
        yield WaitForSeconds(15);
            while (time < 25)
        {
            yield;
            fade -= Time.deltaTime / 5;
            time += Time.deltaTime;
        }
        fade = 0;
        yield WaitForSeconds(180);
    }
}

function OnGUI()
{
    if (fade > 0)
    {
        GUI.color = Color.white;
        GUI.color.a = fade;
        GUI.DrawTexture(Rect(0f,0f,105, 120), theTexture);
        GUI.color = Color.white;
    }
}