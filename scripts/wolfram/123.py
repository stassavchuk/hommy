import requests
from time import time
import urllib

import xml.etree.ElementTree as ET
import xml.dom.minidom

import wolframalpha

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
    'It could take a few seconds. Are you hurry?'
]


def get(question):
    t0 = time()
    r = requests.get(
        url=url,
        params=dict(
            appid=APPID,
            format='plaintext',
            input=question
        )
    )
    t1 = time() - t0

    # For debug
    # print r.text

    xml_text = ''.join([i if ord(i) < 128 else ' ' for i in r.text])
    xml_obj = ET.fromstring(xml_text)

    url_link = url + '?appid=' + APPID + '&format=' + '&input=' + question.replace(' ', '%20') + '&format=' + 'plaintext'


    t0 = time()
    # requests.get(r'http://api.wolframalpha.com/v2/query?appid=P7783G-H9899P27J6&format=plaintext&input=what%20is%20the%20highest%20mountain%20in%20the%20world')
    requests.get(url_link)
    t2 = time() - t0



    t0 = time()
    text = urllib.urlopen(url_link).read()
    t3 = time() - t0

    # print text
    print "!!!!!!!", t1, t2, t3

def ask():
    pass

if __name__ == '__main__':
    # get('what is the highest mountain in the world')
    t0 = time()
    client = wolframalpha.Client(APPID)
    question = 'What is the highest mountain in the world'
    res = client.query(question)
    s = ''
    for i in res.results:
        s += i.text
    print s.strip()
    print time() - t0
