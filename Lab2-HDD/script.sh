#!/bin/bash
gnome-terminal -x sh -c 'sudo hdparm -I /dev/sda'
gnome-terminal -x sh -c 'df -h'

