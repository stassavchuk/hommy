import requests
import json


appid = '6e78e5afdbbe747bde1269b09476f183'
url = r'http://api.openweathermap.org/data/2.5/weather'

CITY = 'Lviv'


def _get_weather(city):
    r = requests.get(
        url=url,
        params=dict(
            q=city,
            appid=appid
        )
    )
    decoded = json.loads(r.text)
    # print json.dumps(decoded, indent=4)
    return decoded


def now(city=None):
    if not city:
        city=CITY
    try:
        data = _get_weather(city)

        # general
        text = 'There is ' + data['weather'][0]['description'] + ' in ' + city + '. '

        # temperature
        text += 'The temperature is ' + str(int(float(data['main']['temp']) - 272)) + ' degrees Celsius. '

        # wind
        text += 'The speed of wind is ' + str(int(float(data['wind']['speed']))) + ' meter per second. '

    except:
        text = 'Ops. I can not proceed your question. Please try again.'
    finally:
        return text


if __name__ == '__main__':
    print now('Odesa')
