import re
from urllib import urlopen
u = urlopen('http://www.timeapi.org/utc/now')
data = u.read()
hour = int(data[11:-12])
other = data[14:-6]
hour += 2 
print str(hour) +":" + str(other)
import pyvona
voice = pyvona.create_voice('GDNAJGS7LA727ED4TP2Q', 'DUyJY7AxZbaVJBmU4UYOpAHNe1FDUbuFlezAqeCW')
voice.voice_name = "Eric"
voice.speak(str(hour) +":" + str(other))
