import wolframalpha

APPID = 'P7783G-H9899P27J6'
client = wolframalpha.Client(APPID)


def get(question):
    res = client.query(question)
    answr = ''
    for i in res.results:
        answr += i.text
    return answr