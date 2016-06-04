from twilio.rest import TwilioRestClient

ACCOUNT_SID = "AC3813dad5bbcbfcc2257efde2934ab169"
AUTH_TOKEN = "2b7d26b34696dcd84bb34ce23e80569c"
FROM = '+12012974072'

# The phone in case of emergency
TO = '+380505015275'
NAME = 'Stas'

# Emergency text
TEXT = 'This is emergency.'


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
    finally:
        return response_text
