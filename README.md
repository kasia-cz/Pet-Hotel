# Pet Hotel
Pet Hotel is a Web API project designed to enable comprehensive management of a pet hotel. It allows to create and manage reservations from both user and administrator side. Moreover the application has an algorithm 
that validates reservations as they are added, verifying if they are possible. It checks if the number of pets of a given type in a reservation request is less than the limit of places for that pet type, 
and if it is within the limit by counting the pets in confirmed reservations on a given date. 

## User features
- **Reservation management**: Users can create and cancell reservations for their pets.
- **Personal profile**: Users have a profile so that their details are stored and they do not have to provide them with every  reservation. User's personal profile can be updated.
- **Adding pets to profile**: Users can add their pets to their account (name, type, breed and other information) and update or delete them if needed.

## Admin features
- **Reservation management**: Administrators can confirm or decline pending reservations and also browse reservations by filtering them by status and start and end dates.
- **Hotel capacity management**: Administrators can add and delete places for a specific type of pet, as well as update the number of places.
- **User management**: Administrators can change user roles.

Best practices were applied, using a clean architecture and libraries such as EF Core, AutoMapper and Fluent Validation.
