KanColleAPI
===========

A library written in C# that extracts and interprets JSON player information from the KanColle server.

This is mainly written as an exercise in C# for me. I take no responsibility if you use this library for any hanky-panky and get banned.

Still incomplete.

How to Use
===========
Build this to get the DLL.

This library provides a KanColleProxy class that sends and receives a POST request. The current user-agent is Firefox.

The KanColleProxy class outputs a raw JSON string which you must then implement methods to deal with yourself. Personally I used JSON.NET to achieve this.

To-do
========
Add stuff that interprets battle data.

Add user agent extensions.
