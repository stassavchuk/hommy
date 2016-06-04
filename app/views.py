from django.shortcuts import render
from django.http import JsonResponse
from datetime import datetime


def home(request):
    print "I'm hoomy [ %s ]." % str(datetime.now().time())
    from tasks import test_task
    test_task()
    test_task.delay()
    return JsonResponse({'You are welcome to ': 'HOMMY [ %s ]' % str(datetime.now().time())})