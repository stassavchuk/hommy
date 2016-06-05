# Download the Python helper library from twilio.com/docs/python/install
from twilio.rest import TwilioRestClient

# Your Account Sid and Auth Token from twilio.com/user/account
account_sid = "AC3813dad5bbcbfcc2257efde2934ab169"
auth_token  = "2b7d26b34696dcd84bb34ce23e80569c"
client = TwilioRestClient(account_sid, auth_token)

FROM = '+12012974072'

# The phone in case of emergency
TO = '+16783104685'
NAME = 'Stas'

# Emergency text
TEXT = 'This is emergency.'

call = client.calls.create(
    url="http://demo.twilio.com/docs/voice.xml",
    to=TO,
    from_=FROM,
    method="GET",
    status_callback="https://www.myapp.com/events",
    status_callback_method="POST",
    status_events=["initiated", "ringing", "answered", "completed"],
)
print call.sid