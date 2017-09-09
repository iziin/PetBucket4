use [\\MAC\HOME\DESKTOP\I\GITHUB\PETBUCKET4\PETBUCKET4\APP_DATA\PETBUCKETDATABASE.MDF]
select * from Pets;
select * from Customer;
select * from Appointment;

insert into Pets (name, animal, size, food, photo, active, indoors_safe, under13_safe)
values ('gary', 'dog', 'large', 'dog food', 'N/A', 'yes','yes','yes');

select name, animal from Pets WHERE active='yes' ;


select name from Pets WHERE animal='dog' ;

select name, animal from Pets WHERE size = 'large' AND indoors_safe = 'no'; 


select name, animal from Pets WHERE size = 'small' AND indoors_safe = 'yes'; 





-- shows name of animals witht e price and start date for appointment
SELECT Pets.id, Pets.name, Appointment.price, Appointment.date_start
FROM Appointment
INNER JOIN Pets ON Appointment.id = Pets.id;

-- Show customers and dogs
SELECT Customer.given_name, Customer.surname, Pets.animal, Pets.name
From Customer
INNER JOIN Pets ON Customer.id = Pets.id;

-- Show customers who have picked up their dogs between 2 dates
SELECT Customer.given_name, Customer.surname, Pets.animal, Pets.name, Appointment.date_end
From Customer
INNER JOIN Pets ON Customer.id = Pets.id
INNER JOIN Appointment ON Customer.id = Appointment.id
WHERE date_end BETWEEN 07/04/2017 AND 09/09/2017;

--Show customers with premium service on a specific date
SELECT Pets.name, Appointment.service
From Appointment
INNER JOIN Pets ON Appointment.id = Pets.id
WHERE date_end = 09/09/2017;

-- Show customers who have spent over 300
SELECT Customer.given_name, Customer.surname, Appointment.price
FROM Customer
INNER JOIN Appointment ON Customer.id = Appointment.id
WHERE Appointment.price >= 300;

-- Show details for customer that requires pickup
SELECT Customer.given_name, Customer.surname, Appointment.date_start, Appointment.needs_pickup,
Appointment.pickup_distance, Pets.name
FROM Appointment
INNER JOIN Pets ON Appointment.id = Pets.id
INNER JOIN Customer ON Appointment.id = Customer.id
WHERE Appointment.needs_pickup = 'yes';


--