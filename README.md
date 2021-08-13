# AutoMarket
## This is an application that lays the foundation for the development of a platform for the sale of cars, other vehicles, auto parts and accessories.

### There are currently two main sections:
1. Vehicles;
2. Auto parts;
### There are two main roles:
1. Admin;
2. Dealer;
### Description of roles:

>- Guests<br>
>> They can view all offers, but they can't Create, Edit, or Delete such. They do not have access to the Dealers menu.

>- Regular user<br>
>> When registering, the user does not have a specific role, but already have the opportunity to Create, Edit and Delete Offers. They already have the ability to access the Dealers menu and see all the Dealers offers in one place. Regular user can enter the role of 'Dealer' after filling out the appropriate form in the application.

>- Dealers<br>
>> Regular users can enter the role of 'Dealer' after filling out the appropriate form in the application.Both regular users and dealers can post Offers, but
Dealers get the advantage to be present in a separate section only with Offers of dealers and the opportunity to be found by other users by "Dealer Name".

>- Admin<br>
>> He is a trully God here. He can Create,Edit,Delete offers, can Edit or Delete others users offers, can Edit Users profiles or Delete their Accounts.

#### So far, the project is written almost entirely in C #.

#### Used technologies:
- ASP.NET Core
- Entity Framework Core
- MSSQL Server
- Bootstrap

#### The testing of the project was carried out with the library written by Ivaylo Kenov [MyTested.AspNetCore.Mvc](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc).
