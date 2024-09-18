create schema personalinfo;

set search_path to personalinfo;
show search_path

drop table personalinfo
create table personalinfo( id serial primary key,
	name varchar(20) not null,
	dob date,
	raddress varchar(100) not null,
	paddress varchar(100) not null,
	phone_number varchar(10) not null,
	email varchar(50) not null,
	marital_status varchar(10) not null,
	gender varchar(10) not null,
	occupation varchar(50),
	aadhar_number varchar(12) unique not null,
	pan_number varchar(9) unique not null);


INSERT INTO personalinfo.personalinfo (
    id, name, dob, raddress, paddress, phone_number, email, marital_status, gender, occupation, aadhar_number, pan_number
) VALUES (
    1, 
    'John Doe', 
    '1985-03-25T00:00:00.000Z', 
    '123 Maple Street, ', 
    '456 Oak Avenue, ', 
    '1111111111', 
    'john.doe@example.com', 
    'Married', 
    'Male', 
    'Software Engineer', 
    '123456789123', 
    'ABCD1234F'
);


{
"id":1,
  "name": "Shreya Pandey",
  "dateOfBirth": "2002-09-06",
  "residentialAddress": "Abc, Mumbai, Maharashtra",
  "permanentAddress": "Abc, Mumbai, Maharashtra",
  "phoneNumber": "1010101010",
  "emailAddress": "shreya@gmail.com",
  "maritalStatus": "unmarried",
  "gender": "female",
  "occupation": "developer",
  "aadharCardNumber": "123456789012",
  "panNumber": "ABCD1234E"
}