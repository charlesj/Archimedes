# Archimedes

[![Build status](https://ci.appveyor.com/api/projects/status/f8yhkdhdhtppto47?svg=true)](https://ci.appveyor.com/project/charlesj/archimedes)

*Current Status*: Updating libraries and refactoring. The web project will
start, but doesn't actually do anything.  The console project runs a null
command.  All tests pass locally.

Tests that require app.config files do not run on appveyor.  I'm looking into
this. See https://github.com/charlesj/AppVeyorXunitIssue

Requires C# 6.

This project is a place where I am experimenting with several different things:

- What's the least wrong way I can find to wire up core application services
in a way that can be used wherever I need them to be.
- Learning the basics of Durandal
- Making data flow through the application with commands in a logical and
consistent manner
- Is there a better object mapper than auto mapper?
- What if we don't use entity framework?
