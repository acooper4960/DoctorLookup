# DoctorLookup
This Library performs a lookup of related doctors after a user has selected one.
Based off of the selected doctor, this application will:

1. Filter out doctors that are not in the same location (City, State, Zip, Country)
2. Order results by Doctor Rating and then alphabetical.

Projects are as follows:

DoctorLookup
  - Core Business Logic where filtering and sorting take place.
  
DoctorLookup.DTO
  - Data Transfer objects to pass entity representation to client.
  
DoctorLookup.Repository
  - Data access layer containing a mock repository.
  
DoctorLookup.Tests
  - Unit Tests
