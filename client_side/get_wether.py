import requests
import json
import pyvona

appid = '6e78e5afdbbe747bde1269b09476f183'
url = r'http://api.openweathermap.org/data/2.5/weather'

CITY = 'Lviv'


def _get_weather():
    r = requests.get(
        url=url,
        params=dict(
            q=CITY,
            appid=appid
        )
    )
    decoded = json.loads(r.text)
    # print json.dumps(decoded, indent=4)
    return decoded


def now():
    try:
        data = _get_weather()

        # general
        text = 'There is ' + data['weather'][0]['description'] + ' in ' + CITY + '. '

        # temperature
        text += 'The temperature is ' + str(int(float(data['main']['temp']) - 272)) + ' degrees Celsius. '

        # wind
        text += 'The speed of wind is ' + str(int(float(data['wind']['speed']))) + ' meter per second. '

    except:
        text = 'Ops. I can not proceed your question. Please try again.'
    print text
    return text

def text_to_voice(text):
    voice = pyvona.create_voice('GDNAJGS7LA727ED4TP2Q', 'DUyJY7AxZbaVJBmU4UYOpAHNe1FDUbuFlezAqeCW')
    voice.voice_name = "Eric"
    voice.speak(text)

text_to_voice(now())
