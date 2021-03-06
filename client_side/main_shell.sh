#!/bin/sh
#while true; do 

play bing.mp3
play bing.mp3

# start recording audio
rec -V recording.flac rate 48k silence 0 1 0:00:01 8% silence 0 1 00:00:05 0%

#play it
play recording.flac

# post request
json_result=`curl -X POST -u "3964d214-82a8-44f7-a6ae-b525a60cec98":"vnVsqkE3bke6" --header "Content-Type: audio/flac" --data-binary @recording.flac "https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?timestamps=true&word_alternatives_threshold=1.0"`

# print results
echo "json_result= " $json_result

#play bing
play bing.mp3

url_parametr=`python parce_json.py $json_result`
echo "************************************************url_parametr= " $url_parametr
#curl http://95.164.164.67:8888/?request=$url_parametr

if [ "$url_parametr" = "blink" ] || [ "$url_parametr" = "music_on" ];
	then curl http://95.164.164.67:8888/?request="$url_parametr"

elif [ "$url_parametr" = "time" ] ;
	then python get_time.py
elif [ "$url_parametr" = "weather" ] ;
	then python get_wether.py
elif [ "$url_parametr" = "sms" ] ;
	then python emergency_sms.py
elif [ "$url_parametr" = "who_are_you" ] ;
	then python who_are_you.py
elif [ "$url_parametr" = "introduce" ] ;
	then python introduce_our_project.py
else play repeat_command.mp3
fi	


#done
