// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// View: Class for the Adrress Book Contacts
var initialData = [

    {
        firstName: "Sensei", lastName: "Miyagi", email: "myEmail@mail.com", address: "123 Chatan Ln", city: "Oki Breeze",
        state: "FL", zipcode: "12345", phone: [{ type: "Mobile", number: "(321) 333-6699" }]
    },

];

// Overall ViewModel for the App
var ContactsModel = function (contacts) {
    var person = this;
    person.contacts = ko.observableArray(ko.utils.arrayMap(contacts, function (contact) {
        return { firstName: contact.firstName, lastName: contact.lastName, email: contact.email, address: contact.address,
            city: contact.city, state: contact.state, zipcode: contact.zipcode, phone: ko.observableArray(contact.phone) };
    }));

    person.addContact = function () {
        person.contacts.push({ 
            firstName: "",
            lastName: "",
            email: "",
            address: "",
            city: "",
            state: "",
            zipcode: "",
            phone: ko.observableArray()
        });
    };

    person.removeContact = function (contact) {
        person.contacts.remove(contact);
    };

    person.addPhone = function (contact) {
        contact.phone.push({
            number: ""
        });
    };

    person.removePhone = function (phone) {
        $.each(person.contacts(), function () { this.phone.remove(phone) })
    };

    person.save = function () {
        person.lastSavedJson(JSON.stringify(ko.toJS(person.contacts), null, 2));
    };

    person.lastSavedJson = ko.observable("")
};

ko.applyBindings(new ContactsModel(initialData));