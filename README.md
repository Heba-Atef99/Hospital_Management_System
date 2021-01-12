# Hospital_Management_System
CSE 321: Software Engineering Project for 3rd Year CSE Ain Shams University Students ,Where Students Could Apply Software Engineering concepts on a real life project that can help any Hospital. Our Website can help patient to book Online appointments and tests,help Doctors do their Job and manage their records and help front desk . 



<div align="center">
<img src="https://github.com/Heba-Atef99/Hospital_Management_System/blob/main/images/ASH%202B.png" width="350" height="350" margin-bottom="100">
  
  
![GitHub language count](https://img.shields.io/github/languages/count/Heba-Atef99/Hospital_Management_System?color=%2300&logo=GitHub)
![GitHub contributors](https://img.shields.io/github/contributors/Heba-Atef99/Hospital_Management_System?color=%2300&logo=GitHub)
![GitHub top language](https://img.shields.io/github/languages/top/Heba-Atef99/Hospital_Management_System?color=%2300)


Our project is a hospital site that can be used by all segments of society and can help patients to book and Doctors to do their Job.
</div>  
  
## Contribution

<img src="https://github.com/Heba-Atef99/Hospital_Management_System/blob/main/images/contribution.PNG" width="325" height="56" margin-bottom="40">

## Table of Contents

1. [General Information](#general-information)
2. [Introduction](#introduction)
3. [Technologies](#technolgies)
4. [SetUp](#setup)
5. [Features](#features)
6. [Sources](#Sources) 
 
## General Information

This site is a hospital, which is used by the doctor, the patient and front-desk officer.

## Introduction

Our Hospital is providing medical and Surgical treatment and nursing care for any ill or injured people.
Our patient has many health and psychological services.
Our hospital has many medical departments that make the patient do not need anything.
As we have many services through the site that make the patient not need to go anywhere, especially in light of those epidemics that could expose the patient to danger

## Technologies

1. We use c# language And Asp.net core Mvc for Back End.
2. And HTML, CSS and JavaScript for Front End .
3. SQL for Database. 

## SetUp

TO RUN THIS PROJECT YOU NEED TO :
##### First: You Need To Install visual studio community From here >>[link](https://visualstudio.microsoft.com/vs/community/) and you need to install asp packages
##### Second: Create New Project and choose asp.net core web application And Insert Our Folders On Your New Project Directory.
##### Third: INSTALL PACKAGES FROM HERE:

1. [BCrypt.Net-Next(4.0.2)](https://www.nuget.org/packages/BCrypt.Net-Next/4.0.2?_src=template)
2. [Microsoft.EntityFrameworkCore(5.0.1)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.1?_src=template)
3. [Microsoft.EntityFrameworkCore.Design(5.0.1)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.1?_src=template)
4. [Microsoft.EntityFrameworkCore.SqlServer(5.0.1)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/5.0.1?_src=template)
5. [Microsoft.AspNetCore.Session(2.2.0)](https://www.nuget.org/packages/Microsoft.AspNetCore.Session/)
6. [Microsoft.VisualStudio.Web.CodeGeneration.Design(3.1.4)](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/3.1.4?_src=template)

##### Fourth: you need to write the following command in your terminal to create the HospitalDB Database 
``` dotnet ef database update  ```
##### Fifth: you need to publish our database HospitalDb.dacpac file in the Final_DB Folder by right click on the created Hospital DB in SQL Server Object Explorer then Publish Data_tier Application and choose our database file


## Features

* [Patient](#if-you-are-patient)
* [Doctor](#if-you-are-Doctor)
* [Lab](#if-you-are-Lab)
* [Front-Desk](#if-you-are-front-desk)
* [Donation](#Donation)

#### If you are patient.. 

> Registration >> login >> patient page.

> patient has many features :-
> 1. Register On The System.
> 2. View his followed Doctors list .
> 3. See his Doctor's Schedule.
> 4. he can book an appointment with any doctor from any department.
> 5. He can book any required tests through the site.
> 6. he can pay online using Valid Credit Card.
> 7. he can pay Offline and see the total cost.
> 8. he can view different services offered by the hospital. 
> 9. View his profile and he can edit it.
> 10. show his progress Details.
> 11. show his Hospital Details.
> 12. he can add his medical record.
> 13. he can book a surgery online. 


#### If you are Doctor

> Regestration >> login >> Doctor page.

> Doctor has many features :-
> 1. Register On The System.
> 2. Add/edit their schedules.
> 3. Find their patients and view/edit/add their medical records , health progress and status.
> 4. Transfer patient to another doctor or another hospital.
> 5. Collect statistics regarding his patients.
> 6. Add their professional information.
> 7. For Emergency : Show beds and blood units.
> 8. Search For Patients.
> 9. Sort by Date and Status.  

#### If you are Lab

> Regestration >> login >> Doctor page.

> Doctor has many features :-
> 1. Register On The System.
> 2. Add/edit their schedules.
> 3. Find their patients and view/edit/add their medical records , health progress and status.
> 4. Transfer patient to another doctor or another hospital.
> 5. Collect statistics regarding his patients.
> 6. Add their professional information.

#### If you are Front-Desk..

> Regestration >> login >> Doctor page.

> Front-Desk has many features :-
> 1. Register On The System.
> 2. Allocate room/bed to a patient.
> 3. Transform a patient from one ward to another.
> 4. Check availability of rooms/beds.
> 5. Search for patient room.
> 6. Cancel The Surgery.
> 7. Show All rooms information.


#### Donation

> you can donate to our hospital to support us and help our patients to recover.

## Sources

We used [pluralsight](https://www.pluralsight.com/product/skills?utm_term=&aid=7010a000002LZ5aAAG&promo=&utm_source=branded&utm_medium=digital_paid_search_google&utm_campaign=XYZ_EMEA_Brand_E&utm_content=&gclid=CjwKCAiAi_D_BRApEiwASslbJ5k_uQ3dLDGo8P3FI9k4gZ97Op_P2QeFmPjeoO6Sff10pPYIxMTSrBoCTrwQAvD_BwE) to learn c# & Asp.net core Mvc .

