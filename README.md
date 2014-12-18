Recent Updates
==========
Recent Updates @ 16 Dec '14:
Now I'm quite busy and don't really have the time to keep making new stuff. RunExp is quite stable except for 2 known issues (1 - Sometimes more than 1 expedition will try to access the same __abcd__ text file and cause read/write conflicts and 2 - I need to make the program more resilient against network lags and timeouts)

Suffice to say don't expect any major changes except bug fixes any time soon.

**NOTE: RapidCraft might be removed because I'm a little too lazy to develop it.

Overview
==========
This solution contains a few things:

KanColleAPI
==========
A library written in C# that extracts and interprets JSON player information from the KanColle server.

This is mainly written as an exercise in C# for me. I take no responsibility if you use this library for any hanky-panky and get banned.

Always a work in progress.

Build this to get the DLL.

This library provides a KanColleProxy class that sends and receives a POST request. The current user-agent is Firefox.

The KanColleProxy class outputs a raw JSON string which you must then implement methods to deal with yourself. Personally I used JSON.NET to achieve this.

RunExp
==========
Probably what you are here for.

This is a simple command line program that loops expedition commands.

Sparkler
==========
Another simple cmd line program that sends a single ship out on 1-1 sparkle battles.
You specify which fleet to send out and how many times to sparkle.
This program will tell you the morale/condition of the ship every loop.

[UPDATE] Now this program will skip iterations if the morale is 81 or greater.

To-do
========
Add stuff that interprets battle data.

Add user agent extensions.
