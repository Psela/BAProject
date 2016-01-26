DROP TABLE BA_Project.dbo.users;
DROP TABLE BA_Project.dbo.type_of_users;

CREATE TABLE BA_Project.dbo.type_of_users
(	type_of_user_id INT PRIMARY KEY,
	name VARCHAR(50)
);

CREATE TABLE BA_Project.dbo.users
(
	users_id BIGINT PRIMARY KEY,
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	phone_number VARCHAR(15) NOT NULL,
	type_of_user INT NOT NULL REFERENCES type_of_users,
	address_firstline VARCHAR(60) NOT NULL,
	address_secondline VARCHAR(60),
	address_city VARCHAR(60) NOT NULL,
	postcode VARCHAR(10) NOT NULL,
	profile_picture text,
	description VARCHAR(500)
);

--Dummy Data

INSERT INTO BA_Project.dbo.type_of_users VALUES(1,'Professor');
INSERT INTO BA_Project.dbo.type_of_users VALUES(2,'Student');
INSERT INTO BA_Project.dbo.type_of_users VALUES(3,'Registrar');
INSERT INTO BA_Project.dbo.type_of_users VALUES(4,'IT Support');

INSERT INTO BA_Project.dbo.users VALUES
(
1,
'MrJohnSmith',
'MrJohnSmith',
'john@smith.co.uk',
02046532879,
1,
'42 IExist Road',
'',
'London',
'CE2 4DJ',
'http://www.realestatetaxgroup.com/wp-content/uploads/2013/03/empty-profile.png',
'Professor at the college'
);
INSERT INTO BA_Project.dbo.users VALUES(
2,
'JaneDoe',
'JaneDoe',
'jane@doe.com',
07546325892,
2,
'42 IAlsoExist Street',
'',
'London',
'CU2 4ME',
'http://timelinecoverme.com/watermark.php?path=empty&t=2',
'Student at the college'
);
INSERT INTO BA_Project.dbo.users VALUES(
3,
'JoeBloggs', 
'JoeBloggs',
'joe@bloggs.com',
07543654995,
3,
'31 WhoKnows Lane',
'',
'London',
'CE3 6TS',
'http://www.realestatetaxgroup.com/wp-content/uploads/2013/03/empty-profile.png',
'Registrar'
);
INSERT INTO BA_Project.dbo.users VALUES(
4,
'Admin',
'Admin', 
'admin@ITSupport.co.uk',
02084534659,
4,
'42 InCharge Road',
'',
'London',
'CE42 7GB',
'http://www.realestatetaxgroup.com/wp-content/uploads/2013/03/empty-profile.png',
'IT support, in charge of everything'
);