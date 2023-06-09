# DLL-Injector

[![](https://img.shields.io/badge/Language-C%23-purple.svg?style=flat)](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)) 
[![](https://img.shields.io/github/languages/code-size/TosoxDev/DLL-Injector?color=blue&label=Code%20size&style=flat)](https://github.com/TosoxDev/DLL-Injector)
[![](https://img.shields.io/tokei/lines/github/TosoxDev/DLL-Injector?color=red&label=Total%20lines&style=flat)](https://github.com/TosoxDev/DLL-Injector)

> **Important: This repository is intended as a resource for developers working on DLL-Injection**

## Functionality

This sample project loads the binary data of a dll and stores it as a temporary file on the local disk, which is then injected into a process.
The [binary data](res/TestDLL.dll.cs) of the dll was generated and exported with [HxD](https://mh-nexus.de/de/hxd/).

## Original Use of this Project

_LWS_ is an acronym for _Live Weather Simulator_. This program was created for the game [S.T.A.L.K.E.R. Anomaly](https://www.moddb.com/mods/stalker-anomaly),
with the function to adjust the current weather in the game to the current weather in real life. For this purpose, the memory of the game must be accessed,
which was achieved by DLL injection.

## Preview

<div align="center">

[<img src="readme-res/preview.jpg" height="300" />](readme-res/preview.jpg)
[<img src="readme-res/success.jpg" height="300" />](readme-res/success.jpg)
[<img src="readme-res/warning.jpg" height="300" />](readme-res/warning.jpg)
[<img src="readme-res/error.jpg" height="300" />](readme-res/error.jpg)

</div>

