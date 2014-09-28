Feature: Browser navigation
	For effective Internet serfing
	As a user
	I want to be able to navigate to different sites


Scenario Template: Search Test
	When I navigate to "<URL>"
	Then I see "<System>" Logo

	When I search following content "<Text>" on "<System>" page
	Then I see following serach results
		| Result   | Link   |
		| <Result> | <Link> |
			
Scenarios: 
	| URL            | System | Text   | Result                  | Link                                |
	| www.yandex.com | Yandex | гугл   | Google                  | google.ru                           |
	| www.google.com | Google | погода | Погода Москва Окт. 2014 | www.meteostar.ru/ru/pogoda/Moscow/‎ |
