import json
#data = { "results": [ { "word_alternatives": [], "alternatives": [ { "timestamps": [ [ "emergency", 0.67, 1.29 ], [ "call", 1.29, 1.51 ] ], "confidence": 0.654, "transcript": "emergency call " } ], "final": True } ], "result_index": 0 }

#m = data["results"][0]["alternatives"][0]['transcript']
import sys
import re
#print "(sys.argv)= ", (sys.argv)
def recognise_text():
	normal_text = str(re.findall('transcript(.*?)result_index', str(sys.argv), re.DOTALL)).replace("'", ' ').replace('"', ' ').replace(':', ' ').replace("}"," ").replace("]"," ").replace(","," ").replace("\\"," ").replace("  "," ").replace("  "," ").replace("["," ").replace("true","").replace('final',"")
	#print "++++++++++++++++++++++++normal_text: ", normal_text
	if "temperature" in normal_text:
		print "weather"
	elif "emergency" in normal_text or "message" in normal_text:
		print "sms"
	elif "go" in normal_text:
		print "blink"
	elif "music" in normal_text:
		print "music_on"
	elif "time" in normal_text or "what" in normal_text or "is" in normal_text or "now" in normal_text:
		print "time"


recognise_text()
