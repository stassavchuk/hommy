#!/usr/bin/env python

import os
import tornado.ioloop
import tornado.web
import RPi.GPIO as GPIO
import time

LAMP = 7
TIMEOUT = 0.2

class MainHandler(tornado.web.RequestHandler):
    def get(self):
        request = self.get_argument('request', "No value", True)
        
        if request == "blink":
            os.system("mpg123 -q sounds/bing.mp3 &")
            
            GPIO.setmode(GPIO.BOARD)
            GPIO.setup(LAMP, GPIO.OUT)

            for i in range(0, 10):
                GPIO.output(LAMP, False)
                time.sleep(TIMEOUT)
                GPIO.output(LAMP, True)
                time.sleep(TIMEOUT)
            
            GPIO.cleanup()
            os.system("mpg123 -q sounds/male-mmmm-good_Gk6HPf4_.mp3 &")	
            self.write("OK")
        elif request == "light_on":
            GPIO.setmode(GPIO.BOARD)
            GPIO.setup(LAMP, GPIO.OUT)
            GPIO.output(LAMP, True)
            GPIO.cleanup()
            self.write("LIGHT IS ON")
        elif request == "light_off":
            GPIO.setmode(GPIO.BOARD)
            GPIO.setup(LAMP, GPIO.OUT)
            GPIO.output(LAMP, False)
            GPIO.cleanup()
            self.write("LIGHT IS OFF")
        elif request == "set_background":
            percent = self.get_argument('percent', "90", True)
            self.write("OK")
        elif request == "set_voice":
            type = self.get_argument('type', "Male", True)
            self.write("OK")
        elif request == "music_on":
            os.system('mpg123 -q http://stream.dancewave.online:8080/dance.mp3 &')
            self.write("MUSIC IS ON")
        elif request == "radio":
            stream_url = self.get_argument('stream_url', "None", True)
            if stream_url != "None":
                os.system("mpg123 -q " + stream_url + " &")
                self.write("OK")
        elif request == "music_off":
            os.system('killall mpg123')
            self.write("MUSIC IS OFF")
        else:
            self.write(request)

def make_app():
    return tornado.web.Application([
        (r"/", MainHandler),
	(r"/(.*)", tornado.web.StaticFileHandler, {'path': '/home/pi/server/static/'}),
    ])

if __name__ == "__main__":
	try:
		print "Server has started on 8888 port"
    		app = make_app()
    		app.listen(8888)
    		tornado.ioloop.IOLoop.current().start()
	except KeyboardInterrupt:
		GPIO.cleanup()
