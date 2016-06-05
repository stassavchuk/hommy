from twilio.rest import TwilioRestClient
import pyvona
# ACCOUNT_SID = "AC3813dad5bbcbfcc2257efde2934ab169"
# AUTH_TOKEN = "2b7d26b34696dcd84bb34ce23e80569c"
ACCOUNT_SID = "AC3813dad5bbcbfcc2257efde2934ab169"
AUTH_TOKEN = "2b7d26b34696dcd84bb34ce23e80569c"
FROM = '+12012974072'
######## 0ug9A+pdxiN8ElT5pjzFUnjw1DnDIVPePeZKzXsD

# The phone in case of emergency
TO = '+380505015275'
NAME = 'Stas'
# NAME = "Myroslav"
# TO = '+380986271487'

# Emergency text
TEXT = 'Help me please!'


def send(to=None, text=None):
    if not text:
        text = TEXT
    if not to:
        to = TO
    try:
        client = TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN)
        client.messages.create(to=to, from_=FROM, body=text)

        response_text = 'The emergency text has been sent to' + NAME + '.'
    except:
        response_text = 'Sorry. I can not proceed your question. Please, try again.'

    return response_text

def text_to_voice(text):
    voice = pyvona.create_voice('GDNAJGS7LA727ED4TP2Q', 'DUyJY7AxZbaVJBmU4UYOpAHNe1FDUbuFlezAqeCW')
    voice.voice_name = "Eric"
    voice.speak(text)

text_to_voice(send())