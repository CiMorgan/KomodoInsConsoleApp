# Komodo Insurance Console App
Final Challenge for Eleven Fifty Academy Gold Badge

Table of Contents
1. About project
2. Languages
3. Getting started
4. Contact information
5. Acknowlegments

#1 About project: Developed as the final project for completion of Gold Badge at Eleven Fifty Academy. This project consists of five console applications to assist Komodo Insurance Team Members in our Cafe, Claims Department, Security Administration, Workplace Happiness Center, and Outreach.

Console Application 1 (C1_Cafe): contains the files C1_CafeRepo, C1_CafeTests, and C1_CafeConsole (as GoldBadgeConsoleApp in GitHub). Designed for the manager of the Komodo Cafe, this application allows the user to create, update, delete, and display meals from our extensive Cafe menu. Each meal (Class: Menu) contains a menu number for quick identification, the name and a brief description of the meal, a list of ingredients, and the selling price.

Console Application 2 (C2_Claims): contains the files C2_ClaimsRepository, C2_ClaimsTests, and C2_ClaimsConsole. Designed for our Claims Department, this application allows the user to create a new claim and see all claims that have not been "dealt with". Each claim (Class: Claim) has a unique number that stays with the claim, a type (Car, Home, Theft), a brief description, claim amount, date of incident, date of claim, and whether the claim is valid. A claim is considered valid if it was submitted with 30 days of the incident. The user can add a new claim, defaulting to the current date for adding the claim date. Validity of the dates entered (no February 31) and the claim itself (within 30 days) occurs when a claim is added. The new claim is added to the list (bottom of the queue) and has the next highest claim number. If the user would like to deal with a claim, the claim with the lowest number (top of the queue) is "dealt with" and removed.

Console Application 3 (C3_Badges): contains the files C3_BadgesRepository, C3_BadgesTests, and C3_BadgesConsole. Designed for our Security Administration, this application allows the user to add a new badge, update door access to an existing badge, and display all badges and all doors to which each badge grants access. This application verfies that there are no badges with identical identification numbers. For each badge, it also displays door access in alphabetical order to quickly identify which doors need to be added or removed.

Console Application 4 (C4_Outings): contains the files C4_OutingsRepository, C4_OutingsTests, and C4_OutingsConsole. Designed for our Workplace Happiness Center, this application allows the user to add Komodo Insurance Company Outings and monitor cost based on outing types and total costs. Each outing (Class: Outings) includes an event type, number of attendees, date of event, cost per person, and cost of event. When entering a new event, Komodo Insurance Workplace Happiness Center has four event types from which to choose: Golf, Bowling, Amusement Park, and Concert. Next, the user can enter the number of attendees, the cost per person, and the date of the event. Similar to the Claims Console Application, invalid dates (November 31) are not allowed. The program automatically calculates the total cost by multipling the cost per person by the total number of attendees. The user can view all outings, displayed chronologically, and the total cost for all outings combined. They can also see the total cost for each type of event; for example, the total cost for all Bowling outings.

Console Application 5 (C5_Greeting): contains the files C5_GreetingsRepository, C5_GreetingsTests, and C5_GreetingsConsole. Designed for our Outreach Center, this application allows the user to design emails that specifically target three populations: current customers, former customers, and potential new customers.

#2 Languages: All console applications produced using C# and .NET.

#3 Getting Started: I have no idea what you need to run this in the real world. Works like a charm on Visual Studio Code, but I'm pretty sure the average Komodo Insurance Team Member doesn't have VSC on their computer. Hopefully we will learn how to do this as part of Blue Badge. 

#4 Contact Information: Cindy Morgan camorgan70@gmail.com

#5 Acknowledgements: This product was produced in Visual Studio Code with guidance and direction from Eleven Fifty Academy. Menu descriptions courtesy of Metro Diner. Everything else was made up. Any resemblance to real people, living or dead, is purely coincidental.

