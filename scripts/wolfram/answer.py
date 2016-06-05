import requests
from time import time

APPID = 'P7783G-H9899P27J6'
url = 'http://api.wolframalpha.com/v2/query'

subject = None

waiting_dict = [
    'Well, this is an interesting question.',
    'I have to this about it.',
    'I should search for it in my database.',
    'Hm, I have never thought about it.',
    'Would you wait for a while?',
    'Have you tried to google it? Never mind, I will do it for you.',
    'It could take a few seconds. '
]


def get(question):
    r = requests.get(
        url,
        dict(
            appid=APPID,
            format='cell',
            input=question.replace(' ', '%20')
        )
    )
    print r.text


if __name__ == '__main__':
    t0 = time()
    get('what is the highest mountain in the world')
    print 'Total time:', time() - t0