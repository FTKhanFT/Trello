# Trello
Trello is a collaboration tool that organizes your projects into boards. In one glance, 
Trello tells you what's being worked on, who's working on what and where something is in a process.


This project is simple Trello in desktop. It is written in Windows Form with C#.

## User Guide
You just need to download or clone the project. Then you just start Trello.exe
If you want to change something in the project, you'll need Visual Studio.

You will see the default board when you run the program.

![default](https://user-images.githubusercontent.com/35266212/43569961-31662ba4-964a-11e8-9091-b2248aaf0492.png)

If you want to change boardname, delete board or change background of board, you should click Left mouse button.
In addition, you can create new board , add cards and list. If you click Right mouse button on advanced menu of row, you
will have access to change the name of row and delete row. If you want to delete card, change the name of card and drag&drop, 
you can click Right mouse button on advanced menu of card.

![advancedmenu](https://user-images.githubusercontent.com/35266212/43570753-2302e050-964c-11e8-8a95-3ee075f092ee.png)

For drag&drop you just select row which you want to drop the card.

![draganddrop](https://user-images.githubusercontent.com/35266212/43570756-26008ece-964c-11e8-838a-c2f2ed7ecc6a.png)

All boards is collocated in list. You can look this list by clicking  left button on boards.

## Saving Data
All data is saving in json file.
NewtonSoft.Json.dll was used to create json file.

