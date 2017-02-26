#!/bin/bash

HOST=192.168.0.17:8000
SUFFIX=Android/Serpent.apk

curl -o ./Build/$SUFFIX http://$HOST/$SUFFIX
