// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//MVVM 1st UI App
// Class to represent a row in the seat reservations grid
function SeatReservation(name, initialLevel) {
    var self = this;
    self.name = name;
    self.level = ko.observable(initialLevel);

    self.formattedPrice = ko.computed(function () {
        var price = self.level().price;
        return price ? "$" + price.toFixed(2) : "None";
    });

}

// Overall viewmodel for Seat Reservations, along with initial state
function ReservationsViewModel() {
    var self = this;

    // Non-editable catalog data - would come from the server
    self.availableLevels = [
        { levelName: "Standard (field)", price: 70 },
        { levelName: "Premium (suite)", price: 155 },
        { levelName: "Ultimate (skybox)", price: 300 }
    ];

    // Editable data
    self.seats = ko.observableArray([
        new SeatReservation("Beth", self.availableLevels[0]),
        new SeatReservation("Erin", self.availableLevels[0]),
        new SeatReservation("Tere", self.availableLevels[0])
    ]);

    // Operations
    self.addSeat = function () {
        self.seats.push(new SeatReservation("", self.availableLevels[0]));
        self.removeSeat = function (seat) { self.seats.remove(seat) }
    }

    self.totalSurcharge = ko.computed(function () {
        var total = 0;
        for (var i = 0; i < self.seats().length; i++)
            total += self.seats()[i].level().price;
        return total;
    });
}

ko.applyBindings(new ReservationsViewModel());

