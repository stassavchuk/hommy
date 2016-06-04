#!/bin/sh
if [ -z "$RUN_ENV" ]; then
    echo 'Please set up RUN_ENV variable'
    exit 1
fi

if [ "$RUN_ENV" = "PROD" ]; then
    echo 'This is PROD...'
fi

if [ "$RUN_ENV" = "DEV" ]; then
    docker-compose stop
    if [ "$1" != "stop" ]; then
        docker-compose rm -f
        docker-compose up -d
    fi

fi
