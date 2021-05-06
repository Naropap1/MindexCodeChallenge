Naropa Perez
Code Challenge
Notes

1. Overview

	The challenge made sense in that it was testing my general knowledge about databases and coding in .NET.
	The first task was a good example of working with a recursive one to many relationship
	The second task was a good example of a one to one relationship with a foreign key

2. Deseign Decesions

	I decided that ReportingStructure was not persistent and closely so related to employee such that it was able to share many classes with Employee.
	But I still created its own controller inorder to keep my REST endpoints organized.

	The compensation was its own entity entirely - so it merited the creation of its own Repository and Service and Controller.
	I decided to follow convention over configuration and use a unique primary key for compensation 
	instead of doubling up compensation's foreign key as a primary key

3. Solving Bottlenecks

	Full disclosure this assignment was the first time I've used .NET. 
	It was also the first time I've worked on a Model View Controller design pattern without a view.
	
	I knew what I was looking for, but my time consuming sections was simply a few segments of .Net code that made everything work the way I needed.

	Overall it wasn't too bad, my prior experience working with with PHP, Javascript and Python for web/database development came in handy.
	Adn of course my C++ and Java experience helped as well.
	
4. Who I am as a Programmer

	Over the last year I've made a considerable effort to fit more within what is expected of a conventional programmer.
	I recognize the important of good class models, documentation, and programming for calrity over optimization.
	I am picking up these skills so that I can work as part of a team. 
	I consider myself to be a good team player and highly prefer to be part of a team.

	That said, at my roots, I am a problem solver who enjoys large messy problems with many brand new fields inorder to maximize learning.
	That is most likely why Optel, Inc saught me out as a solo full stack developer where they regularly pit me against difficult new problems.

	I must admit I have enjoyed my time and freedom at Optel, 
	but I am eager to work long term as part of a team of programmers at an oppertunity such as the ones at Mindex.

4. Resources used

	I would like to be upfront with all resources I utlized while working on this challenge.

	Software Skills Training, Inc. (SST) - Introduciton to the C# Programming Language for Windows and Web Programmers
	docs.microsoft.com/en-us/ef/core/
	https://www.learnentityframeworkcore.com/
	https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx


