#!/usr/bin/env python
# -*- coding: utf-8 -*-
from __future__ import absolute_import
from celery import task
from datetime import datetime, timedelta


@task()
def test_task():
    """
    Test task.
    :return: None
    """
    print "I'm test task [ %s ]." % str(datetime.now().time())

