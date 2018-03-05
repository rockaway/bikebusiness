# bikebusiness

A bike rental business example

### What is this?

This is an implementation of a bike rental business using Visual Studio mvc web api project.
It's a n-tier application:
- Business layer.
- DataAccess layer.

The data types validations are in the model, the others are in the RentalController.
I use a factory to create the data access objects (locate the class ServiceManager in the business layer).
Because this is just a testing project there is no database to store the data, the methods returns a new instante of the `BikeRentalInvoice` but nothing is stored.

### Prerequisites

Visual Studio 2015 or higher

### Installing

Download as a zip or clone to you pc.

## Deployment

Once you downloaded locate the folder `VisualStudio`.
inside it is the solution, open it with Visual Studio.
Run the tests with Test Explorer.
Inside Visual Studio goto to main menu->Test->Windows->Test Explorer and select `Run All`.
Enjoy!

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details